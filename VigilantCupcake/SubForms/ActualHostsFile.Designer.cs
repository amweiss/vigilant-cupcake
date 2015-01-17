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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualHostsFile));
            this.actualHostsFileView = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // actualHostsFileView
            // 
            this.actualHostsFileView.DetectUrls = false;
            this.actualHostsFileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualHostsFileView.Location = new System.Drawing.Point(0, 0);
            this.actualHostsFileView.MaxLength = 0;
            this.actualHostsFileView.Name = "actualHostsFileView";
            this.actualHostsFileView.ReadOnly = true;
            this.actualHostsFileView.Size = new System.Drawing.Size(1047, 791);
            this.actualHostsFileView.TabIndex = 0;
            this.actualHostsFileView.Text = "";
            this.actualHostsFileView.WordWrap = false;
            this.actualHostsFileView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.actualHostsFileView_KeyPress);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox actualHostsFileView;
    }
}