﻿namespace VigilantCupcake {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.fragmentListView = new System.Windows.Forms.DataGridView();
            this.Dirty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.currentFragmentView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.selectedFragmentLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.remoteUrlView = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.newHostsLabel = new System.Windows.Forms.Label();
            this.hostsFileView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOnProgramStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeHostsEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flushDNSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCurrentHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fragmentListContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fragmentListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectedFragmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hostsFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFragmentView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.fragmentListContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFragmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1428, 792);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(1428, 816);
            this.toolStripContainer2.TabIndex = 4;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1428, 792);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.fragmentListView, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(220, 792);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // fragmentListView
            // 
            this.fragmentListView.AllowUserToAddRows = false;
            this.fragmentListView.AllowUserToResizeColumns = false;
            this.fragmentListView.AllowUserToResizeRows = false;
            this.fragmentListView.AutoGenerateColumns = false;
            this.fragmentListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fragmentListView.ColumnHeadersVisible = false;
            this.fragmentListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.Dirty});
            this.fragmentListView.DataSource = this.fragmentListBindingSource;
            this.fragmentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentListView.Location = new System.Drawing.Point(3, 23);
            this.fragmentListView.MultiSelect = false;
            this.fragmentListView.Name = "fragmentListView";
            this.fragmentListView.RowHeadersVisible = false;
            this.fragmentListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fragmentListView.Size = new System.Drawing.Size(214, 766);
            this.fragmentListView.TabIndex = 1;
            this.fragmentListView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.fragmentListView_CellFormatting);
            this.fragmentListView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.fragmentListView_CellMouseDown);
            this.fragmentListView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.fragmentListView_CellValidating);
            this.fragmentListView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.fragmentListView_CellValueChanged);
            this.fragmentListView.CurrentCellDirtyStateChanged += new System.EventHandler(this.fragmentListView_CurrentCellDirtyStateChanged);
            this.fragmentListView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.fragmentListView_RowStateChanged);
            this.fragmentListView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.fragmentListView_UserDeletingRow);
            // 
            // Dirty
            // 
            this.Dirty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dirty.DataPropertyName = "Dirty";
            this.Dirty.HeaderText = "Dirty";
            this.Dirty.Name = "Dirty";
            this.Dirty.ReadOnly = true;
            this.Dirty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dirty.Width = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fragment List";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(1204, 792);
            this.splitContainer2.SplitterDistance = 600;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.currentFragmentView, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.selectedFragmentLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(600, 792);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // currentFragmentView
            // 
            this.currentFragmentView.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.currentFragmentView.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.currentFragmentView.BackBrush = null;
            this.currentFragmentView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentFragmentView.CharHeight = 14;
            this.currentFragmentView.CharWidth = 8;
            this.currentFragmentView.CommentPrefix = "#";
            this.currentFragmentView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.currentFragmentView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectedFragmentBindingSource, "FileContents", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.currentFragmentView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.currentFragmentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentFragmentView.IsReplaceMode = false;
            this.currentFragmentView.Location = new System.Drawing.Point(3, 49);
            this.currentFragmentView.Name = "currentFragmentView";
            this.currentFragmentView.Paddings = new System.Windows.Forms.Padding(0);
            this.currentFragmentView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.currentFragmentView.Size = new System.Drawing.Size(594, 740);
            this.currentFragmentView.TabIndex = 2;
            this.currentFragmentView.Zoom = 100;
            // 
            // selectedFragmentLabel
            // 
            this.selectedFragmentLabel.AutoSize = true;
            this.selectedFragmentLabel.Location = new System.Drawing.Point(3, 0);
            this.selectedFragmentLabel.Name = "selectedFragmentLabel";
            this.selectedFragmentLabel.Size = new System.Drawing.Size(96, 13);
            this.selectedFragmentLabel.TabIndex = 0;
            this.selectedFragmentLabel.Text = "Selected Fragment";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.17962F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.82037F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.remoteUrlView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 20);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remote URL:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remoteUrlView
            // 
            this.remoteUrlView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectedFragmentBindingSource, "RemoteLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.remoteUrlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteUrlView.Location = new System.Drawing.Point(128, 3);
            this.remoteUrlView.Name = "remoteUrlView";
            this.remoteUrlView.Size = new System.Drawing.Size(463, 20);
            this.remoteUrlView.TabIndex = 1;
            this.remoteUrlView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.remoteUrlView_KeyPress);
            this.remoteUrlView.Validated += new System.EventHandler(this.remoteUrlView_Validated);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.newHostsLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.hostsFileView, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(600, 792);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // newHostsLabel
            // 
            this.newHostsLabel.AutoSize = true;
            this.newHostsLabel.Location = new System.Drawing.Point(3, 0);
            this.newHostsLabel.Name = "newHostsLabel";
            this.newHostsLabel.Size = new System.Drawing.Size(59, 13);
            this.newHostsLabel.TabIndex = 1;
            this.newHostsLabel.Text = "New Hosts";
            // 
            // hostsFileView
            // 
            this.hostsFileView.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.hostsFileView.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.hostsFileView.BackBrush = null;
            this.hostsFileView.BackColor = System.Drawing.SystemColors.Control;
            this.hostsFileView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostsFileView.CharHeight = 14;
            this.hostsFileView.CharWidth = 8;
            this.hostsFileView.CommentPrefix = "#";
            this.hostsFileView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hostsFileView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hostsFileBindingSource, "FileContents", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hostsFileView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hostsFileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsFileView.IsReplaceMode = false;
            this.hostsFileView.Location = new System.Drawing.Point(3, 49);
            this.hostsFileView.Name = "hostsFileView";
            this.hostsFileView.Paddings = new System.Windows.Forms.Padding(0);
            this.hostsFileView.ReadOnly = true;
            this.hostsFileView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.hostsFileView.Size = new System.Drawing.Size(594, 740);
            this.hostsFileView.TabIndex = 2;
            this.hostsFileView.Zoom = 100;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1428, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.saveToolStripMenuItem.Text = "&Save and Flush DNS";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(215, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Checked = global::VigilantCupcake.Properties.Settings.Default.AutoSaveOnStartup;
            this.optionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOnProgramStartToolStripMenuItem,
            this.mergeHostsEntriesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // saveOnProgramStartToolStripMenuItem
            // 
            this.saveOnProgramStartToolStripMenuItem.Checked = global::VigilantCupcake.Properties.Settings.Default.AutoSaveOnStartup;
            this.saveOnProgramStartToolStripMenuItem.CheckOnClick = true;
            this.saveOnProgramStartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveOnProgramStartToolStripMenuItem.Name = "saveOnProgramStartToolStripMenuItem";
            this.saveOnProgramStartToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveOnProgramStartToolStripMenuItem.Text = "&Save on Program Start";
            this.saveOnProgramStartToolStripMenuItem.CheckedChanged += new System.EventHandler(this.saveOnProgramStartToolStripMenuItem_CheckedChanged);
            // 
            // mergeHostsEntriesToolStripMenuItem
            // 
            this.mergeHostsEntriesToolStripMenuItem.Checked = global::VigilantCupcake.Properties.Settings.Default.MergeHostsEntries;
            this.mergeHostsEntriesToolStripMenuItem.CheckOnClick = true;
            this.mergeHostsEntriesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mergeHostsEntriesToolStripMenuItem.Name = "mergeHostsEntriesToolStripMenuItem";
            this.mergeHostsEntriesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.mergeHostsEntriesToolStripMenuItem.Text = "&Merge Hosts Entries";
            this.mergeHostsEntriesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.mergeHostsEntriesToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flushDNSToolStripMenuItem,
            this.viewCurrentHostsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // flushDNSToolStripMenuItem
            // 
            this.flushDNSToolStripMenuItem.Name = "flushDNSToolStripMenuItem";
            this.flushDNSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.flushDNSToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.flushDNSToolStripMenuItem.Text = "&Flush DNS";
            this.flushDNSToolStripMenuItem.Click += new System.EventHandler(this.flushDns_Click);
            // 
            // viewCurrentHostsToolStripMenuItem
            // 
            this.viewCurrentHostsToolStripMenuItem.Name = "viewCurrentHostsToolStripMenuItem";
            this.viewCurrentHostsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.viewCurrentHostsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.viewCurrentHostsToolStripMenuItem.Text = "&View Current Hosts";
            this.viewCurrentHostsToolStripMenuItem.Click += new System.EventHandler(this.viewCurrentHostsToolStripMenuItem_Click);
            // 
            // fragmentListContextMenu
            // 
            this.fragmentListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fragmentListContextMenuDelete,
            this.fragmentListContextMenuRename});
            this.fragmentListContextMenu.Name = "fragmentListContextMenu";
            this.fragmentListContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // fragmentListContextMenuDelete
            // 
            this.fragmentListContextMenuDelete.Name = "fragmentListContextMenuDelete";
            this.fragmentListContextMenuDelete.Size = new System.Drawing.Size(152, 22);
            this.fragmentListContextMenuDelete.Text = "Delete";
            this.fragmentListContextMenuDelete.Click += new System.EventHandler(this.fragmentListContextMenuDelete_Click);
            // 
            // fragmentListContextMenuRename
            // 
            this.fragmentListContextMenuRename.Name = "fragmentListContextMenuRename";
            this.fragmentListContextMenuRename.Size = new System.Drawing.Size(152, 22);
            this.fragmentListContextMenuRename.Text = "Rename";
            this.fragmentListContextMenuRename.Click += new System.EventHandler(this.fragmentListContextMenuRename_Click);
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.enabledDataGridViewCheckBoxColumn.Width = 20;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // fragmentListBindingSource
            // 
            this.fragmentListBindingSource.DataSource = typeof(VigilantCupcake.Models.FragmentList);
            // 
            // selectedFragmentBindingSource
            // 
            this.selectedFragmentBindingSource.DataSource = typeof(VigilantCupcake.Models.Fragment);
            // 
            // hostsFileBindingSource
            // 
            this.hostsFileBindingSource.DataSource = typeof(VigilantCupcake.Models.Fragment);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 816);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Vigilant Cupcake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentListView)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFragmentView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.fragmentListContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fragmentListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFragmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label newHostsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label selectedFragmentLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView fragmentListView;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flushDNSToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox remoteUrlView;
        private System.Windows.Forms.ToolStripMenuItem viewCurrentHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOnProgramStartToolStripMenuItem;
        private FastColoredTextBoxNS.FastColoredTextBox currentFragmentView;
        private FastColoredTextBoxNS.FastColoredTextBox hostsFileView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mergeHostsEntriesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip fragmentListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuRename;
        private System.Windows.Forms.BindingSource fragmentListBindingSource;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirty;
        private System.Windows.Forms.BindingSource selectedFragmentBindingSource;
        private System.Windows.Forms.BindingSource hostsFileBindingSource;

    }
}

