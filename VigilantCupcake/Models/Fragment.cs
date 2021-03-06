﻿using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using VigilantCupcake.OperatingSystemUtilities;

namespace VigilantCupcake.Models {

    public class Fragment : INotifyPropertyChanged {
        string _currentContents = null;
        bool _dirty = false;
        bool _downloadPending = false;
        bool _enabled = false;
        bool _loaded = false;
        string _name = null;
        string _oldFullPath = null;

        string _remoteLocation = null;

        string _rootPath = null;

        public event EventHandler ContentsDownloaded;

        public event EventHandler DownloadStarting;

        public event PropertyChangedEventHandler PropertyChanged;

        private RemoteCertificateValidationCallback _allowInvalidCerts = (sender, cert, chain, sslPolicyErrors) => true;

        public bool Dirty {
            get { return _dirty; }
            set {
                if (_dirty != value) {
                    _dirty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool DownloadPending {
            get { return _downloadPending; }
            private set {
                if (_downloadPending != value) {
                    _downloadPending = value;
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
                ForceLoad();
                return _currentContents;
            }
            set {
                var newContents = Regex.Replace(value, Regex.Escape(Properties.Settings.Default.LineCleaningRegex), Regex.Escape(Properties.Settings.Default.LineCleaningReplacement));
                if (_currentContents == null || !_currentContents.Equals(newContents)) {
                    _currentContents = newContents;
                    _loaded = true;
                    Dirty = true;
                    CheckForRemoteLocation();
                    NotifyPropertyChanged();
                }
            }
        }

        public string FullPath {
            get {
                return (IsHostsFile) ? OperatingSystemUtilities.HostsFileUtil.CurrentHostsFile : Path.Combine(RootPath, Name + Properties.Settings.Default.FragmentFileExtension);
            }
            set {
                if (!string.IsNullOrWhiteSpace(_name) && (_oldFullPath == null || (!File.Exists(_oldFullPath) && File.Exists(FullPath)))) _oldFullPath = FullPath;
                var newRootPath = Path.GetDirectoryName(value);
                var newName = Path.GetFileNameWithoutExtension(value);
                if (!RootPath.Equals(newRootPath) || !Name.Equals(newName)) {
                    RootPath = newRootPath;
                    Name = newName;
                    Dirty = true;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsHostsFile { get; set; }

        public string Name {
            get {
                return (!IsHostsFile) ? _name : "hosts";
            }
            set {
                value = value.AsFileName();
                if (string.IsNullOrWhiteSpace(value)) { throw new InvalidDataException("Invalid value for Name"); }
                if (!string.IsNullOrWhiteSpace(_name) && (_oldFullPath == null || (!File.Exists(_oldFullPath) && File.Exists(FullPath)))) _oldFullPath = FullPath;
                if ((_name == null && value != null) || !_name.Equals(value)) {
                    _name = value;
                    Dirty = true;
                    NotifyPropertyChanged();
                }
            }
        }

        public string RemoteLocation {
            get {
                return (IsHostsFile) ? string.Empty : _remoteLocation;
            }
            set {
                if (_remoteLocation != null && _remoteLocation.Equals(value)) return;
                if ((_remoteLocation == null && value != null) || !_remoteLocation.Equals(value)) {
                    _remoteLocation = value;
                    if (!string.IsNullOrWhiteSpace(RemoteLocation)) DownloadFile();
                    Dirty = true;
                    NotifyPropertyChanged();
                }
            }
        }

        public string RootPath {
            get {
                if (_rootPath == null) _rootPath = OperatingSystemUtilities.LocalFiles.BaseDirectory;
                return _rootPath;
            }
            set {
                if (!string.IsNullOrWhiteSpace(_name) && (_oldFullPath == null || (!File.Exists(_oldFullPath) && File.Exists(FullPath)))) _oldFullPath = FullPath;
                if ((_rootPath == null && value != null) || !_rootPath.Equals(value)) {
                    _rootPath = value;
                    Dirty = true;
                    NotifyPropertyChanged();
                }
            }
        }

        public void Delete() {
            if (!File.Exists(FullPath)) return;
            var fileHandleFree = OperatingSystemUtilities.LocalFiles.WaitForFile(FullPath);
            if (fileHandleFree)
                File.Delete(FullPath);
            else
                throw new IOException("There was an error deleting the fragment");
        }

        public async void DownloadFile() {
            if (string.IsNullOrWhiteSpace(RemoteLocation)) return;
            DownloadPending = true;
            OnDownloadStarting(EventArgs.Empty);
            var sb = new StringBuilder();
            try {
                if (UserConfig.Instance.AllowInvalidCertificates){
                    ServicePointManager.ServerCertificateValidationCallback = _allowInvalidCerts;
                } else {
                    ServicePointManager.ServerCertificateValidationCallback = null;
                }

                using (var client = new HttpClient()) {
                    var result = await client.GetStringAsync(RemoteLocation);
                    sb.Append(Regex.Replace(result, Regex.Escape(Properties.Settings.Default.LineCleaningRegex), Regex.Escape(Properties.Settings.Default.LineCleaningReplacement)));
                }
            } catch (Exception e) {
                sb.Append((e.InnerException != null) ? e.InnerException.Message : e.Message);
            }
            FileContents = sb.ToString();
            DownloadPending = false;
            OnContentsDownloaded(EventArgs.Empty);
        }

        public void ForceLoad() {
            if (!_loaded) {
                if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
                    DownloadFile();
                } else {
                    if (!File.Exists(FullPath)) using (File.Create(FullPath)) { }
                    _currentContents = Regex.Replace(File.ReadAllText(FullPath), Regex.Escape(Properties.Settings.Default.LineCleaningRegex), Regex.Escape(Properties.Settings.Default.LineCleaningReplacement));
                    CheckForRemoteLocation();
                }
                _loaded = true;
                Dirty = false;
            }
        }

        public void Save() {
            if (Dirty && !DownloadPending) {
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

                SaveTextAs(FullPath, sb.ToString());
                Dirty = false;
            }
        }

        protected static bool IsARemoteUrlString(string value) {
            if (value != null) {
                return value.StartsWith(Properties.Settings.Default.RemoteLocationSyntax, StringComparison.Ordinal);
            } else {
                throw new ArgumentException(nameof(value));
            }
        }

        static protected void SaveTextAs(string filename, string text) {
            var fileHandleFree = OperatingSystemUtilities.LocalFiles.WaitForFile(filename);
            if (fileHandleFree)
                File.WriteAllText(filename, text);
            else
                throw new IOException("There was an error saving the fragment");
        }

        protected void CheckForRemoteLocation() {
            var length = (_currentContents.IndexOf(Environment.NewLine, StringComparison.Ordinal) > 0) ? _currentContents.IndexOf(Environment.NewLine, StringComparison.Ordinal) : _currentContents.Length;
            if (length >= 0) {
                var firstLine = _currentContents.Substring(0, length);
                if (_currentContents.Length > 0 && IsARemoteUrlString(firstLine)) {
                    RemoteLocation = firstLine.Substring(Properties.Settings.Default.RemoteLocationSyntax.Length);
                }
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnContentsDownloaded(EventArgs e) {
            ContentsDownloaded?.Invoke(this, e);
        }

        protected virtual void OnDownloadStarting(EventArgs e) {
            DownloadStarting?.Invoke(this, e);
        }
    }
}