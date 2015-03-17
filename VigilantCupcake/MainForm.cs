using Aga.Controls.Tree;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.OperatingSystemUtilities;
using VigilantCupcake.SubForms;
using VigilantCupcake.ViewUtilities;

namespace VigilantCupcake {

    public partial class MainForm : Form {
        private AboutBox _aboutBox = new AboutBox();
        private ActualHostsFile _currentHostsForm = new ActualHostsFile();
        private HostfileRecordCombiner _hostfileRecordCombiner = new HostfileRecordCombiner();
        private Fragment _newHostsFile = new Fragment() { IsHostsFile = true };
        private int _pendingDownloads = 0;
        private bool _reallyClose = false;
        private Fragment _selectedFragment = null;
        private List<ToolStripMenuItem> _syncDurationMenuItems;
        private FragmentBrowserModel _treeModel = new FragmentBrowserModel(OperatingSystemUtilities.LocalFiles.BaseDirectory);

        private Label loadingLabel = new Label() {
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Text = "Loading..."
        };

        public MainForm() {
            InitializeComponent();

            _syncDurationMenuItems = new List<ToolStripMenuItem>() {
                syncFiveMinutes, syncFifteenMinutes, syncThirtyMinutes, syncSixtyMinutes
            };

            loadUserSettings();
            currentFragmentView.TextChanged += ViewUtilities.FastColoredTextBoxUtility.FastColoredTextBoxTextChanged;
            hostsFileView.TextChanged += ViewUtilities.FastColoredTextBoxUtility.FastColoredTextBoxTextChanged;

            enabledToolStripMenuItem_CheckedChanged(null, null);

            fragmentTreeView.Model = _treeModel;
            fragmentTreeView.Root.Children.ToList().ForEach(x => x.Expand());
            fragmentTreeView.SelectionChanged += triStateTreeView1_SelectionChanged;

            _newHostsFile.PropertyChanged += fragmentPropertyChanged;

            fragmentListContextMenu.Opening += fragmentListContextMenu_Opening;

            _treeModel.NodesChanged += _treeModel_NodesChanged;
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE) {
                ShowWindow();
            }
            base.WndProc(ref m);
        }

        static private DialogResult confirmAndDelete(FragmentNode node) {
            DialogResult result = MessageBox.Show("Delete " + node.Text + "?", "Delete Fragment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                node.Delete();
                node.Parent = null;
            }

            return result;
        }

        private static string GetLongestCommonPrefix(IEnumerable<string> lines) {
            var matching =
                from len in Enumerable.Range(0, lines.Min(s => s.Length)).Reverse()
                let possibleMatch = lines.First().Substring(0, len)
                where lines.All(f => f.StartsWith(possibleMatch))
                select possibleMatch;
            return matching.FirstOrDefault();
        }

        private void _treeModel_NodesChanged(object sender, TreeModelEventArgs e) {
            var node = (FragmentNode)e.Children[0];
            node.Text = node.Text.AsFileName();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            _aboutBox.ShowDialog();
        }

        private void backgroundDownloadTimer_Tick(object sender, EventArgs e) {
            _treeModel.Fragments.AsParallel().ForAll(y => y.DownloadFile());
            saveAll();
        }

        private void buildImportedPaths(string remoteUrl, string name) {
            var split = name.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            if (split.Length > 1) {
                var foundChild = fragmentTreeView.SelectedNode.Children.FirstOrDefault(x => ((FragmentNode)x.Tag).Text == split[0]);
                if (foundChild != null) {
                    fragmentTreeView.SelectedNode = foundChild;
                } else {
                    createNewNode(false, split[0], split[0]);
                }
                buildImportedPaths(remoteUrl, string.Join(Path.DirectorySeparatorChar.ToString(), split.Skip(1)));
            } else {
                createNewNode(true, name, remoteUrl, false);
            }
        }

