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
            this.panelContact = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContact
            // 
            this.panelContact.BackColor = System.Drawing.Color.White;
            this.panelContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panelContact.Location = new System.Drawing.Point(1140, 232);
            this.panelContact.Name = "panelContact";
            this.panelContact.Size = new System.Drawing.Size(692, 1034);
            this.panelContact.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(100, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(484, 114);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Contact Us";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblName.Location = new System.Drawing.Point(50, 130);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(147, 59);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtName.Location = new System.Drawing.Point(50, 192);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(580, 64);
            this.txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblEmail.Location = new System.Drawing.Point(40, 259);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(135, 59);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtEmail.Location = new System.Drawing.Point(50, 321);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(580, 64);
            this.txtEmail.TabIndex = 4;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblSubject.Location = new System.Drawing.Point(40, 388);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(173, 59);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtSubject.Location = new System.Drawing.Point(50, 450);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(580, 64);
            this.txtSubject.TabIndex = 6;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblMessage.Location = new System.Drawing.Point(40, 517);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(200, 59);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtMessage.Location = new System.Drawing.Point(50, 579);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(580, 257);
            this.txtMessage.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(60, 870);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(250, 90);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightGray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(380, 870);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(250, 90);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ContactUs
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(2278, 1759);
            this.Controls.Add(this.panelContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ContactUs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContactUs_Load);
            this.panelContact.ResumeLayout(false);
            this.panelContact.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
