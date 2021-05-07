using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBLLibrary
{
    public interface IRepo<T>
    {
        bool Add(T t);
        bool UpdateCapacity(T t);
        bool UpdateDriverId(T t);
        bool UpdateVehicleFilledStatus(T t);
        bool UpdateVehicleStatus(T t);

        ICollection<T> GetAll();
    }
}
