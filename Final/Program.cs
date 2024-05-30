using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Formats.Asn1;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;

namespace VehicleApp
{
    //ТС
    public class Vehicle
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Area => Width * Length;

        public Vehicle() { }

        public Vehicle(string name, int speed, double width, double length)
        {
            Name = name;
            Speed = speed;
            Width = width;
            Length = length;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Speed: {Speed}, Width: {Width}, Length: {Length}";
        }
    }

    //Car Truck Motorcycle
    public class Car : Vehicle, IMovable
    {
        public int Doors { get; set; }
        public string Color { get; set; }
        public int MaxSpeed { get; private set; }

        public Car() : base("", 0, 0, 0) { }

        public Car(string name, int speed, double width, double length, int doors, string color, int maxSpeed)
            : base(name, speed, width, length)
        {
            Doors = doors;
            Color = color;
            MaxSpeed = maxSpeed;
            Type = "Car";
        }

        public void Accelerate(int increment)
        {
            Speed = Math.Min(Speed + increment, MaxSpeed);
        }

        public void SlowDown(int decrement)
        {
            Speed = Math.Max(Speed - decrement, 0);
        }

        public override string ToString()
        {
            return $"Car: {base.ToString()}, Doors: {Doors}, Color: {Color}";
        }
    }

    public class Truck : Vehicle, IMovable
    {
        public int Capacity { get; set; }
        public int Wheels { get; set; }
        public int MaxSpeed { get; private set; }

        public Truck() : base("", 0, 0, 0) { }

        public Truck(string name, int speed, double width, double length, int capacity, int wheels, int maxSpeed)
            : base(name, speed, width, length)
        {
            Capacity = capacity;
            Wheels = wheels;
            MaxSpeed = maxSpeed;
            Type = "Truck";
        }

        public void Accelerate(int increment)
        {
            Speed = Math.Min(Speed + increment, MaxSpeed);
        }

        public void SlowDown(int decrement)
        {
            Speed = Math.Max(Speed - decrement, 0);
        }

        public override string ToString()
        {
            return $"Truck: {base.ToString()}, Capacity: {Capacity}kg, Wheels: {Wheels}";
        }
    }

    public class Motorcycle : Vehicle, IMovable
    {
        public string MotorcycleType { get; set; }
        public string EngineSize { get; set; }
        public int MaxSpeed { get; private set; }

        public Motorcycle() : base("", 0, 0, 0) { }

        public Motorcycle(string name, int speed, double width, double length, string motorcycleType, string engineSize, int maxSpeed)
            : base(name, speed, width, length)
        {
            MotorcycleType = motorcycleType;
            EngineSize = engineSize;
            MaxSpeed = maxSpeed;
            Type = "Motorcycle";
        }

        public void Accelerate(int increment)
        {
            Speed = Math.Min(Speed + increment, MaxSpeed);
        }

        public void SlowDown(int decrement)
        {
            Speed = Math.Max(Speed - decrement, 0);
        }

        public override string ToString()
        {
            return $"Motorcycle: {base.ToString()}, Type: {MotorcycleType}, EngineSize: {EngineSize}";
        }
    }

    //Движения
    public interface IMovable
    {
        int MaxSpeed { get; }
        void Accelerate(int increment);
        void SlowDown(int decrement);
    }

    //Гараж
    public partial class Garage
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public Garage(string name, int area)
        {
            Name = name;
            Area = area;
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Sum(v => v.Area) + vehicle.Area <= Area)
            {
                Vehicles.Add(vehicle);
            }
            else
            {
                Console.WriteLine("Not enough space to add this vehicle.");
            }
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }
    }


    public partial class Garage
    {
        public void SortVehiclesByArea()
        {
            for (int i = 0; i < Vehicles.Count - 1; i++)
            {
                for (int j = 0; j < Vehicles.Count - i - 1; j++)
                {
                    if (Vehicles[j].Area > Vehicles[j + 1].Area)
                    {
                        var temp = Vehicles[j];
                        Vehicles[j] = Vehicles[j + 1];
                        Vehicles[j + 1] = temp;
                    }
                }
            }
        }

    }


    public partial class Garage
    {
        public override string ToString()
        {
            string vehicleInfo = string.Join("\n", Vehicles.Select(v => v.ToString()));
            return $"Garage: {Name}\nArea: {Area}\nVehicles:\n{vehicleInfo}\n";
        }
    }

    //сериализация
    public abstract class MySerializer
    {
        public abstract void Write(List<Garage> garages, string filePath);
        public abstract List<Garage> Read(string filePath);
    }

    //JSON
    public class VehicleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vehicle);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var vehicleType = jsonObject["Type"].Value<string>();

            Vehicle vehicle;
            switch (vehicleType)
            {
                case "Car":
                    vehicle = new Car();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                case "Motorcycle":
                    vehicle = new Motorcycle();
                    break;
                default:
                    throw new InvalidOperationException("Unknown vehicle type");
            }

            serializer.Populate(jsonObject.CreateReader(), vehicle);
            return vehicle;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


    public class MyJsonSerializer : MySerializer
    {
        public override void Write(List<Garage> garages, string filePath)
        {
            var jsonData = JsonConvert.SerializeObject(garages, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        public override List<Garage> Read(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new VehicleConverter());
            return JsonConvert.DeserializeObject<List<Garage>>(jsonData, settings);
        }
    }

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