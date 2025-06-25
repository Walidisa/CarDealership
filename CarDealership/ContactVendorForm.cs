using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarDealership
{
    public partial class ContactVendorForm : Form
    {
        private Car selectedCar;

        public ContactVendorForm(Car car)
        {
            InitializeComponent();
            selectedCar = car;

            txtSubject.Text = $"Interested in {car.Make} {car.Model}";
            txtSubject.ReadOnly = true;
            txtMessage.Text = $"Hello,\n\nI am interested in the {car.Make} {car.Model} ({car.Year}).\n\nPlease provide more details.\n\nThank you!";

            this.Text = "Contact Seller";
            this.Size = new Size(900, 1200);
            this.BackColor = Color.WhiteSmoke;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BuyerMessage message = new BuyerMessage(
                txtName.Text,
                txtEmail.Text,
                txtMessage.Text,
                selectedCar
            );

            // Add to in-memory Inbox list
            selectedCar.Vendor?.Inbox.Add(message);

            // Save to database
            if (selectedCar.Vendor != null)
            {
                try
                {
                    DatabaseHelper.InsertBuyerMessage(message, selectedCar.Vendor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send message to vendor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Don't close the form on failure
                }
            }
            else
            {
                MessageBox.Show("No vendor associated with this car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Message sent to vendor successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContactVendorForm_Load(object sender, EventArgs e)
        {
            // optional customization
        }

        private void lblSubject_Click(object sender, EventArgs e)
        {

        }
    }
}
