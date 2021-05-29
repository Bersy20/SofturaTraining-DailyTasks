using RegistrationMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMVCProject.Services
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);        
        bool Register(T t);
        bool Login(T t);
        
    }
}
