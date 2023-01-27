namespace Searcher
{
    partial class Regexr
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Any Character (sans newline)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ignore Case");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Word");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Not Word");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Digit");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Not Digit");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Space");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("NotSpace");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Any Of");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("None Of");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("In Range");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Character Classes", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Start of String");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("End of String");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Word Boundary");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Not Word Boundary");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Anchors", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode(".");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("*");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("\\");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Tab");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Linefeed");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Carriage Return");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Escaped Characters", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Capture Group");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Non Capture Group");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Backreference Group#");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Positive Lookahead");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Negative Lookahead");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Groups & Lookaround", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("0 or more");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("1 or more");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("0 or 1");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Exactly #");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("# or more");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Between #");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Lazy Match");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Lazy Match at least #");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Match A or B");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Quantifiers & Alternations", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39});
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitRegexr = new System.Windows.Forms.SplitContainer();
            this.treeCheatSheet = new System.Windows.Forms.TreeView();
            this.rtbTest = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRegexr)).BeginInit();
            this.splitRegexr.Panel1.SuspendLayout();
            this.splitRegexr.Panel2.SuspendLayout();
            this.splitRegexr.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(499, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(580, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(485, 74);
            this.txtInput.TabIndex = 3;
            this.txtInput.Text = "REGEX";
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 35);
            this.panel1.TabIndex = 4;
            // 
            // splitRegexr
            // 
            this.splitRegexr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRegexr.Location = new System.Drawing.Point(0, 0);
            this.splitRegexr.Name = "splitRegexr";
            // 
            // splitRegexr.Panel1
            // 
            this.splitRegexr.Panel1.AutoScroll = true;
            this.splitRegexr.Panel1.Controls.Add(this.treeCheatSheet);
            // 
            // splitRegexr.Panel2
            // 
            this.splitRegexr.Panel2.Controls.Add(this.rtbTest);
            this.splitRegexr.Panel2.Controls.Add(this.txtInput);
            this.splitRegexr.Size = new System.Drawing.Size(667, 349);
            this.splitRegexr.SplitterDistance = 178;
            this.splitRegexr.TabIndex = 5;
            // 
            // treeCheatSheet
            // 
            this.treeCheatSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCheatSheet.Location = new System.Drawing.Point(0, 0);
            this.treeCheatSheet.Name = "treeCheatSheet";
            treeNode1.Name = "anyChar";
            treeNode1.Text = "Any Character (sans newline)";
            treeNode1.ToolTipText = ".";
            treeNode2.Name = "ignoreCase";
            treeNode2.Text = "Ignore Case";
            treeNode2.ToolTipText = "(?i)<selection>(?-i)";
            treeNode3.Name = "word";
            treeNode3.Text = "Word";
            treeNode3.ToolTipText = "\\w";
            treeNode4.Name = "notWord";
            treeNode4.Text = "Not Word";
            treeNode4.ToolTipText = "\\W";
            treeNode5.Name = "digit";
            treeNode5.Text = "Digit";
            treeNode5.ToolTipText = "\\d";
            treeNode6.Name = "notDigit";
            treeNode6.Text = "Not Digit";
            treeNode6.ToolTipText = "\\D";
            treeNode7.Name = "space";
            treeNode7.Text = "Space";
            treeNode7.ToolTipText = "\\s";
            treeNode8.Name = "notSpace";
            treeNode8.Text = "NotSpace";
            treeNode8.ToolTipText = "\\S";
            treeNode9.Name = "anyOf";
            treeNode9.Text = "Any Of";
            treeNode9.ToolTipText = "[<selection>]";
            treeNode10.Name = "noneOf";
            treeNode10.Text = "None Of";
            treeNode10.ToolTipText = "[^<selection>]";
            treeNode11.Name = "inRange";
            treeNode11.Text = "In Range";
            treeNode11.ToolTipText = "[a-z]";
            treeNode12.Name = "CharacterClasses";
            treeNode12.Text = "Character Classes";
            treeNode13.Name = "start";
            treeNode13.Text = "Start of String";
            treeNode13.ToolTipText = "^";
            treeNode14.Name = "end";
            treeNode14.Text = "End of String";
            treeNode14.ToolTipText = "$";
            treeNode15.Name = "wordBoundary";
            treeNode15.Text = "Word Boundary";
            treeNode15.ToolTipText = "\\b";
            treeNode16.Name = "notWordBoundary";
            treeNode16.Text = "Not Word Boundary";
            treeNode16.ToolTipText = "\\W";
            treeNode17.Name = "anchors";
            treeNode17.Text = "Anchors";
            treeNode18.Name = "period";
            treeNode18.Text = ".";
            treeNode18.ToolTipText = "\\.";
            treeNode19.Name = "asterisk";
            treeNode19.Text = "*";
            treeNode19.ToolTipText = "\\*";
            treeNode20.Name = "slash";
            treeNode20.Text = "\\";
            treeNode20.ToolTipText = "\\\\";
            treeNode21.Name = "tab";
            treeNode21.Text = "Tab";
            treeNode21.ToolTipText = "\\t";
            treeNode22.Name = "linefeed";
            treeNode22.Text = "Linefeed";
            treeNode22.ToolTipText = "\\n";
            treeNode23.Name = "carriageReturn";
            treeNode23.Text = "Carriage Return";
            treeNode23.ToolTipText = "\\r";
            treeNode24.Name = "escapedCharacters";
            treeNode24.Text = "Escaped Characters";
            treeNode25.Name = "captureGroup";
            treeNode25.Text = "Capture Group";
            treeNode25.ToolTipText = "(<selection>)";
            treeNode26.Name = "nonCaptureGroup";
            treeNode26.Text = "Non Capture Group";
            treeNode26.ToolTipText = "(?:<selection>)";
            treeNode27.Name = "backreference";
            treeNode27.Text = "Backreference Group#";
            treeNode27.ToolTipText = "\\#";
            treeNode28.Name = "posLookahead";
            treeNode28.Text = "Positive Lookahead";
            treeNode28.ToolTipText = "(?=<selection>)";
            treeNode29.Name = "negLookahead";
            treeNode29.Text = "Negative Lookahead";
            treeNode29.ToolTipText = "(?!<selection>)";
            treeNode30.Name = "groups";
            treeNode30.Text = "Groups & Lookaround";
            treeNode31.Name = "zeroOrMore";
            treeNode31.Text = "0 or more";
            treeNode31.ToolTipText = "*";
            treeNode32.Name = "oneOrMore";
            treeNode32.Text = "1 or more";
            treeNode32.ToolTipText = "+";
            treeNode33.Name = "zeroOrOne";
            treeNode33.Text = "0 or 1";
            treeNode33.ToolTipText = "?";
            treeNode34.Name = "exactCount";
            treeNode34.Text = "Exactly #";
            treeNode34.ToolTipText = "{#}";
            treeNode35.Name = "atLeast";
            treeNode35.Text = "# or more";
            treeNode35.ToolTipText = "{#,}";
            treeNode36.Name = "between";
            treeNode36.Text = "Between #";
            treeNode36.ToolTipText = "{#,#}";
            treeNode37.Name = "lazyMatch";
            treeNode37.Text = "Lazy Match";
            treeNode37.ToolTipText = "+?";
            treeNode38.Name = "minMatch";
            treeNode38.Text = "Lazy Match at least #";
            treeNode38.ToolTipText = "{#,}?";
            treeNode39.Name = "or";
            treeNode39.Text = "Match A or B";
            treeNode39.ToolTipText = "|";
            treeNode40.Name = "quantifiers";
            treeNode40.Text = "Quantifiers & Alternations";
            this.treeCheatSheet.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode17,
            treeNode24,
            treeNode30,
            treeNode40});
            this.treeCheatSheet.Size = new System.Drawing.Size(178, 349);
            this.treeCheatSheet.TabIndex = 0;
            this.treeCheatSheet.DoubleClick += new System.EventHandler(this.treeCheatSheet_DoubleClick);
            // 
            // rtbTest
            // 
            this.rtbTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTest.Location = new System.Drawing.Point(0, 74);
            this.rtbTest.Name = "rtbTest";
            this.rtbTest.Size = new System.Drawing.Size(485, 275);
            this.rtbTest.TabIndex = 4;
            this.rtbTest.Text = "Input REGEX above. \n\nClick \"OK\" to replace search string with REGEX above.\n\nClick" +
    " \"Cancel\" to close this window without replacing search string.";
            this.rtbTest.TextChanged += new System.EventHandler(this.rtbTest_TextChanged);
            // 
            // Regexr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 384);
            this.ControlBox = false;
            this.Controls.Add(this.splitRegexr);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Regexr";
            this.ShowIcon = false;
            this.Text = "Regex Helper";
            this.panel1.ResumeLayout(false);
            this.splitRegexr.Panel1.ResumeLayout(false);
            this.splitRegexr.Panel2.ResumeLayout(false);
            this.splitRegexr.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRegexr)).EndInit();
            this.splitRegexr.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitRegexr;
        private System.Windows.Forms.TreeView treeCheatSheet;
        private System.Windows.Forms.RichTextBox rtbTest;
    }
}