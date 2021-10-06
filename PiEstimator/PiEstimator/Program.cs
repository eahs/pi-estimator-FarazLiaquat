using System;

namespace PiEstimator
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            
            Console.WriteLine("Pi Estimator");
            Console.WriteLine("================================================");

            n = GetNumber("Enter number of iterations (n): ");

            double pi = EstimatePi(n);
            double diff = Math.Abs(pi - Math.PI);

            Console.WriteLine();
            Console.WriteLine($"Pi (estimate): {pi}, Pi (system): {Math.PI}, Difference: {diff}");
        }

        static double EstimatePi(long n)
        {
            Random rand = new Random(System.Environment.TickCount);
            double xpos, ypos;
            double inner = 0;
            double outer = 0;
            for (int i = 0; i < n; i++)
            {
                xpos = Math.Round((rand.NextDouble() / -1), 15) * (rand.Next(0, 2) * 2 - 1);
                ypos = Math.Round((rand.NextDouble() / -1), 15) * (rand.Next(0, 2) * 2 - 1);;
                if (Math.Sqrt((xpos*xpos)+(ypos*ypos))<=1) 
                {
                    inner += 1;
                }
                else
                {
                    outer += 1;
                }
            }
            double pi = 0;
            pi = (4*inner)/(inner + outer);
            // TODO: Calculate Pi

            return pi;
        }

        static long GetNumber(string prompt)
        {
            long output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Int64.TryParse(input, out output))
                {
                    return output;
                }
            }
        }
    }
}