using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class UploadCar : Form
    {
        private Vendor currentVendor;
        public bool UploadSuccessful { get; private set; } = false;

        public UploadCar(Vendor vendor)
        {
            InitializeComponent();
            currentVendor = vendor;
            this.TopLevel = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal; // or Maximized
            this.Size = new Size(1300, 1300); // adjust as needed
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = false;

        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = ofd.FileName;
                pictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Car newCar = new Car(
                    txtMake.Text,
                    txtModel.Text,
                    int.Parse(txtYear.Text),
                    txtPrice.Text,
                    txtImagePath.Text,
                    txtMileage.Text,
                    cmbCondition.SelectedItem.ToString(),
                    txtFuel.Text,
                    txtTransmission.Text,
                    txtColor.Text,
                    txtVIN.Text,
                    currentVendor
                );

                // Save to database
                DatabaseHelper.InsertCar(newCar, currentVendor);
                currentVendor.UploadCar(newCar); // optional in-memory list update

                UploadSuccessful = true;
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Car uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
