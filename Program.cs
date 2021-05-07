using DriverBLLibrary;
using System;

namespace TransportDriverFEApplication
{
    class Program
    {
        DriverManagement management;
        DriverBL bl;
        public Program()
        {
            bl = new DriverBL();
            management = new DriverManagement(bl);
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add new Drivers");
                Console.WriteLine("2. Print all Drives available");
                Console.WriteLine("3. Print Driver By ID");
                Console.WriteLine("4. Sort Drivers Based on Id");
                Console.WriteLine("5. Update Phone number of Drivers");
                Console.WriteLine("6. Update Status of drivers");               
                Console.WriteLine("7. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        management.CreateDriver();
                        break;
                    case 2:
                        management.PrintAllDrivers();
                        break;
                    case 3:
                        management.PrintDriverByID();
                        break;
                    case 4:
                        management.PrintDriversSortById();
                        break;
                    case 5:
                        management.UpdateDriverPhone();
                        break;
                    case 6:
                        management.UpdateDriverStatus();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 6);

        }
        static void Main(string[] args)
        {
            new Program().PrintMenu();
        }
    }
}

