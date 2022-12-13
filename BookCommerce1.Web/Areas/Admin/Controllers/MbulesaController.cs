using BookCommerce1.DataAccess;
using BookCommerce1.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce1.Web.Areas.Admin.Controllers
{
    public class MbulesaController : Controller
    {
        private Konteksti _konteksti;
        public MbulesaController(Konteksti konteksti)
        {
            _konteksti = konteksti;
        }
        public IActionResult Listo()
        {
            List<Mbulesa> lista = _konteksti.Mbulesat.ToList();
            return View(lista);
        }

        public IActionResult Krijo()
        {
            Mbulesa kat = new Mbulesa();
            return View(kat);
        }
        [HttpPost]
        public IActionResult Krijo(Mbulesa mbulesa)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Mbulesat.Add(mbulesa);
                _konteksti.SaveChanges();
                TempData["suksesi"] = "U shtua me sukses";
                return RedirectToAction("Listo");
            }

            return View(mbulesa);
        }
        public IActionResult Ndrysho(int? categoriId)
        {
            if (categoriId==null || categoriId==0)
            {
                return NotFound();
            }

            var kat= _konteksti.Mbulesat.Find(categoriId);
            if (kat==null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost]
        public IActionResult Ndrysho(Mbulesa mbulesa)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Mbulesat.Update(mbulesa);
                _konteksti.SaveChanges();
                TempData["suksesi"] = "U ndryshua me sukses";
                return RedirectToAction("Listo");
            }

            return View(mbulesa);
        }

        public IActionResult Fshi(int? categoriId)
        {
            if (categoriId == null || categoriId == 0)
            {
                return NotFound();
            }

            var kat = _konteksti.Mbulesat.Find(categoriId);
            if (kat == null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost,ActionName("Fshi")]
        public IActionResult FshiPost(int? categoriId)
        {
            var kat = _konteksti.Mbulesat.Find(categoriId);
            if (kat == null)
            {
                return NotFound();
            }
            _konteksti.Mbulesat.Remove(kat);
            _konteksti.SaveChanges();
            TempData["fshiMeSukes"] = "Eshte fshire me sukses";
            return RedirectToAction("Listo");

        }

    }
}
