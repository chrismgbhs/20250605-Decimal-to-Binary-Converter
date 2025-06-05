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

            /* The manual method for converting a decimal number to binary has been applied. 
             * * A variable quotient[0] will also hold the quotient of the maximum decimal with 2.
             * The binary digits are obtained by getting the modulous answer of the maximum decimal with 2 (only for first instance).
             * The answer will be stacked on the boolStack with true if 1, false if 0.
             * The loop will repeat itself and instead of getting the quotient of maximum decimal with 2, quotient[0] will rather be divided by 2. 
             * Also it will be getting the binay digit with modulous again and add it to boolStack by performing modulous 2 with quotient[0].
             * Repeat the process until quotient[0] becomes 0.
             */

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

            /* BASED ON THE NUMBER OF DIGITS OF THE BINARY NUMBER OF THE MAXIMUM DECIMAL, THE FULL RANGE BIT WILL BE DETERMINED
             * "IF THE NUMBER OF DIGITS OF THE BINARY OF THE MAX DECIMAL IS GREATER THAN" 32, THEN THE FULL RANGE WILL BE 64.
             * "                                                                        " 16, THEN THE FULL RANGE WILL BE 32.
             * "                                                                        " 8, THEN THE FULL RANGE WILL BE 16.
             */


            if (boolStack.Count > 32)
            {
                numBits = 64;
            }

            else if (boolStack.Count > 16) 
            {
                numBits = 32;
            }

            else if (boolStack.Count > 8)
            {
                numBits = 16;
            }

            else
            {
                numBits = 8;
            }

            // DISPLAYING OF PARAMETERS AND LABELS

            Console.WriteLine($"MAX DECIMAL: {maximumDecimal}");
            Console.WriteLine($"FULL BIT RANGE: {numBits}");
            Console.WriteLine();

            quotients[0] = 0;
            quotients[1] = 0;
            boolStack = new Stack<bool> ();

            // GETTING THE NUMBER WHICH WILL BE CONVERTED TO BINARY.
            /* MUST BE NOT LESS THAN 0 AND NOT GREATER THAN THE SET MAXIMUM DECIMAL.
             */

            while (true)
            {
                Console.Write($"CONVERT TO BINARY (MAX: {maximumDecimal}): ");
                if (int.TryParse(Console.ReadLine(), out quotients[0]) && quotients[0] <= maximumDecimal && quotients[0] >= 0)
                {
                    break;
                }
            }

            Console.Write("BINARY OUTPUT: ");

            // DISPLAYING OF OUTPUT

            /* WITH THE SAME LOGIC AS THE DETERMINING THE BINARY NUMBER OF THE MAXIMUM DECIMAL,
             * THE NUMBER INPUT WILL ALSO BE CONVERTED IN THAT WAY.
             */

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

            // DISPLAYING THE EXCESS 0s IF THE DIGITS OF THE CONVERTED BINARY NUMBER OF THE NUMBER INPUT DID NOT TAKE ALL OF THE SLOTS OF THE FULL BIT RANGE.
            // FOR EVERY 4 BITS, THERE WILL BE A SPACE THAT WILL BE PRINTED.

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

            // DISPLAYING THE BINARY NUMBER OF THE CONVERTED NUMBER INPUT.
            /* IT IS DONE BY GETTING EACH OF THE BOOLEAN VALUES FROM THE BOOLSTACK.
             * IF THE VALUE IS TRUE, THEN 1 WILL BE PRINTED. OTHERWISE, 0 WILL BE PRINTED.
             */

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
