using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {

    class FragmentList : BindingList<Fragment> {
        public void loadFromDirectory(string path) {
            if (!File.Exists(path))
                Directory.CreateDirectory(OS_Utils.LocalFiles.BaseDirectory);
            var files = Directory.GetFiles(OS_Utils.LocalFiles.BaseDirectory);
            if (files.Count() > 0) {
                var names = from file in files
                            select new Fragment() {
                                Name = new FileInfo(file).Name,
                                Enabled = Properties.Settings.Default.SelectedFiles != null && Properties.Settings.Default.SelectedFiles.Contains(new FileInfo(file).Name)
                            };
                names.ToList().ForEach(x => Add(x));
            }
        }
    }

    class Fragment : INotifyPropertyChanged {

        private bool _loaded = false;
        private string _currentContents = null;
        private string _remoteLocation = null;
        private string _name = null;

        private static int _newFragmentCount = 0;

        public bool Dirty { get; protected set; }
        public bool Enabled { get; set; }
        public bool IsHostsFile { get; set; }

        public string Name {
            get {
                if (!IsHostsFile) {
                    if (string.IsNullOrWhiteSpace(_name)) {
                        do {
                            _name = "New Fragment" + ((_newFragmentCount > 0) ? (" " + _newFragmentCount) : string.Empty);
                            _newFragmentCount++;
                        } while (File.Exists(FullPath));
                        using (File.Create(FullPath)) { }
                    }
                    return _name;
                } else {
                    return "hosts";
                }
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) { throw new Exception("Invalid value for Name"); }
                var oldVal = _name;
                _name = value;
                if (oldVal != null && !oldVal.Equals(_name)) {
                    File.Move(Path.Combine(OS_Utils.LocalFiles.BaseDirectory, oldVal), FullPath);
                }
                NotifyPropertyChanged();
            }
        }

        public string RemoteLocation {
            get {
                return (IsHostsFile)? string.Empty : _remoteLocation;
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

        public string FullPath {
            get {
                return (IsHostsFile) ? OS_Utils.HostsFileUtil.CurrentHostsFile : Path.Combine(OS_Utils.LocalFiles.BaseDirectory, Name);
            }
        }

        public string FileContents {
            get {
                if (!_loaded) {
                    if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
                        downloadFile();
                    } else {
                        _currentContents = Regex.Replace(File.ReadAllText(FullPath), @"\r\n|\n\r|\n|\r", "\r\n");
                        checkForRemoteLocation();
                    }
                    _loaded = true;
                    Dirty = false;
                }
                return _currentContents;
            }
            set {
                _currentContents = Regex.Replace(value, @"\r\n|\n\r|\n|\r", "\r\n"); ;
                checkForRemoteLocation();
                Dirty = true;
                NotifyPropertyChanged();
            }
        }

        public void save() {
            if (Dirty) {
                var sb = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
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
                throw new Exception("There was an error saving the hosts file");
        }

        public void delete() {
            File.Delete(FullPath);
        }

        public async void downloadFile() { //TODO: make this private with something wrapping it? force refresh?
            if (string.IsNullOrWhiteSpace(RemoteLocation)) return;

            _currentContents = "127.0.0.1 Loading...";
            OnDownloadStarting(EventArgs.Empty);
            var sb = new StringBuilder();
            try {
                using (var client = new HttpClient()) {
                    var result = await client.GetStringAsync(RemoteLocation);
                    sb.Append(Regex.Replace(result, @"\r\n|\n\r|\n|\r", "\r\n"));
                }
            } catch (Exception e) {
                sb.Append((e.InnerException != null) ? e.InnerException.Message : e.Message);
            }
            FileContents = sb.ToString();
            OnContentsDownloaded(EventArgs.Empty);
        }

        private void checkForRemoteLocation() {
            var length = (_currentContents.IndexOf(Environment.NewLine) > 0) ? _currentContents.IndexOf(Environment.NewLine) : _currentContents.Length;
            if (length >= 0) {
                var firstLine = _currentContents.Substring(0, length);
                if (_currentContents.Length > 0 && IsARemoteUrlString(firstLine)) {
                    RemoteLocation = firstLine.Substring(Properties.Settings.Default.RemoteLocationSyntax.Length);
                }
            }
        }

        public static bool IsARemoteUrlString(string value) {
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



        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler DownloadStarting;
        public event EventHandler ContentsDownloaded;
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
