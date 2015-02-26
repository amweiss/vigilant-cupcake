using Aga.Controls.Tree;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.OperatingSystemUtilities;
using VigilantCupcake.SubForms;
using VigilantCupcake.ViewUtilities;

namespace VigilantCupcake {

    public partial class MainForm : Form {
        private ActualHostsFile _currentHostsForm = new ActualHostsFile();
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

            mergeHostsEntriesToolStripMenuItem.Visible = false;

            saveOnProgramStartToolStripMenuItem.Checked = Properties.Settings.Default.AutoSaveOnStartup;
            mergeHostsEntriesToolStripMenuItem.Checked = Properties.Settings.Default.MergeHostsEntries;
            currentFragmentView.TextChanged += ViewUtilities.FastColoredTextBoxUtility.FastColoredTextBoxTextChanged;
            hostsFileView.TextChanged += ViewUtilities.FastColoredTextBoxUtility.FastColoredTextBoxTextChanged;

            _syncDurationMenuItems = new List<ToolStripMenuItem>() {
                syncFiveMinutes, syncFifteenMinutes, syncThirtyMinutes, syncSixtyMinutes
            };

            enabledToolStripMenuItem_CheckedChanged(null, null);

            fragmentTreeView.Model = _treeModel;
            fragmentTreeView.Root.Children.ToList().ForEach(x => x.Expand());
            fragmentTreeView.SelectionChanged += triStateTreeView1_SelectionChanged;

            _newHostsFile.PropertyChanged += fragmentPropertyChanged;

            fragmentListContextMenu.Opening += fragmentListContextMenu_Opening;
        }

        void fragmentListContextMenu_Opening(object sender, CancelEventArgs e) {
            if (fragmentTreeView.SelectedNode != null) {
                var selectedNode = (FragmentNode)fragmentTreeView.SelectedNode.Tag;
                if (selectedNode != null && selectedNode.Fragment != null) {
                    var visible = !string.IsNullOrWhiteSpace(selectedNode.Fragment.RemoteLocation);
                    toolStripSeparator5.Visible = visible;
                    downloadFragmentToolStripMenuItem.Visible = visible;
                }
            }
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

        private void backgroundDownloadTimer_Tick(object sender, EventArgs e) {
            _treeModel.Fragments.AsParallel().ForAll(y => y.DownloadFile());
            saveAll();
        }

        private void closeToTrayToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.CloseToTray = closeToTrayToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void createNewDirectory() {
            createNewNode(false);
        }

        private void createNewFragment() {
            createNewNode(true);
        }

        private void createNewNode(bool isFragment) {
            if (fragmentTreeView.SelectedNode != null) {
                var selectedNode = (FragmentNode)fragmentTreeView.SelectedNode.Tag;
                var directoryNode = selectedNode.IsLeaf ? selectedNode.Parent : selectedNode;
                var treeNode = new FragmentNode();

                if (isFragment) {
                    var rootPath = Path.Combine(OperatingSystemUtilities.LocalFiles.BaseDirectoryRoot, directoryNode.FullPath);
                    var fragment = new Fragment() {
                        RootPath = rootPath,
                        FileContents = string.Empty
                    };
                    fragment.PropertyChanged += fragmentPropertyChanged;
                    fragment.DownloadStarting += fragmentDownloadStarting;
                    fragment.ContentsDownloaded += fragmentDownloadEnding;
                    treeNode.Fragment = fragment;
                }

                var name = (isFragment) ? "New Fragment" : "New Folder";
                treeNode.Text = name;
                var fileNumber = 1;
                while (directoryNode.Nodes.Any(x => x.Text.Equals(treeNode.Text))) {
                    var newName = string.Format("{0} {1}", name, fileNumber);
                    treeNode.Text = newName;
                    fileNumber++;
                }

                treeNode.Parent = directoryNode;
                fragmentTreeView.SelectedNode = fragmentTreeView.FindNodeByTag(treeNode);
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
            Properties.Settings.Default.DownloadInBackground = syncEnabledToolStripMenuItem.Checked;
            backgroundDownloadTimer.Enabled = Properties.Settings.Default.DownloadInBackground;
            _syncDurationMenuItems.ForEach(x => {
                x.Enabled = syncEnabledToolStripMenuItem.Checked;
                x.Checked = (int.Parse(x.Tag.ToString()) == Properties.Settings.Default.MinutesBetweenDownloads);
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
                tableLayoutPanel3.BeginInvokeIfRequired(() => {
                    tableLayoutPanel3.Controls.Remove(loadingLabel);
                    tableLayoutPanel3.Controls.Add(currentFragmentView, 0, 2);
                });
            }
            downloadingLabel.BeginInvokeIfRequired(() => downloadingLabel.Visible = (_treeModel.Fragments.Any(f => f.DownloadPending)));
        }

        private void fragmentDownloadStarting(object sender, EventArgs e) {
            var fragment = (Fragment)sender;
            if (fragment == _selectedFragment && fragment.DownloadPending) {
                tableLayoutPanel3.BeginInvokeIfRequired(() => {
                    tableLayoutPanel3.Controls.Add(loadingLabel, 0, 2);
                    tableLayoutPanel3.Controls.Remove(currentFragmentView);
                });
            }
            downloadingLabel.BeginInvokeIfRequired(() => downloadingLabel.Visible = (_treeModel.Fragments.Any(f => f.DownloadPending)));
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
                case "Enabled": updateHostsFileView(); break;
                case "Dirty": updateHostsFileView(); if (fragment == _selectedFragment) updateCurrentFragmentView(); break;
                default: break;
            }
        }

        private void fragmentSearchTextChanged(object sender, EventArgs e) {
            _treeModel.Filter = fragmentFilter.Text;
            fragmentTreeView.ExpandAll();
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            savePreferences();
            OperatingSystemUtilities.DnsUtility.FlushDns();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (Properties.Settings.Default.CloseToTray && !_reallyClose) {
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
            if (Properties.Settings.Default.AutoSaveOnStartup) saveAll();
        }

        private void menuNewFolder_Click(object sender, EventArgs e) {
            createNewDirectory();
        }

        private void menuNewFragment_Click(object sender, EventArgs e) {
            createNewFragment();
        }

        private void mergeHostsEntriesToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.MergeHostsEntries = mergeHostsEntriesToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            updateHostsFileView();
        }

        private void remoteUrlView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                updateCurrentFragmentView();
                e.Handled = true;
            }
        }

