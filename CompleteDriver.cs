using DriverDALLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TransportDriverFEApplication
{
    class CompleteDriver : Driver, IComparable<Driver>
    {
        public int CompareTo([AllowNull] Driver other)
        {
            return this.Id.CompareTo(other.Id);
        }
        public CompleteDriver()
        {

        }
        public CompleteDriver(Driver driver)
        {
            this.Id = driver.Id;
            this.Name = driver.Name;
            this.Phone = driver.Phone;
            this.Status = driver.Status;
        }
        public void TakeDriverData()
        {
            Console.WriteLine("Enter the driver Name");
            Name = Console.ReadLine();            
            Console.WriteLine("Enter driver phone number");
            Phone = Console.ReadLine();
            Console.WriteLine("Enter the driver Status:");
            Status = Console.ReadLine();           
        }
        public override string ToString()
        {
            return " Id : " + Id + " Name : " + Name + " Phone : " + Phone + "  Status : " + Status;

        }
    }
}
