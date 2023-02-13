using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Searcher
{
	internal class Utility
	{

		public static string GetVersion(string file)
		{
			var vers = FileVersionInfo.GetVersionInfo(file);
			return vers.ProductVersion;
		}

		public static DataTable GetFileDatas(string[] filePaths)
		{
			var output = new DataTable();
			output.Columns.Add("Name", typeof(string));
			output.Columns.Add("Path", typeof(string));
			output.Columns.Add("Version", typeof(string));
			output.Columns.Add("Created", typeof(DateTime));
			output.Columns.Add("Opened", typeof(DateTime));
			output.Columns.Add("Modified", typeof(DateTime));
			output.Columns.Add("Size", typeof(string));

			foreach (var filePath in filePaths)
			{
				var row = output.NewRow();
				getFileData(filePath, row);
				output.Rows.Add(row);
			}

			return output;
		}

		private static void getFileData(string filePath, DataRow input)
		{
			if (!File.Exists(filePath)) return;

			var fi = new FileInfo(filePath);
			var vers = FileVersionInfo.GetVersionInfo(filePath);
			input["Name"] = fi.Name;
			input["Path"] = filePath;
			input["Version"] = vers.ProductVersion;
			input["Created"] = fi.CreationTime;
			input["Opened"] = fi.LastAccessTime;
			input["Modified"] = fi.LastWriteTime;
			input["Size"] = fi.Length + " bytes";
		}

		public static void TestRegexPattern(string pattern)
		{
			if (string.IsNullOrEmpty(pattern)) throw new ArgumentException("Regex Pattern Is Empty.");

			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			Regex.Match("", pattern);
		}

		#region search stuff methods
		internal static void SearchFolder(SearchParameters sp,
			IDictionary<string, Exception> failedFiles, List<Match> matches,
			ToolStripStatusLabel status, Label fileCount, DataGridView resultGrid, DataTable dataSource)
		{
			searchFolder(sp, sp.RootFolder, failedFiles, matches, status, fileCount, resultGrid, dataSource);
		}

		private static void searchFolder(SearchParameters sp, string searchPath, IDictionary<string, Exception> failedFiles, List<Match> matches, ToolStripStatusLabel status, Control fileCount, DataGridView resultGrid, DataTable dataSource)
		{
			if (sp.CancellationToken.IsCancellationRequested
				 || matches.Count >= sp.StopAfterN
				 || !Directory.Exists(searchPath)
				 || sp.SkipFolders().Any(skip => searchPath.ToUpper().Contains(skip.ToUpper()) || skip.ToUpper().Contains(searchPath.ToUpper())))
                return;

            MultiThread.UpdateToolStripStatus(status, searchPath);
			searchFiles(sp, searchPath, failedFiles, matches, resultGrid, dataSource);
			MultiThread.SetProperty(fileCount, "Text", "Hits:" + matches.Count);

			if (!sp.IsRecursive)
				return;

			var dirs = Directory.GetDirectories(searchPath);
			foreach (var dir in dirs)
			{
				searchFolder(sp, dir, failedFiles, matches, status, fileCount, resultGrid, dataSource);
			}
		}

		private static void searchFiles(SearchParameters sp, string filePath, IDictionary<string, Exception> failedFiles, List<Match> matches, DataGridView resultGrid, DataTable dataSource)
		{
			try
			{
				var matchBatch = new List<Match>();
				var di = new DirectoryInfo(filePath);
				if (di.LastAccessTime < sp.AccessMin || di.LastAccessTime > sp.AccessMax
					|| di.LastWriteTime < sp.WriteMin || di.LastWriteTime > sp.WriteMax) 
					return;

				if (sp.SearchType == SearchType.Foldername)
				{
					if (searchString(sp, filePath))
                    {
						var m = new Match(di);
						addMatch(sp, matches, resultGrid, dataSource, m);
					}
					return;
				}

				var files = Directory.GetFiles(filePath);
				foreach (var file in files)
				{
					try
					{
						if (sp.SearchType == SearchType.FileContents || sp.SearchType == SearchType.FileName)
						{
							searchFile(sp, file, matches, resultGrid, dataSource);
						}
					}
					catch (Exception x) { failedFiles.Add(file, x); }
				}
			}
			catch (Exception x)
			{
				if (!x.Message.StartsWith("Access"))
				{ failedFiles.Add(filePath, x); }
			}
		}

		private static void searchFile(SearchParameters sp, string filePath, List<Match> matches, DataGridView resultGrid, DataTable dataSource)
		{
			if (sp.CancellationToken.IsCancellationRequested || matches.Count >= sp.StopAfterN)
				return;

			var fi = new FileInfo(filePath);
			if (skipFile(sp, fi))
				return;

			var matchLine = string.Empty;
			var isMatch = searchString(sp, filePath);
			if (!isMatch && sp.SearchType == SearchType.FileContents)
			{
				isMatch = SearchContents(sp, filePath, out matchLine);
			}

			if (isMatch)
			{
				var m = new Match(fi, matchLine);
				addMatch(sp, matches, resultGrid, dataSource, m);
			}
		}

		public static bool SearchContents(SearchParameters sp, string filePath, out string firstMatch)
		{
			firstMatch = null;
			var fi = new FileInfo(filePath);
			if (fi.Length > 50 * 1024 * 1024) { }

			var buffer = new StringBuilder();
			using (var reader = new StreamReader(filePath))
			{
				var temp = new char[1024];
				for (var len = reader.Read(temp, 0, 1024); len != 0; len = reader.Read(temp, 0, 1024))
				{
					buffer.Append(temp);
					if (searchString(sp, buffer.ToString()))
					{
						firstMatch = buffer.ToString();
						return true;
					}

					while (buffer.Length > 4096) { buffer.Remove(0, 1024); }

					if (sp.CancellationToken.IsCancellationRequested)
						return false;
				}
			}

			return false;
		}

		private static bool searchString(SearchParameters sp, string hayStack)
		{
			if (sp.IsRegex)
			{
				return Regex.IsMatch(hayStack, sp.SearchString);
			}
			return CultureInfo.CurrentCulture.CompareInfo.IndexOf(hayStack, sp.SearchString, CompareOptions.IgnoreCase) >= 0;
        }

        private static void addMatch(SearchParameters sp, List<Match> matches, 
			DataGridView dataGrid, DataTable dataSource, Match match)
        {
			matches.Add(match);

			//add matches in batches to limit flicker
			var batch = matches.Where(x => !x.IsAdded);
			if (batch.Count() < 20) { return; }

			var vScroll = Math.Max(0, dataGrid.FirstDisplayedScrollingRowIndex);
			MultiThread.SetProperty(dataGrid, "Visible", false);
			MultiThread.SetProperty(dataGrid, "DataSource", null);

			foreach (var m in batch)
			{
				var newRow = dataSource.NewRow();
				new RowData(m, sp.SearchType).BuildRow(newRow, dataSource.Columns, m.FirstMatch);
				dataSource.Rows.Add(newRow);
				m.IsAdded = true;
			}

            MultiThread.SetProperty(dataGrid, "DataSource", dataSource);
			MultiThread.SetProperty(dataGrid, "FirstDisplayedScrollingRowIndex", vScroll);
			MultiThread.SetProperty(dataGrid, "Visible", true);
		}


		/// <summary>
		/// Return true if file should be skipped and not searched.
		/// </summary>
		/// <param name="sp"></param>
		/// <param name="fi"></param>
		/// <returns></returns>
		private static bool skipFile(SearchParameters sp, FileInfo fi)
		{

			var skip = sp.SkipExtensions();
			var search = sp.SearchExtensions();

			if (skip.Contains(fi.Extension))
			{
				return true;
			}

			if (fi.LastAccessTime < sp.AccessMin || fi.LastAccessTime > sp.AccessMax
				|| fi.LastWriteTime < sp.WriteMin || fi.LastWriteTime > sp.WriteMax)
			{
				return true;
			}

			if (fi.Length < sp.SizeMin || fi.Length > sp.SizeMax) { return true; }

			IEnumerable<string> includedFiles = search as string[] ?? search.ToArray();
			return includedFiles.Any() && !(includedFiles.Contains(fi.Extension)
											 || includedFiles.Contains(fi.Extension.TrimStart('.')));
		}
		#endregion
	}
	public enum SearchType { FileContents, FileName, Foldername }

	public class Match
	{
		public FileInfo FileInfo { get; set; }
		public DirectoryInfo DirectoryInfo { get; set; }
		public string FirstMatch { get; set; }
		public bool IsAdded { get; set; }

		public Match(FileInfo fileInfo, string firstMatch)
		{
			FileInfo = fileInfo;
			FirstMatch = firstMatch;
			DirectoryInfo = null;
			IsAdded = false;
		}
		public Match(DirectoryInfo directoryInfo)
		{
			FileInfo = null;
			FirstMatch = null;
			DirectoryInfo = directoryInfo;
			IsAdded = false;
		}
	}

	public class SearchHistory
	{
		public SearchParameters SearchParameters { get; }
		public Match[] Matches { get; }
		public bool SearchCanceled { get; }

		public SearchHistory(SearchParameters searchParameters, List<Match> matches, bool searchCanceled)
        {
			SearchParameters = searchParameters;
			Matches = new Match[matches.Count];
			matches.CopyTo(Matches);
			SearchCanceled = searchCanceled;
        }

		public override string ToString()
        {
			return $"Key:{SearchParameters.SearchString} Type:{SearchParameters.SearchType} Root:{SearchParameters.RootFolder} Matches:{Matches.Length}";
        }
	}

	public class SearchParameters
    {
		public SearchType SearchType { get; set; }

        public string SearchString { get; set; }

	    public string RootFolder { get; set; }

	    public string[] SkipFolder { get; set; }

	    public string[] SearchExtension { get; set; }

	    public string[] SkipExtension { get; set; }

		public int StopAfterN { get; set; }

		public decimal SizeMin { get; set; }
		public decimal SizeMax { get; set; }

		public DateTime AccessMin { get; set; }
		public DateTime AccessMax { get; set; }
		public DateTime WriteMin { get; set; }
		public DateTime WriteMax { get; set; }

	    public CancellationToken CancellationToken { get; }

        public bool IsRegex;
        public bool IsRecursive;

	    public SearchParameters(CancellationToken cancellationToken)
	    {
		    CancellationToken = cancellationToken;
	    }

	    public string[] SkipFolders()
        {
            return SkipFolder;
        }

        public string[] SearchExtensions()
        {
            var output = SearchExtension;
            for (var i = 0; i < output.Length; i++) { if (!output[i].StartsWith(".")) { output[i] = '.' + output[i]; } }
            return output;
        }

        public string[] SkipExtensions()
        {
            var output = SkipExtension;
            for (var i = 0; i < output.Length; i++) { if (!output[i].StartsWith(".")) { output[i] = '.' + output[i]; } }
            return output;
        }
    }

    public class FileContext
    {
        public List<ContextGroup> Chunks = new List<ContextGroup>();
        public string FilePath;

        public FileContext(string filePath)
        {
            FilePath = filePath;
        }
    }

    public class ContextGroup
    {
        public List<ContextLine> Lines = new List<ContextLine>();
    }

    public class ContextLine
    {
        public int LineNumber;
        public string Line;

        public ContextLine(int lineNumber, string line)
        {
            LineNumber = lineNumber;
            Line = line;
        }
    }

	public class RowData
	{
		private readonly FileInfo _fileInfo;
		private readonly DirectoryInfo _directoryInfo;

		private SearchType _searchType {get; set;}
        public RowData(Match input, SearchType searchType)
		{
			_searchType = searchType;
			switch (searchType)
			{
				case SearchType.FileName:
				case SearchType.FileContents:
					{
						_fileInfo = input.FileInfo;
						break;
					}
				case SearchType.Foldername:
					{
						_directoryInfo = input.DirectoryInfo;
						break;
					}
			}
		}

		public void BuildRow(DataRow row, DataColumnCollection columns, string matchLine)
		{
            switch (_searchType)
			{
				case SearchType.FileName:
				case SearchType.FileContents:
					{
						populateFileRow(row, columns);
						break;
					}
				case SearchType.Foldername:
					{
                        populateDirectoryRow(row, columns);
                        break;
					}
			}

            if (columns.Contains("First Match"))
            {
                row["First Match"] = matchLine.Trim();
            }
        }


		private void populateFileRow(DataRow row, DataColumnCollection columns)
		{
			foreach (var prop in _fileInfo.GetType().GetProperties())
            {
                if (columns.Contains(prop.Name))
                {
					row[prop.Name] = prop.GetValue(_fileInfo);
                }
            }
        }

        private void populateDirectoryRow(DataRow row, DataColumnCollection columns)
		{
            foreach (var prop in _directoryInfo.GetType().GetProperties())
            {
				var name = prop.Name == "FullName" ? "Directory" : prop.Name;

                if (columns.Contains(name))
                {
                    row[name] = prop.GetValue(_directoryInfo);
                }

            }
        }
    }
}
