using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            List<Car> cars = new List<Car>
            {
            new Car("Toyota", "Camry", 2021, "$24,000", "images/camry.jpeg",
                    15000, "Used", "Gasoline", "Automatic", "Silver", "JTNB11HK8M3001234"),

            new Car("Honda", "Civic", 2020, "$20,000", "images/civic.jpeg",
                    22000, "Used", "Gasoline", "Manual", "White", "2HGFC2F69LH000456"),

            new Car("Ford", "Mustang", 2022, "$35,000", "images/mustang.jpeg",
                    8000, "Used", "Gasoline", "Automatic", "Red", "1FA6P8TH4N5100789"),

            new Car("Tesla", "Model 3", 2023, "$42,000", "images/model3.jpeg",
                    3000, "New", "Electric", "Automatic", "Black", "5YJ3E1EA5PF321789"),

            new Car("Chevrolet", "Malibu", 2019, "$18,000", "images/malibu.jpeg",
                    36000, "Used", "Gasoline", "Automatic", "Blue", "1G1ZD5ST6KF158901"),

            new Car("Nissan", "Altima", 2021, "$22,000", "images/altima.jpeg",
                    17000, "Used", "Gasoline", "CVT", "Gray", "1N4BL4CV2MN320654"),

            new Car("BMW", "3 Series", 2022, "$45,000", "images/bmw3series.jpeg",
                    9000, "Used", "Gasoline", "Automatic", "White", "WBA5R1C03MFK21367"),

            new Car("Audi", "A4", 2023, "$50,000", "images/audiA4.jpeg",
                    2000, "New", "Gasoline", "Automatic", "Black", "WAUEAAF43PN003215"),

            new Car("Mercedes-Benz", "\nC-Class", 2021, "$48,000", "images/mercedesCClass.jpeg",
                    12000, "Used", "Gasoline", "Automatic", "Silver", "W1KWF8DB3MR658321"),

            new Car("Volkswagen", "Jetta", 2020, "$19,000", "images/jetta.jpeg",
                    25000, "Used", "Gasoline", "Automatic", "Red", "3VW2B7AJ8LM123456"),

            new Car("Hyundai", "Elantra", 2021, "$21,000", "images/elantra.jpeg",
                    18000, "Used", "Gasoline", "Automatic", "Blue", "5NPD84LF2MH123456"),

            new Car("Kia", "Optima", 2020, "$20,500", "images/optima.jpeg",
                    20000, "Used", "Gasoline", "Automatic", "White", "5XXGT4L39LG123456"),



        };

            foreach (var car in cars)
                AddCarCard(car);
        }

        private void AddCarCard(Car car)
        {
            Panel card = new Panel
            {
                Width = 430, // Much bigger width
                Height = 600, // Much bigger height
                Margin = new Padding(20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Width = 380,
                Height = 260,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(car.ImagePath),
                Location = new Point(20, 20)
            };

            Label makeLabel = new Label
            {
                Text = $"{car.Make} {car.Model}",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(20, 300), // was 300
                AutoSize = true
            };

            Label yearLabel = new Label
            {
                Text = $"Year: {car.Year}",
                Font = new Font("Segoe UI", 14),
                Location = new Point(20, 380), // was 340
                AutoSize = true
            };

            Label priceLabel = new Label
            {
                Text = $"Price: {car.Price}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 420), // was 380
                AutoSize = true,
                ForeColor = Color.Green
            };

            Button viewBtn = new Button
            {
                Text = "View Details",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 500), // unchanged, but you can lower if needed
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
                // Use the top-level MDI container as the parent
                if (this.MdiParent != null)
                    child.MdiParent = this.MdiParent;
                else
                    child.MdiParent = this; // fallback, but only if this is the MDI container
                child.Show();
            };


            card.Controls.Add(pic);
            card.Controls.Add(makeLabel);
            card.Controls.Add(yearLabel);
            card.Controls.Add(priceLabel);
            card.Controls.Add(viewBtn);
            carFlowPanel.Controls.Add(card);
        }
    }

    public class Car
    {
        public string Make, Model, Price, ImagePath, Condition, FuelType, Transmission, Color, VIN;
        public int Year, Mileage;

        public Car(string make, string model, int year, string price, string imagePath,
                   int mileage, string condition, string fuelType, string transmission, string color, string vin)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            ImagePath = imagePath;
            Mileage = mileage;
            Condition = condition;
            FuelType = fuelType;
            Transmission = transmission;
            Color = color;
            VIN = vin;
        }
    }

}

