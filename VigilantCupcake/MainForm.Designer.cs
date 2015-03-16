namespace VigilantCupcake {
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
            this.fragmentTreeView = new Aga.Controls.Tree.TreeViewAdv();
            this.fragmentListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.importRemoteFragmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFragmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fragmentListContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeCheckBox1 = new Aga.Controls.Tree.NodeControls.NodeCheckBox();
            this.nodeStateIcon1 = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fragmentFilter = new System.Windows.Forms.RichTextBox();
            this.currentFragmentView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.selectedFragmentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.remoteUrlView = new System.Windows.Forms.RichTextBox();
            this.newHostsLabel = new System.Windows.Forms.Label();
            this.hostsFileView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.newHostFilterBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOnProgramStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newHostsAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncronizeFragmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.syncFiveMinutes = new System.Windows.Forms.ToolStripMenuItem();
            this.syncFifteenMinutes = new System.Windows.Forms.ToolStripMenuItem();
            this.syncThirtyMinutes = new System.Windows.Forms.ToolStripMenuItem();
            this.syncSixtyMinutes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flushDNSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCurrentHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundDownloadTimer = new System.Windows.Forms.Timer(this.components);
            this.updateCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.mainBodyTable = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.downloadingLabel = new System.Windows.Forms.Label();
            this.selectedFragmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hostsFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.fragmentListContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFragmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.notifyIconMenu.SuspendLayout();
            this.mainBodyTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFragmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.mainBodyTable);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1428, 765);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(1428, 789);
            this.toolStripContainer2.TabIndex = 4;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // fragmentTreeView
            // 
            this.fragmentTreeView.AllowDrop = true;
            this.fragmentTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.mainBodyTable.SetColumnSpan(this.fragmentTreeView, 2);
            this.fragmentTreeView.ContextMenuStrip = this.fragmentListContextMenu;
            this.fragmentTreeView.DefaultToolTipProvider = null;
            this.fragmentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentTreeView.DragDropMarkColor = System.Drawing.Color.Black;
            this.fragmentTreeView.FullRowSelect = true;
            this.fragmentTreeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this.fragmentTreeView.Location = new System.Drawing.Point(3, 55);
            this.fragmentTreeView.Model = null;
            this.fragmentTreeView.Name = "fragmentTreeView";
            this.fragmentTreeView.NodeControls.Add(this.nodeCheckBox1);
            this.fragmentTreeView.NodeControls.Add(this.nodeStateIcon1);
            this.fragmentTreeView.NodeControls.Add(this.nodeTextBox1);
            this.fragmentTreeView.SelectedNode = null;
            this.fragmentTreeView.Size = new System.Drawing.Size(192, 707);
            this.fragmentTreeView.TabIndex = 3;
            this.fragmentTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.triStateTreeView1_ItemDrag);
            this.fragmentTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.triStateTreeView1_DragDrop);
            this.fragmentTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.triStateTreeView1_DragOver);
            // 
            // fragmentListContextMenu
            // 
            this.fragmentListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.fragmentListContextMenuNewFolder,
            this.toolStripSeparator5,
            this.importRemoteFragmentsToolStripMenuItem,
            this.downloadFragmentToolStripMenuItem,
            this.fragmentListContextMenuSeparator1,
            this.fragmentListContextMenuDelete,
            this.fragmentListContextMenuRename});
            this.fragmentListContextMenu.Name = "fragmentListContextMenu";
            this.fragmentListContextMenu.Size = new System.Drawing.Size(214, 148);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::VigilantCupcake.Properties.Resources.NewRequest_8796;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem3.Text = "New Fragment";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.menuNewFragment_Click);
            // 
            // fragmentListContextMenuNewFolder
            // 
            this.fragmentListContextMenuNewFolder.Image = global::VigilantCupcake.Properties.Resources.NewSolutionFolder_6289;
            this.fragmentListContextMenuNewFolder.Name = "fragmentListContextMenuNewFolder";
            this.fragmentListContextMenuNewFolder.Size = new System.Drawing.Size(213, 22);
            this.fragmentListContextMenuNewFolder.Text = "New Folder";
            this.fragmentListContextMenuNewFolder.Click += new System.EventHandler(this.menuNewFolder_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
            // 
            // importRemoteFragmentsToolStripMenuItem
            // 
            this.importRemoteFragmentsToolStripMenuItem.Image = global::VigilantCupcake.Properties.Resources.ListMembers_2407;
            this.importRemoteFragmentsToolStripMenuItem.Name = "importRemoteFragmentsToolStripMenuItem";
            this.importRemoteFragmentsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.importRemoteFragmentsToolStripMenuItem.Text = "Import Remote Fragments";
            this.importRemoteFragmentsToolStripMenuItem.Click += new System.EventHandler(this.importRemoteFragmentsToolStripMenuItem_Click);
            // 
            // downloadFragmentToolStripMenuItem
            // 
            this.downloadFragmentToolStripMenuItem.Image = global::VigilantCupcake.Properties.Resources.FileDownload;
            this.downloadFragmentToolStripMenuItem.Name = "downloadFragmentToolStripMenuItem";
            this.downloadFragmentToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.downloadFragmentToolStripMenuItem.Text = "Download Fragment";
            this.downloadFragmentToolStripMenuItem.Click += new System.EventHandler(this.downloadFragmentToolStripMenuItem_Click);
            // 
            // fragmentListContextMenuSeparator1
            // 
            this.fragmentListContextMenuSeparator1.Name = "fragmentListContextMenuSeparator1";
            this.fragmentListContextMenuSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // fragmentListContextMenuDelete
            // 
            this.fragmentListContextMenuDelete.Image = global::VigilantCupcake.Properties.Resources.Clearallrequests_8816;
            this.fragmentListContextMenuDelete.Name = "fragmentListContextMenuDelete";
            this.fragmentListContextMenuDelete.Size = new System.Drawing.Size(213, 22);
            this.fragmentListContextMenuDelete.Text = "Delete";
            this.fragmentListContextMenuDelete.Click += new System.EventHandler(this.fragmentListContextMenuDelete_Click);
            // 
            // fragmentListContextMenuRename
            // 
            this.fragmentListContextMenuRename.Name = "fragmentListContextMenuRename";
            this.fragmentListContextMenuRename.Size = new System.Drawing.Size(213, 22);
            this.fragmentListContextMenuRename.Text = "Rename";
            this.fragmentListContextMenuRename.Click += new System.EventHandler(this.fragmentListContextMenuRename_Click);
            // 
            // nodeCheckBox1
            // 
            this.nodeCheckBox1.DataPropertyName = "CheckState";
            this.nodeCheckBox1.EditEnabled = true;
            this.nodeCheckBox1.LeftMargin = 0;
            this.nodeCheckBox1.ParentColumn = null;
            this.nodeCheckBox1.ThreeState = true;
            // 
            // nodeStateIcon1
            // 
            this.nodeStateIcon1.LeftMargin = 1;
            this.nodeStateIcon1.ParentColumn = null;
            this.nodeStateIcon1.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // nodeTextBox1
            // 
            this.nodeTextBox1.DataPropertyName = "Text";
            this.nodeTextBox1.EditEnabled = true;
            this.nodeTextBox1.IncrementalSearchEnabled = true;
            this.nodeTextBox1.LeftMargin = 3;
            this.nodeTextBox1.ParentColumn = null;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fragmentFilter
            // 
            this.fragmentFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fragmentFilter.DetectUrls = false;
            this.fragmentFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragmentFilter.Location = new System.Drawing.Point(83, 29);
            this.fragmentFilter.MaxLength = 0;
            this.fragmentFilter.Multiline = false;
            this.fragmentFilter.Name = "fragmentFilter";
            this.fragmentFilter.Size = new System.Drawing.Size(112, 20);
            this.fragmentFilter.TabIndex = 1;
            this.fragmentFilter.Text = "";
            this.fragmentFilter.TextChanged += new System.EventHandler(this.fragmentSearchTextChanged);
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
            this.mainBodyTable.SetColumnSpan(this.currentFragmentView, 2);
            this.currentFragmentView.CommentPrefix = "#";
            this.currentFragmentView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.currentFragmentView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectedFragmentBindingSource, "FileContents", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.currentFragmentView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.currentFragmentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentFragmentView.IsReplaceMode = false;
            this.currentFragmentView.Location = new System.Drawing.Point(201, 55);
            this.currentFragmentView.Name = "currentFragmentView";
            this.currentFragmentView.Paddings = new System.Windows.Forms.Padding(0);
            this.currentFragmentView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.currentFragmentView.Size = new System.Drawing.Size(608, 707);
            this.currentFragmentView.TabIndex = 2;
            this.currentFragmentView.Zoom = 100;
            // 
            // selectedFragmentLabel
            // 
            this.selectedFragmentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainBodyTable.SetColumnSpan(this.selectedFragmentLabel, 2);
            this.selectedFragmentLabel.Location = new System.Drawing.Point(201, 0);
            this.selectedFragmentLabel.Name = "selectedFragmentLabel";
            this.selectedFragmentLabel.Size = new System.Drawing.Size(608, 20);
            this.selectedFragmentLabel.TabIndex = 0;
            this.selectedFragmentLabel.Text = "Selected Fragment";
            this.selectedFragmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(201, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remote:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // remoteUrlView
            // 
            this.remoteUrlView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteUrlView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectedFragmentBindingSource, "RemoteLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.remoteUrlView.DetectUrls = false;
            this.remoteUrlView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remoteUrlView.Location = new System.Drawing.Point(281, 29);
            this.remoteUrlView.Multiline = false;
            this.remoteUrlView.Name = "remoteUrlView";
            this.remoteUrlView.Size = new System.Drawing.Size(528, 20);
            this.remoteUrlView.TabIndex = 1;
            this.remoteUrlView.Text = "";
            this.remoteUrlView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.remoteUrlView_KeyPress);
            this.remoteUrlView.Validated += new System.EventHandler(this.remoteUrlView_Validated);
            // 
            // newHostsLabel
            // 
            this.newHostsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainBodyTable.SetColumnSpan(this.newHostsLabel, 2);
            this.newHostsLabel.Location = new System.Drawing.Point(815, 0);
            this.newHostsLabel.Name = "newHostsLabel";
            this.newHostsLabel.Size = new System.Drawing.Size(610, 20);
            this.newHostsLabel.TabIndex = 1;
            this.newHostsLabel.Text = "New Hosts";
            this.newHostsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.mainBodyTable.SetColumnSpan(this.hostsFileView, 2);
            this.hostsFileView.CommentPrefix = "#";
            this.hostsFileView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hostsFileView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hostsFileBindingSource, "FileContents", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hostsFileView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hostsFileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsFileView.IsReplaceMode = false;
            this.hostsFileView.Location = new System.Drawing.Point(815, 55);
            this.hostsFileView.Name = "hostsFileView";
            this.hostsFileView.Paddings = new System.Windows.Forms.Padding(0);
            this.hostsFileView.ReadOnly = true;
            this.hostsFileView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.hostsFileView.Size = new System.Drawing.Size(610, 707);
            this.hostsFileView.TabIndex = 2;
            this.hostsFileView.Zoom = 100;
            // 
            // newHostFilterBox
            // 
            this.newHostFilterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newHostFilterBox.DetectUrls = false;
            this.newHostFilterBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newHostFilterBox.Location = new System.Drawing.Point(895, 30);
            this.newHostFilterBox.MaxLength = 0;
            this.newHostFilterBox.Multiline = false;
            this.newHostFilterBox.Name = "newHostFilterBox";
            this.newHostFilterBox.Size = new System.Drawing.Size(530, 18);
            this.newHostFilterBox.TabIndex = 0;
            this.newHostFilterBox.Text = "";
            this.newHostFilterBox.TextChanged += new System.EventHandler(this.newHostFilterBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(815, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exclude:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.updateNotification});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
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
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::VigilantCupcake.Properties.Resources.NewRequest_8796;
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.newToolStripMenuItem.Text = "&New Fragment";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.menuNewFragment_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::VigilantCupcake.Properties.Resources.NewSolutionFolder_6289;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItem4.Text = "New Folder";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.menuNewFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::VigilantCupcake.Properties.Resources.Save_6530;
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
            this.optionsToolStripMenuItem.Checked = true;
            this.optionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOnProgramStartToolStripMenuItem,
            this.newHostsAnalysisToolStripMenuItem,
            this.closeToTrayToolStripMenuItem,
            this.syncronizeFragmentsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // saveOnProgramStartToolStripMenuItem
            // 
            this.saveOnProgramStartToolStripMenuItem.Checked = true;
            this.saveOnProgramStartToolStripMenuItem.CheckOnClick = true;
            this.saveOnProgramStartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveOnProgramStartToolStripMenuItem.Name = "saveOnProgramStartToolStripMenuItem";
            this.saveOnProgramStartToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.saveOnProgramStartToolStripMenuItem.Text = "&Save on Program Start";
            this.saveOnProgramStartToolStripMenuItem.CheckedChanged += new System.EventHandler(this.saveOnProgramStartToolStripMenuItem_CheckedChanged);
            // 
            // newHostsAnalysisToolStripMenuItem
            // 
            this.newHostsAnalysisToolStripMenuItem.Checked = true;
            this.newHostsAnalysisToolStripMenuItem.CheckOnClick = true;
            this.newHostsAnalysisToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newHostsAnalysisToolStripMenuItem.Name = "newHostsAnalysisToolStripMenuItem";
            this.newHostsAnalysisToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.newHostsAnalysisToolStripMenuItem.Text = "&Enable New Hosts Analysis";
            this.newHostsAnalysisToolStripMenuItem.CheckedChanged += new System.EventHandler(this.newHostsAnalysisToolStripMenuItem_CheckedChanged);
            // 
            // closeToTrayToolStripMenuItem
            // 
            this.closeToTrayToolStripMenuItem.CheckOnClick = true;
            this.closeToTrayToolStripMenuItem.Name = "closeToTrayToolStripMenuItem";
            this.closeToTrayToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.closeToTrayToolStripMenuItem.Text = "Close to &Tray";
            this.closeToTrayToolStripMenuItem.CheckedChanged += new System.EventHandler(this.closeToTrayToolStripMenuItem_CheckedChanged);
            // 
            // syncronizeFragmentsToolStripMenuItem
            // 
            this.syncronizeFragmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncEnabledToolStripMenuItem,
            this.toolStripSeparator2,
            this.syncFiveMinutes,
            this.syncFifteenMinutes,
            this.syncThirtyMinutes,
            this.syncSixtyMinutes});
            this.syncronizeFragmentsToolStripMenuItem.Name = "syncronizeFragmentsToolStripMenuItem";
            this.syncronizeFragmentsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.syncronizeFragmentsToolStripMenuItem.Text = "Background Sync and Save";
            // 
            // syncEnabledToolStripMenuItem
            // 
            this.syncEnabledToolStripMenuItem.Checked = true;
            this.syncEnabledToolStripMenuItem.CheckOnClick = true;
            this.syncEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.syncEnabledToolStripMenuItem.Name = "syncEnabledToolStripMenuItem";
            this.syncEnabledToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.syncEnabledToolStripMenuItem.Text = "Enabled";
            this.syncEnabledToolStripMenuItem.CheckedChanged += new System.EventHandler(this.enabledToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // syncFiveMinutes
            // 
            this.syncFiveMinutes.CheckOnClick = true;
            this.syncFiveMinutes.Name = "syncFiveMinutes";
            this.syncFiveMinutes.Size = new System.Drawing.Size(163, 22);
            this.syncFiveMinutes.Tag = "300000";
            this.syncFiveMinutes.Text = "Every 5 Minutes";
            this.syncFiveMinutes.CheckedChanged += new System.EventHandler(this.syncDuration_CheckedChanged);
            // 
            // syncFifteenMinutes
            // 
            this.syncFifteenMinutes.CheckOnClick = true;
            this.syncFifteenMinutes.Name = "syncFifteenMinutes";
            this.syncFifteenMinutes.Size = new System.Drawing.Size(163, 22);
            this.syncFifteenMinutes.Tag = "900000";
            this.syncFifteenMinutes.Text = "Every 15 Minutes";
            this.syncFifteenMinutes.CheckedChanged += new System.EventHandler(this.syncDuration_CheckedChanged);
            // 
            // syncThirtyMinutes
            // 
            this.syncThirtyMinutes.CheckOnClick = true;
            this.syncThirtyMinutes.Name = "syncThirtyMinutes";
            this.syncThirtyMinutes.Size = new System.Drawing.Size(163, 22);
            this.syncThirtyMinutes.Tag = "1800000";
            this.syncThirtyMinutes.Text = "Every 30 Minutes";
            this.syncThirtyMinutes.CheckStateChanged += new System.EventHandler(this.syncDuration_CheckedChanged);
            // 
            // syncSixtyMinutes
            // 
            this.syncSixtyMinutes.Checked = true;
            this.syncSixtyMinutes.CheckOnClick = true;
            this.syncSixtyMinutes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.syncSixtyMinutes.Name = "syncSixtyMinutes";
            this.syncSixtyMinutes.Size = new System.Drawing.Size(163, 22);
            this.syncSixtyMinutes.Tag = "3600000";
            this.syncSixtyMinutes.Text = "Every 60 Minutes";
            this.syncSixtyMinutes.CheckStateChanged += new System.EventHandler(this.syncDuration_CheckedChanged);
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
            this.flushDNSToolStripMenuItem.Image = global::VigilantCupcake.Properties.Resources.Restart_6322;
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // updateNotification
            // 
            this.updateNotification.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.updateNotification.Image = global::VigilantCupcake.Properties.Resources.Activity_16xLG;
            this.updateNotification.Name = "updateNotification";
            this.updateNotification.Size = new System.Drawing.Size(282, 20);
            this.updateNotification.Text = "Update will be applied on next application start";
            this.updateNotification.Visible = false;
            this.updateNotification.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Vigilant Cupcake";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.showMainForm);
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.notifyIconMenu.Name = "notifyIconMenu";
            this.notifyIconMenu.Size = new System.Drawing.Size(129, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.showMainForm);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(125, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::VigilantCupcake.Properties.Resources.Restart_6322;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "Flush DNS";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.flushDns_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem1.Text = "E&xit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.exit_Click);
            // 
            // backgroundDownloadTimer
            // 
            this.backgroundDownloadTimer.Tick += new System.EventHandler(this.backgroundDownloadTimer_Tick);
            // 
            // updateCheckTimer
            // 
            this.updateCheckTimer.Enabled = true;
            this.updateCheckTimer.Interval = global::VigilantCupcake.Properties.Settings.Default.UpdateCheckInterval;
            this.updateCheckTimer.Tick += new System.EventHandler(this.updateCheckTimer_Tick);
            // 
            // mainBodyTable
            // 
            this.mainBodyTable.ColumnCount = 6;
            this.mainBodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mainBodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainBodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mainBodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.mainBodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mainBodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.mainBodyTable.Controls.Add(this.hostsFileView, 4, 2);
            this.mainBodyTable.Controls.Add(this.currentFragmentView, 2, 2);
            this.mainBodyTable.Controls.Add(this.fragmentTreeView, 0, 2);
            this.mainBodyTable.Controls.Add(this.newHostFilterBox, 5, 1);
            this.mainBodyTable.Controls.Add(this.remoteUrlView, 3, 1);
            this.mainBodyTable.Controls.Add(this.label2, 4, 1);
            this.mainBodyTable.Controls.Add(this.label3, 2, 1);
            this.mainBodyTable.Controls.Add(this.fragmentFilter, 1, 1);
            this.mainBodyTable.Controls.Add(this.label1, 0, 1);
            this.mainBodyTable.Controls.Add(this.newHostsLabel, 4, 0);
            this.mainBodyTable.Controls.Add(this.downloadingLabel, 1, 0);
            this.mainBodyTable.Controls.Add(this.selectedFragmentLabel, 2, 0);
            this.mainBodyTable.Controls.Add(this.label4, 0, 0);
            this.mainBodyTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBodyTable.Location = new System.Drawing.Point(0, 0);
            this.mainBodyTable.Name = "mainBodyTable";
            this.mainBodyTable.RowCount = 3;
            this.mainBodyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mainBodyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mainBodyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainBodyTable.Size = new System.Drawing.Size(1428, 765);
            this.mainBodyTable.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fragment List";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // downloadingLabel
            // 
            this.downloadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadingLabel.Location = new System.Drawing.Point(83, 0);
            this.downloadingLabel.Name = "downloadingLabel";
            this.downloadingLabel.Size = new System.Drawing.Size(112, 14);
            this.downloadingLabel.TabIndex = 4;
            this.downloadingLabel.Text = "Downloading...";
            this.downloadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.downloadingLabel.Visible = false;
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
            this.ClientSize = new System.Drawing.Size(1428, 789);
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
            this.fragmentListContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentFragmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notifyIconMenu.ResumeLayout(false);
            this.mainBodyTable.ResumeLayout(false);
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
        private System.Windows.Forms.Label newHostsLabel;
        private System.Windows.Forms.Label selectedFragmentLabel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flushDNSToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox remoteUrlView;
        private System.Windows.Forms.ToolStripMenuItem viewCurrentHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOnProgramStartToolStripMenuItem;
        private FastColoredTextBoxNS.FastColoredTextBox currentFragmentView;
        private FastColoredTextBoxNS.FastColoredTextBox hostsFileView;
        private System.Windows.Forms.ToolStripMenuItem newHostsAnalysisToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip fragmentListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuRename;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.BindingSource selectedFragmentBindingSource;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuNewFolder;
        private System.Windows.Forms.ToolStripSeparator fragmentListContextMenuSeparator1;
        private System.Windows.Forms.Timer backgroundDownloadTimer;
        private System.Windows.Forms.ToolStripMenuItem syncronizeFragmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem syncFiveMinutes;
        private System.Windows.Forms.ToolStripMenuItem syncFifteenMinutes;
        private System.Windows.Forms.ToolStripMenuItem syncThirtyMinutes;
        private System.Windows.Forms.ToolStripMenuItem syncSixtyMinutes;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem closeToTrayToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Aga.Controls.Tree.TreeViewAdv fragmentTreeView;
        private System.Windows.Forms.BindingSource hostsFileBindingSource;
        private Aga.Controls.Tree.NodeControls.NodeCheckBox nodeCheckBox1;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon nodeStateIcon1;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox fragmentFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem downloadFragmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRemoteFragmentsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox newHostFilterBox;
        private System.Windows.Forms.Timer updateCheckTimer;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNotification;
        private System.Windows.Forms.TableLayoutPanel mainBodyTable;
        private System.Windows.Forms.Label downloadingLabel;
        private System.Windows.Forms.Label label4;

    }
}

