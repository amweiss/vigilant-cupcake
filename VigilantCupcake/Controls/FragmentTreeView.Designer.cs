namespace VigilantCupcake.Controls {
    partial class FragmentTreeView {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.nodeCheckBox1 = new Aga.Controls.Tree.NodeControls.NodeCheckBox();
            this.nodeStateIcon1 = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.fragmentListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.importRemoteFragmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFragmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fragmentListContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentListContextMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.fragmentListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.fragmentListContextMenu_Opening);
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
            // FragmentTreeView
            // 
            this.ContextMenuStrip = this.fragmentListContextMenu;
            this.NodeControls.Add(this.nodeCheckBox1);
            this.NodeControls.Add(this.nodeStateIcon1);
            this.NodeControls.Add(this.nodeTextBox1);
            this.Size = new System.Drawing.Size(120, 240);
            this.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.fragmentTreeView_ItemDrag);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.fragmentTreeView_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.fragmentTreeView_DragOver);
            this.fragmentListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip fragmentListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem importRemoteFragmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadFragmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fragmentListContextMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem fragmentListContextMenuRename;
        private Aga.Controls.Tree.NodeControls.NodeCheckBox nodeCheckBox1;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon nodeStateIcon1;
        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
    }
}
