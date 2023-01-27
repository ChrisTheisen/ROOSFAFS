using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/*
* ignore case: (?i)regex(?-i)
* word: /w
* not word: /W
* digit: /d
* not digit: /D
* whitespace: /s
* not whitespace: /S
* start of string: ^
* end of string: $
* any of: [regex]
* none of: [^regex]
* between(inclusive): [a-m]
* 0+: *
* 1+: +
* 0|1: ?
* match as few as possible: regex+? || regex{2,}?
* capture group: (regex)
* non capturing group: (?:regex)
* positive lookahead: (?=regex)
* negative lookahead: (?!regex)
*/

namespace Searcher
{
    public partial class Regexr : Form
    {
        public string Output = string.Empty;

        public Regexr()
        {
            InitializeComponent();
        }
        public Regexr(string input) {
            InitializeComponent();
            txtInput.Text = input;

            Highlight();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Output = txtInput.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Output = null;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void treeCheatSheet_DoubleClick(object sender, EventArgs e)
        {
            if (treeCheatSheet.SelectedNode == null) { return; }
            var pos = txtInput.SelectionStart;
            var len = txtInput.SelectionLength;
            var injection = treeCheatSheet.SelectedNode.ToolTipText;
            var text = txtInput.Text;

            var selection = txtInput.Text.Substring(pos, len);
            injection = injection.Replace("<selection>", selection);
            text = selection.Length == 0 ? text : txtInput.Text.Replace(selection, "");

            txtInput.Text = $"{text.Substring(0,pos)}{injection}{text.Substring(pos)}";
            txtInput.SelectionStart = pos + injection.Length;
        }

        private void Highlight() {
            int pos = rtbTest.SelectionStart;
            RichTextBox buffer = new RichTextBox();
            buffer.Rtf = rtbTest.Rtf;

            buffer.SelectAll();
            buffer.SelectionColor = Color.Black;
            buffer.SelectionBackColor = Color.White;
            buffer.DeselectAll();

            try {
                var matches = Regex.Matches(rtbTest.Text, txtInput.Text);

                foreach (System.Text.RegularExpressions.Match match in matches) {

                    buffer.Select(match.Index, match.Length);
                    buffer.SelectionBackColor = Color.LightGray;
                    buffer.SelectionColor = Color.Red;
                }
            }
            catch {
                txtInput.BackColor = Color.LightPink;
                return;
            }

            txtInput.BackColor = Color.LightGreen;
            rtbTest.Rtf = buffer.Rtf;
            rtbTest.SelectionStart = pos;
            rtbTest.SelectionLength = 0;
        }

        private void txtInput_TextChanged(object sender, EventArgs e) {
            Highlight();
        }

        private void rtbTest_TextChanged(object sender, EventArgs e) {
            Highlight();
        }
    }
}
