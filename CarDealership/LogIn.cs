using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class LogIn : Form
    {
        public static bool IsVendorLoggedIn = false;
        public static Vendor vendor;
        public LogIn()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
           Vendor vendorFromDb = DatabaseHelper.GetVendorByUsernameAndPassword(username, password);

            if (vendorFromDb != null)
            {
                vendor = vendorFromDb;

                RibbonForm1.currentVendor = vendorFromDb;

                MessageBox.Show($"Login successful! Logged in as {vendor.Name}.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                IsVendorLoggedIn = true;

                foreach (Form f in Application.OpenForms)
                {
                    if (f is RibbonForm1 ribbonForm)
                    {
                        ribbonForm.UpdateUIAfterLogin();
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnQuickLogIn_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "guest"; // Example username
            txtPassword.Text = "guest123"; // Example password
            btnLogin.PerformClick(); // Trigger the login button click event

        }
    }
}
