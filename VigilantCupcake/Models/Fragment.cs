using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {
    class Fragment {

        private bool _dirty = false;
        private string _currentContents = null;
        private string _remoteLocation = null;

        public bool Enabled { get; set; }
        public string Name { get; set; }

        public string RemoteLocation {
            get {
                return _remoteLocation;
            }
            set {
                _remoteLocation = value;
                _dirty = true;
                if (!string.IsNullOrWhiteSpace(RemoteLocation))
                    downloadFile();
            }
        }

        public string FullPath {
            get {
                return Path.Combine(OS_Utils.LocalFiles.BaseDirectory, Name);
            }
        }

        public string FileContents {
            get {
                if (_dirty == false) {
                    if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
                        downloadFile();
                    } else {
                        _currentContents = Regex.Replace(File.ReadAllText(FullPath), @"\r\n|\n\r|\n|\r", "\r\n");
                        checkForRemoteLocation();
                        if (!string.IsNullOrWhiteSpace(RemoteLocation))
                            downloadFile();
                    }
                }
                return _currentContents;
            }
            set {
                _currentContents = Regex.Replace(value, @"\r\n|\n\r|\n|\r", "\r\n"); ;
                _dirty = true;
                checkForRemoteLocation();
            }
        }

        public void save() {
            var sb = new StringBuilder();
            if (RemoteLocation != null) {
                sb.Append(Properties.Settings.Default.RemoteLocationSyntax);
                sb.AppendLine(RemoteLocation);
            }
            sb.Append(FileContents);

            File.WriteAllText(FullPath, sb.ToString());
        }

        private void checkForRemoteLocation() {
            var length = (_currentContents.IndexOf(Environment.NewLine) > 0)? _currentContents.IndexOf(Environment.NewLine) : _currentContents.Length;
            if (length >= 0) {
                var firstLine = _currentContents.Substring(0, length);
                if (_currentContents.Length > 0 && IsARemoteUrlString(firstLine)) {
                    RemoteLocation = firstLine.Substring(Properties.Settings.Default.RemoteLocationSyntax.Length);
                    _currentContents = _currentContents.Substring(length);
                }
            }
        }

        private void downloadFile() {
            _currentContents = null;
            var sb = new StringBuilder();
            try {
                using (var client = new HttpClient()) {
                    var result = client.GetStringAsync(RemoteLocation).Result;
                    sb.Append(Regex.Replace(result, @"\r\n|\n\r|\n|\r", "\r\n"));
                }
            } catch (Exception e) {
                sb.Append(e.InnerException.Message);
            }
            _currentContents = sb.ToString();
        }

        public static bool IsARemoteUrlString(string value) {
            return value.StartsWith(Properties.Settings.Default.RemoteLocationSyntax);
        }
    }

}
