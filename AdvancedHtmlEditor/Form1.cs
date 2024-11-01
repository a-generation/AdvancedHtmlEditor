using Microsoft.Web.WebView2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedHtmlEditor
{
    public partial class Form1 : Form
    {
        private TabControl tabControl;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            ShowFormInfo();
        }
        private void ShowFormInfo()
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }

        private void InitializeUI()
        {
            this.Text = "HTML Instant editor";
            this.Width = 1200;
            this.Height = 800;

            tabControl = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tabControl);

            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Items.Add(new ToolStripButton("New Tab", null, NewTab_Click));
            toolStrip.Items.Add(new ToolStripButton("Open", null, OpenFile_Click));
            toolStrip.Items.Add(new ToolStripButton("Save", null, SaveFile_Click));
            toolStrip.Items.Add(new ToolStripButton("Insert Doctype", null, InsertDoctype_Click));
            toolStrip.Items.Add(new ToolStripButton("Bold", null, BoldText_Click));
            toolStrip.Items.Add(new ToolStripButton("Search & Replace", null, SearchReplace_Click));

            this.Controls.Add(toolStrip);
            this.MainMenuStrip = new MenuStrip();
            this.Controls.Add(toolStrip);
        }

        private void NewTab_Click(object sender, EventArgs e)
        {
            var newTab = new TabPage("Untitled");
            var editor = new CodeEditor();
            newTab.Controls.Add(editor);
            var webView = new WebView2 { Dock = DockStyle.Right, Width = 400 };
            newTab.Controls.Add(webView);
            tabControl.TabPages.Add(newTab);
            tabControl.SelectedTab = newTab;

            editor.TextChanged += (s, args) => webView.Source = new Uri("data:text/html," + Uri.EscapeDataString(editor.Text));
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            FileManager.OpenFile(tabControl);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            FileManager.SaveFile(tabControl);
        }

        private void InsertDoctype_Click(object sender, EventArgs e)
        {
            TextFormatter.InsertDoctype(tabControl);
        }

        private void BoldText_Click(object sender, EventArgs e)
        {
            TextFormatter.BoldText(tabControl);
        }

        private void SearchReplace_Click(object sender, EventArgs e)
        {
            SearchReplace.ShowDialog(tabControl);
        }
    }
}
