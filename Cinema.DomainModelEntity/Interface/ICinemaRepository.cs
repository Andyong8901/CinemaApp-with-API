using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DomainModelEntity.Interface
{
    public interface ICinemaRepository
    {
        IEnumerable<User> GetUsers();
    }
}
