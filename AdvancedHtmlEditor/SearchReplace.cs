using System;
using System.Windows.Forms;

namespace AdvancedHtmlEditor
{
    public static class SearchReplace
    {
        public static void ShowDialog(TabControl tabControl)
        {
            var searchForm = new Form
            {
                Width = 300,
                Height = 200,
                Text = "Search & Replace"
            };

            var searchBox = new TextBox { Dock = DockStyle.Top, Text = "Search..." };
            searchBox.GotFocus += (s, e) => { if (searchBox.Text == "Search...") searchBox.Text = ""; };
            searchBox.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(searchBox.Text)) searchBox.Text = "Search..."; };

            var replaceBox = new TextBox { Dock = DockStyle.Top, Text = "Replace..." };
            replaceBox.GotFocus += (s, e) => { if (replaceBox.Text == "Replace...") replaceBox.Text = ""; };
            replaceBox.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(replaceBox.Text)) replaceBox.Text = "Replace..."; };

            var replaceButton = new Button { Text = "Replace", Dock = DockStyle.Top };

            replaceButton.Click += (s, e) =>
            {
                var tabPage = (TabPage)tabControl.SelectedTab;
                var editor = (CodeEditor)tabPage.Controls[0]; // Убедитесь, что здесь правильный тип контроллера
                editor.Text = editor.Text.Replace(searchBox.Text, replaceBox.Text);
                searchForm.Close();
            };

            searchForm.Controls.Add(replaceButton);
            searchForm.Controls.Add(replaceBox);
            searchForm.Controls.Add(searchBox);
            searchForm.ShowDialog();
        }
    }
}
