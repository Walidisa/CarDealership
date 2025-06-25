using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    partial class VendorDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private Label lblVendorName;
        private ListBox lstCars;
        private Button btnUpload, btnRemove, btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.lblVendorName = new Label();
            this.lstCars = new ListBox();
            this.btnUpload = new Button();
            this.btnRemove = new Button();
            this.btnExit = new Button();

            this.SuspendLayout();

            // 
            // Form settings
            // 
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.Name = "VendorDashboard";
            this.Text = "Vendor Dashboard";
            this.ClientSize = new Size(1200, 800);

            // 
            // mainPanel - centered panel container
            // 
            this.mainPanel.Size = new Size(950, 750);
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.BorderStyle = BorderStyle.FixedSingle;

            // Center the panel inside the form (adjusted on resize)
            this.mainPanel.Location = new Point(
                (this.ClientSize.Width - this.mainPanel.Width) / 2,
                (this.ClientSize.Height - this.mainPanel.Height) / 2
            );

            // 
            // lblVendorName
            // 
            this.lblVendorName.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblVendorName.TextAlign = ContentAlignment.MiddleCenter;
            this.lblVendorName.Size = new Size(860, 80);
            this.lblVendorName.Location = new Point(20, 20);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.TabIndex = 0;

            // 
            // lstCars
            // 
            this.lstCars.Font = new Font("Segoe UI", 14F);
            this.lstCars.ItemHeight = 32;
            this.lstCars.Size = new Size(860, 460);
            this.lstCars.Location = new Point(20, lblVendorName.Bottom + 20);
            this.lstCars.Name = "lstCars";
            this.lstCars.TabIndex = 1;

            // Buttons layout inside panel
            int btnWidth = 260;
            int btnHeight = 65;
            int btnSpacing = 40;

            int buttonsY = lstCars.Bottom + 20;

            int totalButtonsWidth = 3 * btnWidth + 2 * btnSpacing;
            int startX = (this.mainPanel.Width - totalButtonsWidth) / 2;

            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = Color.LightSkyBlue;
            this.btnUpload.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnUpload.Size = new Size(btnWidth, btnHeight);
            this.btnUpload.Location = new Point(startX, buttonsY);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload New Car";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new EventHandler(this.btnUpload_Click);

            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = Color.Orange;
            this.btnRemove.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnRemove.Size = new Size(btnWidth, btnHeight);
            this.btnRemove.Location = new Point(startX + btnWidth + btnSpacing, buttonsY);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);

            // 
            // btnExit
            // 
            this.btnExit.BackColor = Color.LightGray;
            this.btnExit.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnExit.Size = new Size(btnWidth, btnHeight);
            this.btnExit.Location = new Point(startX + 2 * (btnWidth + btnSpacing), buttonsY);
            this.btnExit.Name = "btnExit";
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Log Out";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // Add controls to panel
            this.mainPanel.Controls.Add(this.lblVendorName);
            this.mainPanel.Controls.Add(this.lstCars);
            this.mainPanel.Controls.Add(this.btnUpload);
            this.mainPanel.Controls.Add(this.btnRemove);
            this.mainPanel.Controls.Add(this.btnExit);

            // Add panel to form
            this.Controls.Add(this.mainPanel);

            this.ResumeLayout(false);

            // Add form resize handler to keep panel centered
            this.Resize += VendorDashboard_Resize;
        }

        private void VendorDashboard_Resize(object sender, EventArgs e)
        {
            if (this.mainPanel != null)
            {
                this.mainPanel.Location = new Point(
                    (this.ClientSize.Width - this.mainPanel.Width) / 2,
                    (this.ClientSize.Height - this.mainPanel.Height) / 2
                );
            }
        }
    }
}
