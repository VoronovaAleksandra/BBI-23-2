using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace VehicleApp
{    
    class Program
    {
        static void Main()
        {
            var garages = new List<Garage>
            {
                new Garage("Garage 1", 500),
                new Garage("Garage 2", 500),
                new Garage("Garage 3", 500),
                new Garage("Garage 4", 500),
                new Garage("Garage 5", 500)
            };

            var vehicles = new List<Vehicle>
            {
                new Car("Toyota", 150, 2.5, 4, 4, "Red", 200),
                new Truck("Volvo", 100, 3, 6, 5000, 8, 120),
                new Motorcycle("Harley-Davidson", 200, 1.5, 2, "Cruiser", "1200cc", 220),
                new Car("Ford", 140, 2.7, 4.5, 2, "Blue", 180),
                new Truck("Mercedes-Benz", 110, 3.2, 6.5, 6000, 6, 130),
                new Motorcycle("Yamaha", 180, 1.3, 2.2, "Sport", "1000cc", 200),
                new Car("Chevrolet", 130, 2.6, 4.2, 4, "Black", 170),
                new Truck("Ford", 120, 3.5, 7, 7000, 10, 140),
                new Motorcycle("Ducati", 190, 1.4, 2.1, "Cafe Racer", "900cc", 210),
                new Car("Honda", 160, 2.4, 4.3, 4, "Silver", 190),
                new Truck("Scania", 105, 3.7, 7.5, 8000, 12, 115),
                new Truck("Scania", 105, 3.7, 7.5, 8000, 12, 115),
                new Motorcycle("Kawasaki", 170, 1.6, 2.3, "Cruiser", "1500cc", 190),
                new Car("BMW", 155, 2.8, 4.7, 4, "White", 200),
                new Truck("MAN", 115, 3.8, 7.7, 9000, 14, 125),
                new Motorcycle("Triumph", 175, 1.7, 2.4, "Adventure", "1200cc", 210)
            };

            // Distribute vehicles across garages
            for (int i = 0; i < garages.Count; i++)
            {
                garages[i].AddVehicle(vehicles[i * 3]);
                garages[i].AddVehicle(vehicles[i * 3 + 1]);
                garages[i].AddVehicle(vehicles[i * 3 + 2]);
            }

            // Sort vehicles by area in each garage and display
            foreach (var garage in garages)
            {
                garage.SortVehiclesByArea();
                Console.WriteLine(garage);
            }

            // Serialization example
            var serializer = new MyJsonSerializer();
            string filePath = "garages.json";
            serializer.Write(garages, filePath);

            // Deserialize and display data from the file
            var deserializedGarages = serializer.Read(filePath);
            foreach (var garage in deserializedGarages)
            {
                Console.WriteLine(garage);
            }
        }
    }
}