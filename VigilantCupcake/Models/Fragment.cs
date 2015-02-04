using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace VigilantCupcake.Models {

    internal class Fragment : INotifyPropertyChanged {
        private bool _loaded = false;
        private static int _newFragmentCount = 0;
        private string _oldFullPath = null;

        public bool IsHostsFile { get; set; }

        private bool _dirty = false;

        public bool Dirty {
            get { return _dirty; }
            set {
                if (_dirty != value) {
                    _dirty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _enabled = false;

        public bool Enabled {
            get { return _enabled; }
            set {
                if (_enabled != value) {
                    _enabled = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _name = null;

        public string Name {
            get {
                if (!IsHostsFile) {
                    if (string.IsNullOrWhiteSpace(_name)) {
                        _name = "New Fragment" + ((_newFragmentCount > 0) ? (" " + _newFragmentCount) : string.Empty);
                        _newFragmentCount++;
                    }
                    return _name;
                } else {
                    return "hosts";
                }
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) { throw new Exception("Invalid value for Name"); }
                if (_oldFullPath == null) {
                    _oldFullPath = _fullPath;
                    Dirty = true;
                }
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private string _rootPath = null;

        public string RootPath {
            get {
                if (_rootPath == null)
                    _rootPath = OS_Utils.LocalFiles.BaseDirectory;
                return _rootPath;
            }
            set {
                if (_oldFullPath == null) {
                    _oldFullPath = _fullPath;
                    Dirty = true;
                }
                _rootPath = value;
                NotifyPropertyChanged();
            }
        }

        private string _fullPath = null;

        public string FullPath {
            get {
                _fullPath = Path.Combine(RootPath, Name + Properties.Settings.Default.FragmentFileExtension);
                return (IsHostsFile) ? OS_Utils.HostsFileUtil.CurrentHostsFile : _fullPath;
            }
            set {
                if (_oldFullPath == null) {
                    _oldFullPath = _fullPath;
                    Dirty = true;
                }
                RootPath = Path.GetDirectoryName(value);
                _fullPath = value;
                NotifyPropertyChanged();
            }
        }

        private string _remoteLocation = null;

        public string RemoteLocation {
            get {
                return (IsHostsFile) ? string.Empty : _remoteLocation;
            }
            set {
                if (_remoteLocation != null && _remoteLocation.Equals(value)) return;
                _remoteLocation = value;
                if (!string.IsNullOrWhiteSpace(RemoteLocation))
                    downloadFile();
                Dirty = true;
                NotifyPropertyChanged();
            }
        }

        private string _currentContents = null;

        public string FileContents {
            get {
                if (!_loaded) {
                    if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
                        downloadFile();
                    } else {
                        _currentContents = Regex.Replace(File.ReadAllText(FullPath), Regex.Escape(Properties.Settings.Default.LineCleaningRegex), Regex.Escape(Properties.Settings.Default.LineCleaningReplacement));
                        checkForRemoteLocation();
                    }
                    _loaded = true;
                    Dirty = false;
                }
                return _currentContents;
            }
            set {
                var newContents = Regex.Replace(value, Regex.Escape(Properties.Settings.Default.LineCleaningRegex), Regex.Escape(Properties.Settings.Default.LineCleaningReplacement));
                if (_currentContents == null || !_currentContents.Equals(newContents)) {
                    _currentContents = newContents;
                    _loaded = true;
                    Dirty = true;
                    checkForRemoteLocation();
                    NotifyPropertyChanged();
                }
            }
        }

        public void save() {
            if (Dirty) {
                Directory.CreateDirectory(Path.GetDirectoryName(FullPath)); //Make sure all directories exist

                if (_oldFullPath != null && File.Exists(_oldFullPath)) {
                    if (File.Exists(FullPath)) File.Delete(FullPath);
                    File.Move(_oldFullPath, FullPath);
                }

                if (!File.Exists(FullPath)) using (File.Create(FullPath)) { }

                var sb = new StringBuilder();
                if (!IsHostsFile && !string.IsNullOrWhiteSpace(RemoteLocation)) {
                    sb.Append(Properties.Settings.Default.RemoteLocationSyntax);
                    sb.AppendLine(RemoteLocation);
                }
                sb.Append(FileContents);

                saveTextAs(FullPath, sb.ToString());
                Dirty = false;
            }
        }

        protected void saveTextAs(string filename, string text) {
            var fileHandleFree = OS_Utils.LocalFiles.WaitForFile(filename);
            if (fileHandleFree)
                File.WriteAllText(filename, text);
            else
                throw new Exception("There was an error saving the fragment");
        }

        public void delete() {
            if (!File.Exists(FullPath)) return;
            var fileHandleFree = OS_Utils.LocalFiles.WaitForFile(FullPath);
            if (fileHandleFree)
                File.Delete(FullPath);
            else
                throw new Exception("There was an error deleting the fragment");
        }

        public async void downloadFile() {
            if (string.IsNullOrWhiteSpace(RemoteLocation)) return;

            _currentContents = "127.0.0.1 Loading...";
            OnDownloadStarting(EventArgs.Empty);
            var sb = new StringBuilder();
            try {
                using (var client = new HttpClient()) {
                    var result = await client.GetStringAsync(RemoteLocation);
                    sb.Append(Regex.Replace(result, Regex.Escape(Properties.Settings.Default.LineCleaningRegex), Regex.Escape(Properties.Settings.Default.LineCleaningReplacement)));
                }
            } catch (Exception e) {
                sb.Append((e.InnerException != null) ? e.InnerException.Message : e.Message);
            }
            FileContents = sb.ToString();
            OnContentsDownloaded(EventArgs.Empty);
        }

        protected void checkForRemoteLocation() {
            var length = (_currentContents.IndexOf(Environment.NewLine) > 0) ? _currentContents.IndexOf(Environment.NewLine) : _currentContents.Length;
            if (length >= 0) {
                var firstLine = _currentContents.Substring(0, length);
                if (_currentContents.Length > 0 && IsARemoteUrlString(firstLine)) {
                    RemoteLocation = firstLine.Substring(Properties.Settings.Default.RemoteLocationSyntax.Length);
                }
            }
        }

        protected static bool IsARemoteUrlString(string value) {
            return value.StartsWith(Properties.Settings.Default.RemoteLocationSyntax);
        }

        protected virtual void OnDownloadStarting(EventArgs e) {
            EventHandler handler = DownloadStarting;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnContentsDownloaded(EventArgs e) {
            EventHandler handler = ContentsDownloaded;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler DownloadStarting;

        public event EventHandler ContentsDownloaded;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}