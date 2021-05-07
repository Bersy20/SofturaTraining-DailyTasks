using System;
using System.Collections.Generic;
using System.Text;

namespace DriverBLLibrary
{
    public interface IRepo<T>
    {
        bool Add(T t);
        bool UpdatePhone(T t);
        bool UpdateStatus(T t);
        ICollection<T> GetAll();
    }
}
