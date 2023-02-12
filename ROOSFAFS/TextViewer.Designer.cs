namespace Searcher {
    partial class TextViewer {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextViewer));
            this.mnuTV = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spltTextViewer = new System.Windows.Forms.SplitContainer();
            this.tabFiles = new System.Windows.Forms.TabControl();
            this.splitRightPanel = new System.Windows.Forms.SplitContainer();
            this.pnlHighlight = new System.Windows.Forms.Panel();
            this.dgvHighlights = new System.Windows.Forms.DataGridView();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNewHilight = new System.Windows.Forms.TextBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.btnAddHilight = new System.Windows.Forms.Button();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.btnFindAllTabs = new System.Windows.Forms.Button();
            this.dgvFind = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.dataSet = new System.Data.DataSet();
            this.Highlighters = new System.Data.DataTable();
            this.colKey = new System.Data.DataColumn();
            this.colSample = new System.Data.DataColumn();
            this.colForeColor = new System.Data.DataColumn();
            this.colBackColor = new System.Data.DataColumn();
            this.FindHits = new System.Data.DataTable();
            this.colIndex = new System.Data.DataColumn();
            this.colFile = new System.Data.DataColumn();
            this.colLineNum = new System.Data.DataColumn();
            this.colChar = new System.Data.DataColumn();
            this.colContext = new System.Data.DataColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuTV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltTextViewer)).BeginInit();
            this.spltTextViewer.Panel1.SuspendLayout();
            this.spltTextViewer.Panel2.SuspendLayout();
            this.spltTextViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightPanel)).BeginInit();
            this.splitRightPanel.Panel1.SuspendLayout();
            this.splitRightPanel.Panel2.SuspendLayout();
            this.splitRightPanel.SuspendLayout();
            this.pnlHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighlights)).BeginInit();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Highlighters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindHits)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuTV
            // 
            this.mnuTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnuTV.Location = new System.Drawing.Point(0, 0);
            this.mnuTV.Name = "mnuTV";
            this.mnuTV.Size = new System.Drawing.Size(1007, 24);
            this.mnuTV.TabIndex = 5;
            this.mnuTV.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeTabToolStripMenuItem,
            this.closeWindowToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeTabToolStripMenuItem.Text = "Close &Tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
            // 
            // closeWindowToolStripMenuItem
            // 
            this.closeWindowToolStripMenuItem.Name = "closeWindowToolStripMenuItem";
            this.closeWindowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeWindowToolStripMenuItem.Text = "Close &Window";
            this.closeWindowToolStripMenuItem.Click += new System.EventHandler(this.closeWindowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "&Language";
            this.languageToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // spltTextViewer
            // 
            this.spltTextViewer.BackColor = System.Drawing.SystemColors.Control;
            this.spltTextViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltTextViewer.Location = new System.Drawing.Point(0, 24);
            this.spltTextViewer.Name = "spltTextViewer";
            // 
            // spltTextViewer.Panel1
            // 
            this.spltTextViewer.Panel1.Controls.Add(this.tabFiles);
            // 
            // spltTextViewer.Panel2
            // 
            this.spltTextViewer.Panel2.BackColor = System.Drawing.Color.Black;
            this.spltTextViewer.Panel2.Controls.Add(this.splitRightPanel);
            this.spltTextViewer.Size = new System.Drawing.Size(1007, 438);
            this.spltTextViewer.SplitterDistance = 730;
            this.spltTextViewer.TabIndex = 6;
            // 
            // tabFiles
            // 
            this.tabFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFiles.Location = new System.Drawing.Point(0, 0);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size(730, 438);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.SelectedIndexChanged += new System.EventHandler(this.TabFiles_TabIndexChanged);
            this.tabFiles.TabIndexChanged += new System.EventHandler(this.TabFiles_TabIndexChanged);
            this.tabFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabFiles_MouseDown);
            this.tabFiles.MouseLeave += new System.EventHandler(this.tabFiles_MouseLeave);
            this.tabFiles.MouseHover += new System.EventHandler(this.tabFiles_MouseHover);
            // 
            // splitRightPanel
            // 
            this.splitRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRightPanel.Location = new System.Drawing.Point(0, 0);
            this.splitRightPanel.Name = "splitRightPanel";
            this.splitRightPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRightPanel.Panel1
            // 
            this.splitRightPanel.Panel1.Controls.Add(this.pnlHighlight);
            // 
            // splitRightPanel.Panel2
            // 
            this.splitRightPanel.Panel2.Controls.Add(this.pnlFind);
            this.splitRightPanel.Size = new System.Drawing.Size(273, 438);
            this.splitRightPanel.SplitterDistance = 197;
            this.splitRightPanel.TabIndex = 8;
            // 
            // pnlHighlight
            // 
            this.pnlHighlight.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHighlight.Controls.Add(this.dgvHighlights);
            this.pnlHighlight.Controls.Add(this.lblCounter);
            this.pnlHighlight.Controls.Add(this.btnDelete);
            this.pnlHighlight.Controls.Add(this.txtNewHilight);
            this.pnlHighlight.Controls.Add(this.lblSample);
            this.pnlHighlight.Controls.Add(this.btnAddHilight);
            this.pnlHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHighlight.Location = new System.Drawing.Point(0, 0);
            this.pnlHighlight.Name = "pnlHighlight";
            this.pnlHighlight.Size = new System.Drawing.Size(273, 197);
            this.pnlHighlight.TabIndex = 6;
            // 
            // dgvHighlights
            // 
            this.dgvHighlights.AllowUserToAddRows = false;
            this.dgvHighlights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHighlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighlights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHighlights.Location = new System.Drawing.Point(0, 71);
            this.dgvHighlights.Name = "dgvHighlights";
            this.dgvHighlights.RowHeadersVisible = false;
            this.dgvHighlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHighlights.ShowCellToolTips = false;
            this.dgvHighlights.Size = new System.Drawing.Size(270, 97);
            this.dgvHighlights.TabIndex = 5;
            this.dgvHighlights.DoubleClick += new System.EventHandler(this.dgvHighlights_DoubleClick);
            this.dgvHighlights.MouseLeave += new System.EventHandler(this.dgvHighlights_MouseLeave);
            this.dgvHighlights.MouseHover += new System.EventHandler(this.dgvHighlights_MouseHover);
            // 
            // lblCounter
            // 
            this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(237, 23);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(30, 13);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "1/15";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(0, 174);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(273, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // txtNewHilight
            // 
            this.txtNewHilight.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewHilight.Location = new System.Drawing.Point(0, 0);
            this.txtNewHilight.Name = "txtNewHilight";
            this.txtNewHilight.Size = new System.Drawing.Size(273, 20);
            this.txtNewHilight.TabIndex = 0;
            this.txtNewHilight.TextChanged += new System.EventHandler(this.TxtNewHilight_TextChanged);
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(3, 26);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(42, 13);
            this.lblSample.TabIndex = 3;
            this.lblSample.Text = "Sample";
            this.lblSample.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblSample_MouseClick);
            // 
            // btnAddHilight
            // 
            this.btnAddHilight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHilight.Location = new System.Drawing.Point(0, 42);
            this.btnAddHilight.Name = "btnAddHilight";
            this.btnAddHilight.Size = new System.Drawing.Size(273, 23);
            this.btnAddHilight.TabIndex = 2;
            this.btnAddHilight.Text = "Add Hilight";
            this.btnAddHilight.UseVisualStyleBackColor = true;
            this.btnAddHilight.Click += new System.EventHandler(this.BtnAddHilight_Click);
            // 
            // pnlFind
            // 
            this.pnlFind.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFind.Controls.Add(this.btnFindAllTabs);
            this.pnlFind.Controls.Add(this.dgvFind);
            this.pnlFind.Controls.Add(this.btnFind);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Controls.Add(this.lblFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(273, 237);
            this.pnlFind.TabIndex = 7;
            // 
            // btnFindAllTabs
            // 
            this.btnFindAllTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindAllTabs.Location = new System.Drawing.Point(126, 35);
            this.btnFindAllTabs.Name = "btnFindAllTabs";
            this.btnFindAllTabs.Size = new System.Drawing.Size(135, 23);
            this.btnFindAllTabs.TabIndex = 8;
            this.btnFindAllTabs.Text = "Find in All Tabs";
            this.btnFindAllTabs.UseVisualStyleBackColor = true;
            this.btnFindAllTabs.Click += new System.EventHandler(this.BtnFindAllTabs_Click);
            // 
            // dgvFind
            // 
            this.dgvFind.AllowUserToAddRows = false;
            this.dgvFind.AllowUserToOrderColumns = true;
            this.dgvFind.AllowUserToResizeRows = false;
            this.dgvFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFind.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFind.Location = new System.Drawing.Point(0, 64);
            this.dgvFind.Name = "dgvFind";
            this.dgvFind.RowHeadersVisible = false;
            this.dgvFind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFind.ShowCellToolTips = false;
            this.dgvFind.Size = new System.Drawing.Size(270, 173);
            this.dgvFind.TabIndex = 0;
            this.dgvFind.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFind_CellClick);
            this.dgvFind.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFind_CellContentDoubleClick);
            this.dgvFind.MouseLeave += new System.EventHandler(this.dgvFind_MouseLeave);
            this.dgvFind.MouseHover += new System.EventHandler(this.dgvFind_MouseHover);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(186, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(58, 9);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(122, 20);
            this.txtFind.TabIndex = 2;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(22, 12);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(30, 13);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Find:";
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "FindHits";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.Highlighters,
            this.FindHits});
            // 
            // Highlighters
            // 
            this.Highlighters.Columns.AddRange(new System.Data.DataColumn[] {
            this.colKey,
            this.colSample,
            this.colForeColor,
            this.colBackColor});
            this.Highlighters.TableName = "Hilighters";
            // 
            // colKey
            // 
            this.colKey.ColumnName = "Key";
            // 
            // colSample
            // 
            this.colSample.ColumnName = "Sample";
            // 
            // colForeColor
            // 
            this.colForeColor.ColumnName = "ForeColor";
            this.colForeColor.DataType = typeof(object);
            // 
            // colBackColor
            // 
            this.colBackColor.ColumnName = "BackColor";
            this.colBackColor.DataType = typeof(object);
            // 
            // FindHits
            // 
            this.FindHits.Columns.AddRange(new System.Data.DataColumn[] {
            this.colIndex,
            this.colFile,
            this.colLineNum,
            this.colChar,
            this.colContext});
            this.FindHits.TableName = "FindHits";
            // 
            // colIndex
            // 
            this.colIndex.ColumnName = "#";
            // 
            // colFile
            // 
            this.colFile.ColumnName = "File";
            // 
            // colLineNum
            // 
            this.colLineNum.ColumnName = "Line";
            // 
            // colChar
            // 
            this.colChar.ColumnName = "Col";
            // 
            // colContext
            // 
            this.colContext.ColumnName = "Context";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipTitle = "ROOSFAFS Top Tips:";
            // 
            // TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 462);
            this.Controls.Add(this.spltTextViewer);
            this.Controls.Add(this.mnuTV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTV;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextViewer";
            this.Text = "TextViewer";
            this.mnuTV.ResumeLayout(false);
            this.mnuTV.PerformLayout();
            this.spltTextViewer.Panel1.ResumeLayout(false);
            this.spltTextViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltTextViewer)).EndInit();
            this.spltTextViewer.ResumeLayout(false);
            this.splitRightPanel.Panel1.ResumeLayout(false);
            this.splitRightPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightPanel)).EndInit();
            this.splitRightPanel.ResumeLayout(false);
            this.pnlHighlight.ResumeLayout(false);
            this.pnlHighlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighlights)).EndInit();
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Highlighters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindHits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTV;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer spltTextViewer;
        private System.Windows.Forms.TextBox txtNewHilight;
        private System.Windows.Forms.Button btnAddHilight;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabFiles;
        private System.Windows.Forms.Panel pnlHighlight;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFindAllTabs;
        private System.Windows.Forms.DataGridView dgvFind;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable Highlighters;
        private System.Data.DataColumn colKey;
        private System.Data.DataColumn colSample;
        private System.Data.DataTable FindHits;
        private System.Data.DataColumn colIndex;
        private System.Data.DataColumn colFile;
        private System.Data.DataColumn colLineNum;
        private System.Data.DataColumn colChar;
        private System.Data.DataColumn colContext;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Data.DataColumn colBackColor;
        private System.Data.DataColumn colForeColor;
        private System.Windows.Forms.DataGridView dgvHighlights;
        private System.Windows.Forms.SplitContainer splitRightPanel;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}