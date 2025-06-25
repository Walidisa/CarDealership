using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarDealership
{
    public static class DatabaseHelper
    {
       private static string dbPath = "Dealership.db";
       // private static string dbPath = "C:\\Users\\walid\\source\\repos\\CarDealership\\CarDealership\\Dealership.db";


        public static string ConnectionString => $"Data Source={dbPath};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                Console.WriteLine("Database created.");
            }

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createVendorsTable = @"
                CREATE TABLE IF NOT EXISTS Vendors (
                    VendorID TEXT PRIMARY KEY,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    Email TEXT,
                    Phone TEXT,
                    Company TEXT
                );";

               string createCarsTable = @"
               CREATE TABLE IF NOT EXISTS Cars (
                VIN TEXT PRIMARY KEY,
                Make TEXT,
                Model TEXT,
                Year INTEGER,
                Price TEXT,
                Mileage TEXT,
                Condition TEXT,
                FuelType TEXT,
                Transmission TEXT,
                Color TEXT,
                ImagePath TEXT,
                VendorID TEXT,
                FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID) ON DELETE CASCADE
            );";

                string createBuyerMessagesTable = @"
            CREATE TABLE IF NOT EXISTS BuyerMessages (
                MessageID TEXT PRIMARY KEY,
                VendorID TEXT,
                FromName TEXT,
                FromEmail TEXT,
                MessageBody TEXT,
                CarVIN TEXT,
                ReceivedAt TEXT,
                FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID) ON DELETE CASCADE,
                FOREIGN KEY (CarVIN) REFERENCES Cars(VIN) ON DELETE CASCADE
            );";
                string createFeedbackMessagesTable = @"
            CREATE TABLE IF NOT EXISTS FeedbackMessages (
                MessageID TEXT PRIMARY KEY,
                VendorID TEXT,
                FromName TEXT,
                FromEmail TEXT,
                MessageBody TEXT,
                ReceivedAt TEXT,
                FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID) ON DELETE CASCADE
            );";


                using (SQLiteCommand cmd = new SQLiteCommand(createVendorsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createCarsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createBuyerMessagesTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(createFeedbackMessagesTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            EnsureAdminAccount(); //initialize admin account
            EnsureGuestAccount(); //initialize guest account

            List<Car> testCars = new List<Car>
            {
                new Car("Toyota", "Camry", 2021, "$24,000", "images/camry.jpeg", "15000", "Used", "Gasoline", "Automatic", "Silver", "JTNB11HK8M3001234"),
                new Car("Honda", "Civic", 2020, "$20,000", "images/civic.jpeg", "22000", "Used", "Gasoline", "Manual", "White", "2HGFC2F69LH000456"),
                new Car("Ford", "Mustang", 2022, "$35,000", "images/mustang.jpeg", "8000", "Used", "Gasoline", "Automatic", "Red", "1FA6P8TH4N5100789"),
                new Car("Tesla", "Model 3", 2023, "$42,000", "images/model3.jpeg", "3000", "New", "Electric", "Automatic", "Black", "5YJ3E1EA5PF321789"),
                new Car("Chevrolet", "Malibu", 2019, "$18,000", "images/malibu.jpeg", "36000", "Used", "Gasoline", "Automatic", "Blue", "1G1ZD5ST6KF158901"),
                new Car("Nissan", "Altima", 2021, "$22,000", "images/altima.jpeg", "17000", "Used", "Gasoline", "CVT", "Gray", "1N4BL4CV2MN320654"),
                new Car("BMW", "3 Series", 2022, "$45,000", "images/bmw3series.jpeg", "9000", "Used", "Gasoline", "Automatic", "White", "WBA5R1C03MFK21367"),
                new Car("Audi", "A4", 2023, "$50,000", "images/audiA4.jpeg", "2000", "New", "Gasoline", "Automatic", "Black", "WAUEAAF43PN003215"),
                new Car("Mercedes-Benz", "C-Class", 2021, "$48,000", "images/mercedesCClass.jpeg", "12000", "Used", "Gasoline", "Automatic", "Silver", "W1KWF8DB3MR658321"),
                new Car("Volkswagen", "Jetta", 2020, "$19,000", "images/jetta.jpeg", "25000", "Used", "Gasoline", "Automatic", "Red", "3VW2B7AJ8LM123456"),
                new Car("Hyundai", "Elantra", 2021, "$21,000", "images/elantra.jpeg", "18000", "Used", "Gasoline", "Automatic", "Blue", "5NPD84LF2MH123456"),
                new Car("Kia", "Optima", 2020, "$20,500", "images/optima.jpeg", "20000", "Used", "Gasoline", "Automatic", "White", "5XXGT4L39LG123456")
            };

            Vendor guest = GetVendorByUsernameAndPassword("guest", "guest123");
            foreach (var car in testCars)
            {
                try
                {
                    DatabaseHelper.InsertCar(car, guest);
                    guest.UploadCar(car); // Update in-memory list for guest vendor
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting car {car.Make} {car.Model}: {ex.Message}");
                }


            }

            void EnsureAdminAccount()
            {
                try
                {
                    using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(*) FROM Vendors WHERE Username = @Username";
                        using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Username", "admin");
                            long count = (long)checkCommand.ExecuteScalar();
                            if (count > 0) 
                            {
                                return;
                            }
                        }

                        string insertQuery = @"
                INSERT INTO Vendors (VendorID, Username, Password, Name, Email, Phone, Company)
                VALUES (@VendorID, @Username, @Password, @Name, @Email, @Phone, @Company);";

                        using (var command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@VendorID", Guid.NewGuid().ToString());
                            command.Parameters.AddWithValue("@Username", "admin");
                            command.Parameters.AddWithValue("@Password", "admin123");
                            command.Parameters.AddWithValue("@Name", "admin");
                            command.Parameters.AddWithValue("@Email", "admin");
                            command.Parameters.AddWithValue("@Phone", "admin");
                            command.Parameters.AddWithValue("@Company", "admin");

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Admin account created.", "Success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating admin account: " + ex.Message);
                }
            }

            void EnsureGuestAccount()
            {
                try
                {
                    using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(*) FROM Vendors WHERE Username = @Username";
                        using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Username", "guest");
                            long count = (long)checkCommand.ExecuteScalar();
                            if (count > 0)
                            {
                                return;
                            }
                        }

                        string insertQuery = @"
                INSERT INTO Vendors (VendorID, Username, Password, Name, Email, Phone, Company)
                VALUES (@VendorID, @Username, @Password, @Name, @Email, @Phone, @Company);";

                        using (var command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@VendorID", Guid.NewGuid().ToString());
                            command.Parameters.AddWithValue("@Username", "guest");
                            command.Parameters.AddWithValue("@Password", "guest123");
                            command.Parameters.AddWithValue("@Name", "Guest");
                            command.Parameters.AddWithValue("@Email", "guest@gmail.com");
                            command.Parameters.AddWithValue("@Phone", "000");
                            command.Parameters.AddWithValue("@Company", "");

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Guest account created.", "Success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating guest account: " + ex.Message);
                }
            }


        }

        public static Vendor GetVendorByUsernameAndPassword(string username, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Vendors WHERE Username = @username AND Password = @password";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Vendor(
                                reader["Username"].ToString(),
                                reader["Name"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"].ToString(),
                                reader["Company"].ToString()
                            )
                            {
                                VendorID = reader["VendorID"].ToString(),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void InsertVendor(Vendor vendor, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string insertVendor = @"
                    INSERT INTO Vendors (VendorID, Username, Password, Name, Email, Phone, Company)
                    VALUES (@VendorID, @Username, @Password, @Name, @Email, @Phone, @Company);";

                using (SQLiteCommand cmd = new SQLiteCommand(insertVendor, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendor.VendorID);
                    cmd.Parameters.AddWithValue("@Username", vendor.Username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Name", vendor.Name);
                    cmd.Parameters.AddWithValue("@Email", vendor.Email ?? "");
                    cmd.Parameters.AddWithValue("@Phone", vendor.Phone ?? "");
                    cmd.Parameters.AddWithValue("@Company", vendor.Company ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertCar(Car car, Vendor vendor)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // First, check if the car already exists by VIN
                string checkQuery = "SELECT COUNT(*) FROM Cars WHERE VIN = @VIN";
                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@VIN", car.VIN);
                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        // Already exists, skip insert
                        return;
                    }
                }

                // Insert only if it doesn't exist
                string insertQuery = @"
            INSERT INTO Cars 
            (Make, Model, Year, Price, ImagePath, Mileage, Condition, FuelType, Transmission, Color, VIN, VendorID) 
            VALUES 
            (@Make, @Model, @Year, @Price, @ImagePath, @Mileage, @Condition, @FuelType, @Transmission, @Color, @VIN, @VendorID)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Make", car.Make);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@Year", car.Year);
                    command.Parameters.AddWithValue("@Price", car.Price);
                    command.Parameters.AddWithValue("@ImagePath", car.ImagePath);
                    command.Parameters.AddWithValue("@Mileage", car.Mileage);
                    command.Parameters.AddWithValue("@Condition", car.Condition);
                    command.Parameters.AddWithValue("@FuelType", car.FuelType);
                    command.Parameters.AddWithValue("@Transmission", car.Transmission);
                    command.Parameters.AddWithValue("@Color", car.Color);
                    command.Parameters.AddWithValue("@VIN", car.VIN);
                    command.Parameters.AddWithValue("@VendorID", vendor.VendorID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Car> GetCarsByVendor(string vendorID)
        {
            List<Car> cars = new List<Car>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
            SELECT c.*, v.Username, v.Name, v.Email, v.Phone, v.Company
            FROM Cars c
            JOIN Vendors v ON c.VendorID = v.VendorID
            WHERE c.VendorID = @vendorID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@vendorID", vendorID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vendor = new Vendor(
                                reader["Username"].ToString(),
                                reader["Name"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"].ToString(),
                                reader["Company"].ToString()
                            )
                            {
                                VendorID = vendorID,
                                Username = reader["Username"].ToString()
                            };

                            Car car = new Car(
                                reader["Make"].ToString(),
                                reader["Model"].ToString(),
                                Convert.ToInt32(reader["Year"]),
                                reader["Price"].ToString(),
                                reader["ImagePath"].ToString(),
                                reader["Mileage"].ToString(),
                                reader["Condition"].ToString(),
                                reader["FuelType"].ToString(),
                                reader["Transmission"].ToString(),
                                reader["Color"].ToString(),
                                reader["VIN"].ToString(),
                                vendor
                            );

                            cars.Add(car);
                        }
                    }
                }
            }

            return cars;
        }

        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
            SELECT c.*, v.VendorID, v.Username, v.Name, v.Email, v.Phone, v.Company
            FROM Cars c
            JOIN Vendors v ON c.VendorID = v.VendorID";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var vendor = new Vendor(
                            reader["Username"].ToString(),
                            reader["Name"].ToString(),
                            reader["Email"].ToString(),
                            reader["Phone"].ToString(),
                            reader["Company"].ToString()
                        )
                        {
                            VendorID = reader["VendorID"].ToString(),
                            Username = reader["Username"].ToString()
                        };

                        Car car = new Car(
                            reader["Make"].ToString(),
                            reader["Model"].ToString(),
                            Convert.ToInt32(reader["Year"]),
                            reader["Price"].ToString(),
                            reader["ImagePath"].ToString(),
                            reader["Mileage"].ToString(),
                            reader["Condition"].ToString(),
                            reader["FuelType"].ToString(),
                            reader["Transmission"].ToString(),
                            reader["Color"].ToString(),
                            reader["VIN"].ToString(),
                            vendor
                        );

                        cars.Add(car);
                    }
                }
            }

            return cars;
        }

        public static bool DeleteCar(string vin)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Cars WHERE VIN = @vin";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@vin", vin);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;  // returns true if a row was deleted
                }
            }
        }
        public static bool DeleteVendor(string vendorID)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Enforce foreign keys
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }

                // Delete related cars first
                string deleteCarsSql = "DELETE FROM Cars WHERE VendorID = @vendorId";
                using (var deleteCarsCmd = new SQLiteCommand(deleteCarsSql, connection))
                {
                    deleteCarsCmd.Parameters.AddWithValue("@vendorId", vendorID);
                    deleteCarsCmd.ExecuteNonQuery();
                }

                // Delete related buyer messages (if you have them)
                string deleteMessagesSql = "DELETE FROM BuyerMessages WHERE VendorID = @vendorId";
                using (var deleteMessagesCmd = new SQLiteCommand(deleteMessagesSql, connection))
                {
                    deleteMessagesCmd.Parameters.AddWithValue("@vendorId", vendorID);
                    deleteMessagesCmd.ExecuteNonQuery();
                }

                // Delete feedback messages (if admin)
                string deleteFeedbackSql = "DELETE FROM FeedbackMessages WHERE VendorID = @vendorId";
                using (var deleteFeedbackCmd = new SQLiteCommand(deleteFeedbackSql, connection))
                {
                    deleteFeedbackCmd.Parameters.AddWithValue("@vendorId", vendorID);
                    deleteFeedbackCmd.ExecuteNonQuery();
                }

                // Finally, delete the vendor
                string deleteVendorSql = "DELETE FROM Vendors WHERE VendorID = @vendorId";
                using (var command = new SQLiteCommand(deleteVendorSql, connection))
                {
                    command.Parameters.AddWithValue("@vendorId", vendorID);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public static void InsertBuyerMessage(BuyerMessage message, Vendor vendor)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string insertSql = @"
            INSERT INTO BuyerMessages
            (VendorID, FromName, FromEmail, MessageBody, RelatedCarVIN, ReceivedAt)
            VALUES (@VendorID, @FromName, @FromEmail, @MessageBody, @RelatedCarVIN, @ReceivedAt);
        ";

                using (var cmd = new SQLiteCommand(insertSql, conn))
                {
                    // No need to set MessageID, it's auto-incremented
                    cmd.Parameters.AddWithValue("@VendorID", vendor.VendorID);
                    cmd.Parameters.AddWithValue("@FromName", message.FromName);
                    cmd.Parameters.AddWithValue("@FromEmail", message.FromEmail);
                    cmd.Parameters.AddWithValue("@MessageBody", message.MessageBody);
                    cmd.Parameters.AddWithValue("@RelatedCarVIN", message.RelatedCar.VIN);
                    cmd.Parameters.AddWithValue("@ReceivedAt", message.ReceivedAt.ToString("o"));  // ISO 8601 format

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertFeedbackMessage(BuyerMessage message, Vendor vendor)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string insertSql = @"
            INSERT INTO FeedbackMessages
            (VendorID, FromName, FromEmail, MessageBody, ReceivedAt)
            VALUES (@VendorID, @FromName, @FromEmail, @MessageBody, @ReceivedAt);
        ";

                using (var cmd = new SQLiteCommand(insertSql, conn))
                {
                    // No need to set MessageID, it's auto-incremented
                    cmd.Parameters.AddWithValue("@VendorID", vendor.VendorID);
                    cmd.Parameters.AddWithValue("@FromName", message.FromName);
                    cmd.Parameters.AddWithValue("@FromEmail", message.FromEmail);
                    cmd.Parameters.AddWithValue("@MessageBody", message.MessageBody);
                    cmd.Parameters.AddWithValue("@ReceivedAt", message.ReceivedAt.ToString("o"));  // ISO 8601 format

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<BuyerMessage> GetBuyerMessagesByVendor(string vendorID)
        {
            var messages = new List<BuyerMessage>();

            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                bm.FromName, 
                bm.FromEmail, 
                bm.MessageBody, 
                bm.ReceivedAt,
                c.Make, c.Model, c.Year, c.Price, c.Mileage, c.Condition,
                c.FuelType, c.Transmission, c.Color, c.VIN AS CarVIN, c.ImagePath,
                v.VendorID, v.Username, v.Name, v.Email, v.Phone, v.Company
            FROM BuyerMessages bm
            INNER JOIN Cars c ON bm.RelatedCarVIN = c.VIN
            INNER JOIN Vendors v ON bm.VendorID = v.VendorID
            WHERE bm.VendorID = @VendorID
            ORDER BY bm.ReceivedAt DESC;";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendorID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create Vendor object
                            Vendor vendor = new Vendor(
                                reader["Username"].ToString(),
                                reader["Name"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"].ToString(),
                                reader["Company"].ToString())
                            {
                                VendorID = reader["VendorID"].ToString()
                            };

                            // Create Car object linked to Vendor
                            Car car = new Car(
                                reader["Make"].ToString(),
                                reader["Model"].ToString(),
                                Convert.ToInt32(reader["Year"]),
                                reader["Price"].ToString(),
                                reader["ImagePath"].ToString(),
                                reader["Mileage"].ToString(),
                                reader["Condition"].ToString(),
                                reader["FuelType"].ToString(),
                                reader["Transmission"].ToString(),
                                reader["Color"].ToString(),
                                reader["CarVIN"].ToString(),
                                vendor
                            );

                            // Create BuyerMessage
                            BuyerMessage message = new BuyerMessage(
                                reader["FromName"].ToString(),
                                reader["FromEmail"].ToString(),
                                reader["MessageBody"].ToString(),
                                car
                            )
                            {
                                ReceivedAt = DateTime.Parse(reader["ReceivedAt"].ToString())
                            };

                            messages.Add(message);
                        }
                    }
                }
            }

            return messages;
        }
        public static List<BuyerMessage> GetFeedbackMessagesByVendor(string vendorID)
        {
            List<BuyerMessage> messages = new List<BuyerMessage>();

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT bm.FromName, bm.FromEmail, bm.MessageBody, bm.ReceivedAt
            FROM FeedbackMessages bm
            WHERE bm.VendorID = @vendorID;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@vendorID", vendorID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BuyerMessage message = new BuyerMessage(
                                reader["FromName"].ToString(),
                                reader["FromEmail"].ToString(),
                                reader["MessageBody"].ToString()
                            );

                            DateTime receivedAt;
                            if (DateTime.TryParse(reader["ReceivedAt"].ToString(), out receivedAt))
                            {
                                message.ReceivedAt = receivedAt;
                            }

                            messages.Add(message);
                        }
                    }
                }
            }

            return messages;
        }
        public static void DeleteBuyerMessage(BuyerMessage message)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string deleteQuery = @"
            DELETE FROM BuyerMessages
            WHERE VendorID = @VendorID AND FromEmail = @FromEmail AND CarVIN = @CarVIN AND MessageBody = @MessageBody;";

                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", message.RelatedCar.Vendor.VendorID);
                    cmd.Parameters.AddWithValue("@FromEmail", message.FromEmail);
                    cmd.Parameters.AddWithValue("@CarVIN", message.RelatedCar.VIN);
                    cmd.Parameters.AddWithValue("@MessageBody", message.MessageBody);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteFeedbackMessage(BuyerMessage message)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                string deleteQuery = @"
            DELETE FROM FeedbackMessages
            WHERE FromName = @FromName AND FromEmail = @FromEmail AND MessageBody = @MessageBody;";

                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FromName", message.FromName);
                    cmd.Parameters.AddWithValue("@FromEmail", message.FromEmail);
                    cmd.Parameters.AddWithValue("@MessageBody", message.MessageBody);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
