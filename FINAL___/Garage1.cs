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

    public double SumArea(List<Vehicle> vehicles)
    {
        double sum = 0;
        foreach (var vehicle in vehicles)
        {
            sum += vehicle.Area;
        }
        return sum;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (SumArea(Vehicles) + vehicle.Area <= Area)
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