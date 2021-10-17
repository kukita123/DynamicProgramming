using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Enter the rows number:");
            int n = int.Parse(Console.ReadLine());

            //creating an jagged array:
            int[][] pascalTriangle = new int[n][];

            GeneratePascalTriangle(pascalTriangle);

            Console.ReadKey();
        }

        static void GeneratePascalTriangle(int[][] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                //create an one dim array - number of elements
                // is i+1:
                arr[i] = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    //the first and the last element of the row is 1:
                    if (j == 0 || j == i)
                    {
                        arr[i][j] = 1;
                        Console.Write(arr[i][j] + " ");
                    }
                    //every new element is the sum of the values of the upper row - previous and the same column:
                    else
                    {
                        arr[i][j] = arr[i - 1][j - 1] + arr[i - 1][j];
                        Console.Write(arr[i][j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
