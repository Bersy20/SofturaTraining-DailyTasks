using DriverBLLibrary;
using DriverDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportDriverFEApplication
{
    class DriverManagement
    {
        private IRepo<Driver> _repo;
        public DriverManagement()
        {

        }
        public DriverManagement(IRepo<Driver> repo)
        {
            _repo = repo;
        }
        public void CreateDriver()
        {
            CompleteDriver driver = new CompleteDriver();
            driver.TakeDriverData();
            try
            {
                if (_repo.Add(driver))
                    Console.WriteLine("Driver created");
                else
                    Console.WriteLine("sorryy could not complete creating an employee");
            }
            catch (Exception e)
            {

                Console.WriteLine("could not add driver");
                Console.WriteLine(e.Message);
            }
        }
        public List<Driver> GetAllDrivers()
        {
            List<Driver> drivers = _repo.GetAll().ToList();
            return drivers;
        }
        public void PrintAllDrivers()
        {
            var drivers = GetAllDrivers();
            foreach (Driver driver in drivers)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(driver);
                Console.WriteLine("-------------------------------------------------------------------------");
            }
        }
        public void PrintDriverByID()
        {
            Console.WriteLine("Enter the Driver Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Driver driver = GetAllDrivers().Find(d => d.Id == id );
           
                Console.WriteLine(driver);
            
        }
        public List<CompleteDriver> SortDrivers()
        {
            List<CompleteDriver> drivers = new List<CompleteDriver>();
            foreach (var item in GetAllDrivers())
            {
                drivers.Add(new CompleteDriver(item));
            }
            return drivers;
        }
        public void PrintDriversSortById()
        {
            var drivers = SortDrivers();
            drivers.Sort();
            foreach (Driver driver in drivers)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(driver);
                Console.WriteLine("-------------------------------------------------------------------------");
            }
        }
        public void UpdateDriverPhone()
        {
            Console.WriteLine("Enter the Driver Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the old Phone number");
            string Phone = Console.ReadLine();
            Driver driver = GetAllDrivers().Find(d => d.Id == id && d.Phone == Phone);
            try
            {
                if (driver != null)
                {
                    Console.WriteLine("Enter the new Phone Number");
                    var newPhone = Console.ReadLine();
                    Console.WriteLine("Enter the new Phone number again");
                    var repeatPhone = Console.ReadLine();
                    if (newPhone == repeatPhone)
                    {
                        driver.Phone = newPhone;
                        if (_repo.UpdatePhone(driver))
                            Console.WriteLine("Phone number is updated");
                        else
                            Console.WriteLine("PLease Try again");
                    }
                }
                else
                    Console.WriteLine("Incorrect phone number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update Phone number at this moment");
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateDriverStatus()
        {
            Console.WriteLine("Enter the Driver Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Driver driver = GetAllDrivers().Find(d => d.Id == id);
            try
            {
                if (driver != null)
                {
                    Console.WriteLine("Enter the new Status");
                    var newStatus = Console.ReadLine();
                    driver.Status = newStatus;
                    if (_repo.UpdateStatus(driver))
                            Console.WriteLine("Status is updated");
                        else
                            Console.WriteLine("PLease Try again");
                    
                }
                else
                    Console.WriteLine("Incorrect id number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update driver Status at this moment");
                Console.WriteLine(e.Message);
            }
        }
    }
}