        private void closeToTrayToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            UserConfig.Instance.CloseToTray = closeToTrayToolStripMenuItem.Checked;
        }

        private void createNewDirectory() {
            createNewNode(false);
        }

        private void createNewFragment() {
            createNewNode(true);
        }

        private void createNewNode(bool isFragment, string text = null, string remote = null, bool selectNode = true) {
            var selectedNode = (fragmentTreeView.SelectedNode != null) ? (FragmentNode)fragmentTreeView.SelectedNode.Tag : (FragmentNode)fragmentTreeView.Root.Children[0].Tag;
            var directoryNode = selectedNode.IsLeaf ? selectedNode.Parent : selectedNode;
            var treeNode = new FragmentNode();

            if (isFragment) {
                var rootPath = Path.Combine(OperatingSystemUtilities.LocalFiles.BaseDirectoryRoot, directoryNode.FullPath);
                var fragment = new Fragment() {
                    RootPath = rootPath,
                    FileContents = string.Empty
                };
                if (!string.IsNullOrWhiteSpace(remote)) fragment.RemoteLocation = remote;
                fragment.PropertyChanged += fragmentPropertyChanged;
                fragment.DownloadStarting += fragmentDownloadStarting;
                fragment.ContentsDownloaded += fragmentDownloadEnding;
                treeNode.Fragment = fragment;
            }

            var validText = !string.IsNullOrWhiteSpace(text);
            var name = (validText) ? text : (isFragment) ? "New Fragment" : "New Folder";
            name = name.AsFileName();
            treeNode.Text = name;
            var fileNumber = 1;
            while (directoryNode.Nodes.Any(x => x.Text.Equals(treeNode.Text))) {
                var newName = string.Format("{0} {1}", name, fileNumber);
                treeNode.Text = newName;
                fileNumber++;
            }

            treeNode.Parent = directoryNode;
            if (selectNode || !validText) fragmentTreeView.SelectedNode = fragmentTreeView.FindNodeByTag(treeNode);
            if (!validText) {
                nodeTextBox1.BeginEdit();
            }
        }

        private void downloadFragmentToolStripMenuItem_Click(object sender, EventArgs e) {
            if (fragmentTreeView.SelectedNode != null) {
                var selectedNode = (FragmentNode)fragmentTreeView.SelectedNode.Tag;
                if (selectedNode != null && selectedNode.Fragment != null) {
                    selectedNode.Fragment.DownloadFile();
                }
            }
        }

        private void enabledToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            UserConfig.Instance.DownloadInBackground = syncEnabledToolStripMenuItem.Checked;
            backgroundDownloadTimer.Enabled = UserConfig.Instance.DownloadInBackground;
            _syncDurationMenuItems.ForEach(x => {
                x.Enabled = syncEnabledToolStripMenuItem.Checked;
                x.Checked = (int.Parse(x.Tag.ToString()) == UserConfig.Instance.SecondsBetweenBackgroundDownloads);
            });
        }

        private void exit_Click(object sender, EventArgs e) {
            _reallyClose = true;
            Close();
        }

        private void flushDns_Click(object sender, EventArgs e) {
            OperatingSystemUtilities.DnsUtility.FlushDns();
        }

        private void fragmentDownloadEnding(object sender, EventArgs e) {
            var fragment = (Fragment)sender;
            if (fragment == _selectedFragment && !fragment.DownloadPending) {
                tableLayoutPanel2.BeginInvokeIfRequired(() => {
                    tableLayoutPanel2.Controls.Remove(loadingLabel);
                    tableLayoutPanel2.Controls.Add(currentFragmentView, 0, 2);
                    tableLayoutPanel2.SetColumnSpan(loadingLabel, 2);
                });
            }
            downloadingLabel.BeginInvokeIfRequired(() => downloadingLabel.Visible = (_treeModel.Fragments.Any(f => f.DownloadPending)));
        }

        private void fragmentDownloadStarting(object sender, EventArgs e) {
            var fragment = (Fragment)sender;
            if (fragment == _selectedFragment && fragment.DownloadPending) {
                tableLayoutPanel2.BeginInvokeIfRequired(() => {
                    tableLayoutPanel2.Controls.Add(loadingLabel, 0, 2);
                    tableLayoutPanel2.Controls.Remove(currentFragmentView);
                    tableLayoutPanel2.SetColumnSpan(loadingLabel, 2);
                });
            }
            downloadingLabel.BeginInvokeIfRequired(() => downloadingLabel.Visible = (_treeModel.Fragments.Any(f => f.DownloadPending)));
        }

        private void fragmentListContextMenu_Opening(object sender, CancelEventArgs e) {
            if (fragmentTreeView.SelectedNode != null) {
                var selectedNode = (FragmentNode)fragmentTreeView.SelectedNode.Tag;
                if (selectedNode == null) return;

                downloadFragmentToolStripMenuItem.Visible = (selectedNode.Fragment != null) && !string.IsNullOrWhiteSpace(selectedNode.Fragment.RemoteLocation);
                importRemoteFragmentsToolStripMenuItem.Visible = (!selectedNode.IsLeaf && selectedNode.Nodes.Count == 0);

                toolStripSeparator5.Visible = downloadFragmentToolStripMenuItem.Visible || importRemoteFragmentsToolStripMenuItem.Visible;
            }
        }

        private void fragmentListContextMenuDelete_Click(object sender, EventArgs e) {
            if (confirmAndDelete(fragmentTreeView.SelectedNode.Tag as FragmentNode) == DialogResult.Yes) {
                if (fragmentTreeView.SelectedNode != null)
                    (fragmentTreeView.SelectedNode.Tag as FragmentNode).Parent = null;
            }
        }

        private void fragmentListContextMenuRename_Click(object sender, EventArgs e) {
            nodeTextBox1.BeginEdit();
        }

        private void fragmentPropertyChanged(object sender, PropertyChangedEventArgs e) {
            var fragment = (Fragment)sender;
            switch (e.PropertyName) {
                case "RemoteLocation": if (fragment == _selectedFragment) updateCurrentFragmentView(); break;
                case "FileContents": if (fragment.Enabled) updateHostsFileView(); break;
                case "Enabled": updateHostsFileView(); if (fragment == _selectedFragment) updateCurrentFragmentView(); break;
                case "Dirty": updateHostsFileView(); if (fragment == _selectedFragment) updateCurrentFragmentView(); break;
                default: break;
            }
        }

        private void fragmentSearchTextChanged(object sender, EventArgs e) {
            _treeModel.Filter = fragmentFilter.Text;
            fragmentTreeView.ExpandAll();
        }

        private void importRemoteFragmentsToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog();
            Stream myStream = null;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    if ((myStream = dialog.OpenFile()) != null) {
                        var lines = new List<string>();
                        using (myStream)
                        using (var sr = new StreamReader(myStream)) {
                            string line;
                            while ((line = sr.ReadLine()) != null) {
                                lines.Add(line);
                            }
                        }

                        var prefix = GetLongestCommonPrefix(lines);
                        var selectedNode = fragmentTreeView.SelectedNode;

                        foreach (var item in lines) {
                            fragmentTreeView.SelectedNode = selectedNode;
                            var name = item;
                            name = name.Replace(prefix, string.Empty);
                            buildImportedPaths(item, name);
                        }

                        fragmentTreeView.SelectedNode = selectedNode;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read from fragment list source. Original error: " + ex.Message);
                }
            }
        }

        private void loadFragments() {
            if (_treeModel.Fragments.Count() == 0) {
                var treeNode = new FragmentNode() { Text = "Existing Hosts" };
                var currentHosts = new Fragment() { Name = treeNode.Text };
                treeNode.Fragment = currentHosts;
                _treeModel.FragmentNodes.First(x => x != null && x.Parent != null).Nodes.Add(treeNode);
                treeNode.CheckState = CheckState.Checked;
                currentHosts.FileContents = _newHostsFile.FileContents;
                currentHosts.Save();
                _selectedFragment = currentHosts;
            }

            hostsFileBindingSource.DataSource = _newHostsFile;
            updateCurrentFragmentView();
            _treeModel.Fragments.AsParallel().ForAll(x => {
                x.PropertyChanged += fragmentPropertyChanged;
                x.DownloadStarting += fragmentDownloadStarting;
                x.ContentsDownloaded += fragmentDownloadEnding;
            });
        }

        private void loadUserSettings() {
            saveOnProgramStartToolStripMenuItem.Checked = UserConfig.Instance.AutoSaveOnStartup;
            closeToTrayToolStripMenuItem.Checked = UserConfig.Instance.CloseToTray;
            syncEnabledToolStripMenuItem.Checked = UserConfig.Instance.DownloadInBackground;
            newHostsAnalysisToolStripMenuItem.Checked = UserConfig.Instance.NewHostsAnalysis;
            _hostfileRecordCombiner.Filter = UserConfig.Instance.NewHostsFilter;
            backgroundDownloadTimer.Interval = UserConfig.Instance.SecondsBetweenBackgroundDownloads;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            savePreferences();
            OperatingSystemUtilities.DnsUtility.FlushDns();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (UserConfig.Instance.CloseToTray && !_reallyClose) {
                notifyIcon1.Visible = true;
                Hide();
                e.Cancel = true;
                return;
            }

            if (_pendingDownloads > 0) {
                DialogResult result = MessageBox.Show("There are still downloads pending, do you really want to exit?", "Downloads Pending", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
            if (!e.Cancel && (_treeModel.Fragments.Any(x => x.Dirty) || _newHostsFile.Dirty)) {
                DialogResult result = MessageBox.Show("Would you like to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result) {
                    case DialogResult.Yes:
                        saveAll();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            loadFragments();
            if (UserConfig.Instance.AutoSaveOnStartup) saveAll();

            updateCheckTimer_Tick(null, null);
        }

        private void menuNewFolder_Click(object sender, EventArgs e) {
            createNewDirectory();
        }

        private void menuNewFragment_Click(object sender, EventArgs e) {
            createNewFragment();
        }

        private void newHostFilterBox_TextChanged(object sender, EventArgs e) {
            UserConfig.Instance.NewHostsFilter = newHostFilterBox.Text;
            _hostfileRecordCombiner.Filter = UserConfig.Instance.NewHostsFilter;
            updateHostsFileView();
            updateCurrentFragmentView();
        }

        private void newHostsAnalysisToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            UserConfig.Instance.NewHostsAnalysis = newHostsAnalysisToolStripMenuItem.Checked;

            newHostFilterBox.Enabled = newHostsAnalysisToolStripMenuItem.Checked;

            updateHostsFileView();
            updateCurrentFragmentView();
        }

        private void save_Click(object sender, EventArgs e) {
            saveAll();
        }

        private void saveAll() {
            try {
                _treeModel.SaveAll();
                _newHostsFile.Save();
                OperatingSystemUtilities.DnsUtility.FlushDns();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveOnProgramStartToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            UserConfig.Instance.AutoSaveOnStartup = saveOnProgramStartToolStripMenuItem.Checked;
        }

        private void savePreferences() {
            UserConfig.Instance.SelectedFiles = new List<string>();
            if (_treeModel != null && _treeModel.Root.Nodes.Count() > 0) {
                var paths = _treeModel.Fragments.Where(x => x.Enabled).Select(x => x.FullPath).ToArray();
                UserConfig.Instance.SelectedFiles.AddRange(paths);
            }
            UserConfig.Instance.Save();
        }

        private void showMainForm(object sender, EventArgs e) {
            ShowWindow();
        }

        private void ShowWindow() {
            notifyIcon1.Visible = false;
            NativeMethods.ShowToFront(this.Handle);
        }

        private void syncDuration_CheckedChanged(object sender, EventArgs e) {
            var item = (ToolStripMenuItem)sender;
            if (item.Checked) {
                UserConfig.Instance.SecondsBetweenBackgroundDownloads = int.Parse(item.Tag.ToString());
                backgroundDownloadTimer.Interval = UserConfig.Instance.SecondsBetweenBackgroundDownloads;
                enabledToolStripMenuItem_CheckedChanged(null, null);
            }
        }

        private void triStateTreeView1_DragDrop(object sender, DragEventArgs e) {
            var nodeBeingDragged = (TreeNodeAdv)e.Data.GetData(typeof(TreeNodeAdv));
            var fragmentNode = nodeBeingDragged.Tag as FragmentNode;
            var dropNode = fragmentTreeView.DropPosition.Node.Tag as FragmentNode;
            if (!dropNode.IsLeaf) {
                fragmentNode.Parent = dropNode;
                fragmentTreeView.DropPosition.Node.IsExpanded = true;
            } else {
                var parent = dropNode.Parent;
                var nextItem = dropNode;
                if (fragmentTreeView.DropPosition.Position == NodePosition.After)
                    nextItem = dropNode.NextNode;

                fragmentNode.Parent = null;

                var index = parent.Nodes.IndexOf(nextItem);
                if (index == -1)
                    parent.Nodes.Add(fragmentNode);
                else {
                    parent.Nodes.Insert(index, fragmentNode);
                }
            }

            if (fragmentNode.Fragment != null) fragmentNode.Fragment.RootPath = (fragmentNode.Parent).FilePath;
        }

        private void triStateTreeView1_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(TreeNodeAdv))
                && fragmentTreeView.DropPosition.Node != null
                && fragmentTreeView.DropPosition.Node.Tag is FragmentNode
                && fragmentTreeView.DropPosition.Position != NodePosition.Before) {
                e.Effect = e.AllowedEffect;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void triStateTreeView1_ItemDrag(object sender, ItemDragEventArgs e) {
            DoDragDrop(fragmentTreeView.SelectedNode, DragDropEffects.Move);
        }

        private void triStateTreeView1_SelectionChanged(object sender, EventArgs e) {
            _selectedFragment = null;
            if (fragmentTreeView.SelectedNode != null && fragmentTreeView.SelectedNode.Tag is FragmentNode) {
                var node = (FragmentNode)fragmentTreeView.SelectedNode.Tag;
                if (node != null && node.Fragment != null) {
                    currentFragmentView.Enabled = true;
                    remoteUrlView.Enabled = true;
                    _selectedFragment = node.Fragment;
                }
            }

            if (_selectedFragment == null) {
                selectedFragmentBindingSource.DataSource = typeof(VigilantCupcake.Models.Fragment);
                currentFragmentView.Enabled = false;
                currentFragmentView.Text = string.Empty;
                remoteUrlView.Text = string.Empty;
                remoteUrlView.Enabled = false;
            } else {
                selectedFragmentBindingSource.DataSource = _selectedFragment;
                if (_selectedFragment.DownloadPending) {
                    tableLayoutPanel2.Controls.Add(loadingLabel, 0, 2);
                    tableLayoutPanel2.Controls.Remove(currentFragmentView);
                    tableLayoutPanel2.SetColumnSpan(loadingLabel, 2);
                }
            }

            updateCurrentFragmentView();
        }

        private async void updateCheckTimer_Tick(object sender, EventArgs e) {
            await Task.Factory.StartNew(async () => {
                using (var mgr = new UpdateManager(Properties.Settings.Default.ReleasesUrl, Properties.Settings.Default.NuspecId, FrameworkVersion.Net45)) {
                    bool ignoreDeltaUpdates = false;

                retry:
                    var updateInfo = default(UpdateInfo);

                    try {
                        updateInfo = await mgr.CheckForUpdate(ignoreDeltaUpdates);
                        await mgr.DownloadReleases(updateInfo.ReleasesToApply);
                        await mgr.ApplyReleases(updateInfo);
                        await mgr.CreateUninstallerRegistryEntry();
                    } catch (Exception) {
                        if (ignoreDeltaUpdates == false) {
                            ignoreDeltaUpdates = true;
                            goto retry;
                        }

                        throw;
                    }
                    var releaseNotes = updateInfo.FetchReleaseNotes();
                    toolStripContainer2.BeginInvokeIfRequired(() => updateNotification.Visible = updateInfo.FutureReleaseEntry.Version > updateInfo.CurrentlyInstalledVersion.Version);
                    _aboutBox.BeginInvokeIfRequired(() => _aboutBox.LatestVersionText = updateInfo.FutureReleaseEntry.Version.ToString());
                }
            });
        }

        private void updateCurrentFragmentView() {
            currentFragmentView.Enabled = _selectedFragment != null;
            remoteUrlView.Enabled = _selectedFragment != null;
            if (_selectedFragment != null) {
                if (_selectedFragment.RemoteLocation != null && !_selectedFragment.RemoteLocation.Equals(remoteUrlView.Text)) {
                    remoteUrlView.Text = _selectedFragment.RemoteLocation;
                }
                currentFragmentView.ReadOnly = !string.IsNullOrEmpty(_selectedFragment.RemoteLocation);
                currentFragmentView.BackColor = (currentFragmentView.ReadOnly) ? SystemColors.Control : Color.White;
                selectedFragmentLabel.BeginInvokeIfRequired(() => selectedFragmentLabel.Text = "Selected Fragment" + ((_selectedFragment.Dirty) ? "*" : string.Empty));
                currentFragmentView.BeginInvokeIfRequired(() => currentFragmentView.RefreshStyles()); //Needed?
            }
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (_treeModel.Fragments.Count() > 0) {
                _treeModel.Fragments.Where(x => x.Enabled).ToList().ForEach(y => text.Add(y.FileContents));

                //TODO: More efficient????
                var newHosts = string.Empty;
                FastColoredTextBoxUtility.Collisions = null;
                if (UserConfig.Instance.NewHostsAnalysis) {
                    // Join then split then join to normalize line endings etc, I don't really like it but it works
                    var blob = string.Join(Environment.NewLine, text);
                    var result = _hostfileRecordCombiner.GenerateOutput(blob.Split(Environment.NewLine.ToArray()));
                    newHosts = string.Join(Environment.NewLine, result);
                    FastColoredTextBoxUtility.Collisions = _hostfileRecordCombiner.Collisions;
                } else {
                    newHosts = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                }

                _newHostsFile.FileContents = newHosts;
                hostsFileView.BeginInvokeIfRequired(() => hostsFileView.RefreshStyles());
                newHostsLabel.BeginInvokeIfRequired(() =>
                    newHostsLabel.Text = "New Hosts" + ((_newHostsFile.Dirty) ? "*" : string.Empty) + ((_hostfileRecordCombiner.Collisions != null && _hostfileRecordCombiner.Collisions.Keys.Count > 0) ? " (Conflicts in red)" : string.Empty)
                );
            }
        }

        private void viewCurrentHostsToolStripMenuItem_Click(object sender, EventArgs e) {
            _currentHostsForm.ShowDialog();
        }

        private void remoteUrlView_TextChanged(object sender, EventArgs e) {
            _selectedFragment.RemoteLocation = remoteUrlView.Text;
        }
    }
}