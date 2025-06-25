using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    partial class SignUp
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelSignUp;
        private Label lblTitle;
        private Label lblUsername, lblPassword, lblConfirmPassword;
        private Label lblName, lblEmail, lblPhone, lblCompany;
        private TextBox txtUsername, txtPassword, txtConfirmPassword;
        private TextBox txtName, txtEmail, txtPhone, txtCompany;
        private Button btnSignUp;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSignUp = new Panel();
            this.lblTitle = new Label();

            this.lblUsername = new Label();
            this.txtUsername = new TextBox();

            this.lblPassword = new Label();
            this.txtPassword = new TextBox();

            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();

            this.lblName = new Label();
            this.txtName = new TextBox();

            this.lblEmail = new Label();
            this.txtEmail = new TextBox();

            this.lblPhone = new Label();
            this.txtPhone = new TextBox();

            this.lblCompany = new Label();
            this.txtCompany = new TextBox();

            this.btnSignUp = new Button();
            this.btnCancel = new Button();

            this.panelSignUp.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelSignUp
            // 
            this.panelSignUp.BackColor = Color.White;
            this.panelSignUp.BorderStyle = BorderStyle.FixedSingle;
            this.panelSignUp.Size = new Size(1000, 1200);
            this.panelSignUp.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - 1000) / 2,
                ((Screen.PrimaryScreen.WorkingArea.Height - 1200) / 2)-100);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            this.lblTitle.Text = "Sign Up";
            // Center horizontally in panel
            this.lblTitle.Location = new Point(((panelSignUp.Width - 250) / 2) - 60, 20);
            this.panelSignUp.Controls.Add(this.lblTitle);

            // Layout constants
            int labelX = 80;
            int inputX = 80;
            int inputWidth = 800;
            int inputHeight = 60;
            int startY = 120;  // ← pushed fields slightly lower
            int spacingY = 120;
            Font labelFont = new Font("Segoe UI", 18F, FontStyle.Regular);
            Font inputFont = new Font("Segoe UI", 18F);

            // Reusable layout method
            void AddLabelAndTextBox(Label lbl, TextBox txt, string labelText, int index, bool isPassword = false)
            {
                int yLabel = startY + index * spacingY;
                int yInput = yLabel + 50;

                lbl.AutoSize = true;
                lbl.Font = labelFont;
                lbl.Location = new Point(labelX, yLabel);
                lbl.Text = labelText;

                txt.Font = inputFont;
                txt.Size = new Size(inputWidth, inputHeight);
                txt.Location = new Point(inputX, yInput);
                if (isPassword)
                    txt.PasswordChar = '*';

                panelSignUp.Controls.Add(lbl);
                panelSignUp.Controls.Add(txt);
            }

            AddLabelAndTextBox(lblUsername, txtUsername, "Username:", 0);
            AddLabelAndTextBox(lblPassword, txtPassword, "Password:", 1, true);
            AddLabelAndTextBox(lblConfirmPassword, txtConfirmPassword, "Confirm Password:", 2, true);
            AddLabelAndTextBox(lblName, txtName, "Name:", 3);
            AddLabelAndTextBox(lblEmail, txtEmail, "Email:", 4);
            AddLabelAndTextBox(lblPhone, txtPhone, "Phone:", 5);
            AddLabelAndTextBox(lblCompany, txtCompany, "Company:", 6);

            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = Color.MediumSeaGreen;
            this.btnSignUp.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.btnSignUp.ForeColor = Color.White;
            this.btnSignUp.Size = new Size(300, 80);
            this.btnSignUp.Location = new Point(110, startY + 7 * spacingY + 20);
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new EventHandler(this.btnSignUp_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.Black;
            this.btnCancel.Size = new Size(300, 80);
            this.btnCancel.Location = new Point(530, startY + 7 * spacingY + 20);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add buttons
            this.panelSignUp.Controls.Add(this.btnSignUp);
            this.panelSignUp.Controls.Add(this.btnCancel);

            // 
            // SignUp (Form)
            // 
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Controls.Add(this.panelSignUp);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "SignUp";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            this.panelSignUp.ResumeLayout(false);
            this.panelSignUp.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
