using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce1.Model;

namespace BookCommerce1.DataAccess.Repository.IRepository
{
    public interface IMbulesaRepository:IRepository<Mbulesa>
    {
        void Update(Mbulesa mbulesa);
    }
}
