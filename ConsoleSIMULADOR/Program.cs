using System;
using System.Collections.Generic;

class Program
{
    private static Random random = new Random();

    public static void Main()
    {
        Console.WriteLine("Digite o número de simulações que deseja executar:");
        int numSimulations = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o número de passos por simulação:");
        int numSteps = int.Parse(Console.ReadLine());

        List<int> maxValuesWithoutCrossingZero = new List<int>();

        for (int i = 0; i < numSimulations; i++)
        {
            var result = SimulateRandomWalk(numSteps);
            if (!result.Item2) // If it didn't cross zero after max
            {
                maxValuesWithoutCrossingZero.Add(result.Item1);
            }
        }

        double averageMaxWithoutCrossingZero = 0;
        foreach (int max in maxValuesWithoutCrossingZero)
        {
            averageMaxWithoutCrossingZero += max;
        }
        averageMaxWithoutCrossingZero /= maxValuesWithoutCrossingZero.Count;

        Console.WriteLine($"Média dos saldos máximos (sem cruzar zero após atingir o máximo) após {numSteps} passos em {numSimulations} simulações: {averageMaxWithoutCrossingZero}");
    }

    public static Tuple<int, bool> SimulateRandomWalk(int steps)
    {
        int balance = 0;
        int maxBalance = 0;
        bool crossedZeroAfterMax = false;

        for (int i = 0; i < steps; i++)
        {
            balance += (random.Next(2) == 0) ? -1 : 1;
            if (balance > maxBalance)
            {
                maxBalance = balance;
                crossedZeroAfterMax = false; // Reset the flag when a new max is reached
            }
            if (balance == 0 && maxBalance > 0)
            {
                crossedZeroAfterMax = true;
            }
        }

        return new Tuple<int, bool>(maxBalance, crossedZeroAfterMax);
    }
}



