using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VigilantCupcake.Models;


namespace VigilantCupcake {
    public partial class MainForm : Form {

        private List<Fragment> _loadedFragments = null;

        public MainForm() {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e) {
            Close();
        }

        private void save_Click(object sender, EventArgs e) {
            if (fragmentGrid.SelectedRows.Count > 0)
                currentFragmentView.SaveFile(((Fragment)fragmentGrid.SelectedRows[0].DataBoundItem).FullPath, RichTextBoxStreamType.PlainText);

            updateHostsFileView();

            hostsFileView.SaveFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText); //TODO: frag

            OS_Utils.DnsUtil.FlushDns();
        }

        private void flushDns_Click(object sender, EventArgs e) {
            OS_Utils.DnsUtil.FlushDns();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            loadFragments();
            updateHostsFileView();
        }

        private void savePreferences() {
            Properties.Settings.Default.SelectedFiles = new StringCollection();
            Properties.Settings.Default.SelectedFiles.AddRange(_loadedFragments.Where(x => x.Enabled).Select(x => x.Name).ToArray());
            Properties.Settings.Default.Save();
        }

        private void loadFragments() {
            var files = Directory.GetFiles(OS_Utils.LocalFiles.BaseDirectory);
            var names = from file in files
                        select new Fragment() {
                            Name = new FileInfo(file).Name,
                            Enabled = Properties.Settings.Default.SelectedFiles.Contains(new FileInfo(file).Name)
                        };

            _loadedFragments = names.ToList();
            fragmentBindingSource1.DataSource = _loadedFragments;
        }

        private void updateHostsFileView() {
            var text = new List<string>();

            if (_loadedFragments != null) {
                foreach (var item in _loadedFragments.Where(x => x.Enabled)) {
                    if ((File.GetAttributes(item.FullPath) & FileAttributes.Directory) == 0) {
                        text.Add(File.ReadAllText(item.FullPath));
                    }
                }

                hostsFileView.Text = (text.Count() > 0) ? text.Aggregate((agg, val) => agg + Environment.NewLine + val) : string.Empty;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            savePreferences();
        }

        private void fragmentGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            switch (e.ColumnIndex) {
                case 0:
                    updateHostsFileView();
                    break;
                case 1:
                    if (_loadedFragments != null && e.RowIndex == _loadedFragments.Count - 1) {
                        File.Create(_loadedFragments.Last().FullPath);
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

            if (fragmentGrid.SelectedRows.Count == 0 || fragmentGrid.SelectedRows[0].DataBoundItem == null) return;
            currentFragmentView.LoadFile(((Fragment)fragmentGrid.SelectedRows[0].DataBoundItem).FullPath, RichTextBoxStreamType.PlainText);
        }

        private void fragmentGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == 1 && e.RowIndex < _loadedFragments.Count - 1) {
                var newValue = e.FormattedValue.ToString();
                File.Move(_loadedFragments[e.RowIndex].FullPath, Path.Combine(OS_Utils.LocalFiles.BaseDirectory, newValue));
            }
        }

        private void currentFragmentView_TextChanged(object sender, EventArgs e) {
            if (fragmentGrid.SelectedRows.Count == 0 || fragmentGrid.SelectedRows[0].DataBoundItem == null) return;
        }
    }
}
