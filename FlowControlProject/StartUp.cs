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
                // Main menu and ticket sub menu with the different program alternatives in methods
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
                                Console.WriteLine("Du måste skriva in en siffra mellan 1-2.");
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
                        Console.WriteLine("Du måste skriva in en siffra mellan 0-3.");
                        break;
                }
            } while (runProgram);
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

        private static int GetUserNumber()
        {
            // Get user number input, used in menus, returning 4 gives default case
            string userInput = Console.ReadLine();
            int number;
            return int.TryParse(userInput, out number) ? number : 4;
        }

        private static int GetUserNumber(string message)
        {
            // Overloaded method used in the ticket program, desired method output is always age
            // Move do-while to here
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            int number;
            return int.TryParse(userInput, out number) ? number : -1;
        }

        private static void ShowTicketMenu()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("BILJETTMENY");
            Console.WriteLine("1. Beräkna biljettpris för en person.");
            Console.WriteLine("2. Beräkna biljettpris för ett sällskap.");
            Console.WriteLine("-------------------------------------------------------------");
        }

        private static void SinglePrice()
        {
            // non-number inputs are handled by the method, negative numbers here
            // fix dry do while and dry if-statements in multiple methods
            int age = -1;
            do
            {
                age = GetUserNumber("Ange ålder: ");
            } while (age < 0);


            string messageToUser;

            if (age < 5 || age > 100)
                messageToUser = "Barn under fem och pensionärer över 100 år går gratis.";
            else
            {
                if (age < 20)
                    messageToUser = "Ungdomspris: 80 kr";
                else
                {
                    if (age > 64)
                        messageToUser = "Pensionärspris: 90 kr";
                    else
                        messageToUser = "Standardpris: 120 kr";
                }
            }
            Console.WriteLine(messageToUser);
        }

        private static void GroupPrice()
        {
            int groupSize = -1;
            do
            {
                groupSize = GetUserNumber("Ange sällskapets storlek: ");
            } while (groupSize < 0);
            int sum = 0;
            for (int i = 0; i < groupSize; i++)
            {
                int age = -1;
                do
                {
                    age = GetUserNumber($"Ange ålder på person nr {i + 1}: ");
                } while (age < 0);
                int price;
                if (age < 5 || age > 100)
                    price = 0;
                else
                {
                    if (age < 20)
                        price = 80;
                    else
                    {
                        if (age > 64)
                            price = 90;
                        else
                            price = 120;
                    }
                }
                sum += price;
            }
            Console.WriteLine($"Totalkostnaden för hela sällskapet på {groupSize} personer blir {sum} kr.");
        }

        private static void RepeatInput()
        {
            // Potentially not allowing empty strings
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
            // Handle exception when third element doesn't exist
            Console.WriteLine("Skriv in en mening med minst tre ord.");
            var sentenceElements = Console.ReadLine().Split();
            Console.WriteLine(sentenceElements[2]);
        }


        private static object TicketType(int age)
        {
            AttendeeType adolescent = new("Ungdoms", 80);
            AttendeeType adult = new("Standard", 120);
            AttendeeType aged = new("Pensionärs", 90);
            AttendeeType child = new("Barn", 0);
            AttendeeType reallyWrinkly = new("Gammelpensionärs", 0);

            if (age < 20)
                if (age < 5)
                    return child;
                else
                    return adolescent;
            else
                if (age > 64)
                    if (age > 99)
                        return reallyWrinkly;
                    else
                        return aged;
                else
                    return adult;

        }
    }
}