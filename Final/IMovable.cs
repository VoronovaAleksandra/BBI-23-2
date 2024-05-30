public interface IMovable
{
    double MaxSpeed { get; set; }
    void Accelerate(int increment);
    void SlowDown(int decrement);
}
