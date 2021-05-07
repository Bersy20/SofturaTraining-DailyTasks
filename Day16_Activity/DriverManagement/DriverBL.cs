using System;
using System.Collections.Generic;
using DriverDALLibrary;
using System.Linq;

namespace DriverBLLibrary
{
    public class DriverBL : IRepo<Driver>
    {
            DriverDAL dal;
            public DriverBL()
            {
                dal = new DriverDAL();
            }

            public bool Add(Driver t)
            {
                try
                {
                    return dal.AddDriver(t);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }

            public ICollection<Driver> GetAll()
            {
                List<Driver> drivers;
                try
                {
                    drivers = dal.SelectAllDrivers().ToList();
                    return drivers;
                }
                catch (Exception exception)
                {

                    throw exception;
                }
            }

            
        public bool UpdatePhone(Driver t)
        {
            try
            {
                return dal.UpdatePhone(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateStatus(Driver t)
        {
            try
            {
                return dal.UpdateDriverStatus(t);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        
        
    }
}
