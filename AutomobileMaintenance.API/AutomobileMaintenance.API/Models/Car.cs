using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AutomobileMaintenance.API.Models
{
    public class Car
    {
        public Car()
        {

        }

        public Car(long carid, string name, long year, DateTime purchasedate, string description, long status, long flags)
        {
            CarID = carid;
            Name = name;
            Year = year;
            PurchaseDate = purchasedate;
            Description = description;
            Status = status;
            Flags = flags;
        }

        public long CarID { get; set; }
        public string Name { get; set; }
        public long Year { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public long Status { get; set; }
        public long Flags { get; set; }

        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            string connectionString = @"Server=LEVICKYSURFACE;Database=AutomobileMaintenance;User Id=sa;Password=poi890; ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "SELECT carid, name, year, purchasedate, description, status, flags " +
                    "FROM dbo.car", con);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(new Car(reader.GetInt64(0),
                                         reader.GetString(1),
                                         reader.GetInt64(2),
                                         reader.GetDateTime(3),
                                         reader.GetString(4),
                                         reader.GetInt64(5),
                                         reader.GetInt64(6)));
                    }
                }
            }
            return cars;
        }
    }
}
