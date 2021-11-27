using DataReader.Classes;
using Guna.UI.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataReader
{
    public partial class MAIN_FORM : Form
    {
        private int Hours, Min, Sec;
        private new bool Move = false;
        private bool Stop = false;
        private Point LastLocation;

        public MAIN_FORM()
        {
            InitializeComponent();
        }
        private void ApplicationExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ApplicationMinmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Btn_Sales_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                GunaCheckBox[] SearchBy = { Location1, Link, Email, Religion, FacebookID, FullName, Phone, Birthday, Education, HomeTown, Work, Position };
                GunaAdvenceButton[] Buttons = { gunaAdvenceButton15, gunaAdvenceButton4, gunaAdvenceButton5, gunaAdvenceButton6, gunaAdvenceButton7, gunaAdvenceButton8, gunaAdvenceButton9, gunaAdvenceButton10, gunaAdvenceButton11, gunaAdvenceButton12 };
                GunaLineTextBox[] TextBox = { Txt_Count, gunaLineTextBox12, gunaLineTextBox1, gunaLineTextBox2, gunaLineTextBox3, gunaLineTextBox4, gunaLineTextBox5, gunaLineTextBox6, gunaLineTextBox7, gunaLineTextBox8, gunaLineTextBox9, gunaLineTextBox10, gunaLineTextBox11 };
                for (int i = 0; i < TextBox.Length; i++)
                {
                    TextBox[i].Text = null;
                    TextBox[i].LineColor = Color.FromArgb(210, 210, 210);
                }
                for (int i = 0; i < Buttons.Length; i++)
                {
                    Buttons[i].Text = "...";
                    Buttons[i].Checked = false;
                }
                for (int i = 0; i < SearchBy.Length; i++)
                {
                    SearchBy[i].Checked = false;
                }
                try
                {
                    DataGrid_Reader.Rows.Clear();
                }
                catch { DataGrid_Reader.DataSource = null; }

                label4.Text = "00:00:00";
                label4.ForeColor = Color.Goldenrod;
                gunaProgressBar1.Value = 0;
                label6.Text = "0%";
                DataGrid_Reader.DataSource = null;
                label5.Invoke((MethodInvoker)delegate
                {
                    label5.Text = "0";
                });
                label5.ForeColor = Color.Goldenrod;
                CB_Relation.SelectedIndex = 0;
                CB_Gender.SelectedIndex = 0;


                Search.FaceBookID.Clear();
                Search.Location.Clear();
                Search.FullName.Clear();
                Search.Phone.Clear();
                Search.Email.Clear();
                Search.Birthday.Clear();
                Search.Education.Clear();
                Search.HomeTown.Clear();
                Search.Work.Clear();
                Search.Position.Clear();
                Search.Religion.Clear();
                Search.Link.Clear();
            }
            catch (Exception ex)
            {
                COMMANDS.Error(ex.Message);
            }
        }
        private void CopyAlltoClipboard(DataGridView datagrid)
        {
            datagrid.SelectAll();
            DataObject dataObj = datagrid.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            if (ViewExcel.Rows.Count > 0)
            {
                try
                {
                    CopyAlltoClipboard(ViewExcel);
                    Excel.Application xlexcel;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlexcel = new Excel.Application { Visible = true };
                    xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    CR.Select();
                    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                }
                catch (Exception ex)
                {
                    COMMANDS.Error(ex.Message);
                }
            }
        }
        private void Btn_Reader_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                #region ( Preparation )

                GunaCheckBox[] SearchBy = { Location1, Link, Email, Religion, FacebookID, FullName, Phone, Birthday, Education, HomeTown, Work, Position };
                string Search = string.Empty;
                for (int i = 0; i < SearchBy.Length; i++)
                {
                    if (SearchBy[i].Checked)
                    {
                        if (SearchBy[i].Name == "Location1")
                        {
                            Search = "Location";
                            break;
                        }
                        else
                        {
                            Search = SearchBy[i].Name;
                            break;
                        }
                    }
                }
                #endregion
                if (!string.IsNullOrEmpty(Search))
                {
                    DataGrid_Reader.DataSource = null;
                    timer1.Start();
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }
        private void Panel_Move_MouseUp(object sender, MouseEventArgs e)
        {
            Move = false;
        }
        private void Panel_Move_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move)
            {
                this.Location = new Point((this.Location.X - LastLocation.X) + e.X, (this.Location.Y - LastLocation.Y) + e.Y);
            }
        }
        private void Panel_Move_MouseDown(object sender, MouseEventArgs e)
        {
            Move = true;
            LastLocation = e.Location;
        }
        public bool smethod_FB()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open FacebookID File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.FaceBookID.Clear();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.FaceBookID.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton4.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton4.Checked = true;
                FacebookID.Checked = true;
            }
            return true;
        }
        public bool smethod_Email()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Email File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.FaceBookID.Clear();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Email.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton13.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton13.Checked = true;
                Email.Checked = true;
            }
            return true;
        }
        public bool smethod_Link()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Link File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.FaceBookID.Clear();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Link.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton14.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton14.Checked = true;
                Link.Checked = true;
            }
            return true;
        }
        public bool smethod_FullName()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open FullName File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.FullName.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.FullName.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton5.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton5.Checked = true;
                FullName.Checked = true;
            }
            return true;
        }
        public bool smethod_Phone()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Phone File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Phone.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Phone.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton6.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton6.Checked = true;
                Phone.Checked = true;
            }
            return true;
        }
        public bool smethod_Birthday()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Birthday File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Birthday.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Birthday.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton8.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton8.Checked = true;
                Birthday.Checked = true;
            }
            return true;
        }
        public bool smethod_Education()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Education File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Education.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Education.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton10.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton10.Checked = true;
                Education.Checked = true;
            }
            return true;
        }
        public bool smethod_HomeTown()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open HomeTown File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.HomeTown.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.HomeTown.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton12.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton12.Checked = true;
                HomeTown.Checked = true;
            }
            return true;
        }
        public bool smethod_Location()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Location File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Location.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Location.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton15.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton15.Checked = true;
                Location1.Checked = true;
            }
            return true;
        }
        public bool smethod_Work()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Work File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Work.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Work.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton7.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton7.Checked = true;
                Work.Checked = true;
            }
            return true;
        }
        public bool smethod_Position()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Position File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Position.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Position.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton9.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton9.Checked = true;
                Position.Checked = true;
            }
            return true;
        }
        public bool smethod_Religion()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Religion File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Environment.CurrentDirectory;
            Search.Religion.Clear();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] array = File.ReadAllLines(theDialog.FileName);
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                    {
                        Search.Religion.Add(text.Trim());
                    }
                }
                int result2 = theDialog.FileName.Split('\\').Length - 1;
                gunaAdvenceButton11.Text = theDialog.FileName.Split('\\')[result2].Split('.')[0];
                gunaAdvenceButton11.Checked = true;
                Religion.Checked = true;
            }
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Sec = Sec + 1;
            if (Sec == 60)
            {
                Sec = 0;
                Min = Min + 1;
            }
            if (Min == 60)
            {
                Min = 0;
                Hours = Hours + 1;
            }
            label4.Invoke((MethodInvoker)delegate
            {
                label4.Text = string.Format("{0}:{1}:{2}", Hours.ToString().PadLeft(2, '0'), Min.ToString().PadLeft(2, '0'), Sec.ToString().PadLeft(2, '0'));
            });

        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                #region ( Preparation )
                string Search = string.Empty, CB_R = string.Empty, CB_G = string.Empty;

                GunaCheckBox[] SearchBy = { FacebookID, FullName, Phone, Email, Birthday, Religion, Education, HomeTown, Location1, Work, Position, Religion, Link };
                for (int i = 0; i < SearchBy.Length; i++)
                {
                    if (SearchBy[i].Checked)
                    {
                        if (SearchBy[i].Name == "Location1")
                        {
                            Search = "Location";
                            break;
                        }
                        else
                        {
                            Search = SearchBy[i].Name;
                            break;
                        }
                    }
                }

                CB_Relation.Invoke((MethodInvoker)delegate
                {
                    CB_R = CB_Relation.Text;
                });
                CB_Gender.Invoke((MethodInvoker)delegate
                {
                    CB_G = CB_Gender.Text;
                });
                if (CB_G == "All")
                {
                    CB_G = string.Empty;
                }
                if (CB_R == "All")
                {
                    CB_R = string.Empty;
                }
                DataGrid_Reader.DataSource = null;

                if (!string.IsNullOrEmpty(Search))
                {
                    Stop = false;
                    label5.Invoke((MethodInvoker)delegate
                    {
                        label5.Text = "0";
                    });
                    label6.Invoke((MethodInvoker)delegate
                    {
                        label6.Text = "0%";
                    });
                    gunaProgressBar1.Invoke((MethodInvoker)delegate
                    {
                        gunaProgressBar1.Value = 0;
                    });
                    label4.ForeColor = Color.Goldenrod;
                    label5.ForeColor = Color.Goldenrod;
                }
           
                #region ( DataTable )
                DataTable Master = new DataTable();
                Master.Columns.Add("FacebookID", typeof(string));
                Master.Columns.Add("FullName", typeof(string));
                Master.Columns.Add("Phone", typeof(string));
                Master.Columns.Add("Email", typeof(string));
                Master.Columns.Add("Birthday", typeof(string));
                Master.Columns.Add("Education", typeof(string));
                Master.Columns.Add("HomeTown", typeof(string));
                Master.Columns.Add("Location", typeof(string));
                Master.Columns.Add("Work", typeof(string));
                Master.Columns.Add("Position", typeof(string));
                Master.Columns.Add("Religion", typeof(string));
                Master.Columns.Add("Gender", typeof(string));
                Master.Columns.Add("RelationShip", typeof(string));
                Master.Columns.Add("Link", typeof(string));
                #endregion

                #endregion

                #region ( START )
                if (!string.IsNullOrEmpty(Search))
                {
                    switch (Search)
                    {
                        case "FacebookID":
                            if (string.IsNullOrEmpty(gunaLineTextBox1.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox1.Text))
                            {
                                for (int i = 0; i < Classes.Search.FaceBookID.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.FaceBookID.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) = '{Classes.Search.FaceBookID[i]}' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1 ).ToString();
                                        });
                                        
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) = '{gunaLineTextBox1.Text.Trim()}' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "FullName":
                            if (string.IsNullOrEmpty(gunaLineTextBox11.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox11.Text))
                            {
                                for (int i = 0; i < Classes.Search.FullName.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.FullName.Count);
                                    foreach (DataRow drtableOld in  Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where FullName LIKE '%{Classes.Search.FullName[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where FullName LIKE '%{gunaLineTextBox11.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }

                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Phone":
                            if (string.IsNullOrEmpty(gunaLineTextBox10.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox10.Text))
                            {
                                for (int i = 0; i < Classes.Search.Phone.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Phone.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) = '{Classes.Search.Phone[i]}' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) = '{gunaLineTextBox10.Text.Trim()}' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Email":
                            if (string.IsNullOrEmpty(gunaLineTextBox9.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox9.Text))
                            {
                                for (int i = 0; i < Classes.Search.Email.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Email.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Email LIKE '%{Classes.Search.Email[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Email LIKE '%{gunaLineTextBox9.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Birthday":
                            if (string.IsNullOrEmpty(gunaLineTextBox8.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox8.Text))
                            {
                                for (int i = 0; i < Classes.Search.Birthday.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Birthday.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Birthday LIKE '%{Classes.Search.Birthday[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Birthday LIKE '%{gunaLineTextBox8.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Education":
                            if (string.IsNullOrEmpty(gunaLineTextBox7.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox7.Text))
                            {
                                for (int i = 0; i < Classes.Search.Education.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Education.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Education LIKE '%{Classes.Search.Education[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Education LIKE '%{gunaLineTextBox7.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "HomeTown":
                            if (string.IsNullOrEmpty(gunaLineTextBox6.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox6.Text))
                            {
                                for (int i = 0; i < Classes.Search.HomeTown.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.HomeTown.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where HomeTown LIKE '%{Classes.Search.HomeTown[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where HomeTown LIKE '%{gunaLineTextBox6.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Location":
                            if (string.IsNullOrEmpty(gunaLineTextBox12.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox12.Text))
                            {
                                for (int i = 0; i < Classes.Search.Location.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Location.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Location LIKE '%{Classes.Search.HomeTown[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Location LIKE '%{gunaLineTextBox12.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Work":
                            if (string.IsNullOrEmpty(gunaLineTextBox5.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox5.Text))
                            {
                                for (int i = 0; i < Classes.Search.Work.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Work.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Work LIKE '%{Classes.Search.Work[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Work LIKE '%{gunaLineTextBox5.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Position":
                            if (string.IsNullOrEmpty(gunaLineTextBox4.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox4.Text))
                            {
                                for (int i = 0; i < Classes.Search.Position.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Position.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Work LIKE '%{Classes.Search.Position[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Work LIKE '%{gunaLineTextBox4.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Religion":
                            if (string.IsNullOrEmpty(gunaLineTextBox2.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox2.Text))
                            {
                                for (int i = 0; i < Classes.Search.Religion.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Religion.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Religion LIKE '%{Classes.Search.Position[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Religion LIKE '%{gunaLineTextBox2.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        case "Link":
                            if (string.IsNullOrEmpty(gunaLineTextBox3.Text) || string.IsNullOrWhiteSpace(gunaLineTextBox3.Text))
                            {
                                for (int i = 0; i < Classes.Search.Link.Count; i++)
                                {
                                    int percentComplete = (int)Math.Round((double)(100 * (i + 1)) / Classes.Search.Link.Count);
                                    foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Link LIKE '%{Classes.Search.Link[i]}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                    {
                                        Master.ImportRow(drtableOld);
                                        label5.Invoke((MethodInvoker)delegate
                                        {
                                            label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                        });
                                    }
                                    if (Stop)
                                    {
                                        goto default;
                                    }
                                    backgroundWorker1.ReportProgress(percentComplete);
                                }
                            }
                            else
                            {
                                foreach (DataRow drtableOld in Querys.Reader_Table($"select CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',FacebookID)) as FacebookID,FullName,CONVERT (varchar(100),DECRYPTBYPASSPHRASE('NovaTools',Phone)) as Phone,Email,Birthday,Education,HomeTown,Location,Work,Position,Religion,Gender,RelationShip,Link from TG where Link LIKE '%{gunaLineTextBox3.Text.Trim()}%' and RelationShip LIKE '%{CB_R}%' and Gender Like '{CB_G}%'").Rows)
                                {
                                    Master.ImportRow(drtableOld);
                                    label5.Invoke((MethodInvoker)delegate
                                    {
                                        label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                                    });
                                }
                                if (Stop)
                                {
                                    goto default;
                                }
                                backgroundWorker1.ReportProgress(100);
                            }
                            goto default;
                        default:
                            if ((!string.IsNullOrEmpty(Txt_Count.Text) || !string.IsNullOrWhiteSpace(Txt_Count.Text)) && Convert.ToInt32(Txt_Count.Text) > 0)
                            {
                                DataGrid_Reader.Invoke((MethodInvoker)(() => DataGrid_Reader.DataSource = Master.AsEnumerable().Take(Convert.ToInt32(Txt_Count.Text.Trim())).CopyToDataTable()));
                            }
                            else
                            {
                                DataGrid_Reader.Invoke((MethodInvoker)(() => DataGrid_Reader.DataSource = Master));
                            }
                            DataGrid_Reader.Invoke((MethodInvoker)(() => ViewExcel.DataSource = Master));
                            break;
                    }
                }
                #endregion ( END )
            }
            catch (Exception ex)
            { COMMANDS.Error(ex.Message); }
            finally
            {
                timer1.Stop();
                Hours = 0; Min = 0; Sec = 0;
                label4.ForeColor = Color.GreenYellow;
                label5.ForeColor = Color.GreenYellow;
                COMMANDS.Information($"Load [{DataGrid_Reader.Rows.Count}] Rows Has Been Successful!,In Time [{label4.Text}]");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            gunaProgressBar1.Value = e.ProgressPercentage;
            label6.Text = gunaProgressBar1.Value + "%";
        }
        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            smethod_FB();
        }
        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            smethod_FullName();
        }
        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            smethod_Phone();
        }
        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            smethod_Birthday();
        }
        private void gunaAdvenceButton10_Click(object sender, EventArgs e)
        {
            smethod_Education();
        }
        private void gunaAdvenceButton12_Click(object sender, EventArgs e)
        {
            smethod_HomeTown();
        }
        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            smethod_Work();
        }
        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            smethod_Position();
        }
        private void gunaAdvenceButton11_Click(object sender, EventArgs e)
        {
            smethod_Religion();
        }
        private void Religion_CheckedChanged(object sender, EventArgs e)
        {
            GunaCheckBox checkBox = (GunaCheckBox)sender;
            GunaCheckBox[] SearchBy = { Location1, Religion, FacebookID, FullName, Phone, Birthday, Education, Email, HomeTown, Work, Position, Link };

            if (checkBox.Checked.Equals(true))
                checkBox.ForeColor = Color.Goldenrod;
            else
                checkBox.ForeColor = Color.Linen;
            for (int i = 0; i < SearchBy.Length; i++)
            {
                if (!SearchBy[i].Equals(checkBox) && SearchBy[i].Checked.Equals(true))
                    SearchBy[i].Checked = false;
            }
        }
        private void Txt_LoginID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void DataGrid_Reader_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Clipboard.SetText(DataGrid_Reader.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());
                COMMANDS.Information("Copid!");
            }
            catch { }
        }
        private void DataGrid_Reader_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var a = "";
                for (int i = 0; i <= 13; i++)
                {
                    a = a + "  " + DataGrid_Reader.Rows[e.RowIndex].Cells[i].Value.ToString().Trim();
                }
                Clipboard.SetText(a);
                COMMANDS.Information("Copid!");
            }
            catch { }
        }
        private void gunaAdvenceButton13_Click(object sender, EventArgs e)
        {
            smethod_Email();
        }
        private void gunaAdvenceButton14_Click(object sender, EventArgs e)
        {
            smethod_Link();
        }
        private void DataGrid_Reader_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var a = "";
                for (int i = 0; i <= DataGrid_Reader.Rows.Count - 1; i++)
                {
                    a = a + "  " + DataGrid_Reader.Rows[i].Cells[e.ColumnIndex].Value.ToString().Trim();
                }
                Clipboard.SetText(a);
                COMMANDS.Information("Copid!");
            }
            catch { }
        }
        private void gunaAdvenceButton15_Click(object sender, EventArgs e)
        {
            smethod_Location();
        }
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            Stop = true;
        }
    }
}
