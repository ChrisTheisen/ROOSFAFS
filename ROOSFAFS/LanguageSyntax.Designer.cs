namespace Searcher
{
    partial class LanguageSyntax
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
            this.ddlLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFoldClose = new System.Windows.Forms.TextBox();
            this.txtFoldOpen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ddlLanguage
            // 
            this.ddlLanguage.FormattingEnabled = true;
            this.ddlLanguage.Items.AddRange(new object[] {
            "None",
            "C#",
            "HTML",
            "JavaScript",
            "JSON",
            "Lua",
            "PHP",
            "SQL",
            "VB",
            "XML"});
            this.ddlLanguage.Location = new System.Drawing.Point(73, 6);
            this.ddlLanguage.Name = "ddlLanguage";
            this.ddlLanguage.Size = new System.Drawing.Size(121, 21);
            this.ddlLanguage.TabIndex = 0;
            this.ddlLanguage.Text = "None";
            this.ddlLanguage.SelectedIndexChanged += new System.EventHandler(this.ddlLanguage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Language";
            // 
            // txtFoldClose
            // 
            this.txtFoldClose.Location = new System.Drawing.Point(349, 6);
            this.txtFoldClose.MaxLength = 1;
            this.txtFoldClose.Name = "txtFoldClose";
            this.txtFoldClose.Size = new System.Drawing.Size(21, 20);
            this.txtFoldClose.TabIndex = 36;
            // 
            // txtFoldOpen
            // 
            this.txtFoldOpen.Location = new System.Drawing.Point(322, 6);
            this.txtFoldOpen.MaxLength = 1;
            this.txtFoldOpen.Name = "txtFoldOpen";
            this.txtFoldOpen.Size = new System.Drawing.Size(21, 20);
            this.txtFoldOpen.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Folding Markers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "FUTURE PROJECT";
            // 
            // LanguageSyntax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 404);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFoldClose);
            this.Controls.Add(this.txtFoldOpen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlLanguage);
            this.Name = "LanguageSyntax";
            this.ShowIcon = false;
            this.Text = "Language Syntax Styles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFoldClose;
        private System.Windows.Forms.TextBox txtFoldOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}