using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praque_Parking_2._0
{
    public class ParkingSpace
    {
        private int space;
        private char place;
        private Vehicle vehicle;

        public ParkingSpace()
        {
        }

        public ParkingSpace(int space, char place, Vehicle vehicle)
        {
            this.space = space;
            this.place = place;
            this.vehicle = vehicle;
        }

        public int Space
        {
            get => this.space;
            set => this.space = value;
        }
        public char Place
        {
            get => this.place;
            set => this.place = value;
        }
        public Vehicle Vehicle
        {
            get => this.vehicle;
            set => this.vehicle = value;
        }
        
    }
}
