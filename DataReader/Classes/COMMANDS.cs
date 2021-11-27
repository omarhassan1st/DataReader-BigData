using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataReader
{
    class COMMANDS
    {
        public delegate void Message(object txt);
        public static Message Error = (object txt) => MessageBox.Show(txt.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public static Message Information = (object txt) => MessageBox.Show(txt.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static string Question(string txt)
        {
            DialogResult Answer = MessageBox.Show(txt, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Answer == DialogResult.Yes)
                return "Yes";
            else
                return "No";
        }
    }
}
