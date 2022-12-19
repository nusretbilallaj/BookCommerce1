using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce1.DataAccess.Repository.IRepository;
using BookCommerce1.Model;

namespace BookCommerce1.DataAccess.Repository
{
    public class MbulesaRepository:Repository<Mbulesa>,IMbulesaRepository
    {
        private readonly Konteksti _konteksti;
        public MbulesaRepository(Konteksti konteksti) : base(konteksti)
        {
            _konteksti = konteksti;
        }

        public void Update(Mbulesa mbulesa)
        {
            var ent = _konteksti.Mbulesat.FirstOrDefault(x => x.Id == mbulesa.Id);
            ent.Emri = mbulesa.Emri;
        }
    }
}
