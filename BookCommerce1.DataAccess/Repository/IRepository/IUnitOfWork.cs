using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCommerce1.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IKategoriaRepository Kategoria { get; }
        public IMbulesaRepository Mbulesa { get; }
        void Save();
    }
}
