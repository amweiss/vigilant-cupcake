using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace VigilantCupcake.Models {

    public sealed class UserConfig {
        private static readonly Lazy<UserConfig> lazy = new Lazy<UserConfig>(() => new UserConfig());

        private string _settingFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductName,
                Properties.Settings.Default.UserSettingsFile
                );

        private UserConfig() {
        }

        public static UserConfig Instance { get { return lazy.Value; } }

        public bool AutoSaveOnStartup { get; set; }

        public bool CloseToTray { get; set; }

        public bool DownloadInBackground { get; set; }

        public bool NewHostsAnalysis { get; set; }

        public string NewHostsFilter { get; set; }

        public int SecondsBetweenBackgroundDownloads { get; set; }

        public List<string> SelectedFiles { get; set; }

        public int Version { get; set; }

        public void Reload() {
            if (!File.Exists(_settingFilePath)) {
                Reset();
                return;
            }
            var fileHandleFree = OperatingSystemUtilities.LocalFiles.WaitForFile(_settingFilePath);
            if (fileHandleFree) {
                var settings = File.ReadAllText(_settingFilePath);
                JsonConvert.PopulateObject(settings, Instance);
            }
        }

        public void Reset() {
            AutoSaveOnStartup = true;
            CloseToTray = false;
            DownloadInBackground = true;
            NewHostsAnalysis = true;
            NewHostsFilter = "";
            SecondsBetweenBackgroundDownloads = 3600000;
            SelectedFiles = new List<string>() { };
            Version = 1;
        }

        public void Save() {
            Directory.CreateDirectory(Path.GetDirectoryName(_settingFilePath));
            var fileHandleFree = !File.Exists(_settingFilePath) || OperatingSystemUtilities.LocalFiles.WaitForFile(_settingFilePath);
            if (fileHandleFree) {
                File.WriteAllText(_settingFilePath, JsonConvert.SerializeObject(Instance, Formatting.Indented));
            }
        }
    }
}