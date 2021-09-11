using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci1
{
    class Program
    {
        // Редица на Фибоначи
        static List<int> fib = new List<int>();

        public static void FibonacciByLoop(int n)
        {
            int a = 1, b = 1, c = a + b;

            // Добавяме първите три елемента в списъка
            fib.Add(a); fib.Add(b); fib.Add(c);

            // Обхождаме до N
            for (int i = 0; i < n - 3; i++)
            {
                // Метод на плаващия прозорец
                a = b;
                b = c;
                c = a + b;
                // добавяме следващия получен елемент
                fib.Add(c);
            }
        }

        public static int FibonacciByRecurssion(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return FibonacciByRecurssion(n - 1) + FibonacciByRecurssion(n - 2);
            }
        }

        static void Main(string[] args)
        {
            // Вход
            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());

            FibonacciByLoop(n);

            // Отпечатваме резултат 1
            Console.WriteLine(string.Join(", ", fib));

            // Отпечатваме резултат 2
            fib.Clear();
            for (int i = n; i >= 1; i--)
            {
                fib.Add(FibonacciByRecurssion(i));
            }
            fib.Reverse();
            Console.WriteLine(string.Join(", ", fib));

            Console.ReadKey();
        }
    }
}
