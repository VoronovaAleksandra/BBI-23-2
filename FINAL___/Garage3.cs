public partial class Garage
{
    public override string ToString()
    {
        string vehicleInfo = string.Join("\n", Vehicles.Select(v => v.ToString()));
        return $"Garage: {Name}\nArea: {Area}\nVehicles:\n{vehicleInfo}\n";
    }
}