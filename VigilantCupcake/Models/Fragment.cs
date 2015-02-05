﻿using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace VigilantCupcake.Models {

    internal class Fragment : INotifyPropertyChanged {
        private string _currentContents = null;
        private bool _dirty = false;
        private bool _enabled = false;
        private bool _loaded = false;
        private string _name = null;
        private string _oldFullPath = null;

        private string _remoteLocation = null;

        private string _rootPath = null;

        public event EventHandler ContentsDownloaded;

        public event EventHandler DownloadStarting;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Dirty {
            get { return _dirty; }
            set {
                if (_dirty != value) {
                    _dirty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool Enabled {
            get { return _enabled; }
            set {
                if (_enabled != value) {
                    _enabled = value;
                    NotifyPropertyChanged();
                }
            }
        }

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

        public string FullPath {
            get {
                return (IsHostsFile) ? OperatingSystemUtilities.HostsFileUtil.CurrentHostsFile : Path.Combine(RootPath, Name + Properties.Settings.Default.FragmentFileExtension);
            }
            set {
                if (_oldFullPath == null || (!File.Exists(_oldFullPath) && File.Exists(FullPath))) _oldFullPath = FullPath;
                RootPath = Path.GetDirectoryName(value);
                Name = Path.GetFileNameWithoutExtension(value);
                Dirty = true;
                NotifyPropertyChanged();
            }
        }

        public bool IsHostsFile { get; set; }

        public string Name {
            get {
                if (!IsHostsFile) {
                    if (string.IsNullOrWhiteSpace(_name)) {
                        _name = "New Fragment";
                    }
                    return _name;
                } else {
                    return "hosts";
                }
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) { throw new InvalidDataException("Invalid value for Name"); }
                if (_oldFullPath == null || (!File.Exists(_oldFullPath) && File.Exists(FullPath))) _oldFullPath = FullPath;
                _name = value;
                Dirty = true;
                NotifyPropertyChanged();
            }
        }

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

        public string RootPath {
            get {
                if (_rootPath == null)
                    _rootPath = OperatingSystemUtilities.LocalFiles.BaseDirectory;
                return _rootPath;
            }
            set {
                if (_oldFullPath == null || (!File.Exists(_oldFullPath) && File.Exists(FullPath))) _oldFullPath = FullPath;
                _rootPath = value;
                Dirty = true;
                NotifyPropertyChanged();
            }
        }

        public void delete() {
            if (!File.Exists(FullPath)) return;
            var fileHandleFree = OperatingSystemUtilities.LocalFiles.WaitForFile(FullPath);
            if (fileHandleFree)
                File.Delete(FullPath);
            else
                throw new IOException("There was an error deleting the fragment");
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

        public void save() {
            if (Dirty) {
                Directory.CreateDirectory(Path.GetDirectoryName(FullPath)); //Make sure all directories exist

                if (_oldFullPath != null && !FullPath.Equals(_oldFullPath) && File.Exists(_oldFullPath)) {
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

        protected static bool isARemoteUrlString(string value) {
            return value.StartsWith(Properties.Settings.Default.RemoteLocationSyntax);
        }

        static protected void saveTextAs(string filename, string text) {
            var fileHandleFree = OperatingSystemUtilities.LocalFiles.WaitForFile(filename);
            if (fileHandleFree)
                File.WriteAllText(filename, text);
            else
                throw new IOException("There was an error saving the fragment");
        }

        protected void checkForRemoteLocation() {
            var length = (_currentContents.IndexOf(Environment.NewLine) > 0) ? _currentContents.IndexOf(Environment.NewLine) : _currentContents.Length;
            if (length >= 0) {
                var firstLine = _currentContents.Substring(0, length);
                if (_currentContents.Length > 0 && isARemoteUrlString(firstLine)) {
                    RemoteLocation = firstLine.Substring(Properties.Settings.Default.RemoteLocationSyntax.Length);
                }
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnContentsDownloaded(EventArgs e) {
            EventHandler handler = ContentsDownloaded;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnDownloadStarting(EventArgs e) {
            EventHandler handler = DownloadStarting;
            if (handler != null) {
                handler(this, e);
            }
        }
    }
}