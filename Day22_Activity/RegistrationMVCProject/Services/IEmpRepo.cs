using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMVCProject.Services
{
    public interface IEmpRepo<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
