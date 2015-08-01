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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fragmentFilter = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadingLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fragmentTreeView = new VigilantCupcake.Controls.FragmentTreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.remoteUrlView = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedFragmentLabel = new System.Windows.Forms.Label();
            this.currentFragmentView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.selectedFragmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.newHostFilterBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newHostsLabel = new System.Windows.Forms.Label();
            this.hostsFileView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.hostsFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFragmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFragmentBindingSource)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.notifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.splitContainer1);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1428, 765);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fragmentFilter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.downloadingLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fragmentTreeView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(184, 765);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fragmentFilter
            // 
            this.fragmentFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fragmentFilter.DetectUrls = false;
            this.fragmentFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragmentFilter.Location = new System.Drawing.Point(68, 29);
            this.fragmentFilter.MaxLength = 0;
            this.fragmentFilter.Multiline = false;
            this.fragmentFilter.Name = "fragmentFilter";
            this.fragmentFilter.Size = new System.Drawing.Size(113, 20);
            this.fragmentFilter.TabIndex = 9;
            this.fragmentFilter.Text = "";
            this.fragmentFilter.TextChanged += new System.EventHandler(this.fragmentSearchTextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // downloadingLabel
            // 
            this.downloadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadingLabel.AutoSize = true;
            this.downloadingLabel.Location = new System.Drawing.Point(68, 6);
            this.downloadingLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.downloadingLabel.Name = "downloadingLabel";
            this.downloadingLabel.Size = new System.Drawing.Size(113, 13);
            this.downloadingLabel.TabIndex = 7;
            this.downloadingLabel.Text = "Downloading...";
            this.downloadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.downloadingLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.MinimumSize = new System.Drawing.Size(59, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fragments";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fragmentTreeView
            // 
            this.fragmentTreeView.AllowDrop = true;
            this.fragmentTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.fragmentTreeView, 2);
            this.fragmentTreeView.DefaultToolTipProvider = null;
            this.fragmentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentTreeView.DragDropMarkColor = System.Drawing.Color.Black;
            this.fragmentTreeView.FullRowSelect = true;
            this.fragmentTreeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this.fragmentTreeView.Location = new System.Drawing.Point(3, 55);
            this.fragmentTreeView.MinimumSize = new System.Drawing.Size(120, 120);
            this.fragmentTreeView.Name = "fragmentTreeView";
            this.fragmentTreeView.SelectedNode = null;
            this.fragmentTreeView.Size = new System.Drawing.Size(178, 707);
            this.fragmentTreeView.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(1240, 765);
            this.splitContainer2.SplitterDistance = 618;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.remoteUrlView, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.selectedFragmentLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.currentFragmentView, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(618, 765);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // remoteUrlView
            // 
            this.remoteUrlView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteUrlView.DetectUrls = false;
            this.remoteUrlView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remoteUrlView.Location = new System.Drawing.Point(68, 29);
            this.remoteUrlView.Multiline = false;
            this.remoteUrlView.Name = "remoteUrlView";
            this.remoteUrlView.Size = new System.Drawing.Size(547, 20);
            this.remoteUrlView.TabIndex = 7;
            this.remoteUrlView.Text = "";
            this.remoteUrlView.TextChanged += new System.EventHandler(this.remoteUrlView_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remote:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectedFragmentLabel
            // 
            this.selectedFragmentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedFragmentLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.selectedFragmentLabel, 2);
            this.selectedFragmentLabel.Location = new System.Drawing.Point(3, 6);
            this.selectedFragmentLabel.MinimumSize = new System.Drawing.Size(120, 0);
            this.selectedFragmentLabel.Name = "selectedFragmentLabel";
            this.selectedFragmentLabel.Size = new System.Drawing.Size(612, 13);
            this.selectedFragmentLabel.TabIndex = 5;
            this.selectedFragmentLabel.Text = "Selected Fragment";
            this.selectedFragmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel2.SetColumnSpan(this.currentFragmentView, 2);
            this.currentFragmentView.CommentPrefix = "#";
            this.currentFragmentView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.currentFragmentView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectedFragmentBindingSource, "FileContents", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.currentFragmentView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.currentFragmentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentFragmentView.IsReplaceMode = false;
            this.currentFragmentView.Location = new System.Drawing.Point(3, 55);
            this.currentFragmentView.Name = "currentFragmentView";
            this.currentFragmentView.Paddings = new System.Windows.Forms.Padding(0);
            this.currentFragmentView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.currentFragmentView.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("currentFragmentView.ServiceColors")));
            this.currentFragmentView.Size = new System.Drawing.Size(612, 707);
            this.currentFragmentView.TabIndex = 4;
            this.currentFragmentView.Zoom = 100;
            // 
            // selectedFragmentBindingSource
            // 
            this.selectedFragmentBindingSource.DataSource = typeof(VigilantCupcake.Models.Fragment);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.newHostFilterBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.newHostsLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.hostsFileView, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(618, 765);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // newHostFilterBox
            // 
            this.newHostFilterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newHostFilterBox.DetectUrls = false;
            this.newHostFilterBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newHostFilterBox.Location = new System.Drawing.Point(68, 30);
            this.newHostFilterBox.MaxLength = 0;
            this.newHostFilterBox.Multiline = false;
            this.newHostFilterBox.Name = "newHostFilterBox";
            this.newHostFilterBox.Size = new System.Drawing.Size(547, 18);
            this.newHostFilterBox.TabIndex = 7;
            this.newHostFilterBox.Text = "";
            this.newHostFilterBox.TextChanged += new System.EventHandler(this.newHostFilterBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Exclude:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // newHostsLabel
            // 
            this.newHostsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newHostsLabel.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.newHostsLabel, 2);
            this.newHostsLabel.Location = new System.Drawing.Point(3, 6);
            this.newHostsLabel.MinimumSize = new System.Drawing.Size(120, 0);
            this.newHostsLabel.Name = "newHostsLabel";
            this.newHostsLabel.Size = new System.Drawing.Size(612, 13);
            this.newHostsLabel.TabIndex = 5;
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
            this.tableLayoutPanel3.SetColumnSpan(this.hostsFileView, 2);
            this.hostsFileView.CommentPrefix = "#";
            this.hostsFileView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hostsFileView.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hostsFileBindingSource, "FileContents", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hostsFileView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hostsFileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsFileView.IsReplaceMode = false;
            this.hostsFileView.Location = new System.Drawing.Point(3, 55);
            this.hostsFileView.Name = "hostsFileView";
            this.hostsFileView.Paddings = new System.Windows.Forms.Padding(0);
            this.hostsFileView.ReadOnly = true;
            this.hostsFileView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.hostsFileView.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("hostsFileView.ServiceColors")));
            this.hostsFileView.Size = new System.Drawing.Size(612, 707);
            this.hostsFileView.TabIndex = 4;
            this.hostsFileView.Zoom = 100;
            // 
            // hostsFileBindingSource
            // 
            this.hostsFileBindingSource.DataSource = typeof(VigilantCupcake.Models.Fragment);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 789);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFragmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedFragmentBindingSource)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostsFileBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flushDNSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCurrentHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOnProgramStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHostsAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.BindingSource selectedFragmentBindingSource;
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
        private System.Windows.Forms.BindingSource hostsFileBindingSource;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer updateCheckTimer;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNotification;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox fragmentFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label downloadingLabel;
        private System.Windows.Forms.Label label4;
        private VigilantCupcake.Controls.FragmentTreeView fragmentTreeView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox remoteUrlView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label selectedFragmentLabel;
        private FastColoredTextBoxNS.FastColoredTextBox currentFragmentView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RichTextBox newHostFilterBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label newHostsLabel;
        private FastColoredTextBoxNS.FastColoredTextBox hostsFileView;

    }
}

