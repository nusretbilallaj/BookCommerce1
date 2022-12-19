using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce1.DataAccess.Repository.IRepository;
using BookCommerce1.Model;

namespace BookCommerce1.DataAccess.Repository
{
    public class KategoriaRepository:Repository<Kategoria>,IKategoriaRepository
    {
        private readonly Konteksti _konteksti;
        public KategoriaRepository(Konteksti konteksti) : base(konteksti)
        {
            _konteksti = konteksti;
        }

        public void Update(Kategoria kategoria)
        {
            var ent = _konteksti.Kategorite.FirstOrDefault(x => x.Id == kategoria.Id);
            ent.Emri = kategoria.Emri;
            ent.Renditja = kategoria.Renditja;
        }
    }
}
