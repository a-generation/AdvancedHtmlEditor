using System;
using System.IO;
using System.Windows.Forms;

namespace AdvancedHtmlEditor
{
    public static class FileManager
    {
        public static void OpenFile(TabControl tabControl)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "HTML files (*.html;*.htm)|*.html;*.htm|JavaScript files (*.js)|*.js|CSS files (*.css)|*.css|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var tabPage = (TabPage)tabControl.SelectedTab;
                    var editor = (CodeEditor)tabPage.Controls[0];
                    editor.Text = File.ReadAllText(openFileDialog.FileName);
                    tabPage.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        public static void SaveFile(TabControl tabControl)
        {
            var tabPage = (TabPage)tabControl.SelectedTab;
            var editor = (CodeEditor)tabPage.Controls[0];

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "HTML files (*.html;*.htm)|*.html;*.htm|JavaScript files (*.js)|*.js|CSS files (*.css)|*.css|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, editor.Text);
                    tabPage.Text = Path.GetFileName(saveFileDialog.FileName);
                }
            }
        }
    }
}
