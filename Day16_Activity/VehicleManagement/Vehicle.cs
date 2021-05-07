using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleDALLibrary
{
    public class Vehicle
    {
        public string VechicleNumber { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int DriverID { get; set; }
        public int FilledStatus { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return "VechicleNumber : " + VechicleNumber + " Type : " + Type + " Capacity : " + Capacity + "  DriverID : " + DriverID+ " FilledStatus : " + FilledStatus+ " Status : "+ Status;

        }
    }
}
