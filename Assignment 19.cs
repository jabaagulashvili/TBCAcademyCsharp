using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] numbers = GenerateRandomArray(10000000); 


        var sequentialSum = CalculateSequentialSum(numbers);
        Console.WriteLine($"Sequential Sum: {sequentialSum}");


        var parallelSum = CalculateParallelSum(numbers);
        Console.WriteLine($"Parallel Sum: {parallelSum}");
    }

    static int[] GenerateRandomArray(int length)
    {
        Random random = new Random();
        return Enumerable.Range(0, length).Select(_ => random.Next(1, 100)).ToArray();
    }

    static int CalculateSequentialSum(int[] numbers)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        stopwatch.Stop();
        Console.WriteLine($"Sequential Time: {stopwatch.Elapsed}");
        return sum;
    }

    static int CalculateParallelSum(int[] numbers)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        int sum = 0;
        const int batchSize = 100000; 

        Parallel.For(0, numbers.Length / batchSize, i =>
        {
            int localSum = 0;
            for (int j = i * batchSize; j < (i + 1) * batchSize; j++)
            {
                localSum += numbers[j];
            }
            lock (numbers) 
            {
                sum += localSum;
            }
        });


        for (int i = numbers.Length / batchSize * batchSize; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        stopwatch.Stop();
        Console.WriteLine($"Parallel Time: {stopwatch.Elapsed}");
        return sum;
    }
}
