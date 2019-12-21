using System;
using System.Windows.Forms;
using FacebookWrapper;

namespace Ex02
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Clipboard.SetText("designpatterns");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
