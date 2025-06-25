using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class HomePage : Form
    {
        public static Vendor CurrentVendor = new Vendor("Samuel", "samuel@gmail.com", "0555-555-5555", "Samuel Enterprises");

        public HomePage()
        {
            InitializeComponent();

            // Hook up Activated event to refresh cars when form becomes active
            this.Activated += HomePage_Activated;

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadCars();
        }

        private void HomePage_Activated(object sender, EventArgs e)
        {
            LoadCars();
        }

        private void LoadCars()
        {
            // Clear existing cars to avoid duplicates on refresh
            carFlowPanel.Controls.Clear();

            List<Car> cars = DatabaseHelper.GetAllCars();

            foreach (var car in cars)
            {
                AddCarCard(car);
            }
        }

        private void AddCarCard(Car car)
        {
            Panel card = new Panel
            {
                Width = 430,
                Height = 600,
                Margin = new Padding(20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Width = 380,
                Height = 260,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(20, 20)
            };
            try
            {
                pic.Image = Image.FromFile(car.ImagePath);
            }
            catch
            {
                // Handle missing image gracefully, e.g. assign default image or skip
                pic.Image = null;
            }

            Label makeLabel = new Label
            {
                Text = $"{car.Make} {car.Model}",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(20, 300),
                AutoSize = true
            };

            Label yearLabel = new Label
            {
                Text = $"Year: {car.Year}",
                Font = new Font("Segoe UI", 14),
                Location = new Point(20, 380),
                AutoSize = true
            };

            Label priceLabel = new Label
            {
                Text = $"Price: {car.Price}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 420),
                AutoSize = true,
                ForeColor = Color.Green
            };

            Button viewBtn = new Button
            {
                Text = "View Details",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 500),
                Width = 350,
                Height = 80,
                Font = new Font("Segoe UI", 14),
                BackColor = Color.LightSteelBlue
            };

            viewBtn.Click += (s, e) =>
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is CarDetails)
                    {
                        f.BringToFront();
                        return;
                    }
                }
                CarDetails child = new CarDetails(car);
                if (this.MdiParent != null)
                    child.MdiParent = this.MdiParent;
                else
                    child.MdiParent = this;
                child.Show();
            };

            card.Controls.Add(pic);
            card.Controls.Add(makeLabel);
            card.Controls.Add(yearLabel);
            card.Controls.Add(priceLabel);
            card.Controls.Add(viewBtn);
            carFlowPanel.Controls.Add(card);
        }
        public void PerformSearch(string query)
        {
            // Clear the current display first
            carFlowPanel.Controls.Clear();

            if (string.IsNullOrWhiteSpace(query))
            {
                // If empty query, just load all cars again
                LoadCars();
                return;
            }

            query = query.Trim().ToLower();

            // Get all cars from the database
            List<Car> allCars = DatabaseHelper.GetAllCars();

            // Filter cars by checking if query is contained in Make, Model, or Year or Price (converted to string)
            List<Car> filteredCars = allCars.FindAll(car =>
                (car.Make != null && car.Make.ToLower().Contains(query)) ||
                (car.Model != null && car.Model.ToLower().Contains(query)) ||
                car.Year.ToString().Contains(query) ||
                car.Price.ToString().Contains(query)
            );

            // Add filtered cars to the UI
            foreach (var car in filteredCars)
            {
                AddCarCard(car);
            }
        }

        private void carFlowPanel_Paint(object sender, PaintEventArgs e)
        {
            // Optional: custom paint logic
        }
    }
}
