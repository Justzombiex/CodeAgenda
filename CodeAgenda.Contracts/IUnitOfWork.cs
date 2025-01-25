using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Contracts
{

    public interface IUnitOfWork
    {
        void SaveChanges();
    }

}
