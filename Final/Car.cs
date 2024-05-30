public class Car : Vehicle, IMovable
{
    public int NumberOfDoors { get; set; }
    public string FuelType { get; set; }
    public double MaxSpeed { get; set; }

    public Car(string name, double speed, double width, double length, int numberOfDoors, string fuelType, double maxSpeed)
        : base(name, speed, width, length)
    {
        NumberOfDoors = numberOfDoors;
        FuelType = fuelType;
        MaxSpeed = maxSpeed;
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
        return $"Car: {base.ToString()}, NumberOfDoors = {NumberOfDoors}, FuelType = {FuelType}, MaxSpeed = {MaxSpeed}";
    }
}
