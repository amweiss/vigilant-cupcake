using Aga.Controls.Tree;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantCupcake.ExtensionMethods;
using VigilantCupcake.Models;
using VigilantCupcake.OperatingSystemUtilities;
using VigilantCupcake.SubForms;
using VigilantCupcake.ViewExtensions;

namespace VigilantCupcake {

    public partial class MainForm : Form {
        private AboutBox _aboutBox = new AboutBox();
        private ActualHostsFile _currentHostsForm = new ActualHostsFile();
        private HostfileRecordCombiner _hostfileRecordCombiner = new HostfileRecordCombiner();
        private Fragment _newHostsFile = new Fragment() { IsHostsFile = true };
        private bool _reallyClose = false;
        private Fragment _selectedFragment = null;

        private Label loadingLabel = new Label() {
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
            Text = "Loading..."
        };

        public MainForm() {
            InitializeComponent();
            components.Add(loadingLabel);

            loadUserSettings();
            currentFragmentView.TextChanged += FastColoredTextBoxUtility.FastColoredTextBoxTextChanged;
            hostsFileView.TextChanged += FastColoredTextBoxUtility.FastColoredTextBoxTextChanged;

            enabledToolStripMenuItem_CheckedChanged(null, null);

            fragmentTreeView.SelectionChanged += triStateTreeView1_SelectionChanged;

            _newHostsFile.PropertyChanged += fragmentPropertyChanged;

            fragmentTreeView.Model.NodesInserted += Model_NodesInserted;
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE) {
                ShowWindow();
            }
            base.WndProc(ref m);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            _aboutBox.ShowDialog();
        }

        private void backgroundDownloadTimer_Tick(object sender, EventArgs e) {
            fragmentTreeView.Model.Fragments.AsParallel().ForAll(y => y.DownloadFile());
            saveAll();
        }

