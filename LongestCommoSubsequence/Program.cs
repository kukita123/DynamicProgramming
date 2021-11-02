using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommoSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "beach";
            string str2 = "bear";
            Console.WriteLine("The first string is: {0}", str1);
            Console.WriteLine("The second string is: {0}", str2);

            int x = str1.Length;
            int y = str2.Length;

            int [,] m = new int[x + 1, y + 1];

            m = FillTable(m, str1, str2);

            DisplayTable(m);

            Console.WriteLine("The length of the longest common subsequence is: {0}", m[x, y]);
            
            Console.WriteLine("The longest common subsequence is: " + Result(m, str1, str2));

            Console.WriteLine("The shortest common supersequens length is: {0}", str1.Length + str2.Length - m[x, y]);

            Console.ReadKey();
        }

        static int[,] FillTable(int[,] m, string str1, string str2)
        {
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        m[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                        m[i, j] = 1 + m[i - 1, j - 1];
                    else
                        m[i, j] = Math.Max(m[i, j - 1], m[i - 1, j]);
                }
            }
            return m;
        }

        static void DisplayTable(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("m[{0}, {1}] = {2}\t",i , j, m[i, j] );
                }
                Console.WriteLine();
            }
        }

        static string Result(int[,] m, string str1, string str2)
        {
            int resultLength = m[str1.Length, str2.Length];
            char[] result = new char[resultLength];
            int i = str1.Length;
            int j = str2.Length;

            while(i >= 1 && j >= 1 && resultLength >= 1)
            {
                if (str1[i - 1] == str1[j - 1])
                {
                    result[resultLength - 1] = str1[i - 1];
                    i--;
                    j--;
                    resultLength--;
                }
                else if (m[i - 1, j] > m[i, j - 1])
                    i--;
                else
                    j--;
            }
            return new string(result);
        }
    }
}
