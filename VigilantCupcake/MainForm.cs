using Fragments;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.OS_Utils;
using VigilantCupcake.SubForms;
using VigilantCupcake.View_Utils;

namespace VigilantCupcake {

    public partial class MainForm : Form {
        private FragmentBrowserModel _treeModel = new FragmentBrowserModel(OS_Utils.LocalFiles.BaseDirectory);
        private Fragment _selectedFragment = null;
        private Fragment _newHostsFile = new Fragment() { IsHostsFile = true };

        private ActualHostsFile _currentHostsForm = new ActualHostsFile();
        private int _pendingDownloads = 0;
        private bool _reallyClose = false;

        private List<ToolStripMenuItem> _syncDurationMenuItems;

        public MainForm() {
            InitializeComponent();

            mergeHostsEntriesToolStripMenuItem.Visible = false;

            saveOnProgramStartToolStripMenuItem.Checked = Properties.Settings.Default.AutoSaveOnStartup;
            mergeHostsEntriesToolStripMenuItem.Checked = Properties.Settings.Default.MergeHostsEntries;
            currentFragmentView.TextChanged += View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged;
            hostsFileView.TextChanged += View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged;

            _syncDurationMenuItems = new List<ToolStripMenuItem>() {
                syncFiveMinutes, syncFifteenMinutes, syncThirtyMinutes, syncSixtyMinutes
            };

            enabledToolStripMenuItem_CheckedChanged(null, null);

            triStateTreeView1.Model = _treeModel;
            triStateTreeView1.SelectionChanged += triStateTreeView1_SelectionChanged;

            _newHostsFile.PropertyChanged += fragmentPropertyChanged;
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

        private void triStateTreeView1_SelectionChanged(object sender, EventArgs e) {
            //TODO: Make this a bit more sane with setting _selectedFragment
            if (triStateTreeView1.SelectedNode == null || !(triStateTreeView1.SelectedNode.Tag is FragmentNode)) {
                _selectedFragment = null;
            } else if (triStateTreeView1.SelectedNode != null) {
                var node = triStateTreeView1.SelectedNode.Tag as FragmentNode;
                if (node != null && node.Fragment != null) {
                    currentFragmentView.Enabled = true;
                    remoteUrlView.Enabled = true;
                    _selectedFragment = node.Fragment;
                } else {
                    _selectedFragment = null;
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
            }

            updateCurrentFragmentView();
        }

        protected override void WndProc(ref Message message) {
            if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE) {
                ShowWindow();
            }
            base.WndProc(ref message);
        }

        private void ShowWindow() {
            notifyIcon1.Visible = false;
            NativeMethods.ShowToFront(this.Handle);
        }

        private void saveAll() {
            try {
                _treeModel.saveAll();
                _newHostsFile.save();
                OS_Utils.DnsUtil.FlushDns();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_Click(object sender, EventArgs e) {
            _reallyClose = true;
            Close();
        }

        private void save_Click(object sender, EventArgs e) {
            saveAll();
        }

        private void flushDns_Click(object sender, EventArgs e) {
            OS_Utils.DnsUtil.FlushDns();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            loadFragments();
            if (Properties.Settings.Default.AutoSaveOnStartup) saveAll();
        }

        private void savePreferences() {
            Properties.Settings.Default.SelectedFiles = new StringCollection();
            if (_treeModel != null && _treeModel.Nodes.Count() > 0) {
                var paths = _treeModel.Fragments.Where(x => x.Enabled).Select(x => x.FullPath).ToArray();
                Properties.Settings.Default.SelectedFiles.AddRange(paths);
            }
            Properties.Settings.Default.Save();
        }

        private void loadFragments() {
            if (_treeModel.Fragments.Count() == 0) {
                var treeNode = new FragmentNode("Existing Hosts");
                var currentHosts = new Fragment() { Name = treeNode.Text, Enabled = true };
                treeNode.Fragment = currentHosts;
                _treeModel.FragmentNodes.First(x => x != null).Nodes.Add(treeNode);
                currentHosts.FileContents = _newHostsFile.FileContents;
                currentHosts.save();
                _selectedFragment = currentHosts;
                _selectedFragment.PropertyChanged += fragmentPropertyChanged;
            }

            hostsFileBindingSource.DataSource = _newHostsFile;
            updateCurrentFragmentView();
            _treeModel.Fragments.AsParallel().ForAll(x => x.PropertyChanged += fragmentPropertyChanged);
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (_treeModel.Fragments.Count() > 0) {
                _treeModel.Fragments.Where(x => x.Enabled).ToList().ForEach(y => text.Add(y.FileContents));

                //TODO: More efficient????
                var newHosts = string.Empty;
                if (false && Properties.Settings.Default.MergeHostsEntries) { //TODO: MAKE MERGING WORK AND NAME IT BETTER
                    var combiner = new FragmentCombiner();
                    var blob = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                    var result = combiner.generateOutput(blob.Split(Environment.NewLine.ToArray()));
                    newHosts = (result.Count() > 0) ? result.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                } else {
                    newHosts = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                }
                _newHostsFile.FileContents = newHosts;
                newHostsLabel.BeginInvokeIfRequired(() => newHostsLabel.Text = "New Hosts" + ((_newHostsFile.Dirty) ? "*" : string.Empty));
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            savePreferences();
            OS_Utils.DnsUtil.FlushDns();
        }

        private void createNewFragment() {
            createNewNode(true);
        }

        private void createNewDirectory() {
            createNewNode(false);
        }

        private void createNewNode(bool isFragment) {
            if (triStateTreeView1.SelectedNode != null) {
                var selectedNode = (FragmentNode)triStateTreeView1.SelectedNode.Tag;
                var directoryNode = selectedNode.IsLeaf ? (FragmentNode)selectedNode.Parent : selectedNode;
                var treeNode = new FragmentNode((isFragment) ? "New Fragment" : "New Folder");

                if (isFragment) {
                    var fragment = new Fragment() {
                        RootPath = Path.Combine(OS_Utils.LocalFiles.BaseDirectoryRoot, directoryNode.FullPath),
                        FileContents = string.Empty
                    };
                    fragment.PropertyChanged += fragmentPropertyChanged;
                    treeNode.Fragment = fragment;
                }

                treeNode.Parent = directoryNode;
                triStateTreeView1.SelectedNode = triStateTreeView1.FindNodeByTag(treeNode);
                nodeTextBox1.BeginEdit();
            }
        }

        private void remoteUrlView_Validated(object sender, EventArgs e) {
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

        private void viewCurrentHostsToolStripMenuItem_Click(object sender, EventArgs e) {
            _currentHostsForm.ShowDialog();
        }

        private void fragmentListContextMenuDelete_Click(object sender, EventArgs e) {
            if (confirmAndDelete(triStateTreeView1.SelectedNode.Tag as FragmentNode) == DialogResult.Yes) {
                if (triStateTreeView1.SelectedNode != null)
                    _treeModel.remove(triStateTreeView1.SelectedNode.Tag as FragmentNode);
            }
        }

        private DialogResult confirmAndDelete(FragmentNode node) {
            DialogResult result = MessageBox.Show("Delete " + node.Text + "?", "Delete Fragment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                node.Fragment.delete();
                _treeModel.remove(node);
            }

            return result;
        }

        private void saveOnProgramStartToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.AutoSaveOnStartup = saveOnProgramStartToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void mergeHostsEntriesToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.MergeHostsEntries = mergeHostsEntriesToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            updateHostsFileView();
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

        private void menuNewFragment_Click(object sender, EventArgs e) {
            createNewFragment();
        }

        private void remoteUrlView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                updateCurrentFragmentView();
                e.Handled = true;
            }
        }

        private void backgroundDownloadTimer_Tick(object sender, EventArgs e) {
            _treeModel.Fragments.Where(x => x.Enabled).AsParallel().ForAll(y => y.downloadFile());
            saveAll();
        }

        private void enabledToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.DownloadInBackground = syncEnabledToolStripMenuItem.Checked;
            backgroundDownloadTimer.Enabled = Properties.Settings.Default.DownloadInBackground;
            _syncDurationMenuItems.ForEach(x => {
                x.Enabled = syncEnabledToolStripMenuItem.Checked;
                x.Checked = (int.Parse(x.Tag.ToString()) == Properties.Settings.Default.MinutesBetweenDownloads);
            });
        }

        private void syncDuration_CheckedChanged(object sender, EventArgs e) {
            var item = (ToolStripMenuItem)sender;
            if (item.Checked) {
                Properties.Settings.Default.MinutesBetweenDownloads = int.Parse(item.Tag.ToString());
                backgroundDownloadTimer.Interval = Properties.Settings.Default.MinutesBetweenDownloads;
                enabledToolStripMenuItem_CheckedChanged(null, null);
            }
        }

        private void closeToTrayToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.CloseToTray = closeToTrayToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void showMainForm(object sender, EventArgs e) {
            ShowWindow();
        }

        private void menuNewFolder_Click(object sender, EventArgs e) {
            createNewDirectory();
        }
    }
}