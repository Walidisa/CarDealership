using CarDealership;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Price { get; set; }
    public string Mileage { get; set; }
    public string Condition { get; set; }
    public string FuelType { get; set; }
    public string Transmission { get; set; }
    public string Color { get; set; }
    public string VIN { get; set; }
    public string ImagePath { get; set; }
    public Vendor Vendor { get; set; }  // Optional

    public Car(string make, string model, int year, string price, string imagePath, string mileage, string condition, string fuelType, string transmission, string color, string vin, Vendor vendor)
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
        Vendor = vendor;  // Link to vendor
    }
    public Car(string make, string model, int year, string price, string imagePath, string mileage, string condition, string fuelType, string transmission, string color, string vin)
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

    public override string ToString()
    {
        return $"{Year} {Make} {Model} - {Price}";
    }
}

