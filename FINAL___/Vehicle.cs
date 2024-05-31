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