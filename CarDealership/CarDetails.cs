using CarDealership;
using DevExpress.Export.Xl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class CarDetails : Form
    {
        public CarDetails(Car car)
        {
            InitializeComponent();
            LoadDetails(car);
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadDetails(Car car)
        {
            lblMakeModel.Text = $"{car.Make} {car.Model}";
            lblYear.Text = $"Year: {car.Year}";
            lblPrice.Text = $"Price: {car.Price}";
            lblMileage.Text = $"Mileage: {car.Mileage} km";
            lblCondition.Text = $"Condition: {car.Condition}";
            lblFuel.Text = $"Fuel Type: {car.FuelType}";
            lblTransmission.Text = $"Transmission: {car.Transmission}";
            lblColor.Text = $"Color: {car.Color}";
            lblVIN.Text = $"VIN: {car.VIN}";

            try
            {
                picCar.Image = Image.FromFile(car.ImagePath);
            }
            catch
            {
                picCar.Image = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMorePics_Click(object sender, EventArgs e)
        {
            MessageBox.Show("More Pics  feature is not implemented yet.");

        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buy feature is not implemented yet.");
        }
    }
}
