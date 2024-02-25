using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <ship> ships = new List <ship> ();

            while (true) 
            {
                Console.Clear ();
                string choice = menu();
                if (choice == "1")
                {
                    ship s = takeInput();
                    ships.Add (s);
                    returnMenu ();
                }
                else if (choice == "2")
                {
                    string shipNumber = takeSerial();
                    ship FoundShip = findShip(shipNumber, ships);
                    if(FoundShip!=null)
                    {
                        FoundShip.printPosition();
                    }
                    else
                    {
                        Console.WriteLine("Ship not Found.");
                    }

                    returnMenu ();
                }
                else if (choice == "3")
                {
                    Angle latitude = takeLatitude();
                    Angle longitude = takeLongitude();
                    ship FoundShip = findShipwithCoord(latitude, longitude, ships);
                    if (FoundShip!=null)
                    {
                        FoundShip.printSerialNumber();
                    }
                    else
                    {
                        Console.WriteLine("Ship not Found.");
                    }

                }
                else if (choice == "4")
                {
                    string shipNumber = takeSerial();
                    ship FoundShip = findShip(shipNumber, ships);
                    if (FoundShip != null)
                    {
                        Angle latitude = takeLatitude();
                        Angle longitude = takeLongitude();
                        FoundShip.changeLatandLong(latitude, longitude);


                    }
                    else
                    {
                        Console.WriteLine("Ship not Found.");
                    }

                    returnMenu ();
                }

                else if(choice == "5")
                {
                    break;
                }
            }
        }

        static string menu()
        {
            Console.WriteLine("-----Ocean Navigation------");
            Console.WriteLine();
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        static ship takeInput()
        {
            Console.Write("Enter Ship Number: ");
            string serial = Console.ReadLine();
            Angle latitude = takeLatitude();
            Angle longitude = takeLongitude();

            return new ship (serial, latitude, longitude);

            
        }

        static Angle takeLatitude()
        {
            Console.WriteLine("Enter Ship Latitude:");
            Console.Write("Enter Latitude's Degree: ");
            int degree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minute: ");
            float minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char direction = char.Parse(Console.ReadLine());

            return new Angle(degree, minutes, direction);
        }

        static Angle takeLongitude()
        {
            Console.WriteLine("Enter Ship Longitude:");
            Console.Write("Enter Longitude's Degree: ");
            int degree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minute: ");
            float minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char direction = char.Parse(Console.ReadLine());

            return new Angle(degree, minutes, direction);
        }

        static string takeSerial()
        {
            Console.Write("Enter the serial Number of the ship: ");
            return Console.ReadLine();

        }

        static ship findShip(string shipNumber, List <ship> ships)
        {
            ship FoundShip = ships.Find(ship => ship.shipNumber == shipNumber);
            return FoundShip;
        }

        static void returnMenu()
        {
            Console.WriteLine();
            Console.Write("Enter any key...");
            Console.Read();
        }

        static ship findShipwithCoord(Angle latitude, Angle longitude, List <ship> ships)
        {
            ship FoundShip = ships.Find(ship => ship.latitude == latitude && ship.longitude == longitude);
            return FoundShip;
        }
    }
}
