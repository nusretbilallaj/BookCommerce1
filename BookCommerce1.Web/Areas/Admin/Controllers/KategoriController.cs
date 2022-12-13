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
                TempData["suksesi"] = "U shtua me sukses";
                return RedirectToAction("Listo");
            }

            return View(kategoria);
        }
        public IActionResult Ndrysho(int? categoriId)
        {
            if (categoriId==null || categoriId==0)
            {
                return NotFound();
            }

            var kat= _konteksti.Kategorite.Find(categoriId);
            if (kat==null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost]
        public IActionResult Ndrysho(Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Update(kategoria);
                _konteksti.SaveChanges();
                TempData["suksesi"] = "U ndryshua me sukses";
                return RedirectToAction("Listo");
            }

            return View(kategoria);
        }

        public IActionResult Fshi(int? categoriId)
        {
            if (categoriId == null || categoriId == 0)
            {
                return NotFound();
            }

            var kat = _konteksti.Kategorite.Find(categoriId);
            if (kat == null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost,ActionName("Fshi")]
        public IActionResult FshiPost(int? categoriId)
        {
            var kat = _konteksti.Kategorite.Find(categoriId);
            if (kat == null)
            {
                return NotFound();
            }
            _konteksti.Kategorite.Remove(kat);
            _konteksti.SaveChanges();
            TempData["fshiMeSukes"] = "Eshte fshire me sukses";
            return RedirectToAction("Listo");

        }

    }
}
