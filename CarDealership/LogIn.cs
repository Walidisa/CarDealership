using System;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Dummy login check (replace with actual logic)
            if ((username == "admin" && password == "admin123") || 
                (username == "staff" && password == "staff123"))
            {
                MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HomePage home = new HomePage(); // or navigate to a dashboard
                home.Show();
                this.Hide();
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
    }
}
