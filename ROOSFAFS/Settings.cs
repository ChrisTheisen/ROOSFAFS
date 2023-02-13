using ROOSFAFS.Properties;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Searcher
{
    public partial class SettingsForm : Form
    {
        private const string _defaultRoot = "C:\\";
        private const string _defaultTextEditor = "notepad++.exe";
        private const bool _defaultExternalEditor = false;
        private const int _defaultContextSize = 5;
        private const bool _defaultConfirmCloseTab = true;
        private const bool _defaultLogInfo = true;
        private const bool _defaultLogWarning = true;
        private const bool _defaultLogError = true;
        private const bool _defaultShowToolTip = true;
        private readonly string[] _defaultSkipExtensions = {"svn", "git", "vs", "dll", "exe"};
        private readonly string[] _defaultSkipFolders = {"RECYCLE"};
        private readonly string[] _defaultResultsColumns = {"CreationTime", "LastWriteTime", "LastAccessTime", "Length"};
        private readonly string[] _defaultColumnOrder = { "CreationTime", "LastWriteTime", "LastAccessTime", "Length"};
        private readonly string[] _requiredResultsColumns = {"Name", "Directory"};

        private static string _root
        {
            get => (string)Settings.Default["root"];
            set => Settings.Default["root"] = value;
        }
        private static string _textEditor
        {
            get => (string) Settings.Default["textEditor"];
            set => Settings.Default["textEditor"] = value;
        }
        private static int _contextSize
        {
            get => (int) Settings.Default["contextSize"];
            set => Settings.Default["contextSize"] = value;
        }
        private static bool _externalEditor
        {
            get => (bool) Settings.Default["useExternalFileViewer"];
            set => Settings.Default["useExternalFileViewer"] = value;
        }
        private static bool _confirmCloseTab
        {
            get => (bool)Settings.Default["confirmCloseTab"];
            set => Settings.Default["confirmCloseTab"] = value;
        }
        private static bool _logInfo
        {
            get => (bool)Settings.Default["logInfo"];
            set => Settings.Default["logInfo"] = value;
        }
        private static bool _logWarning
        {
            get => (bool)Settings.Default["logWarning"];
            set => Settings.Default["logWarning"] = value;
        }
        private static bool _logError
        {
            get => (bool)Settings.Default["logError"];
            set => Settings.Default["logError"] = value;
        }
        private static bool _showToolTip
        {
            get => (bool)Settings.Default["showToolTip"];
            set => Settings.Default["showToolTip"] = value;
        }

        private static StringCollection _skipFolders => (StringCollection)Settings.Default["commonSkipFolders"];
        private static StringCollection _skipExtensions => (StringCollection)Settings.Default["commonSkipExtensions"];
        private static StringCollection _resultsColumns => (StringCollection)Settings.Default["resultsColumns"];
        private static StringCollection _columnOrder => (StringCollection)Settings.Default["columnOrder"];

        public string Root => _root;
        public string TextEditor => _textEditor;
        public int ContextSize => _contextSize;
        public bool ExternalEditor => _externalEditor;
        public bool ConfirmCloseTab => _confirmCloseTab;
        public bool LogInfo => _logInfo;
        public bool LogWarning => _logWarning;
        public bool LogError => _logError;
        public bool ShowToolTip => _showToolTip;
        public StringCollection SkipFolders => _skipFolders;
        public StringCollection SkipExtensions => _skipExtensions;

        public StringCollection ColumnOrder
        {
            get
            {
                var temp = new string[_columnOrder.Count];
                _columnOrder.CopyTo(temp, 0);
                var sc = new StringCollection();
                sc.AddRange(_requiredResultsColumns);
                sc.AddRange(temp);

                return sc;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            foreach (var prop in typeof(FileInfo).GetProperties())
            {
                if (_requiredResultsColumns.Contains(prop.Name)) { continue; }
                clbResults.Items.Add(prop.Name);
            }
            populateInputs();
        }

        private void populateInputs()
        {
            txtRoot.Text = _root;
            txtSkipExtensions.Text = string.Join(",", SkipExtensions.Cast<string>().ToArray());
            txtSkipFolders.Text = string.Join(",", SkipFolders.Cast<string>().ToArray());
            txtTextEditor.Text = _textEditor;
            chkExternalFileViewer.Checked = ExternalEditor;
            chkLogInfo.Checked = LogInfo;
            chkLogWarning.Checked = LogWarning;
            chkLogError.Checked = LogError;
            chkShowTooltip.Checked = ShowToolTip;
            numContextSize.Value = ContextSize;
            setAllChecks(clbResults, _resultsColumns);
            setListItems(lstColOrder, _columnOrder);

            txtTextEditor.Visible = chkExternalFileViewer.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtRoot.Text))
            {
                _root = txtRoot.Text;
            }

            if (!string.IsNullOrEmpty(txtTextEditor.Text))
            {
                _textEditor = txtTextEditor.Text;
            }

            _contextSize = (int) numContextSize.Value;
            _externalEditor = chkExternalFileViewer.Checked;
            _logInfo = chkLogInfo.Checked;
            _logWarning = chkLogWarning.Checked;
            _logError = chkLogError.Checked;
            _showToolTip = chkShowTooltip.Checked;
            _skipFolders.Clear();
            _skipExtensions.Clear();
            _resultsColumns.Clear();
            _columnOrder.Clear();
            _skipFolders.AddRange(txtSkipFolders.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            _skipExtensions.AddRange(txtSkipExtensions.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            _resultsColumns.AddRange(clbResults.CheckedItems.OfType<object>().Select(x => x.ToString()).ToArray());
            _columnOrder.AddRange(lstColOrder.Items.OfType<object>().Select(x => x.ToString()).ToArray());

            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtRoot.Text = _root;
            txtTextEditor.Text = _textEditor;
            numContextSize.Value = _contextSize;
            chkExternalFileViewer.Checked = _externalEditor;
            chkLogInfo.Checked = _logInfo;
            chkLogWarning.Checked = _logWarning;
            chkLogError.Checked = _logError;
            chkShowTooltip.Checked = _showToolTip;
            txtSkipFolders.Text = string.Join(",", _skipFolders);
            txtSkipExtensions.Text = string.Join(",", _skipExtensions);
            setAllChecks(clbResults, _resultsColumns);
            setListItems(lstColOrder, _columnOrder);

            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private static void setAllChecks(CheckedListBox chklistbox, IEnumerable itemList)
        {
            if (itemList == null) return;

            foreach (var item in itemList)
            {
                var index = chklistbox.Items.IndexOf(item);
                if (index < 0) continue;
                chklistbox.SetItemChecked(index, true);
            }
        }

        private static void setListItems(ListBox lst, IEnumerable itemList)
        {
            if (itemList == null) return;
            lst.Items.Clear();

            foreach (string item in itemList)
            {
                if (item == "Name") { continue; }
                if (!lst.Items.Contains(item)) lst.Items.Add(item);
            }
        }

        private void barOpacity_Scroll(object sender, EventArgs e)
        {
            Opacity = barOpacity.Value / 100f;
        }

        private void chkExternalFileViewer_CheckedChanged(object sender, EventArgs e)
        {
            txtTextEditor.Visible = chkExternalFileViewer.Checked;
        }

        private void btnRestoreDefault_Click(object sender, EventArgs e)
        {
            _root = _defaultRoot;
            _textEditor = _defaultTextEditor;
            _contextSize = _defaultContextSize;
            _externalEditor = _defaultExternalEditor;
            _confirmCloseTab = _defaultConfirmCloseTab;
            _skipFolders.Clear();
            _skipExtensions.Clear();
            _resultsColumns.Clear();
            _columnOrder.Clear();
            _skipFolders.AddRange(_defaultSkipFolders);
            _skipExtensions.AddRange(_defaultSkipExtensions);
            _resultsColumns.AddRange(_defaultResultsColumns);
            _columnOrder.AddRange(_defaultColumnOrder);
            _logInfo = _defaultLogInfo;
            _logWarning = _defaultLogWarning;
            _logError = _defaultLogError;
            _showToolTip = _defaultShowToolTip;

            populateInputs();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveItem(lstColOrder, -1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveItem(lstColOrder, 1);
        }


        public void MoveItem(ListBox listBox, int direction)
        {
            var newIndex = listBox.SelectedIndex + direction;

            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0
                || newIndex < 0 || newIndex >= listBox.Items.Count)
                return;

            var selected = listBox.SelectedItem;

            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SetSelected(newIndex, true);
        }

        ////has to be a better way to do this part:
        private void clbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbResults.CheckedItems.Contains(clbResults.SelectedItem))
            {
                //add
                lstColOrder.Items.Add(clbResults.SelectedItem);
            }
            else
            {
                //remove
                lstColOrder.Items.Remove(clbResults.SelectedItem);
            }
        }
        private void clbResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (clbResults.CheckedItems.Contains(clbResults.SelectedItem))
            {
                //add
                lstColOrder.Items.Add(clbResults.SelectedItem);
            }
            else
            {
                //remove
                lstColOrder.Items.Remove(clbResults.SelectedItem);
            }
        }

        private void btnRootFolder_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowser.SelectedPath = string.IsNullOrEmpty(txtRoot.Text) ? @"C:\" : txtRoot.Text;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtRoot.Text = folderBrowser.SelectedPath;
                }
            }
            catch {}
        }
    }
}
