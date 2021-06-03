using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Praque_Parking_2._0
{
    class ReadWrite
    {
        public static List<Vehicle> ReadDatabase()
        {
            
            //StreamReader sr = new StreamReader("Database.txt");

            List<Vehicle> list = new List<Vehicle>();

            try
            {
                using (StreamReader sr = new StreamReader("Database.txt"))
                {
                    string temp = "";
                    try
                    {
                        temp = sr.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Something went wrong");
                    }
                    do
                    {
                        list.Add(MakeVehicle(temp));
                        try
                        {
                            temp = sr.ReadLine();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something went wrong");
                        }
                    } while (temp != null);

                    return list;
                }
            }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex);
                Console.WriteLine("THE PROGRAM WILL NOT WORK BECAUSE THE DATABASE FILE IS MISSING!");
                Console.ReadLine();
                Environment.Exit(1);
                    return list;
                }
            }
        public static void WriteDatabase(List<Vehicle> list)
        {
            var sw = new StreamWriter("Database.txt");

            using (sw)
            {
                foreach(Vehicle vehicle in P_Hus.Parking)
                {
                    sw.WriteLine(vehicle.ToString());
                }
            }
        }

        public static Vehicle MakeVehicle(string temp)
        {

            Vehicle.VehicleType type = Vehicle.VehicleType.EMPTY;
            string[] temparr = temp.Split('|');
            

            var time = DateTime.Parse(temparr[2]);

            if(temparr[0] == "CAR")
            {
                type = Vehicle.VehicleType.CAR;
            }
            else if (temparr[0] == "MC")
            {
                type = Vehicle.VehicleType.MC;
            }

            return new Vehicle(type, temparr[1], time);
        }
    }
}
