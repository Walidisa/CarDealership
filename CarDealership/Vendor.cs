using System;
using System.Collections.Generic;

namespace CarDealership
{
    public class Vendor
    {
        
        public string VendorID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public List<Car> CarsListed { get; set; }
        public List<BuyerMessage> Inbox { get; set; }  // NEW
        public static List<Vendor> AllVendors { get; } = new List<Vendor>();


        public Vendor(string username, string name, string email, string phone, string company = "")
        {
            VendorID = Guid.NewGuid().ToString();
            Username = username;
            Name = name;
            Email = email;
            Phone = phone;
            Company = company;
            CarsListed = new List<Car>();
            Inbox = new List<BuyerMessage>();
        }

        public void UploadCar(Car car)
        {
            car.Vendor = this;  // Link back to vendor
            CarsListed.Add(car);
        }


        // Remove a car from vendor's list (by car object)
        public bool RemoveCar(Car car)
        {
            return CarsListed.Remove(car);
        }

        // Optional: display vendor info
        public override string ToString()
        {
            return $"{Name} ({Email}) - {Company}";
        }
    }
}
