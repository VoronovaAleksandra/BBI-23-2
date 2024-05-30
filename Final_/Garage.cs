using System;
using System.Collections.Generic;
using System.Linq;

public partial class Garage
{
    public string Name { get; set; }
    public double Area { get; set; }
    private List<Vehicle> vehicles;

    public Vehicle[] Vehicles => vehicles.ToArray();

    public Garage(string name, double area)
    {
        Name = name;
        Area = area;
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicles.Sum(v => v.Area) + vehicle.Area <= Area)
        {
            vehicles.Add(vehicle);
        }
        else
        {
            throw new InvalidOperationException("Недостаточно места в гараже!");
        }
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        vehicles.Remove(vehicle);
    }

        public void PrintGarageInfo()
    {
        Console.WriteLine($"Garage: {Name}");
        Console.WriteLine($"Area: {Area}");
        Console.WriteLine("Vehicles:");

        if (vehicles.Any())
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        else
        {
            Console.WriteLine("В гараже нет машин!");
        }

        Console.WriteLine();
    }




    public void SortVehiclesByArea()
    {
        vehicles = vehicles.OrderBy(v => v.Area).ToList();
    }
}
