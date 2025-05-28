using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarDealership
{
    public partial class ContactUs : Form
    {
        public ContactUs()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For now, show a success message
            MessageBox.Show("Your message has been sent successfully!", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally clear fields
            txtName.Clear();
            txtEmail.Clear();
            txtSubject.Clear();
            txtMessage.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
