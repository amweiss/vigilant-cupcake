﻿using Fragments;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.SubForms;


namespace VigilantCupcake {
    public partial class MainForm : Form {

        private FragmentList _loadedFragments = new FragmentList();
        private Fragment _selectedFragment = null;
        private Fragment _newHostsFile = new Fragment() { IsHostsFile = true };

        private ActualHostsFile _currentHostsForm = new ActualHostsFile();
        private int _pendingDownloads = 0;

        public MainForm() {
            InitializeComponent();

            mergeHostsEntriesToolStripMenuItem.Visible = false;

            saveOnProgramStartToolStripMenuItem.Checked = Properties.Settings.Default.AutoSaveOnStartup; //TODO: this is bound, should not be needed
            mergeHostsEntriesToolStripMenuItem.Checked = Properties.Settings.Default.MergeHostsEntries; //TODO: this is bound, should not be needed
            currentFragmentView.TextChanged += View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged;
            hostsFileView.TextChanged += View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged;
        }

        private void exit_Click(object sender, EventArgs e) {
            Close();
        }

        private void save_Click(object sender, EventArgs e) {
            saveAll();
        }

        private void saveAll() {
            if (_pendingDownloads > 0) {
                var backgroundSave = new TaskFactory().StartNew(() => {
                    while (_pendingDownloads > 0) {
                        System.Threading.Thread.Sleep(1000);
                    }
                    doSaveAll();
                });
            } else {
                doSaveAll();
            }
        }

