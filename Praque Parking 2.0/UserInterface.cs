using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Praque_Parking_2._0
{
    public class UserInterface
    {
        public static void PromptUserVehicle()
        {
            
            Console.WriteLine("What type of vehicle do you want to park? (MC or CAR)");
        }
        public static void PromptUserRegnum()
        {
            Console.Clear();
            Console.WriteLine("Enter a regnum that you would like to park: ");
        }
        public static void PromptNoSpace()
        {
            Console.Clear();
            Console.WriteLine("There are no spaces left.");
        }
        public static void PromptUserRegnumDel()
        {
            Console.WriteLine("What regnum would you like to retrive? ");
        }
        public static void SearchUi()
        {
            Console.Clear();
            string regnum = P_Hus.GetRegnum();
            int index = P_Hus.SearchVehicle(regnum);

            if(index != -1 && P_Hus.Parking[index].RegNum == regnum && P_Hus.Parking[index].Type == Vehicle.VehicleType.CAR)
            {
                Console.WriteLine("Your car is parked at spot {0}", index + 1);
            }
            else if(index != -1 && P_Hus.Parking[index].RegNum == regnum && P_Hus.Parking[index].Type == Vehicle.VehicleType.MC && index < 100)
            {
                Console.WriteLine("Your bike is parked at spot {0}", index + 1);
            }
            else if(index != -1 && P_Hus.Parking[index].RegNum == regnum && P_Hus.Parking[index].Type == Vehicle.VehicleType.MC && index > 100)
            {
                Console.WriteLine("Your bike is parked at stpot {0}", index - 101);
            }
            else
            {
                Console.WriteLine("A vehicle with that registration number is not parked here");
            }
        }
        public static void menu()
        {
            while (true)
            {
                Console.WriteLine("Main Menu!");
                Console.WriteLine("[1] Add vehicle");
                Console.WriteLine("[2] Retrive vehicle");
                Console.WriteLine("[3] Move vehicle");
                Console.WriteLine("[4] Search vehicle");
                Console.WriteLine("[5] Search for parking spot");
                Console.WriteLine("[6] Print out the parking house");
                Console.WriteLine("[7] Optimize vehicles");
                Console.WriteLine("[8] Optimize bikes");
                Console.WriteLine("[9] Exit");
                ConsoleKey input = Console.ReadKey().Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        try
                        {
                            P_Hus.AddVehicle(); // execute add vehicle.
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("File Cannot be found");
                        }
                        
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        P_Hus.RetriveVehicle();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        P_Hus.MoveVehicle();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        SearchUi();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        P_Hus.SearchParkingSpot();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        P_Hus.PrintPhus();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        P_Hus.VehicleOptimize();
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        P_Hus.McOptimize();
                        break;

                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.Escape:

                        Console.Clear();
                        Console.WriteLine("Are you sure you want to exit? y/n");
                        ConsoleKey exitYN = Console.ReadKey().Key;

                        if (exitYN == ConsoleKey.Y || exitYN == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

    }
}
