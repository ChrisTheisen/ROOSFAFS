using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Searcher
{
    public partial class MainWindow : Form
    {
        private enum LogType
        {
            Info,
            Warning,
            Error
        }

        //Options area:
        private readonly DataTable _dataSource = new DataTable();
        private readonly List<Match> _matches = new List<Match>();
        private readonly SettingsForm _properties = new SettingsForm();

        private readonly List<SearchHistory> _searchHistories = new List<SearchHistory>();

        private DateTime _startTime;
        private bool _stop;
        private bool _newErrors = false;
        private bool _newWarnings = false;
        private CancellationTokenSource _cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();

            txtRootFolder.Text = _properties.Root;

            folderBrowser.SelectedPath = @"C:\"; 

            rtbLog.AppendText("Opened: " + DateTime.Now);
        }

        #region Events
        private void btnCopyFiles_Click(object sender, EventArgs e)
        {
            try
            {
                selectedToClipboard();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                prepFilter();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }

        private void btnFindInFolder_Click(object sender, EventArgs e)
        {
            try
            {
                findFilesInFolder();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                hideSelectedRows();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdResults.Rows)
                {
                    row.Visible = true;
                }
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void btnRootFolder_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowser.SelectedPath = string.IsNullOrEmpty(txtRootFolder.Text) ? @"C:\" : txtRootFolder.Text;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtRootFolder.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                prepSearch();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _stop = true;
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                viewSelectedItems();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSettings();
        }
        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    prepSearch();
                }
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    prepFilter();
                }
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }
        private void grdResults_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    hideSelectedRows();
                    break;
                case Keys.Enter:
                    viewSelectedItems();
                    break;

            }
        }
        #endregion
        #region private
        private void prepSearch()
        {
            txtSearchString.BackColor = Color.White;
            if (string.IsNullOrEmpty(txtRootFolder.Text) || string.IsNullOrEmpty(txtSearchString.Text))
                return;
            if (chkSearchRegex.Checked)
            {
                try
                {
                    Utility.TestRegexPattern(txtSearchString.Text);
                }
                catch (Exception x)
                {
                    addError("Invalid Regex: " + x.Message);
                    txtSearchString.BackColor = Color.Red;
                    return;
                }
            }

            _startTime = DateTime.Now;
            lblStart.Text = $@"Start Search: {_startTime:HH:mm:ss}";
            addInfo(lblStart.Text);
            lblStopped.Text = string.Empty;
            lblDuration.Text = string.Empty;

            grdResults.ClearSelection();
            //grdResults.DataSource = null;
            

            grdResults.DataSource = _dataSource;
            _dataSource.Rows.Clear();
            _dataSource.Clear();
            _dataSource.DefaultView.Sort = string.Empty;

            _matches.Clear();
            _stop = false;
            _cancellationTokenSource = new CancellationTokenSource();
            var ct = _cancellationTokenSource.Token;

            var skipExt = new string[0];
            if (chkSkipExtensions.Checked)
            {
                skipExt = new string[_properties.SkipExtensions.Count];
                _properties.SkipExtensions.CopyTo(skipExt, 0);
            }
            skipExt = skipExt.Concat(txtSkipExtension.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).ToArray();

            var skipFolder = new string[0];
            if (chkSkipFolders.Checked)
            {
                skipFolder = new string[_properties.SkipFolders.Count];
                _properties.SkipFolders.CopyTo(skipFolder, 0);
            }
            skipFolder = skipFolder.Concat(txtSkipFolder.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).ToArray();

            var searchExt = txtSearchExtension.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var sp = new SearchParameters(ct)
            {
                SearchType = _selectedSearchType,
                IsRecursive = chkRecursive.Checked,
                IsRegex = chkSearchRegex.Checked,
                RootFolder = txtRootFolder.Text,
                SearchString = txtSearchString.Text,
                SearchExtension = searchExt,
                SkipExtension = skipExt,
                SkipFolder = skipFolder,
                StopAfterN = (int)numStopAfterN.Value,
                AccessMin = dateAccessedMin.Value,
                AccessMax = dateAccessedMax.Value,
                WriteMin = dateWriteMin.Value,
                WriteMax = dateWriteMax.Value,
                SizeMin = numSizeMin.Value,
                SizeMax = numSizeMax.Value                
            };

            txtFilter.Text = null;
            //tabControl.Visible = false;
            lblCount.Text = @"Hits:0";

            foreach (Control c in Controls)
            {
                if (c is Button || c is CheckBox || c is TextBox)
                {
                    c.Enabled = false;
                }
            }

            btnStop.Visible = true;
            btnStop.Enabled = true;
            btnStop.BackColor = Color.Red;
            btnStop.Focus();
            setDataColumns();

            Task.Run(() => doSearch(sp), ct);
        }
        private void hideSelectedRows()
        {
            var selected = new List<int>();
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                selected.Add(row.Index);
            }

            grdResults.CurrentCell = null;
            foreach (var item in selected)
            {
                grdResults.Rows[item].Visible = false;
            }

            grdResults.ClearSelection();
        }
        private void doSearch(object o)
        {
            var failedFiles = new Dictionary<string, Exception>();

            if (!(o is SearchParameters)) { return; }
            var sp = (SearchParameters)o;
            Utility.SearchFolder(sp, failedFiles, _matches, lblStatus, lblCount, grdResults, _dataSource);

            _searchHistories.Add(new SearchHistory(sp, _matches, _stop));
            updateHistory();

            postSearchUiCleanup(failedFiles);
        }
        private void postSearchUiCleanup(Dictionary<string, Exception> failedFiles)
        {
            foreach (var key in failedFiles.Keys)
            {
                addWarning($"Skipped {key}: {failedFiles[key]}");
            }

            populateRows();

            MultiThread.SetProperty(btnSearch, "Enabled", true);
            MultiThread.UpdateToolStripStatus(lblStatus, _stop ? $"Stopped: {_dataSource.Rows.Count} hits" : $"Done: {_dataSource.Rows.Count} hits");
            var endTime = DateTime.Now;
            var duration = endTime - _startTime;
            MultiThread.UpdateToolStripStatus(lblStopped, $@"Stop Search: {endTime:HH:mm:ss}");
            addInfo($@"Stop Search: {endTime:HH:mm:ss}");
            MultiThread.UpdateToolStripStatus(lblDuration, $@"Duration: {duration.TotalSeconds}s");


            foreach (Control c in Controls)
            {
                if (c is Button || c is CheckBox || c is TextBox)
                {
                    MultiThread.SetProperty(c, "Enabled", true);
                }
            }

            MultiThread.SetProperty(btnStop, "BackColor", SystemColors.Control);
            MultiThread.SetProperty(btnStop, "Enabled", false);
            MultiThread.SetProperty(btnStop, "Visible", false);

            MultiThread.InvokeMethod(txtSearchString, "Focus", null);
            //MultiThread.SetProperty(grdResults, "DataSource", _dataSource);

            MultiThread.SetProperty(tabControl, "SelectedIndex", 0);

            //might be a better way to do this, but this works.
            if (grdResults.Columns.Count > 0)
            {
                foreach (DataGridViewColumn col in grdResults.Columns)
                {
                    MultiThread.SetChildProperty(grdResults, col, "AutoSizeMode", DataGridViewAutoSizeColumnMode.AllCells);
                }
                foreach (DataGridViewColumn col in grdResults.Columns)
                {
                    int w = col.Width;
                    MultiThread.SetChildProperty(grdResults, col, "AutoSizeMode", DataGridViewAutoSizeColumnMode.None);
                    MultiThread.SetChildProperty(grdResults, col, "Width", w);
                }
            }

            MultiThread.SetProperty(tabControl, "Visible", true);
            MultiThread.InvokeMethod(grdResults, "Focus", null);
        }

        private void prepFilter()
        {
            grdResults.ClearSelection();

            foreach (Control c in Controls) { c.Enabled = false; }
            btnStop.Enabled = true;
            btnStop.BackColor = Color.Red;
            btnStop.Focus();

            _cancellationTokenSource = new CancellationTokenSource();
            var ct = _cancellationTokenSource.Token;

            var sp = new SearchParameters(ct)
            {
                SearchType = _selectedFilterType,
                IsRecursive = false,
                IsRegex = chkFilterRegex.Checked,
                RootFolder = "GRID",
                SearchString = txtFilter.Text,
                SearchExtension = null,
                SkipExtension = null,
                SkipFolder = null,
                StopAfterN = 1000
            };
            addInfo($@"Start Filter: {_startTime:HH:mm:ss}");

            Task.Run(() => doFilter(sp), ct);
        }
        private void doFilter(SearchParameters sp)
        {
            foreach (DataGridViewRow row in grdResults.Rows)
            {
                var rowText = new StringBuilder();
                foreach (DataGridViewCell cell in row.Cells) { rowText.Append(cell.Value); }
                var itemText = rowText.ToString();

                //Check row text
                var match = Regex.IsMatch(itemText, sp.SearchString);

                //Check FileContents
                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
                if (!match && sp.SearchType == SearchType.FileContents && File.Exists(filePath))
                {
                    match = Utility.SearchContents(sp, filePath, out var _);
                }

                var selectMatch = (string)MultiThread.GetProperty(ddlFilterInclude, "Text");
                if (match == (selectMatch == "Select Match"))
                {
                    row.Selected = true;
                }
            }

            postFilterUiCleanup();

        }
        private void postFilterUiCleanup()
        {
            foreach (Control c in Controls)
            {
                MultiThread.SetProperty(c, "Enabled", true);
            }
            MultiThread.SetProperty(btnStop, "Enabled", false);
            MultiThread.SetProperty(btnStop, "BackColor", SystemColors.Control);

            addInfo($@"End Filter: {_startTime:HH:mm:ss}");
        }

        private void viewSelectedItems()
        {
            var files = new List<string>();
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
                if (File.Exists(filePath))
                {
                    files.Add(filePath);
                }
            }


            if (_properties.ExternalEditor)
            {
                foreach (var filePath in files)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(_properties.TextEditor, filePath);
                    }
                    catch (Exception x)
                    {
                        addError($"Error opening text Text Editor '{_properties.TextEditor}'");
                        addError(x.Message);
                        break;
                    }
                }
            }
            else if (files.Count > 0)
            {
                var tv = new TextViewer();
                tv.ShowFiles("Selected Files", files, txtSearchString.Text, _properties.ShowToolTip);
            }

        }

        private void findFilesInFolder()
        {
            var c = 0;
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
                if (!File.Exists(filePath)) continue;

                var argument = "/select, \"" + filePath + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
                c++;
            }
            lblStatus.Text = c + " File Locations Opened.";
        }
        private void selectedToClipboard()
        {
            var filePaths = new System.Collections.Specialized.StringCollection();
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
                if (!File.Exists(filePath)) continue;

                filePaths.Add(filePath);
            }

            Clipboard.SetFileDropList(filePaths);
            lblStatus.Text = filePaths.Count + " Files copied to clipboard";
        }

        private void setDataColumns()
        {
            var hiddenRows = (from DataGridViewRow row in grdResults.Rows where !row.Visible select row.Index).ToList();
            _dataSource.Columns.Clear();
            foreach (var column in _properties.ColumnOrder.OfType<string>().Distinct())
            {
                var type = typeof(string);
                switch (column)
                {
                    case "Length":
                        type = typeof(int);
                        break;
                    case "LastAccessTime":
                    case "LastAccessTimeUTC":
                    case "LastWriteTime":
                    case "LastWriteTimeUTC":
                        type = typeof(DateTime);
                        break;
                    default:
                        type = typeof(string);
                        break;
                }

                _dataSource.Columns.Add(column, type);
            }
            populateRows();
            grdResults.CurrentCell = null;
            foreach (var i in hiddenRows)
            {
                if (i >= grdResults.RowCount) { break; }
                grdResults.Rows[i].Visible = false;
            }
        }

        private void populateRows()
        {
            MultiThread.SetProperty(grdResults, "DataSource", null);
            _dataSource.Rows.Clear();
            foreach (var match in _matches)
            {
                var newRow = _dataSource.NewRow();
                new RowData(match, _selectedSearchType).BuildRow(newRow, _dataSource.Columns, match.FirstMatch);
                _dataSource.Rows.Add(newRow);
            }
            MultiThread.SetProperty(grdResults, "DataSource", _dataSource);
        }
        private SearchType _selectedSearchType
        {
            get
            {
                if (rdoContents.Checked) { return SearchType.FileContents; }
                if (rdoFileName.Checked) { return SearchType.FileName; }
                if (rdoFolderName.Checked) { return SearchType.Foldername; }
                return SearchType.FileContents;
            }
        }

        private SearchType _selectedFilterType
        {
            get
            {
                if (ddlFilterType.SelectedIndex == 0) { return SearchType.FileContents; }
                if (ddlFilterType.SelectedIndex == 1) { return SearchType.FileName; }
                return SearchType.FileContents;
            }
        }

        private void showSettings()
        {
            try
            {
                if (_properties.ShowDialog() == DialogResult.OK)
                {
                    setDataColumns();
                }
            }
            catch (Exception x)
            {
                addError(x.Message);
            }

        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];
            if (e.Index == 3 && (_newErrors || _newWarnings))
            {
                if (_newErrors)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                }
                else if (_newWarnings)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.BlueViolet), e.Bounds);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
            }


            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 3)
            {
                _newErrors = false;
                _newWarnings = false;
            }
        }

        private void showToolTip(Control control, string text)
        {
            if (!_properties.ShowToolTip) { return; }

            text += "\r\n\r\n (Disable tooltips in setttings)";
            var p = new Point(control.Width, control.Height);

            toolTip.Show(text, control, p);
        }

        private void hideToolTip()
        {
            toolTip.Hide(this);
        }

        #endregion

        #region logging
        private void addLog(string message, LogType logType)
        {
            Color lineColor;

            switch (logType)
            {
                case LogType.Info:
                    if (!_properties.LogInfo) return;
                    lineColor = Color.Black;
                    break;
                case LogType.Warning:
                    if (!_properties.LogWarning) return;
                    lineColor = Color.BlueViolet;
                    _newWarnings = true;
                    tabControl.Refresh();
                    break;
                case LogType.Error:
                    if (!_properties.LogError) return;
                    lineColor = Color.Red;
                    _newErrors = true;
                    tabControl.Refresh();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }


            var preLength = int.Parse(MultiThread.GetProperty(rtbLog, "TextLength").ToString());

            MultiThread.InvokeMethod(rtbLog, "AppendText", new object[] { $"\r\n {DateTime.Now} - " });
            MultiThread.InvokeMethod(rtbLog, "AppendText", new object[] { message });

            var postLength = int.Parse(MultiThread.GetProperty(rtbLog, "TextLength").ToString());
            MultiThread.InvokeMethod(rtbLog, "Select", new object[] { preLength, postLength });

            MultiThread.SetProperty(rtbLog, "SelectionColor", lineColor);

            switch (logType)
            {
                case LogType.Info:
                    MultiThread.SetProperty(rtbLog, "SelectionColor", Color.Black);
                    break;
                case LogType.Warning:
                    MultiThread.SetProperty(rtbLog, "SelectionColor", Color.BlueViolet);
                    break;
                case LogType.Error:
                    MultiThread.SetProperty(rtbLog, "SelectionColor", Color.Red);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }

            MultiThread.InvokeMethod(rtbLog, "Select", new object[] { 0, 0 });
        }

        private void addInfo(string message)
        {
            addLog(message, LogType.Info);
        }

        private void addWarning(string message)
        {
            addLog(message, LogType.Warning);
        }

        private void addError(string message)
        {
            addLog(message, LogType.Error);
        }
        #endregion

        #region history

        private void updateHistory()
        {
            Action action = () =>
            {
                lstSearchHistory.Items.Clear();
                lstSearchHistory.Items.AddRange(_searchHistories.ToArray());
            };

            if (lstSearchHistory.InvokeRequired)
            {
                lstSearchHistory.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void lstSearchHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hi = (SearchHistory)lstSearchHistory.SelectedItem;
            if (hi == null) { return; }

            txtSearchString.Text = hi.SearchParameters.SearchString;
            txtRootFolder.Text = hi.SearchParameters.RootFolder;

            switch (hi.SearchParameters.SearchType)
            {
                case SearchType.FileContents:
                    rdoContents.Checked = true;
                    break;
                case SearchType.FileName:
                    rdoFileName.Checked = true;
                    break;
                case SearchType.Foldername:
                    rdoFolderName.Checked = true;
                    break;
            }

            var skipFolders = hi.SearchParameters.SkipFolder.Where(x => !_properties.SkipFolders.Contains(x));
            var skipExtensions = hi.SearchParameters.SkipExtension.Where(x =>
                !_properties.SkipExtensions.Contains(x) &&
                !_properties.SkipExtensions.Contains(x.Replace(".", ""))
            );

            txtSkipFolder.Text = string.Join(", ", skipFolders);
            txtSkipExtension.Text = string.Join(", ", skipExtensions);


            txtSearchExtension.Text = string.Join(", ", hi.SearchParameters.SearchExtension);
            numStopAfterN.Value = hi.SearchParameters.StopAfterN;

            _matches.Clear();
            _matches.AddRange(hi.Matches);
            populateRows();

            tabControl.SelectedIndex = 0;
        }

        #endregion



        private void grdResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            viewSelectedItems();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void btnBuildRegex_Click(object sender, EventArgs e)
        {
            try
            {
                string input = string.IsNullOrEmpty(txtSearchString.Text) ? "[REGEX GOES HERE]" : txtSearchString.Text;
                var helper = new Regexr(input);
                if (helper.ShowDialog() == DialogResult.OK)
                {
                    txtSearchString.Text = helper.Output;
                    chkSearchRegex.Checked = true;
                }

                helper.Dispose();
            }
            catch (Exception x)
            {
                addError(x.Message);
            }
        }

        #region tooltips
        private void control_MouseLeave(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void control_MouseHover(object sender, EventArgs e)
        {
            if (!(sender is Control)) return;

            string text = null;
            switch ((sender as Control).Name)
            {
                case "grdResults":
                    if (grdResults.Rows.Count == 0) return;
                    text = "* Double click row to open file.\r\n* Hold CTRL or SHIFT and click to select multiple rows.\r\n* Press 'Delete' to hide selected files.\r\n* Press 'Enter' to open selected files.";
                    break;
                case "txtSearchString":
                    text = "Enter search string here and press 'Enter' or click Search button.";
                    break;
                case "btnBuildRegexSearch":
                    text = "Get help building regex.";
                    break;
                case "btnCopyFiles":
                    text = "Copy selected files to clipboard.";
                    break;
                case "btnView":
                    text = "Open selected files in text viewer. Custom text viewer can be set in Settings.";
                    break;
                case "btnFindInFolder":
                    text = "Open folder of all selected files.";
                    break;
                case "btnFilter":
                    text = "Filter results based on the filter string.";
                    break;
                case "txtFilter":
                    text = "Do a follow up search. Search remaining results and either select matches or non-matches.";
                    break;
                case "btnRestore":
                    text = "Restore all hidden rows.";
                    break;
                case "btnRemove":
                    text = "Hide all selected rows.";
                    break;
                case "rdoContents":
                    text = "Search file contents, name, and path.";
                    break;
                case "rdoFileName":
                    text = "Search file name and path.";
                    break;
                case "rdoFolderName":
                    text = "Search folder name and path.";
                    break;
                case "txtSkipFolder":
                    text = "Comma delimited list of folders to skip.";
                    break;
                case "chkSkipFolders":
                    text = "Skip the common folders to skip defined in the settings.";
                    break;
                case "txtSearchExtension":
                    text = "If blank all file extensions not set in the Skip Extionsion will be searched.\r\nIf populated this is a comma delimited list of file extensions to search.\r\nAll files with a different file extension will be skipped.\r\nThis will supersede the Skip Extensions below.";
                    break;
                case "txtSkipExtension":
                    text = "Comma delimited list of file extensions to skip.";
                    break;
                case "chkSkipExtensions":
                    text = "Skip the file extentions to skip defined in the settings.";
                    break;
                case "chkStopAfterN":
                    text = "Stop searching after the desired number of results has been met.";
                    break;
                case "lstSearchHistory":
                    text = "Double click an item to restore the search results.\r\nThis does not redo the search but only recovers the past results.\r\nAny changes to files or folders since the search was done will not be shown.\r\nResets when ROOSFAFS is closed.";
                    break;
                case "rtbLog":
                    text = "Logs past actions. Set the level of logging in the settings.\r\nResets when ROOSFAFS is closed.";
                    break;
                case "dateAccessedMin":
                    text = "";
                    break;
                case "dateAccessedMax":
                    text = "";
                    break;
                case "dateWriteMin":
                    text = "";
                    break;
                case "dateWriteMax":
                    text = "";
                    break;

            }

            if (string.IsNullOrWhiteSpace(text)) return;
            showToolTip((Control)sender, text);

        }
        #endregion

    }
}
