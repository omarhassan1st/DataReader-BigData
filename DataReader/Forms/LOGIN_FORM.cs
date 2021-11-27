using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataReader
{
    public partial class LOGIN_FORM : Form
    {
        public static string UserTerms = string.Empty, AdminID = string.Empty, AdminCode = string.Empty;
        private static bool MouseDwn = false;
        private Point LastLocation;
        public LOGIN_FORM()
        {
            InitializeComponent();
        }

        private void Panel_Move_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDwn = false;
        }

        private void Panel_Move_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDwn)
            {
                int Newx = (this.Location.X - LastLocation.X) + e.X;
                int Newy = (this.Location.Y - LastLocation.Y) + e.Y;
                this.Location = new Point(Newx, Newy);
            }
        }

        private void Panel_Move_MouseDown(object sender, MouseEventArgs e)
        {

            MouseDwn = true;
            LastLocation = e.Location;
        }

        private void Btn_ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Btn_ForgetPassword_Click(object sender, EventArgs e)
        {
            Licenses.SendNewMsg($"Hello Mr {Querys.Reader_SingleValue("select ID from OWNER").Trim()},\nHere is your Account Information!\nID: {Querys.Reader_SingleValue("select ID from OWNER").Trim()} \nPW: {Querys.Reader_SingleValue("select PW from OWNER").Trim()} \nRequest Password date: [{DateTime.Now}]\n Glad To Serve You, NovaTools_Team");
            COMMANDS.Information($"Please Check your E-Mail  Mr {Querys.Reader_SingleValue("select ID from OWNER where Service = 1").Trim()},");
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txt_LoginID.Text) && !string.IsNullOrEmpty(Txt_LoginPW.Text))
                {
                    if (Querys.Reader_SingleValue($"select PW from OWNER where ID ='{Txt_LoginID.Text}'").Trim().Equals(Txt_LoginPW.Text.Trim()))
                    {
                        UserTerms = "OWNER";
                        AdminID = Txt_LoginID.Text;
                        AdminCode = "0";
                        if (Application.OpenForms["MAIN_FORM"] == null)
                        {
                            MAIN_FORM Main = new MAIN_FORM();
                            Main.Show();
                            Hide();
                        }
                        else
                        {
                            Application.OpenForms["MAIN_FORM"].Show();
                            this.Hide();
                        }
                        Licenses.SendNewMsg($"Hello Mr {Querys.Reader_SingleValue("select ID from OWNER").Trim()},\nThere is a New Login as a (OWNER) on your Application!!! \nID:{Txt_LoginID.Text.Trim()} \nPW:{Txt_LoginPW.Text.Trim()} \nDateTime:[{DateTime.Now}]\nLogin Has Been Successful !!");
                    }
                    else if (Querys.Reader_SingleValue($"select EmployPW from Employs where EmployID ='{Txt_LoginID.Text}'").Trim().Equals(Txt_LoginPW.Text.Trim()) && Querys.Reader_SingleValue($"select Service from Employs where EmployID = '{Txt_LoginID.Text}'").Trim().Equals("1"))
                    {
                        UserTerms = Querys.Reader_SingleValue($"select EmployPostion from _Employs where EmployID ='{Txt_LoginID.Text}'").Trim();
                        AdminID = Txt_LoginID.Text;
                        AdminCode = Querys.Reader_SingleValue($"select EmployCode from _Employs where EmployID ='{Txt_LoginID.Text}'").Trim();
                        if (Application.OpenForms["MAIN_FORM"] == null)
                        {
                            MAIN_FORM Main = new MAIN_FORM();
                            Main.Show();
                            this.Hide();
                        }
                        else
                        {
                            Application.OpenForms["MAIN_FORM"].Show();
                            this.Hide();
                        }
                        Licenses.SendNewMsg($"Hello Mr {Querys.Reader_SingleValue("select ID from OWNER").Trim()},\nThere is a New Login as a (Admin) on your Application!!! \nID:{Txt_LoginID.Text.Trim()} \nPW:{Txt_LoginPW.Text.Trim()} \nDateTime:[{DateTime.Now}]\nLogin Has Been Successful !!");
                    }
                    else if (Querys.Reader_SingleValue($"select EmployPW from Employs where EmployID ='{Txt_LoginID.Text}'").Trim().Equals(Txt_LoginPW.Text.Trim()) && Querys.Reader_SingleValue($"select Service from Employs where EmployID = '{Txt_LoginID.Text}'").Trim().Equals("0"))
                    {
                        COMMANDS.Error("تم حظر هذة المستخدم من الدخول للبرنامج");
                        return;
                    }
                    else
                    {
                        COMMANDS.Error("خطأ في الاسم او كلمه المرور");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                COMMANDS.Error(ex.Message);
                return;
            }
        }
    }
}
