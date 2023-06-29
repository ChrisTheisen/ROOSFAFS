namespace Searcher {
    partial class MainWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.txtSkipFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRootFolder = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.chkSkipFolders = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtSearchExtension = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSkipExtension = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSearchRegex = new System.Windows.Forms.CheckBox();
            this.chkFilterRegex = new System.Windows.Forms.CheckBox();
            this.btnFindInFolder = new System.Windows.Forms.Button();
            this.btnCopyFiles = new System.Windows.Forms.Button();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBuildRegexSearch = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStopped = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numSizeMax = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numSizeMin = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.dateWriteMax = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dateWriteMin = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateAccessedMax = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateAccessedMin = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoFolderName = new System.Windows.Forms.RadioButton();
            this.rdoFileName = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoContents = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.numStopAfterN = new System.Windows.Forms.NumericUpDown();
            this.chkSkipExtensions = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.lstSearchHistory = new System.Windows.Forms.ListBox();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.ddlFilterType = new System.Windows.Forms.ComboBox();
            this.ddlFilterInclude = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeMin)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopAfterN)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.tab4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search String: ";
            // 
            // txtSearchString
            // 
            this.txtSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchString.Location = new System.Drawing.Point(101, 29);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(392, 20);
            this.txtSearchString.TabIndex = 0;
            this.txtSearchString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchString_KeyDown);
            this.txtSearchString.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.txtSearchString.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // txtSkipFolder
            // 
            this.txtSkipFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkipFolder.Location = new System.Drawing.Point(105, 48);
            this.txtSkipFolder.Name = "txtSkipFolder";
            this.txtSkipFolder.Size = new System.Drawing.Size(442, 20);
            this.txtSkipFolder.TabIndex = 3;
            this.txtSkipFolder.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.txtSkipFolder.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Skip Folder: ";
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootFolder.Location = new System.Drawing.Point(101, 55);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(392, 20);
            this.txtRootFolder.TabIndex = 1;
            this.txtRootFolder.Text = "C:\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Root Folder: ";
            // 
            // btnRootFolder
            // 
            this.btnRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRootFolder.Location = new System.Drawing.Point(624, 53);
            this.btnRootFolder.Name = "btnRootFolder";
            this.btnRootFolder.Size = new System.Drawing.Size(118, 23);
            this.btnRootFolder.TabIndex = 8;
            this.btnRootFolder.TabStop = false;
            this.btnRootFolder.Text = "Select Folder";
            this.btnRootFolder.UseVisualStyleBackColor = true;
            this.btnRootFolder.Click += new System.EventHandler(this.btnRootFolder_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(748, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 50);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkRecursive
            // 
            this.chkRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(499, 58);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(119, 17);
            this.chkRecursive.TabIndex = 6;
            this.chkRecursive.TabStop = false;
            this.chkRecursive.Text = "Search Sub-Folders";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(748, 26);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(118, 49);
            this.btnStop.TabIndex = 14;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnView.Location = new System.Drawing.Point(751, 323);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(115, 23);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "Open Files";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            this.btnView.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnView.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // chkSkipFolders
            // 
            this.chkSkipFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSkipFolders.AutoSize = true;
            this.chkSkipFolders.Checked = true;
            this.chkSkipFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkipFolders.Location = new System.Drawing.Point(553, 50);
            this.chkSkipFolders.Name = "chkSkipFolders";
            this.chkSkipFolders.Size = new System.Drawing.Size(152, 17);
            this.chkSkipFolders.TabIndex = 19;
            this.chkSkipFolders.TabStop = false;
            this.chkSkipFolders.Text = "Skip Common Skip Folders";
            this.chkSkipFolders.UseVisualStyleBackColor = true;
            this.chkSkipFolders.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.chkSkipFolders.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemove.Location = new System.Drawing.Point(559, 451);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(96, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Hide Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnRemove.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnRemove.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(88, 425);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(588, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            this.txtFilter.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.txtFilter.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestore.Location = new System.Drawing.Point(661, 451);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(88, 23);
            this.btnRestore.TabIndex = 11;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            this.btnRestore.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnRestore.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Filter String: ";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(446, 451);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(107, 23);
            this.btnFilter.TabIndex = 29;
            this.btnFilter.Text = "Filter Results";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            this.btnFilter.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnFilter.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.AllowUserToOrderColumns = true;
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdResults.Location = new System.Drawing.Point(3, 3);
            this.grdResults.Name = "grdResults";
            this.grdResults.RowHeadersVisible = false;
            this.grdResults.RowHeadersWidth = 72;
            this.grdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResults.ShowCellToolTips = false;
            this.grdResults.Size = new System.Drawing.Size(723, 305);
            this.grdResults.TabIndex = 30;
            this.grdResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResults_CellDoubleClick);
            this.grdResults.SelectionChanged += new System.EventHandler(this.grdResults_SelectionChanged);
            this.grdResults.Sorted += new System.EventHandler(this.grdResults_Sorted);
            this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
            this.grdResults.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.grdResults.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(18, 97);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(149, 25);
            this.lblCount.TabIndex = 31;
            this.lblCount.Text = "Files Found: 0";
            // 
            // txtSearchExtension
            // 
            this.txtSearchExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchExtension.Location = new System.Drawing.Point(105, 74);
            this.txtSearchExtension.Name = "txtSearchExtension";
            this.txtSearchExtension.Size = new System.Drawing.Size(600, 20);
            this.txtSearchExtension.TabIndex = 32;
            this.txtSearchExtension.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.txtSearchExtension.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Search Extension: ";
            // 
            // txtSkipExtension
            // 
            this.txtSkipExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkipExtension.Location = new System.Drawing.Point(105, 100);
            this.txtSkipExtension.Name = "txtSkipExtension";
            this.txtSkipExtension.Size = new System.Drawing.Size(425, 20);
            this.txtSkipExtension.TabIndex = 34;
            this.txtSkipExtension.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.txtSkipExtension.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Skip Extension: ";
            // 
            // chkSearchRegex
            // 
            this.chkSearchRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchRegex.AutoSize = true;
            this.chkSearchRegex.Checked = true;
            this.chkSearchRegex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchRegex.Location = new System.Drawing.Point(499, 32);
            this.chkSearchRegex.Name = "chkSearchRegex";
            this.chkSearchRegex.Size = new System.Drawing.Size(57, 17);
            this.chkSearchRegex.TabIndex = 36;
            this.chkSearchRegex.TabStop = false;
            this.chkSearchRegex.Text = "Regex";
            this.chkSearchRegex.UseVisualStyleBackColor = true;
            // 
            // chkFilterRegex
            // 
            this.chkFilterRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFilterRegex.AutoSize = true;
            this.chkFilterRegex.Location = new System.Drawing.Point(682, 428);
            this.chkFilterRegex.Name = "chkFilterRegex";
            this.chkFilterRegex.Size = new System.Drawing.Size(57, 17);
            this.chkFilterRegex.TabIndex = 37;
            this.chkFilterRegex.TabStop = false;
            this.chkFilterRegex.Text = "Regex";
            this.chkFilterRegex.UseVisualStyleBackColor = true;
            // 
            // btnFindInFolder
            // 
            this.btnFindInFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindInFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFindInFolder.Location = new System.Drawing.Point(751, 265);
            this.btnFindInFolder.Name = "btnFindInFolder";
            this.btnFindInFolder.Size = new System.Drawing.Size(115, 23);
            this.btnFindInFolder.TabIndex = 41;
            this.btnFindInFolder.Text = "Find In Folder";
            this.btnFindInFolder.UseVisualStyleBackColor = true;
            this.btnFindInFolder.Click += new System.EventHandler(this.btnFindInFolder_Click);
            this.btnFindInFolder.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnFindInFolder.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // btnCopyFiles
            // 
            this.btnCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCopyFiles.Location = new System.Drawing.Point(751, 294);
            this.btnCopyFiles.Name = "btnCopyFiles";
            this.btnCopyFiles.Size = new System.Drawing.Size(115, 23);
            this.btnCopyFiles.TabIndex = 42;
            this.btnCopyFiles.Text = "Copy Selected";
            this.btnCopyFiles.UseVisualStyleBackColor = true;
            this.btnCopyFiles.Click += new System.EventHandler(this.btnCopyFiles_Click);
            this.btnCopyFiles.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnCopyFiles.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // mnuStrip
            // 
            this.mnuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(874, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnBuildRegexSearch
            // 
            this.btnBuildRegexSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildRegexSearch.Location = new System.Drawing.Point(624, 25);
            this.btnBuildRegexSearch.Name = "btnBuildRegexSearch";
            this.btnBuildRegexSearch.Size = new System.Drawing.Size(118, 23);
            this.btnBuildRegexSearch.TabIndex = 43;
            this.btnBuildRegexSearch.TabStop = false;
            this.btnBuildRegexSearch.Text = "Regex Helper";
            this.btnBuildRegexSearch.UseVisualStyleBackColor = true;
            this.btnBuildRegexSearch.Click += new System.EventHandler(this.btnBuildRegex_Click);
            this.btnBuildRegexSearch.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.btnBuildRegexSearch.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStart,
            this.lblStopped,
            this.lblDuration});
            this.statusStrip.Location = new System.Drawing.Point(0, 484);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(874, 30);
            this.statusStrip.TabIndex = 44;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 25);
            this.lblStatus.Text = "\\\\";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStart
            // 
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(47, 25);
            this.lblStart.Text = "Started:";
            // 
            // lblStopped
            // 
            this.lblStopped.Name = "lblStopped";
            this.lblStopped.Size = new System.Drawing.Size(54, 25);
            this.lblStopped.Text = "Stopped:";
            // 
            // lblDuration
            // 
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(56, 25);
            this.lblDuration.Text = "Duration:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numSizeMax);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.numSizeMin);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dateWriteMax);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dateWriteMin);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dateAccessedMax);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dateAccessedMin);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numStopAfterN);
            this.panel1.Controls.Add(this.chkSkipExtensions);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSkipFolder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearchExtension);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSkipExtension);
            this.panel1.Controls.Add(this.chkSkipFolders);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 305);
            this.panel1.TabIndex = 45;
            // 
            // numSizeMax
            // 
            this.numSizeMax.Location = new System.Drawing.Point(463, 185);
            this.numSizeMax.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSizeMax.Name = "numSizeMax";
            this.numSizeMax.Size = new System.Drawing.Size(111, 20);
            this.numSizeMax.TabIndex = 60;
            this.numSizeMax.Value = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(356, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 59;
            this.label14.Text = "File Size Max (bytes):";
            // 
            // numSizeMin
            // 
            this.numSizeMin.Location = new System.Drawing.Point(226, 185);
            this.numSizeMin.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numSizeMin.Name = "numSizeMin";
            this.numSizeMin.Size = new System.Drawing.Size(111, 20);
            this.numSizeMin.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(117, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "File Size Min (bytes):";
            // 
            // dateWriteMax
            // 
            this.dateWriteMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateWriteMax.Location = new System.Drawing.Point(463, 239);
            this.dateWriteMax.Name = "dateWriteMax";
            this.dateWriteMax.Size = new System.Drawing.Size(111, 20);
            this.dateWriteMax.TabIndex = 56;
            this.dateWriteMax.Value = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateWriteMax.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.dateWriteMax.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(356, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Last Written Before:";
            // 
            // dateWriteMin
            // 
            this.dateWriteMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateWriteMin.Location = new System.Drawing.Point(226, 239);
            this.dateWriteMin.Name = "dateWriteMin";
            this.dateWriteMin.Size = new System.Drawing.Size(111, 20);
            this.dateWriteMin.TabIndex = 54;
            this.dateWriteMin.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateWriteMin.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.dateWriteMin.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Last Written After:";
            // 
            // dateAccessedMax
            // 
            this.dateAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAccessedMax.Location = new System.Drawing.Point(463, 213);
            this.dateAccessedMax.Name = "dateAccessedMax";
            this.dateAccessedMax.Size = new System.Drawing.Size(111, 20);
            this.dateAccessedMax.TabIndex = 52;
            this.dateAccessedMax.Value = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateAccessedMax.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.dateAccessedMax.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(343, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Last Accessed Before:";
            // 
            // dateAccessedMin
            // 
            this.dateAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAccessedMin.Location = new System.Drawing.Point(226, 213);
            this.dateAccessedMin.Name = "dateAccessedMin";
            this.dateAccessedMin.Size = new System.Drawing.Size(111, 20);
            this.dateAccessedMin.TabIndex = 50;
            this.dateAccessedMin.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateAccessedMin.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.dateAccessedMin.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Last Accessed After:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoFolderName);
            this.panel2.Controls.Add(this.rdoFileName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.rdoContents);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 33);
            this.panel2.TabIndex = 48;
            // 
            // rdoFolderName
            // 
            this.rdoFolderName.AutoSize = true;
            this.rdoFolderName.Location = new System.Drawing.Point(252, 7);
            this.rdoFolderName.Name = "rdoFolderName";
            this.rdoFolderName.Size = new System.Drawing.Size(85, 17);
            this.rdoFolderName.TabIndex = 50;
            this.rdoFolderName.Text = "Folder Name";
            this.rdoFolderName.UseVisualStyleBackColor = true;
            this.rdoFolderName.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rdoFolderName.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // rdoFileName
            // 
            this.rdoFileName.AutoSize = true;
            this.rdoFileName.Location = new System.Drawing.Point(174, 7);
            this.rdoFileName.Name = "rdoFileName";
            this.rdoFileName.Size = new System.Drawing.Size(72, 17);
            this.rdoFileName.TabIndex = 49;
            this.rdoFileName.Text = "File Name";
            this.rdoFileName.UseVisualStyleBackColor = true;
            this.rdoFileName.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rdoFileName.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Search Type:";
            // 
            // rdoContents
            // 
            this.rdoContents.AutoSize = true;
            this.rdoContents.Checked = true;
            this.rdoContents.Location = new System.Drawing.Point(82, 7);
            this.rdoContents.Name = "rdoContents";
            this.rdoContents.Size = new System.Drawing.Size(86, 17);
            this.rdoContents.TabIndex = 45;
            this.rdoContents.TabStop = true;
            this.rdoContents.Text = "File Contents";
            this.rdoContents.UseVisualStyleBackColor = true;
            this.rdoContents.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rdoContents.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Stop after N hits:";
            // 
            // numStopAfterN
            // 
            this.numStopAfterN.Location = new System.Drawing.Point(105, 124);
            this.numStopAfterN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStopAfterN.Name = "numStopAfterN";
            this.numStopAfterN.Size = new System.Drawing.Size(60, 20);
            this.numStopAfterN.TabIndex = 45;
            this.numStopAfterN.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // chkSkipExtensions
            // 
            this.chkSkipExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSkipExtensions.AutoSize = true;
            this.chkSkipExtensions.Checked = true;
            this.chkSkipExtensions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkipExtensions.Location = new System.Drawing.Point(536, 102);
            this.chkSkipExtensions.Name = "chkSkipExtensions";
            this.chkSkipExtensions.Size = new System.Drawing.Size(169, 17);
            this.chkSkipExtensions.TabIndex = 36;
            this.chkSkipExtensions.TabStop = false;
            this.chkSkipExtensions.Text = "Skip Common Skip Extensions";
            this.chkSkipExtensions.UseVisualStyleBackColor = true;
            this.chkSkipExtensions.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.chkSkipExtensions.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tab1);
            this.tabControl.Controls.Add(this.tab2);
            this.tabControl.Controls.Add(this.tab3);
            this.tabControl.Controls.Add(this.tab4);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(12, 82);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(737, 337);
            this.tabControl.TabIndex = 36;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.grdResults);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(729, 311);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Results";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.panel1);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(729, 311);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Search Options";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.lstSearchHistory);
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(729, 311);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Search History";
            this.tab3.UseVisualStyleBackColor = true;
            // 
            // lstSearchHistory
            // 
            this.lstSearchHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSearchHistory.FormattingEnabled = true;
            this.lstSearchHistory.Location = new System.Drawing.Point(0, 0);
            this.lstSearchHistory.Name = "lstSearchHistory";
            this.lstSearchHistory.Size = new System.Drawing.Size(729, 311);
            this.lstSearchHistory.TabIndex = 0;
            this.lstSearchHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSearchHistory_MouseDoubleClick);
            this.lstSearchHistory.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.lstSearchHistory.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // tab4
            // 
            this.tab4.Controls.Add(this.rtbLog);
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(729, 311);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Log";
            this.tab4.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(729, 311);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            this.rtbLog.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rtbLog.MouseHover += new System.EventHandler(this.control_MouseHover);
            // 
            // ddlFilterType
            // 
            this.ddlFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlFilterType.FormattingEnabled = true;
            this.ddlFilterType.Items.AddRange(new object[] {
            "File Contents",
            "File Path/Name"});
            this.ddlFilterType.Location = new System.Drawing.Point(12, 451);
            this.ddlFilterType.Name = "ddlFilterType";
            this.ddlFilterType.Size = new System.Drawing.Size(157, 21);
            this.ddlFilterType.TabIndex = 46;
            this.ddlFilterType.Text = "File Contents";
            // 
            // ddlFilterInclude
            // 
            this.ddlFilterInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlFilterInclude.FormattingEnabled = true;
            this.ddlFilterInclude.Items.AddRange(new object[] {
            "Select Match",
            "Select Not Match"});
            this.ddlFilterInclude.Location = new System.Drawing.Point(175, 451);
            this.ddlFilterInclude.Name = "ddlFilterInclude";
            this.ddlFilterInclude.Size = new System.Drawing.Size(157, 21);
            this.ddlFilterInclude.TabIndex = 47;
            this.ddlFilterInclude.Text = "Select Match";
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "ROOSFAFS Top Tips:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 514);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnBuildRegexSearch);
            this.Controls.Add(this.btnCopyFiles);
            this.Controls.Add(this.btnFindInFolder);
            this.Controls.Add(this.chkFilterRegex);
            this.Controls.Add(this.chkSearchRegex);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRootFolder);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.mnuStrip);
            this.Controls.Add(this.ddlFilterInclude);
            this.Controls.Add(this.ddlFilterType);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "MainWindow";
            this.Text = "ROOSFAFS";
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeMin)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopAfterN)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab3.ResumeLayout(false);
            this.tab4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.TextBox txtSkipFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btnRootFolder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox chkSkipFolders;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView grdResults;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtSearchExtension;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSkipExtension;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSearchRegex;
        private System.Windows.Forms.CheckBox chkFilterRegex;
        private System.Windows.Forms.Button btnFindInFolder;
        private System.Windows.Forms.Button btnCopyFiles;
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnBuildRegexSearch;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStart;
        private System.Windows.Forms.ToolStripStatusLabel lblStopped;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tab1;
		private System.Windows.Forms.TabPage tab2;
		private System.Windows.Forms.ToolStripStatusLabel lblDuration;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.CheckBox chkSkipExtensions;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numStopAfterN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoFolderName;
        private System.Windows.Forms.RadioButton rdoFileName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdoContents;
        private System.Windows.Forms.ComboBox ddlFilterType;
        private System.Windows.Forms.ListBox lstSearchHistory;
        private System.Windows.Forms.ComboBox ddlFilterInclude;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DateTimePicker dateAccessedMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateAccessedMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateWriteMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateWriteMin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numSizeMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numSizeMax;
        private System.Windows.Forms.Label label14;
    }
}