        private void remoteUrlView_Validated(object sender, EventArgs e) {
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
            Properties.Settings.Default.AutoSaveOnStartup = saveOnProgramStartToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void savePreferences() {
            Properties.Settings.Default.SelectedFiles = new StringCollection();
            if (_treeModel != null && _treeModel.Root.Nodes.Count() > 0) {
                var paths = _treeModel.Fragments.Where(x => x.Enabled).Select(x => x.FullPath).ToArray();
                Properties.Settings.Default.SelectedFiles.AddRange(paths);
            }
            Properties.Settings.Default.Save();
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
                Properties.Settings.Default.MinutesBetweenDownloads = int.Parse(item.Tag.ToString());
                backgroundDownloadTimer.Interval = Properties.Settings.Default.MinutesBetweenDownloads;
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
                    tableLayoutPanel3.Controls.Add(loadingLabel, 0, 2);
                    tableLayoutPanel3.Controls.Remove(currentFragmentView);
                }
            }

            updateCurrentFragmentView();
        }

        private void updateCurrentFragmentView() {
            currentFragmentView.Enabled = _selectedFragment != null;
            remoteUrlView.Enabled = _selectedFragment != null;
            if (_selectedFragment != null) {
                currentFragmentView.ReadOnly = !string.IsNullOrEmpty(_selectedFragment.RemoteLocation);
                currentFragmentView.BackColor = (currentFragmentView.ReadOnly) ? SystemColors.Control : Color.White;
                selectedFragmentLabel.BeginInvokeIfRequired(() => selectedFragmentLabel.Text = "Selected Fragment" + ((_selectedFragment.Dirty) ? "*" : string.Empty));
            }
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (_treeModel.Fragments.Count() > 0) {
                _treeModel.Fragments.Where(x => x.Enabled).ToList().ForEach(y => text.Add(y.FileContents));

                //TODO: More efficient????
                var newHosts = string.Empty;
                //if (Properties.Settings.Default.MergeHostsEntries) { //TODO: MAKE MERGING WORK AND NAME IT BETTER
                //    var combiner = new FragmentCombiner();
                //    var blob = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                //    var result = combiner.GenerateOutput(blob.Split(Environment.NewLine.ToArray()));
                //    newHosts = (result.Count() > 0) ? result.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                //} else {
                newHosts = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                //}
                _newHostsFile.FileContents = newHosts;
                newHostsLabel.BeginInvokeIfRequired(() => newHostsLabel.Text = "New Hosts" + ((_newHostsFile.Dirty) ? "*" : string.Empty));
            }
        }

        private void viewCurrentHostsToolStripMenuItem_Click(object sender, EventArgs e) {
            _currentHostsForm.ShowDialog();
        }
    }
}