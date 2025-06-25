using System.Drawing;
using System.Windows.Forms;
using System;

namespace CarDealership
{
    partial class CarDetails
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picCar;
        private Label lblMakeModel, lblYear, lblPrice, lblMileage,
                      lblCondition, lblFuel, lblTransmission, lblColor,
                      lblVIN, lblVendor;
        private Button btnClose, btnBuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picCar = new PictureBox();
            this.lblMakeModel = new Label();
            this.lblYear = new Label();
            this.lblPrice = new Label();
            this.lblMileage = new Label();
            this.lblCondition = new Label();
            this.lblFuel = new Label();
            this.lblTransmission = new Label();
            this.lblColor = new Label();
            this.lblVIN = new Label();
            this.lblVendor = new Label(); // NEW
            this.btnClose = new Button();
            this.btnBuy = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            this.SuspendLayout();

            // Form
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.Text = "Car Details";

            // picCar
            this.picCar.Location = new Point(50, 250);
            this.picCar.Size = new Size(1600, 1000);
            this.picCar.SizeMode = PictureBoxSizeMode.Zoom;

            int labelX = 1650;
            int startY = 150;
            int verticalSpacing = 80;

            // lblMakeModel
            this.lblMakeModel.Font = new Font("Segoe UI", 35F, FontStyle.Bold);
            this.lblMakeModel.Location = new Point(labelX, startY - 40);
            this.lblMakeModel.AutoSize = true;

            // lblYear
            this.lblYear.Font = new Font("Segoe UI", 25F);
            this.lblYear.Location = new Point(labelX, startY + 1 * verticalSpacing);
            this.lblYear.AutoSize = true;

            // lblPrice
            this.lblPrice.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            this.lblPrice.ForeColor = Color.Green;
            this.lblPrice.Location = new Point(labelX, startY + 2 * verticalSpacing);
            this.lblPrice.AutoSize = true;

            // lblMileage
            this.lblMileage.Font = new Font("Segoe UI", 25F);
            this.lblMileage.Location = new Point(labelX, startY + 3 * verticalSpacing);
            this.lblMileage.AutoSize = true;

            // lblCondition
            this.lblCondition.Font = new Font("Segoe UI", 25F);
            this.lblCondition.Location = new Point(labelX, startY + 4 * verticalSpacing);
            this.lblCondition.AutoSize = true;

            // lblFuel
            this.lblFuel.Font = new Font("Segoe UI", 25F);
            this.lblFuel.Location = new Point(labelX, startY + 5 * verticalSpacing);
            this.lblFuel.AutoSize = true;

            // lblTransmission
            this.lblTransmission.Font = new Font("Segoe UI", 25F);
            this.lblTransmission.Location = new Point(labelX, startY + 6 * verticalSpacing);
            this.lblTransmission.AutoSize = true;

            // lblColor
            this.lblColor.Font = new Font("Segoe UI", 25F);
            this.lblColor.Location = new Point(labelX, startY + 7 * verticalSpacing);
            this.lblColor.AutoSize = true;

            // lblVIN
            this.lblVIN.Font = new Font("Segoe UI", 25F);
            this.lblVIN.Location = new Point(labelX, startY + 8 * verticalSpacing);
            this.lblVIN.AutoSize = true;

            // lblVendor (NEW)
            this.lblVendor.Font = new Font("Segoe UI", 25F);
            this.lblVendor.Location = new Point(labelX, startY + 9 * verticalSpacing);
            this.lblVendor.AutoSize = true;

            // btnBuy
            this.btnBuy.Text = "Buy";
            this.btnBuy.TextAlign = ContentAlignment.MiddleCenter;
            this.btnBuy.Font = new Font("Segoe UI", 23F);
            this.btnBuy.Size = new Size(400, 140);
            this.btnBuy.Location = new Point(labelX, 20 + startY + 10 * verticalSpacing);
            this.btnBuy.BackColor = Color.LightSteelBlue;
            this.btnBuy.Click += new EventHandler(this.btnBuy_Click);

            // btnClose
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = ContentAlignment.MiddleCenter;
            this.btnClose.Font = new Font("Segoe UI", 23F);
            this.btnClose.Size = new Size(400, 140);
            this.btnClose.Location = new Point(labelX + 500, 20 + startY + 10 * verticalSpacing);
            this.btnClose.BackColor = Color.LightSteelBlue;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // Add Controls
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.lblMakeModel);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.lblFuel);
            this.Controls.Add(this.lblTransmission);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblVIN);
            this.Controls.Add(this.lblVendor); // NEW
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnClose);

            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
