using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountClientMVCProject.Services
{
    public interface IRepo<T>
    {
        bool Login(T t);
    }
}
