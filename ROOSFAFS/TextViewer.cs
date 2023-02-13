using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace Searcher
{
    //Save
    //find/replace
    //Contexts: fix and unhide button?

    public partial class TextViewer : Form
    {
        private readonly TextViewerSettingsForm _properties = new TextViewerSettingsForm();
        private readonly LanguageSyntax _languageSyntax = new LanguageSyntax();
        private List<HighlightSearch> _highlights
        {
            get
            {
                var temp = new List<HighlightSearch>();
                foreach (DataRow row in Highlighters.Rows) {
                    temp.Add(new HighlightSearch() {
                        Key = (string)row[HighlightSearch.Attributes.Key.ToString()],
                        BackColor = (Color)row[HighlightSearch.Attributes.BackColor.ToString()],
                        ForeColor = (Color)row[HighlightSearch.Attributes.ForeColor.ToString()]

                    });
                }
                return temp;
            }
        }
        private bool _showToolTip = true;

        #region build content
        public TextViewer()
        {
            InitializeComponent();

            dgvHighlights.DataSource = Highlighters;
            dgvFind.DataSource = FindHits;

            foreach (var key in Enum.GetValues(typeof(HighlightSearch.Attributes))) {
                var index = (int)(HighlightSearch.Attributes)key;

                dgvHighlights.Columns[key.ToString()].DisplayIndex = index;
            }
        }

        public void ShowFiles(string title, List<string> filePaths, string searchString, bool showToolTips)
        {
            Show();
            AddHilighter(searchString, Color.Red, SystemColors.Control);

            _showToolTip = showToolTips;
            Text = title;

            foreach (var filePath in filePaths)
            {
                var fi = new FileInfo(filePath);
                if (!fi.Exists) continue;

                var tp = new TabPage(fi.Name);

                FancyTextBox ftb = new FancyTextBox(fi.FullName, _highlights)
                {
                    Dock = DockStyle.Fill
                };
                tp.Controls.Add(ftb);

                if (tabFiles.TabCount == 0) { tabFiles.TabPages.Add(tp); }
                else { tabFiles.TabPages.Insert(0, tp); }
            }

            tabFiles.SelectedIndex = 0;
            dgvHighlights.ClearSelection();
            txtNewHilight.Focus();
        }

        private void enforceSettings()
        {
            //TODO: FONT

            if (!_properties.showRightPanel)
            {
                spltTextViewer.Panel2Collapsed = true;
                spltTextViewer.Panel2.Hide();
            }
            else
            {
                spltTextViewer.Panel2Collapsed = false;
                spltTextViewer.Panel2.Show();
            }


        }
        #endregion

        #region hilights
        private void lblSample_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    colorDialog.Color = lblSample.ForeColor;
                    break;
                case MouseButtons.Right:
                    colorDialog.Color = lblSample.BackColor;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    return;
            }

            var dr = colorDialog.ShowDialog();
	        if (dr != DialogResult.OK) return;

	        switch (e.Button)
	        {
		        case MouseButtons.Left:
			        lblSample.ForeColor = colorDialog.Color;
			        break;
		        case MouseButtons.Right:
			        lblSample.BackColor = colorDialog.Color;
			        break;
		        case MouseButtons.None:
			        break;
		        case MouseButtons.Middle:
			        break;
		        case MouseButtons.XButton1:
			        break;
		        case MouseButtons.XButton2:
			        break;
		        default:
			        throw new ArgumentOutOfRangeException();
	        }
        }

        private void btnAddHilight_Click(object sender, EventArgs e)
        {
            AddHilighter(txtNewHilight.Text, lblSample.ForeColor, lblSample.BackColor);
        }

        public void AddHilighter(string searchString, Color foreColor, Color backColor)
        {
            if(Highlighters.Rows.Count == 15) { MessageBox.Show(@"Can only have 15 highlighers active at a time."); return; }
            if (string.IsNullOrEmpty(searchString)) { return; }
            var newRow = Highlighters.NewRow();

            newRow[HighlightSearch.Attributes.Key.ToString()] = searchString;
            newRow[HighlightSearch.Attributes.Sample.ToString()] = searchString;
            newRow[HighlightSearch.Attributes.ForeColor.ToString()] = foreColor;
            newRow[HighlightSearch.Attributes.BackColor.ToString()] = backColor;

            Highlighters.Rows.Add(newRow);

            var lastRow = dgvHighlights.Rows[dgvHighlights.Rows.GetLastRow(DataGridViewElementStates.Visible)];

            lastRow.Cells[HighlightSearch.Attributes.Sample.ToString()].Style.ForeColor = foreColor;
            lastRow.Cells[HighlightSearch.Attributes.Sample.ToString()].Style.BackColor = backColor;

            lastRow.Cells[HighlightSearch.Attributes.Sample.ToString()].Style.SelectionForeColor = foreColor;
            lastRow.Cells[HighlightSearch.Attributes.Sample.ToString()].Style.SelectionBackColor = backColor;

            lblCounter.Text = Highlighters.Rows.Count + @"/15";
            txtNewHilight.Text = null;
            fixGridColumnWidths(dgvHighlights);
            hilightTab();
        }

        private void hilightTab()
        {
            foreach (TabPage tab in tabFiles.TabPages)
            {
                var ftb = tab.Controls.Find("FancyTextBox", false)[0] as FancyTextBox;
                ftb.SetHighlights(_highlights);
            }
        }

        private void txtNewHilight_TextChanged(object sender, EventArgs e)
        {
            lblSample.Text = txtNewHilight.Text;
        }

        private void tabFiles_TabIndexChanged(object sender, EventArgs e)
        {
            hilightTab();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeSelected();
        }

        private void removeSelected()
        {
            foreach (DataGridViewRow row in dgvHighlights.SelectedRows)
            {
                Highlighters.Rows.RemoveAt(row.Index);
            }

            dgvHighlights.ClearSelection();
            lblCounter.Text = Highlighters.Rows.Count + @"/15";
            fixGridColumnWidths(dgvHighlights);

            hilightTab();
        }
        #endregion

        #region find/replace
        private void btnFind_Click(object sender, EventArgs e)
        {
            FindHits.Rows.Clear();

            findInTab(tabFiles.SelectedIndex);
        }

        private void btnFindAllTabs_Click(object sender, EventArgs e)
        {
            FindHits.Rows.Clear();

            for (var i = 0; i < tabFiles.TabCount; i++)
            {
                findInTab(i);
            }
        }

        private void dgvFind_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            selectFind(e.RowIndex);
        }
        private void dgvFind_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) { return; }
            selectFind(e.RowIndex);
        }

        private void selectFind(int index) {
            //find tab
            var tabIndex = int.Parse(dgvFind.Rows[index].Cells["#"].Value.ToString());

            //find location in text.
            var line = int.Parse(dgvFind.Rows[index].Cells["Line"].Value.ToString());
            var col = int.Parse(dgvFind.Rows[index].Cells["Col"].Value.ToString());
            goTo(tabIndex, line, col);
        }

        private void findInTab(int tabIndex)
        {
            var ftb = (FancyTextBox)tabFiles.TabPages[tabIndex].Controls[0];

            Regex regex = new Regex(txtFind.Text);
            MatchCollection matches = regex.Matches(ftb.Text);
            foreach(System.Text.RegularExpressions.Match match in matches)
            {
                var dataRow = FindHits.NewRow();

                dataRow[colIndex] = tabIndex;
                dataRow[colFile] = tabFiles.TabPages[tabIndex].Text;

                var line = ftb.RichTextBox.GetLineFromCharIndex(match.Index);
                dataRow[colLineNum] = line+1;
                dataRow[colContext] = ftb.RichTextBox.Lines[line];
                dataRow[colChar] = match.Index - ftb.RichTextBox.GetFirstCharIndexFromLine(line);

                FindHits.Rows.Add(dataRow);
            }
            fixGridColumnWidths(dgvFind);
        }

        private void fixGridColumnWidths(DataGridView input)
        {
            foreach (DataGridViewColumn col in input.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            foreach (DataGridViewColumn col in input.Columns)
            {
                int w = col.Width;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = w;
            }
        }

        private void goTo(int tabIndex, int line, int Char)
        {
            line -= 1;
            if(tabIndex < 0 || line < 0 || Char < 0) { return; }

            tabFiles.SelectedIndex = tabIndex;
            var ftb = (FancyTextBox)tabFiles.SelectedTab.Controls[0];

            var index = ftb.RichTextBox.GetFirstCharIndexFromLine(line) + Char;
            ftb.RichTextBox.SelectionStart = index;
            ftb.RichTextBox.ScrollToCaret();

            Regex regex = new Regex(txtFind.Text);
            var matchLength = regex.Match(ftb.RichTextBox.Lines[line], Char).Length;
            ftb.RichTextBox.SelectionLength = matchLength;

            ftb.Focus();
        }
        #endregion

        #region events
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_properties.ShowDialog() == DialogResult.OK)
                {
                    enforceSettings();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error setting settings:" + x.Message);
            }
        }
        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_languageSyntax.ShowDialog() == DialogResult.OK)
                {
                    //do language syntax
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error setting settings:" + x.Message);
            }
        }

        private void dgvHighlights_DoubleClick(object sender, EventArgs e)
        {
            var rows = (sender as DataGridView)?.SelectedRows;
            if (rows?.Count == 1)
            {
                txtFind.Text = rows[0].Cells[0].Value.ToString();
                FindHits.Rows.Clear();

                for (var i = 0; i < tabFiles.TabCount; i++)
                {
                    findInTab(i);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tabbed Text Viewer made for reviewing ROOSFAFS Search Results.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var ftb = (FancyTextBox)tabFiles.SelectedTab.Controls[0];
                File.WriteAllText(ftb.FilePath, ftb.Text);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error Saving File:" + x.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeTab(tabFiles.SelectedIndex);
        }

        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion
        private void tabFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is TabControl tc)) return;
            if (e.Button != MouseButtons.Middle) return;

            for (var i = 0; i < tc.TabCount; i++)
            {
                var rect = tc.GetTabRect(i);
                if (!rect.Contains(e.Location)) continue;
                closeTab(i);
                fixSearchResults(i);
                break;
            }
        }

        private void closeTab(int index)
        {
            if (!_properties.confirmCloseTab
                || MessageBox.Show(@"Would you like to Close this Tab?", @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabFiles.TabPages.RemoveAt(index);
            }
        }

        private void fixSearchResults(int index)
        {
            for (var i = 0; i < FindHits.Rows.Count; i++)
            {
                var temp = int.Parse(FindHits.Rows[i]["#"].ToString());

                if (index < temp)
                {
                    FindHits.Rows[i]["#"] = temp - 1;
                }
                else if (index == temp)
                {
                    FindHits.Rows.RemoveAt(i--);
                }
                else if (index > temp)
                {
                    //this is fine.
                }
            }
        }



        #region ToolTips
        private void dgvHighlights_MouseHover(object sender, EventArgs e)
        {
            if (!dgvHighlights.Visible || dgvHighlights.RowCount == 0) { return; }
            showToolTip(dgvHighlights, "Double click row to search files.");
        }
        private void dgvFind_MouseHover(object sender, EventArgs e)
        {
            if (!dgvFind.Visible || dgvFind.RowCount == 0) { return; }
            showToolTip(dgvFind, "Double click row to go to location.");
        }

        private void tabFiles_MouseHover(object sender, EventArgs e)
        {
            showToolTip(tabFiles, "Middle click to close tab.");
        }

        private void dgvFind_MouseLeave(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void dgvHighlights_MouseLeave(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void tabFiles_MouseLeave(object sender, EventArgs e)
        {
            hideToolTip();
        }


        private void showToolTip(Control control, string text)
        {
            if (!_showToolTip) { return; }

            text += "\r\n\r\n (Disable tooltips in ROOSFAFS setttings)";
            var p = new Point(control.Location.X + control.Width, control.Location.Y + (control.Height / 5));
            toolTip.Show(text, control, p);
        }

        private void hideToolTip()
        {
            toolTip.Hide(this);
        }
        #endregion
    }
}
