using ROOSFAFS.Properties;
using System;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;


//side bar items
//    import/save language syntax
//    custom user syntax?
//    replace? (needs TextViewer to have a save)

namespace Searcher
{
    public partial class TextViewerSettingsForm : Form
    {
        private const bool _defaultShowRightPanel = true;
        private const bool _defaultConfirmCloseTab = false;
        private const int _defaultFontSize = 10;
        private const int _defaultScrollSpeed = 5;
        private readonly string _defaultFont = FontFamily.GenericSansSerif.Name;

        private static bool _showRightPanel
        {
            get => (bool)Settings.Default["tvShowRightPanel"];
            set => Settings.Default["tvShowRightPanel"] = value;
        }
        private static bool _confirmCloseTab
        {
            get => (bool)Settings.Default["tvConfirmCloseTab"];
            set => Settings.Default["tvConfirmCloseTab"] = value;
        }
        private static float _fontSize
        {
            get => (float)Settings.Default["tvFontSize"];
            set => Settings.Default["tvFontSize"] = value;
        }

        private static int _scrollSpeed
        {
            get => (int)Settings.Default["tvScrollSpeed"];
            set => Settings.Default["tvScrollSpeed"] = value;
        }

        private static string _fontFamily
        {
            get => (string)Settings.Default["tvFontFamily"];
            set => Settings.Default["tvFontFamily"] = value;
        }

        private static string _syntaxJSON
        {
            get => (string)Settings.Default["tvSyntaxJSON"];
            set => Settings.Default["tvSyntaxJSON"] = value;
        }

        public bool showRightPanel => _showRightPanel;
        public Font font { get => new Font(_fontFamily, _fontSize); }
        public string syntaxJSON => _syntaxJSON;
        public bool confirmCloseTab => _confirmCloseTab;
        public int scrollSpeed => _scrollSpeed;
        public TextViewerSettingsForm()
        {
            InitializeComponent();
            PopulateInputs();
        }

        private void PopulateInputs()
        {
            foreach (var ff in FontFamily.Families)
            {
                //FCTB only supports monospaced fonts.
                //if (IsMonospaced(ff))
                ddlFontFamily.Items.Add(new ListItem(ff.Name, ff.ToString()));
            }
            numFontSize.Value = (decimal)_fontSize;
            chkShowRightPanel.Checked = _showRightPanel;
            chkConfirmTabClose.Checked = _confirmCloseTab;
            ddlFontFamily.Text = _fontFamily;
            numScrollSpeed.Value = _scrollSpeed;
        }

        private bool IsMonospaced(FontFamily ff)
        {
            Font ft = new Font(ff, 10);
            var tests = new [] { "iii", "aaa", "ZZZ", "%%%", "###", "aaa", "BBB", "lll", "mmm", ",,,", "..." };
            float w = TextRenderer.MeasureText(tests[0], ft).Width;

            foreach (var s in tests)
            {
                if (TextRenderer.MeasureText(s, ft).Width != w)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _fontSize = (float)numFontSize.Value;
            _fontFamily = ddlFontFamily.Text;
            _showRightPanel = chkShowRightPanel.Checked;
            _confirmCloseTab = chkConfirmTabClose.Checked;
            _scrollSpeed = (int)numScrollSpeed.Value;

            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void BarOpacity_Scroll(object sender, EventArgs e)
        {
            Opacity = barOpacity.Value / 100f;
        }

        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            _showRightPanel = _defaultShowRightPanel;
            _confirmCloseTab = _defaultConfirmCloseTab;
            _fontFamily = _defaultFont;
            _fontSize = _defaultFontSize;
            _scrollSpeed = _defaultScrollSpeed;

            PopulateInputs();
        }
    }
}
