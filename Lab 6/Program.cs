using System;
// 1 level 3 variant
class Participant
{
    public string Name { get; set; }
    public double Jump { get; set; }

    public Participant(string name, double bestJump)
    {
        Name = name;
        Jump = bestJump;
    }
}

class Program
{
    static void ParticipantBestTrySort(Participant[] participants1, Participant[] participants2)
    {
        int n = participants1.Length;
        Participant temp;

        for (int i = 0; i < n; i++)
        {
            if (participants1[i].Jump > participants2[i].Jump)
            {
                temp = participants1[i];
                participants2[i] = temp;

            }

        }
    }
    static void ParticipantPlaces(Participant[] participants2)
    {
        int n = participants2.Length;
        Participant temp;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {

                if (participants2[j].Jump > participants2[i].Jump)
                {

                    temp = participants2[i];
                    participants2[i] = participants2[j];
                    participants2[j] = temp;

                }
            }

        }
    }

    static void Main()
    {
        Participant[] participants1 = new Participant[5];
        participants1[0] = new Participant("Alice", 1.75);
        participants1[1] = new Participant("Bob", 1.80);
        participants1[2] = new Participant("Charlie", 1.65);
        participants1[3] = new Participant("David", 1.85);
        participants1[4] = new Participant("Eve", 1.70);

        Participant[] participants2 = new Participant[5];
        participants2[0] = new Participant("Alice", 2.5);
        participants2[1] = new Participant("Bob", 1.55);
        participants2[2] = new Participant("Charlie", 2.46);
        participants2[3] = new Participant("David", 1.5);
        participants2[4] = new Participant("Eve", 1.35);
        Console.WriteLine("Первая попытка:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{participants1[i].Name}\t{participants1[i].Jump}");
        }
        Console.WriteLine();
        Console.WriteLine("Вторая попытка:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{participants2[i].Name}\t{participants2[i].Jump}");
        }

        ParticipantBestTrySort(participants1, participants2);
        Console.WriteLine();

        Console.WriteLine("Лучшие попытки:");
        for (int i = 0; i < participants1.Length; i++)
        {
            Console.WriteLine($"{participants2[i].Name}\t{participants2[i].Jump} м");
        }
        Console.WriteLine();
        Console.WriteLine("Места:");
        ParticipantPlaces(participants2);
        for (int i = 0; i < participants1.Length; i++)
        {
            Console.WriteLine($"{i + 1}\t{participants2[i].Name}\t{participants2[i].Jump} м");
        }

    }
}













//2
using System;

class Sportsman
{
    public string Name;
    public double[] Jumps = new double[4];
    public double Difficulty;

    public double GetTotalScore()
    {
        SortSportsman(Jumps);
        double totalScore = 0;
        for (int i = 1; i < 3; i++)
        {
            totalScore += Jumps[i];
        }
        return totalScore * Difficulty;
    }

    private void SortSportsman(double[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    double temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Sportsman[] sportsmen = new Sportsman[3];


        sportsmen[0] = new Sportsman { Name = "Aleksandra", Jumps = new double[] { 5.5, 6.0, 5.0, 5.5 }, Difficulty = 2.5 };
        sportsmen[1] = new Sportsman { Name = "Alice", Jumps = new double[] { 6.0, 6.5, 7.0, 6.5 }, Difficulty = 3.0 };
        sportsmen[2] = new Sportsman { Name = "Eve", Jumps = new double[] { 4.5, 5.0, 4.0, 4.5 }, Difficulty = 3.5 };


        double[] totalScores = new double[sportsmen.Length];
        for (int i = 0; i < sportsmen.Length; i++)
        {
            totalScores[i] = sportsmen[i].GetTotalScore();
        }


        for (int i = 0; i < sportsmen.Length - 1; i++)
        {
            for (int j = i + 1; j < sportsmen.Length; j++)
            {
                if (totalScores[i] < totalScores[j])
                {
                    double tempScore = totalScores[i];
                    totalScores[i] = totalScores[j];
                    totalScores[j] = tempScore;

                    Sportsman tempSportsman = sportsmen[i];
                    sportsmen[i] = sportsmen[j];
                    sportsmen[j] = tempSportsman;
                }
            }
        }


        Console.WriteLine("Final Results:");
        for (int i = 0; i < sportsmen.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {sportsmen[i].Name}: {totalScores[i]}");
        }
    }
}











//3
using System;

struct SkierRace
{
    public string Name;
    public double Result;

    public SkierRace(string name, double result)
    {
        Name = name;
        Result = result;
    }
}

class Program
{
    static void SkierSort(SkierRace[] racers)
    {
        int n = racers.Length;
        SkierRace temp;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (racers[j].Result < racers[j + 1].Result)
                {
                    temp = racers[j];
                    racers[j] = racers[j + 1];
                    racers[j + 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        SkierRace[] group1 = new SkierRace[3];
        group1[0] = new SkierRace("Alice", 30.5);
        group1[1] = new SkierRace("Bob", 28.7);
        group1[2] = new SkierRace("Charlie", 27.9);

        SkierRace[] group2 = new SkierRace[3];
        group2[0] = new SkierRace("David", 31.2);
        group2[1] = new SkierRace("Eve", 29.8);
        group2[2] = new SkierRace("Frank", 26.4);

        SkierSort(group1);
        SkierSort(group2);
        Console.WriteLine($"1 group");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{group1[i].Name}\t{group1[i].Result}");
        }
        Console.WriteLine("\n2 group");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{group2[i].Name}\t{group2[i].Result}");
        }

    }
}