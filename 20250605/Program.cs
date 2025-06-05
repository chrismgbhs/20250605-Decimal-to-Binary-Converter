using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250605
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<bool> boolStack = new Stack<bool>();
            int[] quotients = new int[2];
            int modulous;
            int numBits;
            int maximumDecimal = 65535;
            int displayCounter = 0;

            quotients[0] = maximumDecimal;
            quotients[1] = maximumDecimal;

            // DETERMINING THE FULL-BIT RANGE OF THE MAXIMUM DECIMAL BY CONVERTING IT TO BINARY
            while (true) 
            { 
                if (quotients[0] == 0)
                {
                    break;
                }

                else
                {
                    quotients[1] = quotients[0];
                    quotients[0] = quotients[0] / 2;
                    quotients[1] = quotients[1] % 2;

                    if (quotients[1] == 1)
                    {
                        boolStack.Push(true);
                    }

                    else
                    {
                        boolStack.Push(false);
                    }
                }
            }

            if (boolStack.Count > 8)
            {
                numBits = 16;
            }

            else
            {
                numBits = 8;
            }

            Console.WriteLine($"MAX DECIMAL: {maximumDecimal}");
            Console.WriteLine($"FULL BIT RANGE: {numBits}");
            Console.WriteLine();

            quotients[0] = 0;
            quotients[1] = 0;
            boolStack = new Stack<bool> ();

            while (true)
            {
                Console.Write($"CONVERT TO BINARY (MAX: {maximumDecimal}): ");
                if (int.TryParse(Console.ReadLine(), out quotients[0]) && quotients[0] <= maximumDecimal && quotients[0] >= 0)
                {
                    break;
                }
            }

            Console.Write("BINARY OUTPUT: ");

            while (true)
            {
                if (quotients[0] == 0)
                {
                    break;
                }

                else
                {
                    quotients[1] = quotients[0];
                    quotients[0] = quotients[0] / 2;
                    quotients[1] = quotients[1] % 2;

                    if (quotients[1] == 1)
                    {
                        boolStack.Push(true);
                    }

                    else
                    {
                        boolStack.Push(false);
                    }
                }
            }

            for (int bitCounter = 0; bitCounter < numBits - boolStack.Count; bitCounter++)
            {
                displayCounter++;
                Console.Write(0);

                if (displayCounter == 4)
                {
                    Console.Write(" ");
                    displayCounter = 0;
                }
            }

            foreach (bool element in boolStack)
            {
                displayCounter++;
                switch (element)
                {
                    case true:
                        Console.Write(1);
                        break;


                    case false:
                        Console.Write(0);
                        break;
                }

                if (displayCounter == 4)
                {
                    Console.Write(" ");
                    displayCounter = 0;
                }
            }

            Console.WriteLine();
            Console.ReadKey();

             
        }
    }
}
