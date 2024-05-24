//1 создать структуру Vector ,представляющую собой вектор, составленный из двух точек Вар 3
public struct Dot
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }

    public Dot(int[] mas)
    {
        X = mas[0];
        Y = mas[1];
        Z = mas[2];
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}, Z: {Z}";
    }
}

public struct Vector
{
    public Dot A { get; private set; }
    public Dot B { get; private set; }

    public Vector(int[,] matrix)
    {
        A = new Dot(new int[] { matrix[0, 0], matrix[0, 1], matrix[0, 2] });
        B = new Dot(new int[] { matrix[1, 0], matrix[1, 1], matrix[1, 2] });
    }

    public double Distance()
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.Z - A.Z, 2));
    }

    public override string ToString()
    {
        return $"A: {A}, B: {B}, Distance: {Distance()}";
    }
}

public class Program
{

    public static void Main(string[] args)
    {
        Vector[] vectors = new[]
        {
            new Vector(new int[,]{{10, 2, 3}, {2, 3, 4}}),
            new Vector(new int[,]{{3, 4, 5}, {2, 3, 4}}),
            new Vector(new int[,]{{6, -10, 3}, {1, 5, 4}}),
            new Vector(new int[,]{{1, 0, 3}, {2, 3, 0}}),
            new Vector(new int[,]{{8, 2, 1}, {7, 7, 7}})
        };
        for (int i = 0; i < vectors.Length; ++i)
        {
            for (int j = i + 1; j < vectors.Length; j++)
            {
                if (vectors[i].Distance() < vectors[j].Distance())
                {
                    Vector vector = vectors[i];
                    vectors[i] = vectors[j];
                    vectors[j] = vector;
                }
            }
        }

        foreach (var vector in vectors)
        {
            Console.WriteLine(vector);
        }
    }
}