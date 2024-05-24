//2 
public abstract class Shape
{
    public abstract double Volume();

    public abstract void Print();
}

public class Cube : Shape
{
    public double A { get; private set; }

    public Cube(double a)
    {
        A = a;
    }

    public override double Volume()
    {
        return Math.Pow(A, 3);
    }

    public override void Print()
    {
        Console.WriteLine($"Cube: A: {A}, Volume: {Volume()}");
    }
}

public class Sphere : Shape
{
    public double R { get; private set; }

    public Sphere(double r)
    {
        R = r;
    }

    public override double Volume()
    {
        return 4 * Math.PI * Math.Pow(R, 3) / 3;
    }

    public override void Print()
    {
        Console.WriteLine($"Sphere: R: {R}, Volume: {Volume()}");
    }
}

public class Cylinder : Shape
{
    public double R { get; private set; }
    public double H { get; private set; }

    public Cylinder(double r, double h)
    {
        R = r;
        H = h;
    }

    public override double Volume()
    {
        return H * Math.PI * Math.Pow(R, 2);
    }

    public override void Print()
    {
        Console.WriteLine($"Cylinder: R: {R}, H: {H}, Volume: {Volume()}");
    }
}

public class Program
{
    private static void SortedShapesByVolume(Shape[] shapes)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            for (int j = i + 1; j < shapes.Length; j++)
            {
                if (shapes[i].Volume() < shapes[j].Volume())
                {
                    Shape shape = shapes[i];
                    shapes[i] = shapes[j];
                    shapes[j] = shape;
                }
            }
        }
    }

    private static void PrintShapes(Shape[] shapes)
    {
        foreach (Shape shape in shapes)
        {
            shape.Print();
        }
    }

    public static void Main(string[] args)
    {
        Cube[] cubes = new[]
        {
            new Cube(1),
            new Cube(2),
            new Cube(3),
            new Cube(4),
            new Cube(5)
        };
        Sphere[] spheres = new[]
        {
            new Sphere(1),
            new Sphere(2),
            new Sphere(3),
            new Sphere(4),
            new Sphere(5)
        };
        Cylinder[] cylinders = new[]
        {
            new Cylinder(2, 10),
            new Cylinder(4, 8),
            new Cylinder(6, 6),
            new Cylinder(8, 4),
            new Cylinder(10, 2)
        };

        SortedShapesByVolume(cubes);
        SortedShapesByVolume(spheres);
        SortedShapesByVolume(cylinders);

        Console.WriteLine("Cubes:");
        PrintShapes(cubes);
        Console.WriteLine("Spheres:");
        PrintShapes(spheres);
        Console.WriteLine("Cylinders:");
        PrintShapes(cylinders);

        Shape[] shapes = new Shape[15];
        int k = 0;
        foreach (Cube cube in cubes)
        {
            shapes[k++] = cube;
        }

        foreach (Sphere sphere in spheres)
        {
            shapes[k++] = sphere;
        }

        foreach (Cylinder cylinder in cylinders)
        {
            shapes[k++] = cylinder;
        }

        SortedShapesByVolume(shapes);
        Console.WriteLine("Shapes: ");
        PrintShapes(shapes);
    }
}



