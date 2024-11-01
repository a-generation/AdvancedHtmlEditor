using System.Windows.Forms;

namespace AdvancedHtmlEditor
{
    public static class TextFormatter
    {
        public static void InsertDoctype(TabControl tabControl)
        {
            var tabPage = (TabPage)tabControl.SelectedTab;
            var editor = (CodeEditor)tabPage.Controls[0];
            editor.SelectedText = "<!DOCTYPE html>\n";
        }

        public static void BoldText(TabControl tabControl)
        {
            var tabPage = (TabPage)tabControl.SelectedTab;
            var editor = (CodeEditor)tabPage.Controls[0];
            if (editor.SelectionLength > 0)
            {
                editor.SelectedText = "<strong>" + editor.SelectedText + "</strong>";
            }
        }
    }
}
