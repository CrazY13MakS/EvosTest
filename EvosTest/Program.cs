using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace EvosTest
{

    class Program
    {
        static void Main(string[] args)
        {
            PrintPerformance();
        }

        static void PrintPerformance()
        {
            Tribonacci tribonacci = new Tribonacci();
            Stopwatch stopwatch = new Stopwatch();
            BigInteger res;

            for (int index = 0; index < 30; index++)
            {
                //Loop
                stopwatch.Start();
                res = tribonacci.GetValueLoop(index);
                stopwatch.Stop();
                Console.WriteLine($"{"Loop",-20}. Index {index}. Value: {res,-15}.Time: {stopwatch.Elapsed}");
                //RecursiveMemoize
                stopwatch.Restart();
                res = tribonacci.GetValueRecursiveMemoize(index);
                stopwatch.Stop();
                Console.WriteLine($"{"RecursiveMemoize",-20}. Index {index}. Value: {res,-15}.Time: {stopwatch.Elapsed}");
                //Recursive
                stopwatch.Restart();
                res = tribonacci.GetValueRecursive(index);
                stopwatch.Stop();
                Console.WriteLine($"{"Recursive",-20}. Index {index}. Value: {res,-15}.Time: {stopwatch.Elapsed}");

                stopwatch.Reset();
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

            for (int index = 1000; index < 100000; index += 1000)
            {
                //Loop
                stopwatch.Start();
                res = tribonacci.GetValueLoop(index);
                stopwatch.Stop();
                Console.WriteLine($"{"Loop",-20}. Index {index}.Time: {stopwatch.Elapsed}");
                //RecursiveMemoize
                stopwatch.Restart();
                res = tribonacci.GetValueRecursiveMemoize(index);
                stopwatch.Stop();
                Console.WriteLine($"{"RecursiveMemoize",-20}. Index {index}.Time: {stopwatch.Elapsed}");

                stopwatch.Reset();
                Console.WriteLine("-----------------------------------");
            }
        }

    }
}
