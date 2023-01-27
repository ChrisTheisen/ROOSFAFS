namespace Searcher {
    partial class About {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROOSFAFS";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(35, 122);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(604, 65);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "GITHUB SOURCE: \r\nCONTACT: theisen.christopher@gmail.com";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(214, 127);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(290, 25);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/ChrisTheisen";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(35, 199);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(604, 183);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(40, 330);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(396, 25);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://www.gnu.org/licenses/gpl-3.0.en.html";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Regex Or Other String File And Folder Searcher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Location = new System.Drawing.Point(375, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "V: 0.8.221212";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(35, 394);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 494);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "About";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About ROOSFAFS";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}