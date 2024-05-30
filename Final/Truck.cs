public class Truck : Vehicle, IMovable
{
    public double LoadCapacity { get; set; }
    public int NumberOfWheels { get; set; }
    public double MaxSpeed { get; set; }

    public Truck(string name, double speed, double width, double length, double loadCapacity, int numberOfWheels, double maxSpeed)
        : base(name, speed, width, length)
    {
        LoadCapacity = loadCapacity;
        NumberOfWheels = numberOfWheels;
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
        return $"Truck: {base.ToString()}, LoadCapacity = {LoadCapacity}, NumberOfWheels = {NumberOfWheels}, MaxSpeed = {MaxSpeed}";
    }
}
