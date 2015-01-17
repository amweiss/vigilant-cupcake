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
            //hostsFileView.LoadFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText); //TODO: frag
        }

        private void exit_Click(object sender, EventArgs e) {
            Close();
        }

        private void save_Click(object sender, EventArgs e) {
            hostsFileView.SaveFile(OS_Utils.HostsFileUtil.CurrentHostsFile, RichTextBoxStreamType.PlainText); //TODO: frag
            if (fragmentGrid.SelectedRows.Count > 0)
                currentFragmentView.SaveFile(Path.Combine(OS_Utils.LocalFiles.BaseDirectory, ((Fragment)fragmentGrid.SelectedRows[0].DataBoundItem).Name), RichTextBoxStreamType.PlainText);

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
                    var fullPath = Path.Combine(OS_Utils.LocalFiles.BaseDirectory, item.Name);
                    if ((File.GetAttributes(fullPath) & FileAttributes.Directory) == 0) {
                        text.Add(File.ReadAllText(fullPath));
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
                        File.Create(Path.Combine(OS_Utils.LocalFiles.BaseDirectory,_loadedFragments.Last().Name));
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
            var fullpath = Path.Combine(OS_Utils.LocalFiles.BaseDirectoryRoot, Path.Combine(OS_Utils.LocalFiles.BaseDirectory, ((Fragment)fragmentGrid.SelectedRows[0].DataBoundItem).Name));
            currentFragmentView.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
        }

        private void fragmentGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == 1 && e.RowIndex < _loadedFragments.Count - 1) {
                var oldValue = _loadedFragments[e.RowIndex].Name;
                var newValue = e.FormattedValue.ToString();
                File.Move(Path.Combine(OS_Utils.LocalFiles.BaseDirectory, oldValue), Path.Combine(OS_Utils.LocalFiles.BaseDirectory, newValue));
            }
        }
    }
}
