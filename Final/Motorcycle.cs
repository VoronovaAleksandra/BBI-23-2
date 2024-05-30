public class Motorcycle : Vehicle, IMovable
{
    public bool HasSidecar { get; set; }
    public string Type { get; set; }
    public double MaxSpeed { get; set; }

    public Motorcycle(string name, double speed, double width, double length, bool hasSidecar, string type, double maxSpeed)
        : base(name, speed, width, length)
    {
        HasSidecar = hasSidecar;
        Type = type;
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
        return $"Motorcycle: {base.ToString()}, HasSidecar = {HasSidecar}, Type = {Type}, MaxSpeed = {MaxSpeed}";
    }
}
