using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce1.Model;

namespace BookCommerce1.DataAccess.Repository.IRepository
{
    public interface IKategoriaRepository:IRepository<Kategoria>
    {
        void Update(Kategoria kategoria);
    }
}
