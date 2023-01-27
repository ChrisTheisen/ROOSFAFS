using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

//highlights
//language syntax
//scrollbar
    //tweak maxValue



namespace Searcher {
    public partial class FancyTextBox : UserControl {
        public FancyTextBox() {
            InitializeComponent();
            Highlighters = new List<HighlightSearch>();
        }


        public FancyTextBox(string filePath) {
            InitializeComponent();
            _filePath = filePath;
            Highlighters = new List<HighlightSearch>();

            loadFileContents();
        }

        public FancyTextBox(string filePath, List<HighlightSearch> highlighters) {
            InitializeComponent();
            _filePath = filePath;
            Highlighters = highlighters;

            loadFileContents();
        }


        private string _filePath { get; set; }
        public string FilePath { get { return _filePath; } }
        private List<HighlightSearch> Highlighters { get; set; }
        public RichTextBox RichTextBox { get { return rtbContent; } }

        public override string Text { get { return rtbContent.Text; } set { rtbContent.Text = value; } }

        private void loadFileContents() {
            var fi = new FileInfo(_filePath);
            if (!fi.Exists) {
                MessageBox.Show("File Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPath.Text = _filePath;
            Text = File.ReadAllText(_filePath);
            Highlight();
            rtbContent.Select(0, 0);

            lblSize.Text = $"Size:{rtbContent.Text.Length} Lines:{rtbContent.Lines.Length}";
        }

        private void btnFindInFolder_Click(object sender, EventArgs e) {
            var argument = "/select, \"" + _filePath + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        public void SetHighlights(List<HighlightSearch> input)
        {
            Highlighters = input;
            Highlight();
        }

        public void Highlight() {
            int pos = rtbContent.SelectionStart;
            RichTextBox buffer = new RichTextBox();
            buffer.Rtf = rtbContent.Rtf;

            buffer.SelectAll();
            buffer.SelectionColor = Color.Black;
            buffer.SelectionBackColor = Color.White;
            buffer.DeselectAll();

            foreach (var highlight in this.Highlighters) {
                var matches = Regex.Matches(rtbContent.Text, highlight.Key);

                foreach (System.Text.RegularExpressions.Match match in matches) {

                    buffer.Select(match.Index, match.Length);
                    buffer.SelectionBackColor = highlight.BackColor;
                    buffer.SelectionColor = highlight.ForeColor;
                }
            }

            rtbContent.Rtf = buffer.Rtf;
            rtbContent.SelectionStart = pos;
            rtbContent.SelectionLength = 0;
        }

        private void rtbContent_SelectionChanged(object sender, EventArgs e)
        {
            int index = rtbContent.SelectionStart;
            int line = rtbContent.GetLineFromCharIndex(index);
            int startOfLine = rtbContent.GetFirstCharIndexOfCurrentLine();
            int selectionLength = rtbContent.SelectedText.Length;

            var col = index - startOfLine;
            lblPos.Text = $"L:{line + 1} Col:{col + 1}";
            if (selectionLength > 0)
            {
                lblPos.Text += $" Sel:{selectionLength}";
            }
        }
    }
}
