using System;
using System.Linq;

namespace FlowControlProject
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            bool runProgram = true;
            do
            {
                ShowMainMenu();
                switch (GetUserNumber())
                {
                    case 0:
                        runProgram = false;
                        break;
                    case 1:
                        ShowTicketMenu();
                        switch (GetUserNumber())
                        {
                            case 1:
                                SinglePrice();
                                break;
                            case 2:
                                GroupPrice();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        RepeatInput();
                        break;
                    case 3:
                        ThirdWordExtractor();
                        break;
                    default:
                        break;
                }
                if(runProgram) Console.ReadLine();
            } while (runProgram);
        }

        private static void GroupPrice()
        {
            int groupSize = GetUserNumber("Ange sällskapets storlek: ");
            int sum = 0;
            for (int i = 0; i < groupSize; i++)
            {
                int age = GetUserNumber($"Ange ålder på person {i + 1}: ");
                int price;
                if (age < 20)
                    price = 80;
                else
                    if (age > 64)
                    price = 90;
                else
                    price = 120;
                sum += price;
            }
            Console.WriteLine($"Totalkostnaden för hela sällskapet på {groupSize} personer blir {sum} kr.");
        }

        private static void SinglePrice()
        {
            int age = GetUserNumber("Ange ålder: ");
            string messageToUser;
            if (age < 20)
                messageToUser = "Ungdomspris: 80 kr";
            else
                if (age > 64)
                    messageToUser = "Pensionärspris: 90 kr";
                else
                    messageToUser = "Standardpris: 120 kr";
            Console.WriteLine(messageToUser);
        }

        private static void ShowTicketMenu()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("BILJETTMENY");
            Console.WriteLine("1. Beräkna biljettpris för en person.");
            Console.WriteLine("2. Beräkna biljettpris för ett sällskap.");
            Console.WriteLine("-------------------------------------------------------------");
        }

        private static int GetUserNumber()
        {
            //Exception handling here
            return int.Parse(Console.ReadLine());
        }

        private static int GetUserNumber(string message)
        {
            //Exception handling here
            Console.WriteLine(message);
            return int.Parse(Console.ReadLine());
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("HUVUDMENY");
            Console.WriteLine("Navigera genom att skriva in följande siffror.");
            Console.WriteLine("1: Beräkna biljettpris.");
            Console.WriteLine("2: Upprepa tio gånger.");
            Console.WriteLine("3: Det tredje ordet.");
            Console.WriteLine("0: Avsluta.");
            Console.WriteLine("-------------------------------------------------------------");
        }

        private static void RepeatInput()
        {
            Console.WriteLine("Skriv in en text du vill upprepa tio gånger.");
            string stringToRepeat = Console.ReadLine();
            string repeatingString = "";
            for (int i = 1; i <= 10; i++)
            {
                repeatingString += $"{i}. {stringToRepeat} ";
            }
            Console.WriteLine(repeatingString);
        }

        private static void ThirdWordExtractor()
        {
            Console.WriteLine("Skriv in en mening med minst tre ord.");
            var sentenceElements = Console.ReadLine().Split();
            Console.WriteLine(sentenceElements[2]);
        }
    }
}