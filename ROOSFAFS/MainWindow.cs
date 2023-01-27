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

//BUGS

//TODO
//Re-upload to GitHub


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
        private void BtnBuildMultiSearch_Click(object sender, EventArgs e)
        {

        }
        private void BtnContext_Click(object sender, EventArgs e)
        {
            try
            {
                ViewSelectedContext();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            try {
                SelectedToClipboard();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                PrepFilter();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnFindInFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FindFilesInFolder();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                HideSelectedRows();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
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
                AddError(x.Message);
            }
        }
        private void BtnRootFolder_Click(object sender, EventArgs e)
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
                AddError(x.Message);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PrepSearch();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _stop = true;
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                ViewSelectedItems();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }
        private void TxtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PrepSearch();
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void TxtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PrepFilter();
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void GrdResults_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    HideSelectedRows();
                    break;

            }
        }
        #endregion
        #region private
        private void PrepSearch()
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
                    AddError("Invalid Regex: " + x.Message);
                    txtSearchString.BackColor = Color.Red;
                    return;
                }
            }

            _startTime = DateTime.Now;
            lblStart.Text = $@"Start Search: {_startTime:HH:mm:ss}";
            AddInfo(lblStart.Text);
            lblStopped.Text = string.Empty;
            lblDuration.Text = string.Empty;

            grdResults.ClearSelection();
            grdResults.DataSource = null;
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
            skipExt = skipExt.Concat(txtSkipExtention.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).ToArray();

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
                SearchType = SelectedSearchType,
                IsRecursive = chkRecursive.Checked,
                IsRegex = chkSearchRegex.Checked,
                RootFolder = txtRootFolder.Text,
                SearchString = txtSearchString.Text,
                SearchExtension = searchExt,
                SkipExtension = skipExt,
                SkipFolder = skipFolder,
                StopAfterN = chkStopAfterN.Checked ? (int?)numStopAfterN.Value : null
            };

            txtFilter.Text = null;
            tabControl.Visible = false;
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
            SetDataColumns();

            Task.Run(() => DoSearch(sp), ct);
        }
        private void HideSelectedRows()
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
        private void DoSearch(object o)
        {
            var failedFiles = new Dictionary<string, Exception>();

            if (!(o is SearchParameters)) { return; }
            var sp = (SearchParameters)o;
            Utility.SearchFolder(sp, failedFiles, _matches, lblStatus, lblCount);

            _searchHistories.Add(new SearchHistory(sp, _matches, _stop));
            UpdateHistory();

            PostSearchUiCleanup(failedFiles);
        }
        private void PostSearchUiCleanup( Dictionary<string, Exception> failedFiles )
	    {
	        foreach (var key in failedFiles.Keys)
	        {
                AddWarning($"Skipped {key}: {failedFiles[key]}");
	        }
	        PopulateRows();

            MultiThread.SetProperty( btnSearch, "Enabled", true );
		    MultiThread.UpdateToolStripStatus( lblStatus, _stop ? $"Stopped: {_dataSource.Rows.Count} hits"   : $"Done: {_dataSource.Rows.Count} hits" );
		    var endTime = DateTime.Now;
		    var duration = endTime - _startTime;
		    MultiThread.UpdateToolStripStatus( lblStopped, $@"Stop Search: {endTime:HH:mm:ss}" );
            AddInfo($@"Stop Search: {endTime:HH:mm:ss}");
		    MultiThread.UpdateToolStripStatus( lblDuration, $@"Duration: {duration.TotalSeconds}s" );


			foreach ( Control c in Controls )
		    {
			    if ( c is Button || c is CheckBox || c is TextBox )
			    {
				    MultiThread.SetProperty( c, "Enabled", true );
			    }
		    }

		    MultiThread.SetProperty( btnStop, "BackColor", SystemColors.Control );
		    MultiThread.SetProperty( btnStop, "Enabled", false );
            MultiThread.SetProperty( btnStop, "Visible", false );

            MultiThread.InvokeMethod( txtSearchString, "Focus", null );
		    MultiThread.SetProperty( grdResults, "DataSource", _dataSource );

            MultiThread.SetProperty( tabControl, "SelectedIndex", 0 );

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

        private void PrepFilter()
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
                SearchType = SelectedFilterType,
                IsRecursive = false,
                IsRegex = chkFilterRegex.Checked,
                RootFolder = "GRID",
                SearchString = txtFilter.Text,
                SearchExtension = null,
                SkipExtension = null,
                SkipFolder = null,
                StopAfterN = null
            };
            AddInfo($@"Start Filter: {_startTime:HH:mm:ss}");

            Task.Run(() => DoFilter(sp), ct);
        }
        private void DoFilter(SearchParameters sp)
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

            PostFilterUiCleanup();

        }
        private void PostFilterUiCleanup()
        {
            foreach (Control c in Controls) { 
                MultiThread.SetProperty(c, "Enabled", true);
            }
            MultiThread.SetProperty(btnStop, "Enabled", false);
            MultiThread.SetProperty(btnStop, "BackColor", SystemColors.Control);

            AddInfo($@"End Filter: {_startTime:HH:mm:ss}");
        }

        private void ViewSelectedItems()
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
                    catch(Exception x)
                    {
                        AddError($"Error opening text Text Editor '{_properties.TextEditor}'");
                        AddError(x.Message);
                        break;
                    }
                }
            }
            else if(files.Count > 0)
            {
                var tv = new TextViewer();
                tv.ShowFiles("Selected Files", files, txtSearchString.Text);
            }

        }
        private void ViewSelectedContext()
        {
            var matchFiles = new List<FileContext>();
            const string title = "Context";
            var searchString = txtSearchString.Text;
            var c = 0;
            var mc = 0;

            foreach (DataGridViewRow row in grdResults.Rows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
	            var matchLines = chkSearchRegex.Checked ? GetFileContextsRegex(filePath) : GetFileContexts(filePath);
                matchFiles.Add(GetContexts(matchLines, filePath, _properties.ContextSize));

                mc += matchLines.Length;
	            // ReSharper disable once LocalizableElement
                lblStatus.Text = $"{++c} files searched; {mc} total matches";
            }

            var tv = new TextViewer();
            tv.ShowContexts(title, matchFiles, searchString, chkSearchRegex.Checked);
        }
        private int[] GetFileContexts(string filePath)
        {
            var matchLines = new List<int>();
            var tempSearch = txtSearchString.Text;
            var lineNum = 0;

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
	                lineNum++;
	                if ( string.IsNullOrEmpty(line)) continue;

                    if (line.Contains(tempSearch))
                    {
                        matchLines.Add(lineNum);
                    }
                }
            }

            return matchLines.ToArray();
        }
        private int[] GetFileContextsRegex(string filePath)
        {
            var matchLines = new List<int>();
            var searchString = txtSearchString.Text;
            var lineNum = 0;

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    lineNum++;
	                if (string.IsNullOrEmpty(line)) continue;

                    if (Regex.IsMatch(line, searchString))
                    {
                        matchLines.Add(lineNum);
                    }
                }
            }

            return matchLines.ToArray();
        }
        private static FileContext GetContexts(IList<int> matchLines, string filePath, int contextLines)
        {
            var output = new FileContext(filePath);
            var halfContext = contextLines / 2;
            for (var i = 0; i < matchLines.Count; i++) { matchLines[i] = Math.Max(0, matchLines[i] - halfContext); }

            var lineNum = 0;
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    lineNum++;
                    var line = sr.ReadLine();
                    if (matchLines.Contains(lineNum)) { output.Chunks.Add(new ContextGroup()); }

                    foreach (var chunk in output.Chunks)
                    {
                        if (chunk.Lines.Count < contextLines)
                        {
                            chunk.Lines.Add(new ContextLine(lineNum, line));
                        }
                    }
                }
            }
            return output;
        }

        private void FindFilesInFolder()
        {
            var c = 0;
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
	            if (!File.Exists(filePath)) continue;

	            // combine the arguments together
	            var argument = "/select, \"" + filePath + "\"";
	            System.Diagnostics.Process.Start("explorer.exe", argument);
	            c++;
            }
	        // ReSharper disable once LocalizableElement
            lblStatus.Text = c + " File Locations Opened.";
        }
        private void SelectedToClipboard()
        {
            var filePaths = new System.Collections.Specialized.StringCollection();
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
	            if (!File.Exists(filePath)) continue;

	            // combine the arguments together
	            filePaths.Add(filePath);
            }

            Clipboard.SetFileDropList(filePaths);
	        // ReSharper disable once LocalizableElement
            lblStatus.Text = filePaths.Count + " Files copied to clipboard";
        }

        private void SetDataColumns()
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
            PopulateRows();
            grdResults.CurrentCell = null;
            foreach (var i in hiddenRows)
            {
                if (i >= grdResults.RowCount) { break; }
                grdResults.Rows[i].Visible = false;
            }
        }

        private void PopulateRows()
        {
            _dataSource.Rows.Clear();
            foreach (var match in _matches)
            {
                var newRow = _dataSource.NewRow();
                new RowData(match, SelectedSearchType).BuildRow(newRow, _dataSource.Columns, match.FirstMatch);
                _dataSource.Rows.Add(newRow);
            }
        }
        private void ChkStopAfterN_CheckedChanged(object sender, EventArgs e)
        {
            numStopAfterN.Enabled = chkStopAfterN.Checked;
        }

        private SearchType SelectedSearchType
        {
            get
            {
                if (rdoContents.Checked) { return SearchType.FileContents; }
                if (rdoFileName.Checked) { return SearchType.FileName; }
                if (rdoFolderName.Checked) { return SearchType.Foldername; }
                return SearchType.FileContents;
            }
        }

        private SearchType SelectedFilterType
        {
            get
            {
                if (ddlFilterType.SelectedIndex == 0) { return SearchType.FileContents; }
                if (ddlFilterType.SelectedIndex == 1) { return SearchType.FileName; }
                return SearchType.FileContents;
            }
        }

        private void ShowSettings()
        {
            try
            {
                if (_properties.ShowDialog() == DialogResult.OK)
                {
                    SetDataColumns();
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }

        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
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

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 3)
            {
                _newErrors = false;
                _newWarnings = false;
            }
        }
        #endregion

        #region logging
        private void AddLog(string message, LogType logType)
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

            MultiThread.InvokeMethod(rtbLog, "Select", new object[] { 0 ,0 });
        }

        private void AddInfo(string message)
        {
            AddLog(message, LogType.Info);
        }

        private void AddWarning(string message)
        {
            AddLog(message, LogType.Warning);
        }

        private void AddError(string message)
        {
            AddLog(message, LogType.Error);
        }
        #endregion

        #region history

        private void UpdateHistory()
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

        private void LstSearchHistory_MouseDoubleClick(object sender, MouseEventArgs e)
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
                !_properties.SkipExtensions.Contains(x.Replace(".",""))
            );

            txtSkipFolder.Text = string.Join(", ", skipFolders);
            txtSkipExtention.Text = string.Join(", ", skipExtensions);


            txtSearchExtension.Text = string.Join(", ", hi.SearchParameters.SearchExtension);
            chkStopAfterN.Checked = hi.SearchParameters.StopAfterN.HasValue;
            numStopAfterN.Value = hi.SearchParameters.StopAfterN ?? 0;

            _matches.Clear();
            _matches.AddRange(hi.Matches);
            PopulateRows();

            tabControl.SelectedIndex = 0;
        }

        #endregion



        private void GrdResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1) { return; }
            ViewSelectedItems();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            new About().ShowDialog();
        }

        private void BtnBuildRegex_Click(object sender, EventArgs e) {
            try {
                string input = string.IsNullOrEmpty(txtSearchString.Text) ? "[REGEX GOES HERE]" : txtSearchString.Text;
                var helper = new Regexr(input);
                if (helper.ShowDialog() == DialogResult.OK) {
                    txtSearchString.Text = helper.Output;
                    chkSearchRegex.Checked = true;
                }

                helper.Dispose();
            }
            catch (Exception x) {
                AddError(x.Message);
            }
        }
    }
}
