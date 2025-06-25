using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class VendorDashboard : Form
    {
        private Vendor currentVendor;

        public VendorDashboard(Vendor vendor)
        {
            InitializeComponent();
            currentVendor = vendor;

            lblVendorName.Text = $"{vendor.Name}'s Cars";
            LoadVendorCars();
        }

        private void LoadVendorCars()
        {
            lstCars.Items.Clear();

            // Load cars from database for current vendor
            List<Car> cars = DatabaseHelper.GetCarsByVendor(currentVendor.VendorID);
            currentVendor.CarsListed = cars; // Update vendor's car list

            foreach (Car car in cars)
            {
                lstCars.Items.Add($"{car.Make} {car.Model} - {car.Price}");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var uploader = new UploadCar(currentVendor);
            if (uploader.ShowDialog() == DialogResult.OK && uploader.UploadSuccessful)
            {
                LoadVendorCars(); // Refresh only if upload was successful
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstCars.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var car = currentVendor.CarsListed[selectedIndex];

                // Remove from database
                if (DatabaseHelper.DeleteCar(car.VIN))
                {
                    currentVendor.CarsListed.RemoveAt(selectedIndex);
                    LoadVendorCars();
                }
                else
                {
                    MessageBox.Show("Could not delete car from database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a car to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Optional: Ask for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LogIn.IsVendorLoggedIn = false; // reset login status
                LogIn.vendor = null; 
                foreach (Form f in Application.OpenForms)
                {
                    if (f is RibbonForm1 ribbonForm)
                    {
                        ribbonForm.UpdateUIAfterLogout();
                    }
                }
                this.Close(); // close the dashboard after login opens

            }
        }
    }
}
