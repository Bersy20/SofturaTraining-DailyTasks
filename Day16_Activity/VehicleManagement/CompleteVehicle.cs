using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using VehicleDALLibrary;

namespace TransportVechicleFEProject
{
    class CompleteVehicle : Vehicle, IComparable<Vehicle>
    {
        public int CompareTo([AllowNull] Vehicle other)
        {
            return this.VechicleNumber.CompareTo(other.VechicleNumber);
        }
        public CompleteVehicle()
        {

        }
        public CompleteVehicle(Vehicle vehicle)
        {
            this.VechicleNumber = vehicle.VechicleNumber;
            this.Type = vehicle.Type;
            this.Capacity = vehicle.Capacity;
            this.DriverID = vehicle.DriverID;
            this.FilledStatus = vehicle.FilledStatus;
            this.Status = vehicle.Status;

        }
        public void TakeVehicleData()
        {
            Console.WriteLine("Enter the Vehicle Number");
            VechicleNumber = Console.ReadLine();
            Console.WriteLine("Enter Type of Vehicle");
            Type = Console.ReadLine();
            Console.WriteLine("Enter the Capacity of the vehicle");
            Capacity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the DriverID of the vehicle");
            DriverID = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Enter the Filled Status of the Vehicle of the vehicle");
            FilledStatus = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Status of the vehicle");
            Status = Console.ReadLine();
        }
        public override string ToString()
        {
            return "VechicleNumber : " + VechicleNumber + " Type : " + Type + " Capacity : " + Capacity + "  DriverID : " + DriverID + " FilledStatus : " + FilledStatus + " Status : " + Status;

        }
    }
}
