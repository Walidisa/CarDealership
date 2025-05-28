using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    partial class ContactUs
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContact;
        private Label lblTitle, lblName, lblEmail, lblSubject, lblMessage;
        private TextBox txtName, txtEmail, txtSubject;
        private TextBox txtMessage;
        private Button btnSend, btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContact = new Panel();
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.lblEmail = new Label();
            this.lblSubject = new Label();
            this.lblMessage = new Label();
            this.txtName = new TextBox();
            this.txtEmail = new TextBox();
            this.txtSubject = new TextBox();
            this.txtMessage = new TextBox();
            this.btnSend = new Button();
            this.btnExit = new Button();
            this.SuspendLayout();

            // Form
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Panel
            this.panelContact.BackColor = Color.White;
            this.panelContact.BorderStyle = BorderStyle.FixedSingle;
            this.panelContact.Size = new Size(700, 650);
            this.panelContact.Location = new System.Drawing.Point(1140, 398);


            // Title
            this.lblTitle.Text = "Contact Us";
            this.lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(210, 30);

            // Name
            this.lblName.Text = "Name:";
            this.lblName.Font = new Font("Segoe UI", 16F);
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(50, 110);

            this.txtName.Font = new Font("Segoe UI", 16F);
            this.txtName.Size = new Size(580, 36);
            this.txtName.Location = new Point(50, 150);

            // Email
            this.lblEmail.Text = "Email:";
            this.lblEmail.Font = new Font("Segoe UI", 16F);
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(50, 200);

            this.txtEmail.Font = new Font("Segoe UI", 16F);
            this.txtEmail.Size = new Size(580, 36);
            this.txtEmail.Location = new Point(50, 240);

            // Subject
            this.lblSubject.Text = "Subject:";
            this.lblSubject.Font = new Font("Segoe UI", 16F);
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new Point(50, 290);

            this.txtSubject.Font = new Font("Segoe UI", 16F);
            this.txtSubject.Size = new Size(580, 36);
            this.txtSubject.Location = new Point(50, 330);

            // Message
            this.lblMessage.Text = "Message:";
            this.lblMessage.Font = new Font("Segoe UI", 16F);
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new Point(50, 380);

            this.txtMessage.Font = new Font("Segoe UI", 16F);
            this.txtMessage.Size = new Size(580, 100);
            this.txtMessage.Location = new Point(50, 420);
            this.txtMessage.Multiline = true;
            this.txtMessage.ScrollBars = ScrollBars.Vertical;

            // Send Button
            this.btnSend.Text = "Send";
            this.btnSend.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnSend.BackColor = Color.SeaGreen;
            this.btnSend.ForeColor = Color.White;
            this.btnSend.Size = new Size(250, 60);
            this.btnSend.Location = new Point(50, 540);
            this.btnSend.Click += new EventHandler(this.btnSend_Click);

            // Exit Button
            this.btnExit.Text = "Exit";
            this.btnExit.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnExit.BackColor = Color.LightGray;
            this.btnExit.ForeColor = Color.Black;
            this.btnExit.Size = new Size(250, 60);
            this.btnExit.Location = new Point(380, 540);
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // Add controls
            this.panelContact.Controls.Add(this.lblTitle);
            this.panelContact.Controls.Add(this.lblName);
            this.panelContact.Controls.Add(this.txtName);
            this.panelContact.Controls.Add(this.lblEmail);
            this.panelContact.Controls.Add(this.txtEmail);
            this.panelContact.Controls.Add(this.lblSubject);
            this.panelContact.Controls.Add(this.txtSubject);
            this.panelContact.Controls.Add(this.lblMessage);
            this.panelContact.Controls.Add(this.txtMessage);
            this.panelContact.Controls.Add(this.btnSend);
            this.panelContact.Controls.Add(this.btnExit);

            // Add panel to form
            this.Controls.Add(this.panelContact);

            this.ResumeLayout(false);
        }
    }
}
