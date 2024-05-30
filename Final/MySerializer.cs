
public abstract class MySerializer
{
    public abstract void Write(Garage[] garages, string fileName);
    public abstract Garage[] Read(string fileName);
}