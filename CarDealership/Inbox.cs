using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CarDealership
{
    public partial class InboxForm : Form
    {
        public static Vendor currentVendor { get; set; } // Static property to hold the current vendor

        private List<BuyerMessage> messages;

        public InboxForm(Vendor vendor)
        {
            InitializeComponent();
            currentVendor = vendor;
            LoadMessagesFromDatabase();
            this.WindowState = FormWindowState.Maximized;

            this.Activated += InboxForm_Activated;
            this.Shown += InboxForm_Shown;
        }

        private void InboxForm_Activated(object sender, EventArgs e)
        {
            LoadMessagesFromDatabase();
        }

        private void InboxForm_Shown(object sender, EventArgs e)
        {
            LoadMessagesFromDatabase();
        }

        private void LoadMessagesFromDatabase()
        {
            listBoxMessages.Items.Clear();
            txtDetails.Clear();  // Clear any old message

            if (currentVendor.Name.ToLower() == "admin")
            {
                // Load feedback messages sent to admin
                var feedbackMessages = DatabaseHelper.GetFeedbackMessagesByVendor(currentVendor.VendorID);
                messages = new List<BuyerMessage>(); // Clear buyer messages context

                foreach (var feedback in feedbackMessages)
                {
                    listBoxMessages.Items.Add($"From: {feedback.FromName} ({feedback.FromEmail})");  // Simplified display
                }

                // Attach selection handler for feedback
                listBoxMessages.SelectedIndexChanged -= listBoxMessages_SelectedIndexChanged;
                listBoxMessages.SelectedIndexChanged += listBoxFeedback_SelectedIndexChanged;
            }
            else
            {
                // Load buyer messages for vendor
                messages = DatabaseHelper.GetBuyerMessagesByVendor(currentVendor.VendorID);

                foreach (var msg in messages)
                {
                    listBoxMessages.Items.Add(msg);  // ToString() will show car info
                }

                // Attach selection handler for buyer messages
                listBoxMessages.SelectedIndexChanged -= listBoxFeedback_SelectedIndexChanged;
                listBoxMessages.SelectedIndexChanged += listBoxMessages_SelectedIndexChanged;
            }
        }

        private void listBoxFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {
            var feedbackMessages = DatabaseHelper.GetFeedbackMessagesByVendor(currentVendor.VendorID);

            int selectedIndex = listBoxMessages.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < feedbackMessages.Count)
            {
                var feedback = feedbackMessages[selectedIndex];
                txtDetails.Text =
                    $"From: {feedback.FromName} ({feedback.FromEmail})\r\n\r\n" +
                    $"Message:\r\n{feedback.MessageBody}\r\n\r\n" +
                    $"Received At: {feedback.ReceivedAt}";
            }
            else
            {
                txtDetails.Clear();
            }
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMessages.SelectedIndex >= 0 && listBoxMessages.SelectedIndex < messages.Count)
            {
                BuyerMessage msg = messages[listBoxMessages.SelectedIndex];
                string nl = Environment.NewLine;
                txtDetails.Text = $"From: {msg.FromName} ({msg.FromEmail}){nl}" +
                                  $"Car: {msg.RelatedCar.Make} {msg.RelatedCar.Model} ({msg.RelatedCar.Year}){nl}" +
                                  $"Message: {msg.MessageBody}";
            }
            else
            {
                txtDetails.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxMessages.SelectedIndex;
            if (index >= 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this message?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    if (currentVendor.Name.ToLower() == "admin")
                    {
                        var feedbacks = DatabaseHelper.GetFeedbackMessagesByVendor(currentVendor.VendorID);
                        var messageToDelete = feedbacks[index];
                        DatabaseHelper.DeleteFeedbackMessage(messageToDelete); // You must define this method
                    }
                    else
                    {
                        var messageToDelete = messages[index];
                        DatabaseHelper.DeleteBuyerMessage(messageToDelete); // You must define this method
                    }

                    LoadMessagesFromDatabase(); // Reload UI after deletion
                    txtDetails.Clear();
                }
            }
            else
            {
                MessageBox.Show("Select a message to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void InboxForm_Load(object sender, EventArgs e)
        {

        }
    }
}
