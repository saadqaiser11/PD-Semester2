using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    internal class ship
    {
        public string shipNumber;
        public Angle latitude;
        public Angle longitude;

        public ship(string shipNumber, Angle latitude, Angle longitude)
        {
            this.shipNumber = shipNumber;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void printPosition()
        {
            Console.WriteLine("Longitude of the Ship is : " + longitude.degrees + "°" + longitude.minutes + "' " + longitude.direction);
            Console.WriteLine("Latitude of the Ship is : " + latitude.degrees + "°" + latitude.minutes + "' " + latitude.direction);
        }

        public void changeLatandLong(Angle latitude, Angle longitude)
        {
            this.latitude = latitude;
                this.longitude = longitude;
        }

        public void printSerialNumber()
        {
            Console.WriteLine("The Ship Number is : " + shipNumber);
        }
    }
}
