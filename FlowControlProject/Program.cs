using System;

namespace FlowControlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run program or exit bool
            bool runProgram = true;
            do
            {
                // Main menu with options
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Du har kommit till huvudmenyn.");
                Console.WriteLine("Här kan du skriva in siffror för att testa olika funktioner.");
                Console.WriteLine("1: Ungdom eller pensionär.");
                Console.WriteLine("2: Upprepa tio gånger.");
                Console.WriteLine("3: Det tredje ordet.");
                Console.WriteLine("0: Avsluta");
                Console.WriteLine("-------------------------------------------------------------");

                // User input
                int choice = int.Parse(Console.ReadLine()); // Exception handling/validation here

                // Menu switch-logic
                switch (choice)
                {
                    case 0:
                        runProgram = false;
                        break;
                    case 1:
                        CheckIfPersonOrPension();
                        break;
                    default:
                        break;
                }
            } while (runProgram);
        }

        private static void CheckIfPersonOrPension()
        {
            Console.WriteLine("Ange en ålder.");
            int age = int.Parse(Console.ReadLine());
            if(age < 20)
            {
                Console.WriteLine("Ungdomspris: 80 kr");
            }
            else if(age > 65)
            {
                Console.WriteLine("Pensionärspris: 90 kr");
            }
            else
            {
                Console.WriteLine("Standardpris: 120 kr");
            }
        }
    }
}