        private void closeToTrayToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            UserConfig.Instance.CloseToTray = closeToTrayToolStripMenuItem.Checked;
        }

        private void enabledToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            UserConfig.Instance.DownloadInBackground = syncEnabledToolStripMenuItem.Checked;
            backgroundDownloadTimer.Enabled = UserConfig.Instance.DownloadInBackground;

            foreach (var menuItem in syncronizeFragmentsToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(i => i.Tag != null)) {
                menuItem.Enabled = syncEnabledToolStripMenuItem.Checked;
                menuItem.Checked = (int.Parse(menuItem.Tag.ToString()) == UserConfig.Instance.SecondsBetweenBackgroundDownloads);
            }
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
            downloadingLabel.BeginInvokeIfRequired(() => downloadingLabel.Visible = (fragmentTreeView.Model.Fragments.Any(f => f.DownloadPending)));
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
            downloadingLabel.BeginInvokeIfRequired(() => downloadingLabel.Visible = (fragmentTreeView.Model.Fragments.Any(f => f.DownloadPending)));
        }

        private void fragmentPropertyChanged(object sender, PropertyChangedEventArgs e) {
            var fragment = (Fragment)sender;
            switch (e.PropertyName) {
                case "RemoteLocation":
                    if (fragment == _selectedFragment) updateCurrentFragmentView();
                    break;

                case "FileContents":
                    if (fragment.Enabled) updateHostsFileView();
                    break;

                case "Enabled":
                    updateHostsFileView();
                    if (fragment == _selectedFragment)
                        updateCurrentFragmentView();
                    break;

                case "Dirty":
                    if (fragment.Enabled || fragment == _newHostsFile)
                        updateHostsFileView();
                    if (fragment == _selectedFragment)
                        updateCurrentFragmentView();
                    break;

                default: break;
            }
        }

        private void fragmentSearchTextChanged(object sender, EventArgs e) {
            fragmentTreeView.Model.Filter = fragmentFilter.Text;
            fragmentTreeView.ExpandAll();
        }

        private void loadFragments() {
            if (fragmentTreeView.Model.Fragments.Count() == 0) {
                var treeNode = new FragmentNode() { Text = "Existing Hosts" };
                var currentHosts = new Fragment() { Name = treeNode.Text };
                treeNode.Fragment = currentHosts;
                fragmentTreeView.Model.FragmentNodes.First(x => x != null && x.Parent != null).Nodes.Add(treeNode);
                treeNode.CheckState = CheckState.Checked;
                currentHosts.FileContents = _newHostsFile.FileContents;
                currentHosts.Save();
                _selectedFragment = currentHosts;
            }

            hostsFileBindingSource.DataSource = _newHostsFile;
            updateCurrentFragmentView();
            fragmentTreeView.Model.Fragments.AsParallel().ForAll(x => {
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

            if (fragmentTreeView.Model.Fragments.Any(x => x.DownloadPending)) {
                DialogResult result = MessageBox.Show("There are still downloads pending, do you really want to exit?", "Downloads Pending", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
            if (!e.Cancel && (fragmentTreeView.Model.Fragments.Any(x => x.Dirty) || _newHostsFile.Dirty)) {
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

        private void menuNewFolder_Click(object sender, System.EventArgs e) {
            fragmentTreeView.createNewDirectory();
        }

        private void menuNewFragment_Click(object sender, System.EventArgs e) {
            fragmentTreeView.createNewFragment();
        }

        private void Model_NodesInserted(object sender, TreeModelEventArgs e) {
            var changedNode = fragmentTreeView.Model.FindNode(e.Path);
            if (changedNode != null && changedNode.Fragment != null) {
                changedNode.Fragment.PropertyChanged += fragmentPropertyChanged;
                changedNode.Fragment.DownloadStarting += fragmentDownloadStarting;
                changedNode.Fragment.ContentsDownloaded += fragmentDownloadEnding;
            }
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

        private void remoteUrlView_TextChanged(object sender, EventArgs e) {
            if (_selectedFragment != null) {
                _selectedFragment.RemoteLocation = remoteUrlView.Text;
            }
        }

        private void save_Click(object sender, EventArgs e) {
            saveAll();
        }

        private void saveAll() {
            try {
                fragmentTreeView.Model.SaveAll();
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
            if (fragmentTreeView.Model != null && fragmentTreeView.Model.Root.Nodes.Count() > 0) {
                var paths = fragmentTreeView.Model.Fragments.Where(x => x.Enabled).Select(x => x.FullPath).ToArray();
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
                remoteUrlView.Text = _selectedFragment.RemoteLocation;
                if (_selectedFragment.DownloadPending) {
                    tableLayoutPanel2.Controls.Add(loadingLabel, 0, 2);
                    tableLayoutPanel2.Controls.Remove(currentFragmentView);
                    tableLayoutPanel2.SetColumnSpan(loadingLabel, 2);
                } else if (!_selectedFragment.DownloadPending) {
                    tableLayoutPanel2.BeginInvokeIfRequired(() => {
                        tableLayoutPanel2.Controls.Remove(loadingLabel);
                        tableLayoutPanel2.Controls.Add(currentFragmentView, 0, 2);
                        tableLayoutPanel2.SetColumnSpan(loadingLabel, 2);
                    });
                }
                currentFragmentView.ReadOnly = !string.IsNullOrEmpty(_selectedFragment.RemoteLocation);
                currentFragmentView.BackColor = (currentFragmentView.ReadOnly) ? SystemColors.Control : Color.White;
            }

            updateCurrentFragmentView();
        }

        private async void updateCheckTimer_Tick(object sender, EventArgs e) {
            await Task.Factory.StartNew(async () => {
                using (var mgr = new UpdateManager(Properties.Settings.Default.ReleasesUrl, Properties.Settings.Default.NuspecId)) {
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
                    if (updateInfo != null && updateInfo.FutureReleaseEntry != null && updateInfo.FutureReleaseEntry.Version != null && updateInfo.CurrentlyInstalledVersion != null) {
                        var showNotification = (updateInfo.FutureReleaseEntry.Version > updateInfo.CurrentlyInstalledVersion.Version);
                        toolStripContainer2.BeginInvokeIfRequired(() => updateNotification.Visible = showNotification);
                        _aboutBox.BeginInvokeIfRequired(() => _aboutBox.LatestVersionText = updateInfo.FutureReleaseEntry.Version.ToString());
                    } else {
                        _aboutBox.BeginInvokeIfRequired(() => _aboutBox.LatestVersionText = "Error finding latest version");
                    }
                }
            });
        }

        private void updateCurrentFragmentView() {
            currentFragmentView.Enabled = _selectedFragment != null;
            remoteUrlView.Enabled = _selectedFragment != null;
            if (_selectedFragment != null) {
                selectedFragmentLabel.BeginInvokeIfRequired(() => selectedFragmentLabel.Text = "Selected Fragment" + ((_selectedFragment.Dirty) ? "*" : string.Empty));
            }
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (fragmentTreeView.Model.Fragments.Count() > 0) {
                fragmentTreeView.Model.Fragments.Where(x => x.Enabled).ToList().ForEach(y => text.Add(y.FileContents));

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
    }
}