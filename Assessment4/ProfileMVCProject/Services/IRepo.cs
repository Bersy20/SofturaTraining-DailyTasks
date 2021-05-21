using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCProject.Services
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Register(T t);
        bool Login(T t);
        void Update(int id, T t);
        void Delete(T t);
    }
}
