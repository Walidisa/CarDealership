using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    partial class UploadCar
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMake, lblModel, lblYear, lblPrice, lblImage, lblMileage, lblCondition,
                      lblFuel, lblTransmission, lblColor, lblVIN;
        private TextBox txtMake, txtModel, txtYear, txtPrice, txtImagePath,
                        txtMileage, txtFuel, txtTransmission, txtColor, txtVIN;
        private ComboBox cmbCondition;
        private Button btnBrowseImage, btnSubmit;
        private PictureBox pictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Upload Car";
            this.Size = new Size(900, 1200);
            this.BackColor = Color.WhiteSmoke;
            this.StartPosition = FormStartPosition.CenterScreen;

            Font labelFont = new Font("Segoe UI", 11.2F);
            Font inputFont = new Font("Segoe UI", 12F);

            int labelX = 190;
            int inputX = 390;

            lblMake = new Label() { Text = "Make:", Location = new Point(labelX, 30), Font = labelFont, Size = new Size(200, 50) };
            txtMake = new TextBox() { Location = new Point(inputX, 30), Size = new Size(380, 30), Font = inputFont };

            lblModel = new Label() { Text = "Model:", Location = new Point(labelX, 100), Font = labelFont, Size = new Size(200, 50) };
            txtModel = new TextBox() { Location = new Point(inputX, 100), Size = new Size(380, 30), Font = inputFont };

            lblYear = new Label() { Text = "Year:", Location = new Point(labelX, 170), Font = labelFont, Size = new Size(200, 50) };
            txtYear = new TextBox() { Location = new Point(inputX, 170), Size = new Size(380, 30), Font = inputFont };

            lblPrice = new Label() { Text = "Price:", Location = new Point(labelX, 240), Font = labelFont, Size = new Size(200, 50) };
            txtPrice = new TextBox() { Location = new Point(inputX, 240), Size = new Size(380, 30), Font = inputFont };

            lblImage = new Label() { Text = "Image:", Location = new Point(labelX, 310), Font = labelFont, Size = new Size(200, 50) };
            txtImagePath = new TextBox() { Location = new Point(inputX, 310), Size = new Size(380, 30), Font = inputFont };
            btnBrowseImage = new Button() { Text = "Browse", Location = new Point(800, 310), Size = new Size(150, 50) };
            btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);

            lblMileage = new Label() { Text = "Mileage:", Location = new Point(labelX, 380), Font = labelFont, Size = new Size(200, 50) };
            txtMileage = new TextBox() { Location = new Point(inputX, 380), Size = new Size(380, 30), Font = inputFont };

            lblCondition = new Label() { Text = "Condition:", Location = new Point(labelX, 450), Font = labelFont, Size = new Size(200, 50) };
            cmbCondition = new ComboBox() { Location = new Point(inputX, 450), Size = new Size(380, 30), Font = inputFont };
            cmbCondition.Items.AddRange(new string[] { "New", "Used" });

            lblFuel = new Label() { Text = "Fuel Type:", Location = new Point(labelX, 520), Font = labelFont, Size = new Size(200, 50) };
            txtFuel = new TextBox() { Location = new Point(inputX, 520), Size = new Size(380, 30), Font = inputFont };

            lblTransmission = new Label() { Text = "Transmission:", Location = new Point(labelX, 590), Font = labelFont, Size = new Size(200, 50) };
            txtTransmission = new TextBox() { Location = new Point(inputX, 590), Size = new Size(380, 30), Font = inputFont };

            lblColor = new Label() { Text = "Color:", Location = new Point(labelX, 660), Font = labelFont, Size = new Size(200, 50) };
            txtColor = new TextBox() { Location = new Point(inputX, 660), Size = new Size(380, 30), Font = inputFont };

            lblVIN = new Label() { Text = "VIN:", Location = new Point(labelX, 730), Font = labelFont, Size = new Size(200, 50) };
            txtVIN = new TextBox() { Location = new Point(inputX, 730), Size = new Size(380, 30), Font = inputFont };

            pictureBox = new PictureBox()
            {
                Location = new Point(800, 30),
                Size = new Size(200, 200),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            btnSubmit = new Button()
            {
                Text = "Submit",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                Size = new Size(300, 70),
                Location = new Point(300, 800)
            };
            btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.Controls.AddRange(new Control[]
            {
        lblMake, txtMake,
        lblModel, txtModel,
        lblYear, txtYear,
        lblPrice, txtPrice,
        lblImage, txtImagePath, btnBrowseImage,
        lblMileage, txtMileage,
        lblCondition, cmbCondition,
        lblFuel, txtFuel,
        lblTransmission, txtTransmission,
        lblColor, txtColor,
        lblVIN, txtVIN,
        pictureBox,
        btnSubmit
            });

            this.ResumeLayout(false);
        }
    }
}
