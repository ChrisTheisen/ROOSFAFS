using System;
using System.Windows.Forms;

namespace Searcher {
    public partial class About : Form {
        public About() {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            var link = (LinkLabel)sender;
            System.Diagnostics.Process.Start(link.Text);
        }
    }
}
