using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce1.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookCommerce1.DataAccess
{
    public class Konteksti:IdentityDbContext
    {
        public Konteksti(DbContextOptions<Konteksti> opcionet):base(opcionet)
        {
            
        }

        public DbSet<Kategoria> Kategorite { get; set; }
        public DbSet<Mbulesa> Mbulesat { get; set; }
    }
}
