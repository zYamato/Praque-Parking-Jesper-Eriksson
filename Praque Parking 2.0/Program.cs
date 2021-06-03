using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Praque_Parking_2._0
{

    public class Program : UserInterface
    {
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            P_Hus.Parking = ReadWrite.ReadDatabase();
            menu();

        }
       

    }
}
