using System;
using System.Windows.Forms;

namespace DataReader
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LOGIN_FORM());
        }
    }
}
