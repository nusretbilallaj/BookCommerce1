using BookCommerce1.DataAccess;
using BookCommerce1.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce1.Web.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        private Konteksti _konteksti;
        public KategoriController(Konteksti konteksti)
        {
            _konteksti = konteksti;
        }
        public IActionResult Listo()
        {
            List<Kategoria> lista = _konteksti.Kategorite.ToList();
            return View(lista);
        }

        public IActionResult Krijo()
        {
            return View();
        }
    }
}
