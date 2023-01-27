namespace Searcher
{
    partial class TextViewerSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.barOpacity = new System.Windows.Forms.TrackBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.chkShowRightPanel = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.chkConfirmTabClose = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlFontFamily = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // barOpacity
            // 
            this.barOpacity.AutoSize = false;
            this.barOpacity.Dock = System.Windows.Forms.DockStyle.Right;
            this.barOpacity.LargeChange = 10;
            this.barOpacity.Location = new System.Drawing.Point(358, 0);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 20;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.barOpacity.Size = new System.Drawing.Size(26, 161);
            this.barOpacity.SmallChange = 5;
            this.barOpacity.TabIndex = 6;
            this.barOpacity.TabStop = false;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barOpacity.Value = 100;
            this.barOpacity.Scroll += new System.EventHandler(this.BarOpacity_Scroll);
            // 
            // chkShowRightPanel
            // 
            this.chkShowRightPanel.AutoSize = true;
            this.chkShowRightPanel.Location = new System.Drawing.Point(25, 25);
            this.chkShowRightPanel.Name = "chkShowRightPanel";
            this.chkShowRightPanel.Size = new System.Drawing.Size(111, 17);
            this.chkShowRightPanel.TabIndex = 7;
            this.chkShowRightPanel.Text = "Show Right Panel";
            this.chkShowRightPanel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Right Panel";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(226, 58);
            this.numFontSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(61, 20);
            this.numFontSize.TabIndex = 11;
            this.numFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkConfirmTabClose
            // 
            this.chkConfirmTabClose.AutoSize = true;
            this.chkConfirmTabClose.Location = new System.Drawing.Point(220, 25);
            this.chkConfirmTabClose.Name = "chkConfirmTabClose";
            this.chkConfirmTabClose.Size = new System.Drawing.Size(112, 17);
            this.chkConfirmTabClose.TabIndex = 22;
            this.chkConfirmTabClose.Text = "Confirm Close Tab";
            this.chkConfirmTabClose.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(207, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Misc";
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestoreDefaults.Location = new System.Drawing.Point(12, 126);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(115, 23);
            this.btnRestoreDefaults.TabIndex = 25;
            this.btnRestoreDefaults.Text = "Restore Defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(226, 126);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(293, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlFontFamily
            // 
            this.ddlFontFamily.FormattingEnabled = true;
            this.ddlFontFamily.Location = new System.Drawing.Point(50, 57);
            this.ddlFontFamily.Name = "ddlFontFamily";
            this.ddlFontFamily.Size = new System.Drawing.Size(164, 21);
            this.ddlFontFamily.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Font";
            // 
            // TextViewerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlFontFamily);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRestoreDefaults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkConfirmTabClose);
            this.Controls.Add(this.numFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkShowRightPanel);
            this.Controls.Add(this.barOpacity);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "TextViewerSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Text Viewer Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar barOpacity;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.CheckBox chkShowRightPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.CheckBox chkConfirmTabClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlFontFamily;
        private System.Windows.Forms.Label label2;
    }
}