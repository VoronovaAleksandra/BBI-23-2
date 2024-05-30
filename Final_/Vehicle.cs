public abstract class Vehicle
{
    public string Name { get; set; }
    public double Speed { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Area => Width * Length;

    public Vehicle(string name, double speed, double width, double length)
    {
        Name = name;
        Speed = speed;
        Width = width;
        Length = length;
    }

    public override string ToString()
    {
        return $"Name = {Name}, Speed = {Speed}, Width = {Width}, Length = {Length}, Area = {Area}";
    }
}
