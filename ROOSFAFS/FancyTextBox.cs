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
        private List<int> lineHeights = new List<int>();

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

        private void generateLineNumbersOBD()
        {
            var totalHeight = 0;
            for (var i = 0; i < rtbContent.Lines.Length; i++)
            {
                var lHeight = rtbContent.Font.Height;
                var lbl = new Label
                {
                    Name = $"lbl{i}",
                    Text = (i + 1).ToString(),
                    Location = new Point(0, totalHeight),
                    Font = rtbContent.Font,
                    Padding = new Padding(0),
                    Height = lHeight,
                    Width = pnlLineNumbers.Width,
                    TextAlign = ContentAlignment.TopRight
                };

                pnlLineNumbers.Controls.Add(lbl);

                totalHeight += lHeight;
                lineHeights.Add(totalHeight);
            }
            pnlLineNumbers.VerticalScroll.Maximum = totalHeight;
        }

        private void generateLineNumbers()
        {
            int start = rtbContent.GetCharIndexFromPosition(new Point(0, 0));
            int first = rtbContent.GetLineFromCharIndex(start);

            var lHeight = rtbContent.Font.Height;
            var lines = (rtbContent.Height / lHeight) + 1;

            var max = rtbContent.Lines.Length;

            var totalHeight = 0;
            for (int i = 1; i <= lines; i++)
            {
                var text = i + first > max ? "" : (i + first).ToString();

                var name = $"lbl{i}";
                var c = pnlLineNumbers.Controls.Find(name, false);
                if (c.Length == 0)
                {
                    var lbl = new Label
                    {
                        Name = name,
                        Text = text,
                        Location = new Point(0, totalHeight),
                        Font = rtbContent.Font,
                        Padding = new Padding(0),
                        Height = lHeight,
                        Width = pnlLineNumbers.Width,
                        TextAlign = ContentAlignment.TopRight
                    };

                    lbl.Click += (object sender, EventArgs e) =>
                    {
                        rtbContent.Focus();
                        var temp = int.Parse((sender as Label).Text) -1;
                        rtbContent.Select(rtbContent.GetFirstCharIndexFromLine(temp), rtbContent.Lines[temp].Length);
                    };

                    pnlLineNumbers.Controls.Add(lbl);
                    totalHeight += lHeight;
                }
                else
                {
                    c[0].Text = text;
                    totalHeight += c[0].Height;
                }
            }

            //hack to keep line numbers inline with text. Otherwise sometimes it is a fraction of a line off.
            var caret = rtbContent.GetFirstCharIndexFromLine(first);
            if (caret == -1) return;
            rtbContent.Focus();
            rtbContent.Select(caret, 0);
        }

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

            generateLineNumbers();
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

        private void rtbContent_VScroll(object sender, EventArgs e)
        {
            generateLineNumbers();
        }

        private void rtbContent_Resize(object sender, EventArgs e)
        {
            generateLineNumbers();
        }
    }
}
