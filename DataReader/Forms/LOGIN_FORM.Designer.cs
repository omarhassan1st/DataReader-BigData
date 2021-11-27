
namespace DataReader
{
    partial class LOGIN_FORM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN_FORM));
            this.Panel_Move = new System.Windows.Forms.Panel();
            this.Btn_Minimized = new Guna.UI.WinForms.GunaButton();
            this.PicSmall_LOGO = new System.Windows.Forms.PictureBox();
            this.Btn_ExitApplication = new Guna.UI.WinForms.GunaButton();
            this.PicBig_LOGO = new System.Windows.Forms.PictureBox();
            this.Btn_ForgetPassword = new Guna.UI.WinForms.GunaAdvenceButton();
            this.Btn_Login = new Guna.UI.WinForms.GunaAdvenceButton();
            this.Txt_LoginPW = new Guna.UI.WinForms.GunaLineTextBox();
            this.Txt_LoginID = new Guna.UI.WinForms.GunaLineTextBox();
            this.Panel_Move.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSmall_LOGO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBig_LOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Move
            // 
            this.Panel_Move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Panel_Move.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Move.Controls.Add(this.Btn_Minimized);
            this.Panel_Move.Controls.Add(this.PicSmall_LOGO);
            this.Panel_Move.Controls.Add(this.Btn_ExitApplication);
            this.Panel_Move.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Move.Location = new System.Drawing.Point(0, 0);
            this.Panel_Move.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_Move.Name = "Panel_Move";
            this.Panel_Move.Size = new System.Drawing.Size(968, 49);
            this.Panel_Move.TabIndex = 16;
            this.Panel_Move.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Move_MouseDown);
            this.Panel_Move.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Move_MouseMove);
            this.Panel_Move.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_Move_MouseUp);
            // 
            // Btn_Minimized
            // 
            this.Btn_Minimized.AnimationHoverSpeed = 0.07F;
            this.Btn_Minimized.AnimationSpeed = 0.03F;
            this.Btn_Minimized.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Minimized.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_Minimized.BorderColor = System.Drawing.Color.Black;
            this.Btn_Minimized.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Btn_Minimized.FocusedColor = System.Drawing.Color.Empty;
            this.Btn_Minimized.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Minimized.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_Minimized.Image = null;
            this.Btn_Minimized.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_Minimized.Location = new System.Drawing.Point(871, 4);
            this.Btn_Minimized.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Minimized.Name = "Btn_Minimized";
            this.Btn_Minimized.OnHoverBaseColor = System.Drawing.Color.LightGray;
            this.Btn_Minimized.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Btn_Minimized.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_Minimized.OnHoverImage = null;
            this.Btn_Minimized.OnPressedColor = System.Drawing.Color.Black;
            this.Btn_Minimized.Size = new System.Drawing.Size(38, 41);
            this.Btn_Minimized.TabIndex = 11;
            this.Btn_Minimized.Text = "-";
            this.Btn_Minimized.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Btn_Minimized.Click += new System.EventHandler(this.Btn_Minimized_Click);
            // 
            // PicSmall_LOGO
            // 
            this.PicSmall_LOGO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PicSmall_LOGO.Image = global::DataReader.Properties.Resources.Login_LOGO;
            this.PicSmall_LOGO.Location = new System.Drawing.Point(2, 2);
            this.PicSmall_LOGO.Margin = new System.Windows.Forms.Padding(2);
            this.PicSmall_LOGO.Name = "PicSmall_LOGO";
            this.PicSmall_LOGO.Size = new System.Drawing.Size(43, 42);
            this.PicSmall_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSmall_LOGO.TabIndex = 19;
            this.PicSmall_LOGO.TabStop = false;
            // 
            // Btn_ExitApplication
            // 
            this.Btn_ExitApplication.AnimationHoverSpeed = 0.07F;
            this.Btn_ExitApplication.AnimationSpeed = 0.03F;
            this.Btn_ExitApplication.BackColor = System.Drawing.Color.Transparent;
            this.Btn_ExitApplication.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ExitApplication.BorderColor = System.Drawing.Color.Black;
            this.Btn_ExitApplication.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Btn_ExitApplication.FocusedColor = System.Drawing.Color.Empty;
            this.Btn_ExitApplication.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ExitApplication.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_ExitApplication.Image = null;
            this.Btn_ExitApplication.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_ExitApplication.Location = new System.Drawing.Point(920, 4);
            this.Btn_ExitApplication.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ExitApplication.Name = "Btn_ExitApplication";
            this.Btn_ExitApplication.OnHoverBaseColor = System.Drawing.Color.Red;
            this.Btn_ExitApplication.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Btn_ExitApplication.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ExitApplication.OnHoverImage = null;
            this.Btn_ExitApplication.OnPressedColor = System.Drawing.Color.Black;
            this.Btn_ExitApplication.Size = new System.Drawing.Size(38, 41);
            this.Btn_ExitApplication.TabIndex = 10;
            this.Btn_ExitApplication.Text = "X";
            this.Btn_ExitApplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Btn_ExitApplication.Click += new System.EventHandler(this.Btn_ExitApplication_Click);
            // 
            // PicBig_LOGO
            // 
            this.PicBig_LOGO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PicBig_LOGO.Image = global::DataReader.Properties.Resources.Login_LOGO;
            this.PicBig_LOGO.Location = new System.Drawing.Point(383, 52);
            this.PicBig_LOGO.Margin = new System.Windows.Forms.Padding(2);
            this.PicBig_LOGO.Name = "PicBig_LOGO";
            this.PicBig_LOGO.Size = new System.Drawing.Size(170, 174);
            this.PicBig_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBig_LOGO.TabIndex = 18;
            this.PicBig_LOGO.TabStop = false;
            // 
            // Btn_ForgetPassword
            // 
            this.Btn_ForgetPassword.AnimationHoverSpeed = 0.07F;
            this.Btn_ForgetPassword.AnimationSpeed = 0.03F;
            this.Btn_ForgetPassword.BackColor = System.Drawing.Color.Transparent;
            this.Btn_ForgetPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_ForgetPassword.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.BorderColor = System.Drawing.Color.Black;
            this.Btn_ForgetPassword.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.CheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.CheckedForeColor = System.Drawing.Color.Red;
            this.Btn_ForgetPassword.CheckedImage = null;
            this.Btn_ForgetPassword.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Btn_ForgetPassword.FocusedColor = System.Drawing.Color.Empty;
            this.Btn_ForgetPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ForgetPassword.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_ForgetPassword.Image = null;
            this.Btn_ForgetPassword.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_ForgetPassword.LineColor = System.Drawing.Color.LightGray;
            this.Btn_ForgetPassword.Location = new System.Drawing.Point(565, 512);
            this.Btn_ForgetPassword.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ForgetPassword.Name = "Btn_ForgetPassword";
            this.Btn_ForgetPassword.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Btn_ForgetPassword.OnHoverForeColor = System.Drawing.Color.Red;
            this.Btn_ForgetPassword.OnHoverImage = null;
            this.Btn_ForgetPassword.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_ForgetPassword.Size = new System.Drawing.Size(136, 33);
            this.Btn_ForgetPassword.TabIndex = 17;
            this.Btn_ForgetPassword.TabStop = false;
            this.Btn_ForgetPassword.Text = "Forget  Password ?!";
            this.Btn_ForgetPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Btn_ForgetPassword.Click += new System.EventHandler(this.Btn_ForgetPassword_Click);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Animated = true;
            this.Btn_Login.AnimationHoverSpeed = 0.07F;
            this.Btn_Login.AnimationSpeed = 0.03F;
            this.Btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Login.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Btn_Login.BorderColor = System.Drawing.Color.LightGray;
            this.Btn_Login.BorderSize = 2;
            this.Btn_Login.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Login.CheckedBorderColor = System.Drawing.Color.LightGray;
            this.Btn_Login.CheckedForeColor = System.Drawing.Color.White;
            this.Btn_Login.CheckedImage = null;
            this.Btn_Login.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Btn_Login.FocusedColor = System.Drawing.Color.Empty;
            this.Btn_Login.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_Login.Image = null;
            this.Btn_Login.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_Login.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Btn_Login.Location = new System.Drawing.Point(371, 524);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.OnHoverBaseColor = System.Drawing.Color.LightGray;
            this.Btn_Login.OnHoverBorderColor = System.Drawing.Color.LightGray;
            this.Btn_Login.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Btn_Login.OnHoverImage = null;
            this.Btn_Login.OnHoverLineColor = System.Drawing.Color.Red;
            this.Btn_Login.OnPressedColor = System.Drawing.Color.Black;
            this.Btn_Login.Radius = 20;
            this.Btn_Login.Size = new System.Drawing.Size(184, 50);
            this.Btn_Login.TabIndex = 15;
            this.Btn_Login.Text = "Login";
            this.Btn_Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Txt_LoginPW
            // 
            this.Txt_LoginPW.BackColor = System.Drawing.Color.White;
            this.Txt_LoginPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_LoginPW.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Txt_LoginPW.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_LoginPW.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Txt_LoginPW.LineSize = 10;
            this.Txt_LoginPW.Location = new System.Drawing.Point(267, 440);
            this.Txt_LoginPW.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_LoginPW.Name = "Txt_LoginPW";
            this.Txt_LoginPW.PasswordChar = '\0';
            this.Txt_LoginPW.SelectedText = "";
            this.Txt_LoginPW.Size = new System.Drawing.Size(422, 67);
            this.Txt_LoginPW.TabIndex = 14;
            // 
            // Txt_LoginID
            // 
            this.Txt_LoginID.BackColor = System.Drawing.Color.White;
            this.Txt_LoginID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_LoginID.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Txt_LoginID.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_LoginID.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.Txt_LoginID.LineSize = 10;
            this.Txt_LoginID.Location = new System.Drawing.Point(267, 355);
            this.Txt_LoginID.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_LoginID.Name = "Txt_LoginID";
            this.Txt_LoginID.PasswordChar = '\0';
            this.Txt_LoginID.SelectedText = "";
            this.Txt_LoginID.Size = new System.Drawing.Size(422, 67);
            this.Txt_LoginID.TabIndex = 13;
            // 
            // LOGIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BackgroundImage = global::DataReader.Properties.Resources._1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(968, 595);
            this.ControlBox = false;
            this.Controls.Add(this.Panel_Move);
            this.Controls.Add(this.Btn_ForgetPassword);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.Txt_LoginPW);
            this.Controls.Add(this.Txt_LoginID);
            this.Controls.Add(this.PicBig_LOGO);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LOGIN_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Panel_Move.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicSmall_LOGO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBig_LOGO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Move;
        private Guna.UI.WinForms.GunaButton Btn_Minimized;
        private Guna.UI.WinForms.GunaButton Btn_ExitApplication;
        private System.Windows.Forms.PictureBox PicSmall_LOGO;
        private System.Windows.Forms.PictureBox PicBig_LOGO;
        private Guna.UI.WinForms.GunaAdvenceButton Btn_ForgetPassword;
        private Guna.UI.WinForms.GunaAdvenceButton Btn_Login;
        private Guna.UI.WinForms.GunaLineTextBox Txt_LoginPW;
        private Guna.UI.WinForms.GunaLineTextBox Txt_LoginID;
    }
}