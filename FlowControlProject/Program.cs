using System;

namespace FlowControlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            do
            {
                Console.WriteLine("Du har kommit till huvudmenyn.");
                Console.WriteLine("Här kommer du skriva in siffror för att testa olika funktioner.");
                var choice = Console.ReadLine(); // Exception handling här
                switch (choice)
                {
                    case 0:
                        runProgram = false;
                        break;
                    default:
                        break;
                }
            } while (runProgram);
        }
    }
}
