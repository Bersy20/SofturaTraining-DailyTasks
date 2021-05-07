using System;
using VehicleDALLibrary;
using System.Collections.Generic;
using System.Linq;


namespace VehicleBLLibrary
{
    public class VehicleBL : IRepo<Vehicle>
    {
        VehicleDAL dal;
        public VehicleBL()
        {
            dal = new VehicleDAL();
        }

        public bool Add(Vehicle t)
        {
            try
            {
                return dal.AddVehicle(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ICollection<Vehicle> GetAll()
        {
            List<Vehicle> vehicles;
            try
            {
                vehicles = dal.SelectAllVehicles().ToList();
                return vehicles;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public bool UpdateCapacity(Vehicle t)
        {
            try
            {
                return dal.UpdateCapacity(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateDriverId(Vehicle t)
        {
            try
            {
                return dal.UpdateDriverId(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

       

        public bool UpdateVehicleStatus(Vehicle t)
        {
            try
            {
                return dal.UpdateVehicleStatus(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateVehicleFilledStatus(Vehicle t)
        {
            try
            {
                return dal.UpdateVehicleFilledStatus(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        
    }
}
