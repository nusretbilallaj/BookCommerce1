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
            Kategoria kat = new Kategoria();
            return View(kat);
        }
        [HttpPost]
        public IActionResult Krijo(Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Add(kategoria);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }

            return View(kategoria);
        }
        public IActionResult Ndrysho(int? id)
        {
            Kategoria kat = new Kategoria();
            return View(kat);
        }
        [HttpPost]
        public IActionResult Ndrysho(Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Add(kategoria);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }

            return View(kategoria);
        }
    }
}
