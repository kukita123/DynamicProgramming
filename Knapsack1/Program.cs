using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack1
{
    class Program
    {       
        const int C = 17; // Капацитет на раницата
        static int[] V = new int[] { 0, 5, 3, 9, 1, 1, 2, 5, 2, 4, 5, 12, 13, 4, 1, 22, 5 }; // Цени на предметите
        static int[] W = new int[] { 0, 3, 7, 6, 1, 2, 4, 5, 5, 4, 3, 3,  4,  1, 2,  1, 3 }; // Тегла на предметите
        static int result = 0; // Резултат

        // Раницата
        static int Knapsack(int n, int c)
        {
            if (n == 0 || c == 0)
                return 0;
            else if (W[n] > c)
                return Knapsack(n - 1, c);
            else
            {
                var temp1 = Knapsack(n - 1, c);
                var temp2 = V[n] + Knapsack(n - 1, c - W[n]);
                result = Math.Max(temp1, temp2);
            }
            return result;
        }

        static int[,] arr = new int[V.Length + 1, C + 1];
        static int KS2(int n, int c)
        {           
            if (arr[n, c] != 0)
                result = arr[n, c];
            if (n == 0 || c == 0)
                result = 0;
            else if (W[n] > c)
                result = KS2(n - 1, c);
            else
            {
                var temp1 = KS2(n - 1, c);
                var temp2 = V[n] + KS2(n - 1, c - W[n]);
                result = Math.Max(temp1, temp2);
            }
            return result;

        }

        static void Main(string[] args)
        {
            int N = W.Length - 1;
            Console.WriteLine("Number of items = {0}", N);
            Console.WriteLine("Values: {0}", string.Join(", ", V));
            Console.WriteLine("Weights: {0}", string.Join(", ", W));
            Console.WriteLine("Knapsack Capacity = {0}", C);

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            Console.WriteLine("Knapsack - First Solution: Sum = {0}", Knapsack(N, C));
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            watch.Start();
            Console.WriteLine("Knapsack - Second Solution: Sum = {0}", KS2(N, C));
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
