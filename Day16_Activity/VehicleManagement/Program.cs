using System;
using VehicleBLLibrary;

namespace TransportVechicleFEProject
{
    class Program
    {

        VehicleManagement management;
        VehicleBL bl;
        public Program()
        {
            bl = new VehicleBL();
            management = new VehicleManagement(bl);
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add new Vehicles");
                Console.WriteLine("2. Print all Vehicles available");
                Console.WriteLine("3. Print Vehicle By Vehicle ID");
                Console.WriteLine("4. Sort Vehicles Based on Id");
                Console.WriteLine("5. Update capacity of Vehicles");
                Console.WriteLine("6. Update Filled Status of vehicles");
                Console.WriteLine("7. Update Status of vehicles");
                Console.WriteLine("8. Update Driver Id  of vehicles");
                Console.WriteLine("9. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        management.CreateVehicle();
                        break;
                    case 2:
                        management.PrintAllVehicles();
                        break;
                    case 3:
                        management.PrintVehicleByID();
                        break;
                    case 4:
                        management.PrintVehiclesSortById();
                        break;
                    case 5:
                        management.UpdateVehicleCapacity();
                        break;
                    case 6:
                        management.UpdateVehicleFilledStatus();
                        break;
                    case 7:
                        management.UpdateVehicleStatus();
                        break;
                    case 8:
                        management.UpdateDriverId();
                        break;
                    case 9:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 9);

        }
        static void Main(string[] args)
        {
            new Program().PrintMenu();
        }
    }
}

