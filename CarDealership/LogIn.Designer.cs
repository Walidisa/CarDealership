using System.Drawing;
using System.Windows.Forms;
using System;

namespace CarDealership
{
    partial class LogIn
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelLogin;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Button btnQuickLogIn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLogin = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnExit = new Button();
            this.btnQuickLogIn = new Button();

            this.SuspendLayout();

            // Form
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // panelLogin
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.BorderStyle = BorderStyle.FixedSingle;
            this.panelLogin.Width = 680;
            this.panelLogin.Height = 580;
            this.panelLogin.Location = new System.Drawing.Point(1140, 398);


            // lblTitle
            this.lblTitle.Text = "LogIn";
            this.lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(200, 10);

            // lblUsername
            this.lblUsername.Text = "Username:";
            this.lblUsername.Font = new Font("Segoe UI", 16F);
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new Point(60, 140);

            // txtUsername
            this.txtUsername.Font = new Font("Segoe UI", 16F);
            this.txtUsername.Width = 550;
            this.txtUsername.Location = new Point(60, 180);

            // lblPassword
            this.lblPassword.Text = "Password:";
            this.lblPassword.Font = new Font("Segoe UI", 16F);
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(60, 250);

            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 16F);
            this.txtPassword.Width = 550;
            this.txtPassword.Location = new Point(60, 290);
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Text = "LogIn";
            this.btnLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnLogin.BackColor = Color.SteelBlue;
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Size = new Size(260, 70);
            this.btnLogin.Location = new Point(60, 380);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.Text = "Exit";
            this.btnExit.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnExit.BackColor = Color.LightGray;
            this.btnExit.ForeColor = Color.Black;
            this.btnExit.Size = new Size(260, 70);
            this.btnExit.Location = new Point(360, 380);
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // btnQuickLogIn
            this.btnQuickLogIn.Text = "Quick LogIn";
            this.btnQuickLogIn.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnQuickLogIn.BackColor = Color.LightGreen;
            this.btnQuickLogIn.ForeColor = Color.Black;
            this.btnQuickLogIn.Size = new Size(560, 70);
            this.btnQuickLogIn.Location = new Point(60, 470);
            this.btnQuickLogIn.Click += new EventHandler(this.btnQuickLogIn_Click);

            // Add controls to panel
            this.panelLogin.Controls.Add(this.lblTitle);
            this.panelLogin.Controls.Add(this.lblUsername);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.btnExit);
            this.panelLogin.Controls.Add(this.btnQuickLogIn);

            // Add panel to form
            this.Controls.Add(this.panelLogin);

            this.ResumeLayout(false);
        }
    }
}
