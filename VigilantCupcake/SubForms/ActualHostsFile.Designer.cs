namespace VigilantCupcake.SubForms {
    partial class ActualHostsFile {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualHostsFile));
            this.actualHostsFileView = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.actualHostsFileView)).BeginInit();
            this.SuspendLayout();
            // 
            // actualHostsFileView
            // 
            this.actualHostsFileView.AutoCompleteBracketsList = new char[] {
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
            this.actualHostsFileView.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.actualHostsFileView.BackBrush = null;
            this.actualHostsFileView.BackColor = System.Drawing.SystemColors.Control;
            this.actualHostsFileView.CharHeight = 14;
            this.actualHostsFileView.CharWidth = 8;
            this.actualHostsFileView.CommentPrefix = "#";
            this.actualHostsFileView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.actualHostsFileView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.actualHostsFileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualHostsFileView.IsReplaceMode = false;
            this.actualHostsFileView.Location = new System.Drawing.Point(0, 0);
            this.actualHostsFileView.Name = "actualHostsFileView";
            this.actualHostsFileView.Paddings = new System.Windows.Forms.Padding(0);
            this.actualHostsFileView.ReadOnly = true;
            this.actualHostsFileView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.actualHostsFileView.Size = new System.Drawing.Size(1047, 791);
            this.actualHostsFileView.TabIndex = 0;
            this.actualHostsFileView.Zoom = 100;
            // 
            // ActualHostsFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 791);
            this.Controls.Add(this.actualHostsFileView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualHostsFile";
            this.Text = "Current Hosts File";
            this.Load += new System.EventHandler(this.ActualHostsFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actualHostsFileView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox actualHostsFileView;

    }
}