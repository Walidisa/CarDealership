using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    partial class InboxForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxMessages;
        private TextBox txtDetails;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();

            // 
            // listBoxMessages
            // 
            this.listBoxMessages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.ItemHeight = 37;
            this.listBoxMessages.Location = new System.Drawing.Point(400, 100);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(400, 500);
            this.listBoxMessages.TabIndex = 0;
            this.listBoxMessages.SelectedIndexChanged += new System.EventHandler(this.listBoxMessages_SelectedIndexChanged);

            // 
            // txtDetails
            // 
            this.txtDetails.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtDetails.Location = new System.Drawing.Point(840, 100);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(400, 500);
            this.txtDetails.TabIndex = 1;

            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDelete.Location = new System.Drawing.Point(400, 630);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(840, 50);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Selected Message";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // InboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.listBoxMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InboxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendor Inbox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
