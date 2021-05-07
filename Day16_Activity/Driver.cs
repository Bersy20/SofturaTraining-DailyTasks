using System;
using System.Collections.Generic;
using System.Text;

namespace DriverDALLibrary
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return "Id : " + Id + " Name : " + Name + " Phone : " + Phone +  "  Status : " + Status;

        }
    }
}
