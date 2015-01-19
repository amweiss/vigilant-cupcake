using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VigilantCupcake.Models {

    class FragmentList : BindingList<Fragment> { }

    class Fragment {

        private bool _loaded = false;
        private string _currentContents = null;
        private string _remoteLocation = null;

        public bool Enabled { get; set; }
        public string Name { get; set; }

        public string RemoteLocation {
            get {
                return _remoteLocation;
            }
            set {
                if (_remoteLocation != null && _remoteLocation.Equals(value)) return;
                _remoteLocation = value;
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
                if (!_loaded) {
                    if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
                        downloadFile();
                    } else {
                        _currentContents = Regex.Replace(File.ReadAllText(FullPath), @"\r\n|\n\r|\n|\r", "\r\n");
                        checkForRemoteLocation();
                    }
                }
                _loaded = true;
                return _currentContents;
            }
            set {
                _currentContents = Regex.Replace(value, @"\r\n|\n\r|\n|\r", "\r\n"); ;
                checkForRemoteLocation();
            }
        }

        public void save() {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(RemoteLocation)) {
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
                }
            }
        }

        private async void downloadFile() {
            _currentContents = "127.0.0.1 Loading...";
            OnDownloadStarting(EventArgs.Empty);
            var sb = new StringBuilder();
            try {
                using (var client = new HttpClient()) {
                    var result = await client.GetStringAsync(RemoteLocation);
                    sb.Append(Regex.Replace(result, @"\r\n|\n\r|\n|\r", "\r\n"));
                }
            } catch (Exception e) {
                sb.Append(e.InnerException.Message);
            }
            _currentContents = sb.ToString();
            OnContentsDownloaded(EventArgs.Empty);
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

        public event EventHandler DownloadStarting;
        public event EventHandler ContentsDownloaded;
    }

}
