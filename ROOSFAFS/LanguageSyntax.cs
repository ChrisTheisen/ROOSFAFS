using System;
using System.Windows.Forms;

namespace Searcher
{
    public partial class LanguageSyntax : Form
    {

        public string Language
        {
            get { return ddlLanguage.Text; }
        }

        public LanguageSyntax()
        {
            InitializeComponent();
            //var languages = Enum.GetValues(temp.Language.GetType());
            //foreach(var l in languages)
            //{
            //    ddlLanguage.Items.Add(l.ToString());
            //}
        }

        private void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
