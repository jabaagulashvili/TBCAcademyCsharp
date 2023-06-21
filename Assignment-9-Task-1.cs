using System;
using System.Collections.Generic;

namespace TransportApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the  Transport Application!");

            while (true)
            {
                Console.WriteLine("Please choose transport category:");
                Console.WriteLine("1. Military");
                Console.WriteLine("2. Consumer");
                Console.WriteLine("3. Public Transport");
                Console.WriteLine("4. Sports");
                Console.WriteLine("5. Use Vehicle");
                Console.WriteLine("0. Exit");

                int choice = GetUserChoice(0, 5);

                if (choice == 0)
                {
                    Console.WriteLine("Thank you for using the Transport Application. See ya!");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        CreateMilitaryTransport();
                        break;
                    case 2:
                        CreateConsumerTransport();
                        break;
                    case 3:
                        CreatePublicTransport();
                        break;
                    case 4:
                        CreateSportsTransport();
                        break;
                    case 5:
                        CreateUseVehicle();
                        break;
                }
            }
        }

        static int GetUserChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("Please enter a valid choice.");
            }
        }

        static void CreateMilitaryTransport()
        {
            Console.WriteLine("\nAvailable military transport options:");
            Console.WriteLine("1. Tank");
            Console.WriteLine("2. BTR ");
            Console.WriteLine("3. Fighter Jet");

            int choice = GetUserChoice(1, 3);

            switch (choice)
            {
                case 1:
                    CreateTank();
                    break;
                case 2:
                    CreateBTR();
                    break;
                case 3:
                    CreateFighterJet();
                    break;
            }
        }

        static void CreateTank()
        {
            Console.WriteLine("Creating a Tank...");

        }

        static void CreateBTR()
        {
            Console.WriteLine("Creating a BTR...");

        }

        static void CreateFighterJet()
        {
            Console.WriteLine("Creating a Fighter Jet...");

        }

        static void CreateConsumerTransport()
        {
            Console.WriteLine("\nAvailable consumer transport options:");
            Console.WriteLine("1. Sedan");
            Console.WriteLine("2. SUV");
            Console.WriteLine("3. Motorcycle");
            Console.WriteLine("4. Bicycle");

            int choice = GetUserChoice(1, 4);

            switch (choice)
            {
                case 1:
                    CreateSedan();
                    break;
                case 2:
                    CreateSUV();
                    break;
                case 3:
                    CreateMotorcycle();
                    break;
                case 4:
                    CreateBicycle();
                    break;
            }
        }

        static void CreateSedan()
        {
            Console.WriteLine("Creating a Sedan...");

        }

        static void CreateSUV()
        {
            Console.WriteLine("Creating an SUV...");

        }

        static void CreateMotorcycle()
        {
            Console.WriteLine("Creating a Motorcycle...");

        }

        static void CreateBicycle()
        {
            Console.WriteLine("Creating a Bicycle...");

        }

        static void CreatePublicTransport()
        {
            Console.WriteLine("\nAvailable public transport options:");
            Console.WriteLine("1. Bus");
            Console.WriteLine("2. Subway");

            int choice = GetUserChoice(1, 2);

            switch (choice)
            {
                case 1:
                    CreateBus();
                    break;
                case 2:
                    CreateSubway();
                    break;
            }
        }

        static void CreateBus()
        {
            Console.WriteLine("Creating a Bus...");

        }

        static void CreateSubway()
        {
            Console.WriteLine("Creating a Subway...");

        }

        static void CreateSportsTransport()
        {
            Console.WriteLine("\nAvailable sports transport options:");
            Console.WriteLine("1. Formula 1 Car");
            Console.WriteLine("2. Rally Car");
            Console.WriteLine("3. Off-road Vehicle");

            int choice = GetUserChoice(1, 3);

            switch (choice)
            {
                case 1:
                    CreateFormula1Car();
                    break;
                case 2:
                    CreateRallyCar();
                    break;
                case 3:
                    CreateOffroadVehicle();
                    break;
            }
        }

        static void CreateFormula1Car()
        {
            Console.WriteLine("Creating a Formula 1 Car...");

        }

        static void CreateRallyCar()
        {
            Console.WriteLine("Creating a Rally Car...");

        }

        static void CreateOffroadVehicle()
        {
            Console.WriteLine("Creating an Off-road Vehicle...");

        }

        static void CreateUseVehicle()
        {
            Console.WriteLine("\nCreating a Use Vehicle...");

        }
    }
}
