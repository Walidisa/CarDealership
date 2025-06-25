using DevExpress.Utils.Drawing.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarDealership
{
    public partial class ContactUs : Form
    {

        public static List<FeedbackMessage> adminMessages { get; set; } = new List<FeedbackMessage>();
        // public static Vendor admin {  get; set; }
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
            Debug.WriteLine("Before creating BuyerMessage");
            BuyerMessage message = new BuyerMessage(
                txtName.Text,
                txtEmail.Text,
                txtMessage.Text
            );
            Debug.WriteLine("After creating BuyerMessage");


            Vendor admin = DatabaseHelper.GetVendorByUsernameAndPassword("admin", "admin123");
            if (admin == null)
            {
                MessageBox.Show("Admin account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (admin.Inbox == null)
            {
                admin.Inbox = new List<BuyerMessage>();
            }
            admin.Inbox.Add(message);


            // Save to database
            try
            {
                DatabaseHelper.InsertFeedbackMessage(message, admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Don't close the form on failure
            }
            

            MessageBox.Show("Your message has been sent successfully!", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

        private void ContactUs_Load(object sender, EventArgs e)
        {

        }
    }
}
