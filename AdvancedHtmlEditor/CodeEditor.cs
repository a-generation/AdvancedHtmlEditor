using System.Drawing;
using System.Windows.Forms;

namespace AdvancedHtmlEditor
{
    public class CodeEditor : TextBox
    {
        public CodeEditor()
        {
            this.Multiline = true;
            this.Dock = DockStyle.Fill;
            this.ScrollBars = ScrollBars.Both;
            this.Font = new Font("Consolas", 10);
        }
    }
}
