using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce1.DataAccess.Repository.IRepository;
using BookCommerce1.Model;

namespace BookCommerce1.DataAccess.Repository
{
    public class NenKategoriaRepository:Repository<NenKategoria>,INenKategoriaRepository
    {
        private readonly Konteksti _konteksti;
        public NenKategoriaRepository(Konteksti konteksti) : base(konteksti)
        {
            _konteksti = konteksti;
        }

        public void Update(NenKategoria nenKategoria)
        {
            var ent = _konteksti.NenKategorite.FirstOrDefault(x => x.Id == nenKategoria.Id);
            ent.Emri = nenKategoria.Emri;
            ent.Renditja = nenKategoria.Renditja;
        }
    }
}
