using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBLLibrary;
using VehicleDALLibrary;

namespace TransportVechicleFEProject
{
    class VehicleManagement
    {
        private IRepo<Vehicle> _repo;
        public VehicleManagement()
        {

        }
        public VehicleManagement(IRepo<Vehicle> repo)
        {
            _repo = repo;
        }
        public void CreateVehicle()
        {
            CompleteVehicle vehicle = new CompleteVehicle();
            vehicle.TakeVehicleData();
            try
            {
                if (_repo.Add(vehicle))
                    Console.WriteLine("Vechicle created");
                else
                    Console.WriteLine("sorryy could not complete creating an Vehicle");
            }
            catch (Exception e)
            {

                Console.WriteLine("could not add Vehicle");
                Console.WriteLine(e.Message);
            }
        }
        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = _repo.GetAll().ToList();
            return vehicles;
        }
        public void PrintAllVehicles()
        {
            var vehicles = GetAllVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(vehicle);
                Console.WriteLine("-------------------------------------------------------------------------");
            }
        }
        public void PrintVehicleByID()
        {
            Console.WriteLine("Enter the Vehicle Id");
            string VehicleNumber = Console.ReadLine();
            Vehicle vehicle = GetAllVehicles().Find(v => v.VechicleNumber == VehicleNumber);

            Console.WriteLine(vehicle);

        }
        public List<CompleteVehicle> SortVehicles()
        {
            List<CompleteVehicle> vehicles = new List<CompleteVehicle>();
            foreach (var item in GetAllVehicles())
            {
                vehicles.Add(new CompleteVehicle(item));
            }
            return vehicles;
        }
        public void PrintVehiclesSortById()
        {
            var vehicles = SortVehicles();
            vehicles.Sort();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(vehicle);
                Console.WriteLine("-------------------------------------------------------------------------");
            }
        }
        public void UpdateVehicleCapacity()
        {
            Console.WriteLine("Enter the Vehicle Id");
            string VehicleNumber = Console.ReadLine();

            Vehicle vehicle = GetAllVehicles().Find(v => v.VechicleNumber == VehicleNumber);
            try
            {
                if (vehicle != null)
                {
                    Console.WriteLine("Enter the new Capacity");
                    var newCapacity = Convert.ToInt32(Console.ReadLine());


                    vehicle.Capacity = newCapacity;
                    if (_repo.UpdateCapacity(vehicle))
                        Console.WriteLine("Capacity of vehicle is updated");
                    else
                        Console.WriteLine("PLease Try again");
                }

                else
                    Console.WriteLine("Incorrect Vehicle number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update Capacity at this moment");
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateDriverId()
        {
            Console.WriteLine("Enter the Vehicle Number");
            string VehicleNumber = Console.ReadLine();
            Vehicle vehicle = GetAllVehicles().Find(v => v.VechicleNumber == VehicleNumber);
            try
            {
                if (vehicle != null)
                {
                    Console.WriteLine("Enter the new DriverId");
                    int newDriverId = Convert.ToInt32(Console.ReadLine());
                    vehicle.DriverID = newDriverId;
                    if (_repo.UpdateDriverId(vehicle))
                        Console.WriteLine("DriverId is updated");
                    else
                        Console.WriteLine("PLease Try again");

                }
                else
                    Console.WriteLine("Incorrect vehicle number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update driver id at this moment");
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateVehicleFilledStatus()
        {
            Console.WriteLine("Enter the Vehicle Number");
            string VehicleNumber = Console.ReadLine();
            Vehicle vehicle = GetAllVehicles().Find(v => v.VechicleNumber == VehicleNumber);
            try
            {
                if (vehicle != null)
                {
                    Console.WriteLine("Enter the new filled Status");
                    var newFinalStatus = Convert.ToInt32(Console.ReadLine());
                    vehicle.FilledStatus = newFinalStatus;
                    if (_repo.UpdateVehicleFilledStatus(vehicle))
                        Console.WriteLine("Filled Status is updated");
                    else
                        Console.WriteLine("PLease Try again");

                }
                else
                    Console.WriteLine("Incorrect Vehicle number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update Filled Status of Vehicle at this moment");
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateVehicleStatus()
        {
            Console.WriteLine("Enter the Vehicle Number");
            string VehicleNumber = Console.ReadLine();
            Vehicle vehicle = GetAllVehicles().Find(v => v.VechicleNumber == VehicleNumber);
            try
            {
                if (vehicle != null)
                {
                    Console.WriteLine("Enter the new Status");
                    var newStatus = Console.ReadLine();
                    vehicle.Status = newStatus;
                    if (_repo.UpdateVehicleStatus(vehicle))
                        Console.WriteLine("Status is updated");
                    else
                        Console.WriteLine("PLease Try again");

                }
                else
                    Console.WriteLine("Incorrect Vehicle number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update Vehicle Status at this moment");
                Console.WriteLine(e.Message);
            }
        }
    }
}