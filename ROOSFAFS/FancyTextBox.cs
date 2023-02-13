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
            _highlighters = new List<HighlightSearch>();
        }

        public FancyTextBox(string filePath) {
            InitializeComponent();
            FilePath = filePath;
            _highlighters = new List<HighlightSearch>();

            loadFileContents();
        }

        public FancyTextBox(string filePath, List<HighlightSearch> highlighters) {
            InitializeComponent();
            FilePath = filePath;
            _highlighters = highlighters;

            loadFileContents();
        }


        public string FilePath { get; private set; }

        private List<HighlightSearch> _highlighters { get; set; }
        public RichTextBox RichTextBox { get { return rtbContent; } }

        public override string Text { get { return rtbContent.Text; } set { rtbContent.Text = value; } }

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
            /*
             Try this at some point:
                using System.Runtime.InteropServices;

                .......................................

                [DllImport("user32.dll")]
                static extern int SendMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, IntPtr lParam);

                .......................................

                SendMessage(myRichTextBox.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(-1));

             */
            var caret = rtbContent.GetFirstCharIndexFromLine(first);
            if (caret == -1) return;
            rtbContent.Focus();
            rtbContent.Select(caret, 0);
        }

        private void loadFileContents() {
            var fi = new FileInfo(FilePath);
            if (!fi.Exists) {
                MessageBox.Show("File Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPath.Text = FilePath;
            Text = File.ReadAllText(FilePath);
            Highlight();
            rtbContent.Select(0, 0);

            lblSize.Text = $"Size:{rtbContent.Text.Length} Lines:{rtbContent.Lines.Length}";

            generateLineNumbers();
        }

        private void btnFindInFolder_Click(object sender, EventArgs e) {
            var argument = "/select, \"" + FilePath + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        public void SetHighlights(List<HighlightSearch> input)
        {
            _highlighters = input;
            Highlight();
        }

        public void Highlight() {
            int pos = rtbContent.SelectionStart;
            RichTextBox buffer = new RichTextBox
            {
                Rtf = rtbContent.Rtf
            };

            buffer.SelectAll();
            buffer.SelectionColor = Color.Black;
            buffer.SelectionBackColor = Color.White;
            buffer.DeselectAll();

            foreach (var highlight in this._highlighters) {
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

        private void btnCopyPath_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPath.Text);
        }
    }
}
