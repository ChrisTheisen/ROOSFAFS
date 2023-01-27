namespace Searcher {
    partial class FancyTextBox {
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblPos = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnFindInFolder = new System.Windows.Forms.Button();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblSize);
            this.pnlBottom.Controls.Add(this.lblPos);
            this.pnlBottom.Controls.Add(this.txtPath);
            this.pnlBottom.Controls.Add(this.btnFindInFolder);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 387);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(445, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // lblPos
            // 
            this.lblPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPos.Location = new System.Drawing.Point(209, 32);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(200, 13);
            this.lblPos.TabIndex = 2;
            this.lblPos.Text = "L:1 Col:1 Sel:1";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(3, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(321, 20);
            this.txtPath.TabIndex = 2;
            // 
            // btnFindInFolder
            // 
            this.btnFindInFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindInFolder.Location = new System.Drawing.Point(327, 3);
            this.btnFindInFolder.Name = "btnFindInFolder";
            this.btnFindInFolder.Size = new System.Drawing.Size(113, 23);
            this.btnFindInFolder.TabIndex = 1;
            this.btnFindInFolder.Text = "Find In Folder";
            this.btnFindInFolder.UseVisualStyleBackColor = true;
            this.btnFindInFolder.Click += new System.EventHandler(this.btnFindInFolder_Click);
            // 
            // rtbContent
            // 
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Location = new System.Drawing.Point(0, 0);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(445, 387);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            this.rtbContent.WordWrap = false;
            this.rtbContent.SelectionChanged += new System.EventHandler(this.rtbContent_SelectionChanged);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.rtbContent);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(445, 387);
            this.pnlBody.TabIndex = 0;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.Location = new System.Drawing.Point(3, 32);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(200, 13);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Length:1 Lines:1";
            // 
            // FancyTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FancyTextBox";
            this.Size = new System.Drawing.Size(445, 437);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnFindInFolder;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblSize;
    }
}
