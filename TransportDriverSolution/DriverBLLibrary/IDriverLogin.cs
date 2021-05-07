using System;
using System.Collections.Generic;
using System.Text;

namespace DriverBLLibrary
{
    public interface IDriverLogin<T>
    {
        bool Add(T t);
        bool Login(T t);
    }
}