        private void doSaveAll() {
            if (fragmentListView.SelectedRows.Count > 0) {
                try {
                    _loadedFragments.ToList().ForEach(x => x.save());
                } catch (Exception e) {
                    MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (selectedFragmentLabel.InvokeRequired) {
                    selectedFragmentLabel.Invoke((MethodInvoker)(() => { selectedFragmentLabel.Text = "Selected Fragment" + ((_selectedFragment.Dirty) ? "*" : string.Empty); }));
                } else {
                    selectedFragmentLabel.Text = "Selected Fragment" + ((_selectedFragment.Dirty) ? "*" : string.Empty);
                }
            }

            try {
                _newHostsFile.save();
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (newHostsLabel.InvokeRequired) {
                newHostsLabel.Invoke((MethodInvoker)(() => { newHostsLabel.Text = "New Hosts" + ((_newHostsFile.Dirty) ? "*" : string.Empty); }));
            } else {
                newHostsLabel.Text = "New Hosts" + ((_newHostsFile.Dirty) ? "*" : string.Empty);
            }

            if (fragmentListView.InvokeRequired) {
                fragmentListView.Invoke((MethodInvoker)(() => { fragmentListView.Refresh(); }));
            } else {
                fragmentListView.Refresh();
            }

            OS_Utils.DnsUtil.FlushDns();
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
            if (_loadedFragments != null && _loadedFragments.Count > 0)
                Properties.Settings.Default.SelectedFiles.AddRange(_loadedFragments.Where(x => x.Enabled).Select(x => x.Name).ToArray());
            Properties.Settings.Default.Save();
        }

        private void loadFragments() {
            _loadedFragments.loadFromDirectory(OS_Utils.LocalFiles.BaseDirectory);
            if (_loadedFragments.Count == 0) _loadedFragments.Add(new Fragment());
            _loadedFragments.ToList().ForEach(x => { x.ContentsDownloaded += fragment_ContentsDownloaded; x.DownloadStarting += fragment_DownloadStarting; x.PropertyChanged += fragmentPropertyChanged; });
            hostsFileBindingSource.DataSource = _newHostsFile;
            fragmentListBindingSource.DataSource = _loadedFragments;
        }

        private void fragment_DownloadStarting(object sender, EventArgs e) {
            _pendingDownloads++;
        }

        private void fragment_ContentsDownloaded(object sender, EventArgs e) {
            _pendingDownloads--;
            var fragment = (Fragment)sender;
            if (fragment == _selectedFragment) {
                updateCurrentFragmentView();
            } else if (fragment.Enabled) {
                updateHostsFileView();
            }
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (_loadedFragments != null) {

                _loadedFragments.Where(x => x.Enabled).ToList().ForEach(y => text.Add(y.FileContents));

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
                newHostsLabel.Text = "New Hosts" + ((_newHostsFile.Dirty) ? "*" : string.Empty);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            savePreferences();
            OS_Utils.DnsUtil.FlushDns();
        }

        private void fragmentListView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (fragmentListView.Columns[e.ColumnIndex].DataPropertyName.Equals("Enabled"))
                updateHostsFileView();
        }

        private void createNewFragment() {
            var fragment = new Fragment();

            fragment.ContentsDownloaded += fragment_ContentsDownloaded;
            fragment.DownloadStarting += fragment_DownloadStarting;
            fragment.PropertyChanged += fragmentPropertyChanged;

            _loadedFragments.Add(fragment);
            fragmentListView.CurrentCell = fragmentListView.Rows[_loadedFragments.Count - 1].Cells[1];
            fragmentListView.BeginEdit(true);
        }

        private void fragmentListView_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (fragmentListView.CurrentCell is DataGridViewCheckBoxCell) {
                fragmentListView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void fragmentListView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            if (e.StateChanged == DataGridViewElementStates.Displayed) {
                currentFragmentView.Enabled = (_loadedFragments.Count > 0);
                remoteUrlView.Enabled = (_loadedFragments.Count > 0);
            } else if (e.StateChanged == DataGridViewElementStates.Selected) {
                if (fragmentListView.SelectedRows.Count == 0 || fragmentListView.SelectedRows[0].DataBoundItem == null) {
                    _selectedFragment = null;
                    return;
                }
                _selectedFragment = ((Fragment)fragmentListView.SelectedRows[0].DataBoundItem);
                selectedFragmentBindingSource.DataSource = _selectedFragment;
                updateCurrentFragmentView();
            }
        }

        private void remoteUrlView_Validated(object sender, EventArgs e) {
            updateCurrentFragmentView();
        }

        private void updateCurrentFragmentView() {
            currentFragmentView.ReadOnly = !string.IsNullOrEmpty(_selectedFragment.RemoteLocation);
            currentFragmentView.BackColor = (currentFragmentView.ReadOnly) ? SystemColors.Control : Color.White;
            fragmentListView.Refresh();
            selectedFragmentLabel.Text = "Selected Fragment" + ((_selectedFragment.Dirty) ? "*" : string.Empty);
        }

        private void viewCurrentHostsToolStripMenuItem_Click(object sender, EventArgs e) {
            _currentHostsForm.ShowDialog();
        }

        private void fragmentListView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            var fragmentToDelete = _loadedFragments[e.Row.Index];
            if (confirmAndDelete(fragmentToDelete) == DialogResult.No)
                e.Cancel = true;
        }

        private void fragmentListContextMenuDelete_Click(object sender, EventArgs e) {
            if (confirmAndDelete(_selectedFragment) == DialogResult.Yes) {
                _loadedFragments.Remove(_selectedFragment);
            }
        }

        private DialogResult confirmAndDelete(Fragment fragment) {
            DialogResult result = MessageBox.Show("Delete " + fragment.Name + "?", "Delete Fragment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                fragment.delete();

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
            if (_pendingDownloads > 0) {
                DialogResult result = MessageBox.Show("There are still downloads pending, do you really want to exit?", "Downloads Pending", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
            if (!e.Cancel && (_loadedFragments.Any(x => x.Dirty) || _newHostsFile.Dirty)) {
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

        private void fragmentListView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.RowIndex != _loadedFragments.Count && fragmentListView.SelectedRows.Contains(fragmentListView.Rows[e.RowIndex])) {
                fragmentListView.ContextMenuStrip = fragmentListContextMenu;
            } else {
                fragmentListView.ContextMenuStrip = null;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            createNewFragment();
        }

        private void fragmentListView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (fragmentListView.Columns[e.ColumnIndex].DataPropertyName.Equals("Name") && string.IsNullOrWhiteSpace(e.FormattedValue.ToString())) {
                MessageBox.Show("Fragment name cannot be blank", "Name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void remoteUrlView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                //_selectedFragment.RemoteLocation = remoteUrlView.Text;
                updateCurrentFragmentView();
                e.Handled = true;
            }
        }

        private void fragmentListView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (fragmentListView.Columns[e.ColumnIndex].DataPropertyName.Equals("Dirty")) {
                e.Value = ((bool)e.Value) ? "*" : string.Empty;
                e.FormattingApplied = true;
            }
        }

        private void fragmentPropertyChanged(object sender, PropertyChangedEventArgs e) {
            var fragment = (Fragment)sender;
            if (e.PropertyName == "FileContents" && fragment.Enabled) {
                updateHostsFileView();
            }
        }

        private void fragmentListContextMenuRename_Click(object sender, EventArgs e) {
            fragmentListView.CurrentCell = fragmentListView.SelectedRows[0].Cells[1];
            fragmentListView.BeginEdit(true);
        }
    }
}
