using Fragments;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VigilantCupcake.Models;
using VigilantCupcake.SubForms;


namespace VigilantCupcake {
    public partial class MainForm : Form {

        private List<Fragment> _loadedFragments = null;
        private Fragment _selectedFragment = null;

        private ActualHostsFile _currentHostsForm = new ActualHostsFile();

        public MainForm() {
            InitializeComponent();

            //TODO: Make save on start work with background loading.
            saveOnProgramStartToolStripMenuItem.Visible = false;

            saveOnProgramStartToolStripMenuItem.Checked = Properties.Settings.Default.AutoSaveOnStartup; //TODO: this is bound, should not be needed
            mergeHostsEntriesToolStripMenuItem.Checked = Properties.Settings.Default.MergeHostsEntries; //TODO: this is bound, should not be needed
            currentFragmentView.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged);
            hostsFileView.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(View_Utils.FastColoredTextBoxUtil.hostsView_TextChanged);
        }

        private void exit_Click(object sender, EventArgs e) {
            Close();
        }

        private void save_Click(object sender, EventArgs e) {
            saveAll();
        }

        private void saveAll() {
            if (fragmentGrid.SelectedRows.Count > 0) {
                _selectedFragment.RemoteLocation = remoteUrlView.Text;
                if (!currentFragmentView.ReadOnly)
                    _selectedFragment.FileContents = currentFragmentView.Text;
                _selectedFragment.save();
                updateCurrentFragmentView();
            }

            updateHostsFileView();
            var hostsFileFree = OS_Utils.LocalFiles.WaitForFile(OS_Utils.HostsFileUtil.CurrentHostsFile);
            if (hostsFileFree)
                File.WriteAllText(OS_Utils.HostsFileUtil.CurrentHostsFile, hostsFileView.Text);
            else
                MessageBox.Show("There was an error saving the hosts file", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            OS_Utils.DnsUtil.FlushDns();
        }

        private void flushDns_Click(object sender, EventArgs e) {
            OS_Utils.DnsUtil.FlushDns();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            loadFragments();
            updateHostsFileView();
            if (Properties.Settings.Default.AutoSaveOnStartup) saveAll();
        }

        private void savePreferences() {
            Properties.Settings.Default.SelectedFiles = new StringCollection();
            Properties.Settings.Default.SelectedFiles.AddRange(_loadedFragments.Where(x => x.Enabled).Select(x => x.Name).ToArray());
            Properties.Settings.Default.Save();
        }

        private void loadFragments() {
            if (!File.Exists(OS_Utils.LocalFiles.BaseDirectory))
                Directory.CreateDirectory(OS_Utils.LocalFiles.BaseDirectory);
            var files = Directory.GetFiles(OS_Utils.LocalFiles.BaseDirectory);
            if (files.Count() > 0) {
                var names = from file in files
                            select new Fragment() {
                                Name = new FileInfo(file).Name,
                                Enabled = Properties.Settings.Default.SelectedFiles != null && Properties.Settings.Default.SelectedFiles.Contains(new FileInfo(file).Name)
                            };

                _loadedFragments = names.ToList();
            } else {
                _loadedFragments = new List<Fragment>();
            }
            fragmentBindingSource1.DataSource = _loadedFragments;

            _loadedFragments.ForEach(x => x.ContentsDownloaded += fragment_ContentsDownloaded);
        }

        private void fragment_ContentsDownloaded(object sender, EventArgs e) {
            var fragment = (Fragment)sender;
            if (fragment == _selectedFragment) {
                remoteUrlView.Text = _selectedFragment.RemoteLocation;
                updateCurrentFragmentView();
            }
            updateHostsFileView();
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (_loadedFragments != null) {
                foreach (var item in _loadedFragments.Where(x => x.Enabled)) {
                    if ((File.GetAttributes(item.FullPath) & FileAttributes.Directory) == 0) {
                        text.Add(item.FileContents);
                    }
                }

                //TODO: More efficient????
                var newHosts = string.Empty;
                if (Properties.Settings.Default.MergeHostsEntries) {
                    var combiner = new FragmentCombiner();
                    var blob = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                    var result = combiner.generateOutput(blob.Split(Environment.NewLine.ToArray()));
                    newHosts = (result.Count() > 0) ? result.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                } else {
                    newHosts = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
                }
                hostsFileView.Text = newHosts;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            savePreferences();
            OS_Utils.DnsUtil.FlushDns();
        }

        private void fragmentGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            switch (e.ColumnIndex) {
                case 0:
                    updateHostsFileView();
                    break;
                case 1:
                    if (_loadedFragments != null && e.RowIndex == _loadedFragments.Count - 1) {
                        using (File.Create(_loadedFragments.Last().FullPath)) {
                            _loadedFragments.Last().ContentsDownloaded += fragment_ContentsDownloaded;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void fragmentGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (fragmentGrid.CurrentCell is DataGridViewCheckBoxCell) {
                fragmentGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void fragmentGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            if (fragmentGrid.SelectedRows.Count == 0 || fragmentGrid.SelectedRows[0].DataBoundItem == null) {
                _selectedFragment = null;
                return;
            }
            _selectedFragment = ((Fragment)fragmentGrid.SelectedRows[0].DataBoundItem);
            remoteUrlView.Text = _selectedFragment.RemoteLocation;
            updateCurrentFragmentView();
        }

        private void fragmentGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == 1 && e.RowIndex < _loadedFragments.Count - 1) {
                var oldValue = _loadedFragments[e.RowIndex].Name;
                var newValue = e.FormattedValue.ToString();
                if (!oldValue.Equals(newValue)) {
                    File.Move(_loadedFragments[e.RowIndex].FullPath, Path.Combine(OS_Utils.LocalFiles.BaseDirectory, newValue));
                }
            }
        }

        private void remoteUrlView_Validated(object sender, EventArgs e) {
            updateCurrentFragmentView();
        }

        private void updateCurrentFragmentView() {
            currentFragmentView.Text = _selectedFragment.FileContents;
            remoteUrlView.Text = _selectedFragment.RemoteLocation;
            currentFragmentView.ReadOnly = !string.IsNullOrEmpty(_selectedFragment.RemoteLocation);
            currentFragmentView.BackColor = (currentFragmentView.ReadOnly) ? SystemColors.Control : Color.White;
        }

        private void remoteUrlView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                _selectedFragment.RemoteLocation = remoteUrlView.Text;
                updateCurrentFragmentView();
                e.Handled = true;
            }
        }

        private void viewCurrentHostsToolStripMenuItem_Click(object sender, EventArgs e) {
            _currentHostsForm.ShowDialog();
        }

        private void fragmentGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            File.Delete(_loadedFragments[e.Row.Index].FullPath);
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
    }
}
