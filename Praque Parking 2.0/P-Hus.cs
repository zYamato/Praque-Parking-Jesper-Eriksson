using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Praque_Parking_2._0
{
    public class P_Hus : UserInterface
    {
        public static List<Vehicle> Parking = new List<Vehicle>();
        private static Vehicle.VehicleType type;

        public P_Hus()
        {
            
        }

        public static void AddVehicle()
        {
            Console.Clear();
            type = GetVehicleType();

            string regnum = GetRegnum();

            Vehicle newVehicle = new Vehicle(type, regnum, DateTime.Now);

            if(newVehicle.Type == Vehicle.VehicleType.CAR)
            {
                for(int i = 0; i < 100; i++)
                {
                    if (Parking[i].RegNum == regnum || Parking[i + 100].RegNum == regnum)
                    {
                        Console.WriteLine("A vehicle with that registration number is already parked here.");
                        break;
                    }
                    if (Parking[i].Type == Vehicle.VehicleType.EMPTY && Parking[i + 100].Type == Vehicle.VehicleType.EMPTY)
                    {
                        Parking.RemoveAt(i);
                        Parking.Insert(i,newVehicle);
                        ReadWrite.WriteDatabase(Parking);
                        break;
                    }
                }
            }
            if(newVehicle.Type == Vehicle.VehicleType.MC)
            {
                for(int i = 0; i < 100; i++)
                {
                    if (Parking[i].RegNum == regnum || Parking[i + 100].RegNum == regnum)
                    {
                        Console.WriteLine("A vehicle with that registration number is already parked here.");
                        break;
                    }
                    if (Parking[i].Type == Vehicle.VehicleType.EMPTY)
                    {
                        Parking.RemoveAt(i);
                        Parking.Insert(i,newVehicle);
                        ReadWrite.WriteDatabase(Parking);
                        break;
                    }
                    else if(Parking[i].Type == Vehicle.VehicleType.MC && Parking[i+100].Type == Vehicle.VehicleType.EMPTY)
                    {
                        Parking.RemoveAt(i+100);
                        Parking.Insert(i + 100, newVehicle);
                        ReadWrite.WriteDatabase(Parking);
                        break;
                    }
                }
            }



            

        }
        public static void RetriveVehicle()
        {
            Console.Clear();
            PromptUserRegnumDel();
            string regnum = GetRegnum();


            for(int i = 0; i < 200; i++)
            {
                if(Parking[i].RegNum == regnum && Parking[i].Type == Vehicle.VehicleType.CAR)
                {
                    TimeSpan hoursDiff =  DateTime.Now - Parking[i].DateAdded;

                    Console.WriteLine(hoursDiff);
                    

                    if(hoursDiff.TotalMinutes > 5)
                    {
                        if(hoursDiff.TotalHours < 2)
                        {
                            int price = 2 * 20;

                            Console.WriteLine("Total cost for parking is {0}kr", price);
                            Parking.RemoveAt(i);
                            Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                            Console.WriteLine("Your car has been retrived");
                            ReadWrite.WriteDatabase(Parking);
                            return;
                        }
                        else
                        {
                            TimeSpan hoursToPayFor = hoursDiff.Subtract(TimeSpan.FromMinutes(5));
                            double price = (hoursToPayFor.TotalHours) * 20;

                            Console.WriteLine("Total cost for parking is {0}kr", price);
                            Parking.RemoveAt(i);
                            Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                            Console.WriteLine("Your car has been retrived!");
                            ReadWrite.WriteDatabase(Parking);
                            return;
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine("Your have retrived your car");
                        Parking.RemoveAt(i);
                        Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                        ReadWrite.WriteDatabase(Parking);
                        return;
                    }
                }
                else if(Parking[i].RegNum == regnum && Parking[i].Type == Vehicle.VehicleType.MC)
                {
                    TimeSpan hoursDiff = DateTime.Now - Parking[i].DateAdded;

                    if(hoursDiff.TotalMinutes > 5)
                    {
                        if(hoursDiff.TotalHours < 2)
                        {
                            int price = 2 * 10;

                            Console.WriteLine("Total cost for parking is {0}kr", price);
                            Parking.RemoveAt(i);
                            Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                            Console.WriteLine("Your bike has been retrived");
                            ReadWrite.WriteDatabase(Parking);
                            return;
                        }
                        else
                        {
                            TimeSpan hoursToPayFor = hoursDiff.Subtract(TimeSpan.FromMinutes(5));
                            double price = (hoursToPayFor.TotalHours) * 10;

                            Console.WriteLine("Total cost for parking is {0}kr", price);
                            Parking.RemoveAt(i);
                            Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                            Console.WriteLine("Your bike has been retrived!");
                            ReadWrite.WriteDatabase(Parking);
                            return;
                        }
                    }
                    else if (i >= 200)
                    {
                        Console.WriteLine("Could not find vehicle!");
                    }
                    else
                    {
                        Console.WriteLine("Your have retrived your bike");
                        Parking.RemoveAt(i);
                        Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                        ReadWrite.WriteDatabase(Parking);
                        return;
                    }   
                }
            }
            Console.WriteLine("Could not find that Vehicle");
            Console.WriteLine();
        }
        public static int SearchVehicle(string regnum)
        {

            for(int i = 0; i < 200; i++)
            {
                if(Parking[i].RegNum == regnum && i < 100 && Parking[i].Type == Vehicle.VehicleType.CAR)
                {
                    return i;
                }
                else if(Parking[i].RegNum == regnum && i > 100)
                {
                    return i;
                }
                else if(Parking[i].RegNum == regnum && i < 100 && Parking[i].Type == Vehicle.VehicleType.MC)
                {
                    return i;
                }
            }
            return -1;
            
        }
        public static void SearchParkingSpot()
        {
            Console.Clear();
            int index = 0;
            try
            {
                Console.Write("Enter a Parkingspot: ");
                index = int.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("Enter a valid input");
            }


            if(index > 0)
            {
                if (Parking[index - 1].Type == Vehicle.VehicleType.CAR)
                {
                    Console.WriteLine("The car parked at {0} has registration number {1}", index, Parking[index - 1].RegNum);
                }
                else if (Parking[index - 1].Type == Vehicle.VehicleType.MC)
                {
                    Console.WriteLine("The bike parked at {0} has registration number {1}", index, Parking[index - 1].RegNum);
                }
                else if (Parking[index + 99].Type == Parking[index - 1].Type && Parking[index - 1].Type != Vehicle.VehicleType.EMPTY)
                {
                    Console.WriteLine("The bikes parked at {0} has the registration number {1} and {2}", index, Parking[index - 1].RegNum, Parking[index + 99].RegNum);
                }
                else if (Parking[index - 1].Type == Vehicle.VehicleType.EMPTY)
                {
                    Console.WriteLine("That spot is empty");
                }
            }
           
        }
        public static void MoveVehicle()
        {
            Console.Clear();
            bool moved = false;
            Console.WriteLine("What vehicle do you want to move? (Enter registration number)");
            string regnum = GetRegnum();

            for(int i = 0; i < 100; i++)
            {
                if(Parking[i].RegNum == regnum && Parking[i].Type == Vehicle.VehicleType.CAR)
                {
                    int index = 0;
                    try
                    {
                        Console.Write("Where do you want to move the car? ");
                        index = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("That is not a valid input");
                    }
                    if(index > 100)
                    {
                        Console.WriteLine("There is not spot {0} there is only 100 spots available",index);
                    }
                    if(Parking[index - 1].Type == Vehicle.VehicleType.EMPTY)
                    {
                        Parking[index - 1] = Parking[i];
                        Parking.RemoveAt(i);
                        Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                        ReadWrite.WriteDatabase(Parking);
                        moved = true;
                        Console.WriteLine("That car has been moved to {0}", index);
                        return;
                    }
                    else if(Parking[index - 1].Type == Vehicle.VehicleType.MC || Parking[index - 1].Type == Vehicle.VehicleType.CAR)
                    {
                        Console.WriteLine("That space is already occupied");
                        moved = true;
                    }
                    
                }
                else if(Parking[i].RegNum == regnum && Parking[i].Type == Vehicle.VehicleType.MC)
                {
                    int index = 0;
                    try
                    {
                        Console.Write("Enter a Parkingspot: ");
                        index = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("That is not a valid input");
                    }
                    if (index > 100)
                    {
                        Console.WriteLine("There is not spot {0} there is only 100 spots available", index);
                    }
                    if(Parking[index - 1].Type == Vehicle.VehicleType.EMPTY)
                    {
                        Parking[index - 1] = Parking[i];
                        Parking.RemoveAt(i);
                        Parking.Insert(i, new Vehicle(Vehicle.VehicleType.EMPTY, "EMPTY", DateTime.MinValue));
                        ReadWrite.WriteDatabase(Parking);
                        moved = true;
                        Console.WriteLine("That bike has been moved to {0}", index);
                        return;
                    }
                    else if (Parking[index - 1].Type == Vehicle.VehicleType.MC || Parking[index - 1].Type == Vehicle.VehicleType.CAR)
                    {
                        Console.WriteLine("That space is already occupied");
                        moved = true;
                    }
                }
            }
            if(moved == false)
            {
                Console.WriteLine("That vehicle is not parked here.");
            }
        }
        public static void PrintPhus()
        {
            Console.Clear();
            int place = 1;
            
            Console.WriteLine("|-----------------Parking-------------------|");
            Console.WriteLine("|-------------------------------------------|");
            for(int i = 0; i < 25; i++)
            {
                Console.WriteLine("|          |          |          |          |");
                Console.WriteLine("|          |          |          |          |");
                Console.WriteLine("|          |          |          |          |");
                Console.WriteLine("|  {0:000}     | {1:000}      | {2:000}      |  {3:000}     |", place++, place++, place++, place++);
                Console.WriteLine("|----------|----------|----------|----------|");
            }
            for (int i = 0; i < 100; i++)
            {
                int x = ((i % 4) * 11) + 1;
                int y = ((i / 4) * 5) + 3;
                int z = ((i % 4) * 11) + 1;
                int w = ((i / 4) * 5) + 2;

                if (Parking[i].Type == Vehicle.VehicleType.CAR)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Parking[i].RegNum);
                    Console.SetCursorPosition(z, w);
                    Console.WriteLine("CAR");
                    Console.WriteLine();
                }
                else if (Parking[i].Type == Vehicle.VehicleType.MC)
                {
                    if (Parking[i + 100].Type == Vehicle.VehicleType.MC)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(Parking[i].RegNum);
                        Console.SetCursorPosition(x, y + 1);
                        Console.WriteLine(Parking[i + 100].RegNum);
                        Console.SetCursorPosition(z, w);
                        Console.WriteLine("MC");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(Parking[i].RegNum);
                        Console.SetCursorPosition(z, w);
                        Console.WriteLine("MC");
                    }
                }
                else if (Parking[i + 100].Type == Vehicle.VehicleType.MC)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Parking[i + 100].RegNum);
                    Console.SetCursorPosition(x, y + 1);
                    Console.SetCursorPosition(z, w);
                    Console.WriteLine("MC");
                }
                else
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("Empty");

                }

            }
            Console.SetCursorPosition(0, 127);
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();

        }
        public static void VehicleOptimize()
        {
            Console.Clear();
            for (int i = 0; i < 100; i++)
            {
                if (Parking[i].Type == Vehicle.VehicleType.EMPTY)
                {
                    for (int j = 99; j > i; j--)
                    {
                        if (Parking[j].Type == Vehicle.VehicleType.CAR)
                        {
                            Vehicle temp = Parking[i];
                            Parking[i] = Parking[j];
                            Parking[j] = temp;
                            Console.WriteLine("Move the car with registration number: {0} from spot {1} to spot {2}.", Parking[i].RegNum, j + 1, i + 1);
                            break;
                        }
                        else if (Parking[j].Type == Vehicle.VehicleType.MC)
                        {
                            if (Parking[j + 100].Type == Vehicle.VehicleType.MC)
                            {
                                Vehicle temp = Parking[i];
                                Parking[i] = Parking[j];
                                Parking[i + 100] = Parking[j + 100];
                                Parking[j] = temp;
                                Parking[j + 100] = temp;
                                Console.WriteLine("Move the bikes with registration number: {0} and {1} from spot {2} to spot {3}", Parking[i].RegNum, Parking[i + 100].RegNum, j + 1, i + 1);
                                break;
                            }
                            else
                            {
                                Vehicle temp = Parking[i];
                                Parking[i] = Parking[j];
                                Parking[j] = temp;
                                Console.WriteLine("Move the bike with registration number: {0} from spot {1} to spot {2}", Parking[i].RegNum, j + 1, i + 1);
                                break;
                            }
                        }
                        else if (Parking[j + 100].Type == Vehicle.VehicleType.MC)
                        {
                            if (Parking[j].Type == Vehicle.VehicleType.MC)
                            {
                                Vehicle temp = Parking[i];
                                Parking[i] = Parking[j + 100];
                                Parking[i + 100] = Parking[j];
                                Parking[j + 100] = temp;
                                Parking[j] = temp;
                                Console.WriteLine("Move the bikes with registration number: {0} and {1} from spot {2} to spot {3}", Parking[i].RegNum, Parking[i + 100].RegNum, j + 1, i + 1);
                                break;
                            }
                            else
                            {
                                Vehicle temp = Parking[i];
                                Parking[i] = Parking[j + 100];
                                Parking[j + 100] = temp;
                                Console.WriteLine("Move the bike with registration number: {0} from spot {1} to spot {2}", Parking[i].RegNum, j + 1, i + 1);
                                break;
                            }
                        }
                    }

                }
            }
            try
            {
                ReadWrite.WriteDatabase(Parking);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Optimization done.");
            Console.ReadLine();
        }
        public static void McOptimize()
        {
            Console.Clear();
            for(int i = 0; i < 100; i++)
            {
                if(Parking[i].Type == Vehicle.VehicleType.MC && Parking[i+100].Type == Vehicle.VehicleType.EMPTY)
                {
                    for(int j = i+1; j<100; j++)
                    {
                        if(Parking[j].Type == Vehicle.VehicleType.MC && Parking[j+100].Type == Vehicle.VehicleType.EMPTY)
                        {
                            Vehicle temp = Parking[i + 100];
                            Parking[i + 100] = Parking[j];
                            Parking[j] = temp;
                            Console.WriteLine("Move the bike {0} from spot {1} to spot {2}",Parking[i+100].RegNum,j+1,i+1);
                            break;
                        }
                    }
                }
                else if (Parking[i].Type == Vehicle.VehicleType.EMPTY && Parking[i + 100].Type == Vehicle.VehicleType.MC)
                {
                    for (int j = i + 1; j < 100; j++)
                    {
                        if (Parking[j].Type == Vehicle.VehicleType.MC && Parking[j + 100].Type == Vehicle.VehicleType.EMPTY)
                        {
                            Vehicle temp = Parking[i];
                            Parking[i] = Parking[j];
                            Parking[j] = temp;
                            Console.WriteLine("Move the bike {0} from spot {1} to spot {2}", Parking[i + 100].RegNum, j + 1, i + 1);
                            break;
                        }
                    }
                }
            }
            try
            {
                ReadWrite.WriteDatabase(Parking);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Optimization done.");
            Console.ReadLine();

        }
        public static string GetRegnum()
        {
            string regnum;
            bool validinput = false;
            bool specchar = false;
            string special = "!#¤%&/()=?`^¨'*<>|";
            do
            {
                Console.WriteLine("Enter a registration number");
                regnum = Console.ReadLine().ToUpper();

                foreach(char c in special)
                {
                    if (regnum.Contains(c))
                    {
                        Console.WriteLine("You cannot use special characters in a registration number");
                        specchar = true;
                    }
                }

                if (regnum.Length < 1)
                {
                    Console.WriteLine("A registration number cannot be less than 1 character");
                }
                else
                {
                    validinput = true;
                }
            } while (!validinput && !specchar);
            return regnum;

            
        }
        public static Vehicle.VehicleType GetVehicleType()
        {
            while (true)
            {
                PromptUserVehicle();
                string vehicle = Console.ReadLine().ToUpper();

                if(vehicle == "CAR")
                {
                    return Vehicle.VehicleType.CAR;
                }
                else if(vehicle == "MC" || vehicle == "MOTORCYCLE")
                {
                    return Vehicle.VehicleType.MC;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid vehicle (Car or mc)");
                }

            }

        }
    }
}
