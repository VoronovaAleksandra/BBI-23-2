using System;
using System.ComponentModel;
//1.4
//struct Sportsmen
//{
//    public string famili;
//    public double firstTry, secondTry, bestTry;

//    public Sportsmen(string famili1, double try1, double try2)
//    {
//        famili = famili1;
//        firstTry = try1;
//        secondTry = try2;
//        if (firstTry > secondTry)
//        {
//            bestTry = firstTry;
//        }
//        else
//        {
//            bestTry = secondTry;
//        }
//    }
//}
//    class Program
//    {
//    static void Main(string[] args)
//    {
//        Sportsmen[] s = new Sportsmen[4];
//        s[0] = new Sportsmen("Eve", 1.35, 2.12);
//        s[1] = new Sportsmen("Alice", 3.00, 2.34);
//        s[2] = new Sportsmen("Kate", 2.25, 2.55);
//        s[3] = new Sportsmen("Helen", 1.55, 2.55);
//        for (int i = 0; i < 4; i++)
//        {
//            Console.WriteLine($"{s[i].famili}\t - 1 попытка {s[i].firstTry}\t, 2 попытка - {s[i].secondTry}\t, лучшая попытка - {s[i].bestTry}\t");
//        }
//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                if (s[j].bestTry < s[j + 1].bestTry)
//                {
//                    (s[j + 1], s[j]) = (s[j], s[j + 1]);
//                }
//            }
//        }
//        Console.WriteLine();
//        for(int i = 0;i < 4;i++)
//        {
//            Console.WriteLine($"{s[i].famili}\t- {s[i].bestTry} ");
//        }
//    }
//    }













//2.4
//struct Swim
//{
//    public string famili;
//    public double  [] attempt;
//    public double difficulty;

//    public Swim(string famili1, double[] at, double d)
//    {
//        famili= famili1;
//        attempt= at;
//        difficulty= d;

//    }
//    public double GetTotalScore()
//    {
//        double max = 0; 
//        double min = attempt[0];
//        int imax = 0;
//        int imin=0;
//        double totalScore = 0;
//        for(int i = 0; i < attempt.Length;i++)
//        {
//            if (attempt[i]>max)
//            {
//                max = attempt[i];
//                imax = i;
//            }
//            if (attempt[i]<min)
//            {
//                min = attempt[i];
//                imin = i;
//            }

//        }

//        for (int i = 0; i < 4; i++)
//        {
//            if (i != imin && i != imax)
//            {
//                totalScore += attempt[i];
//            }
//        }

//        return totalScore * difficulty;
//    }

//}
//class Program
//{
//    static void Main()
//    {
//        Swim[] s = new Swim[4];
//        s[0] = new Swim("Alice",new double[] { 4, 5, 3, 5 } ,2.5);
//        s[1] = new Swim("Kate", new double[] { 4, 4, 5, 4 }, 2.5);
//        s[2] = new Swim("Helen", new double[] { 4, 5, 3, 4 }, 3);
//        s[3] = new Swim("Eve", new double[] { 2, 5, 3, 4 }, 3.5);
//        Console.WriteLine();
//        for(int i=0; i<4;i++)
//        {
//            Console.WriteLine($"{s[i].famili}\t");
//            for(int j=0; j<4;j++)
//            {
//                Console.Write($"{s[i].attempt[j]}\t");
//            }

//        }
//        double[] totalScores = new double[s.Length];
//        for (int i = 0; i < 4; i++)
//        {
//            totalScores[i] = s[i].GetTotalScore();
//        }


//        for (int i = 0; i < s.Length - 1; i++)
//        {
//            for (int j = i + 1; j < s.Length; j++)
//            {
//                if (totalScores[i] < totalScores[j])
//                {
//                    double tempScore = totalScores[i];
//                    totalScores[i] = totalScores[j];
//                    totalScores[j] = tempScore;

//                    Swim tempSportsman = s[i];
//                    s[i] = s[j];
//                    s[j] = tempSportsman;
//                }
//            }
//        }
//        Console.WriteLine();
//        for(int i = 0;i < s.Length;i++)
//        {
//            Console.WriteLine($"{i + 1} место- {s[i].famili}-{totalScores[i]}");
//        }
//    }
//}
















//3.4
//struct SkierRace
//{
//    public string Name;
//    public double Result;

//    public SkierRace(string name, double result)
//    {
//        Name = name;
//        Result = result;
//    }
//}

//class Program
//{
//    static void SkierSort(SkierRace[] racers)
//    {
//        int n = racers.Length;
//        SkierRace temp;

//        for (int i = 0; i < n - 1; i++)
//        {
//            for (int j = 0; j < n - i - 1; j++)
//            {
//                if (racers[j].Result < racers[j + 1].Result)
//                {
//                    temp = racers[j];
//                    racers[j] = racers[j + 1];
//                    racers[j + 1] = temp;
//                }
//            }
//        }
//    }

//    static void Main()
//    {
//        SkierRace[] group1 = new SkierRace[3];
//        group1[0] = new SkierRace("Alice", 30.5);
//        group1[1] = new SkierRace("Bob", 28.7);
//        group1[2] = new SkierRace("Charlie", 27.9);

//        SkierRace[] group2 = new SkierRace[3];
//        group2[0] = new SkierRace("David", 31.2);
//        group2[1] = new SkierRace("Eve", 29.8);
//        group2[2] = new SkierRace("Frank", 26.4);

//        SkierSort(group1);
//        SkierSort(group2);
//        Console.WriteLine($"1 group");
//        for (int i = 0; i < 3; i++)
//        {
//            Console.WriteLine($"{group1[i].Name}\t{group1[i].Result}");
//        }
//        Console.WriteLine("\n2 group");
//        for (int i = 0; i < 3; i++)
//        {
//            Console.WriteLine($"{group2[i].Name}\t{group2[i].Result}");
//        }

//    }
//}