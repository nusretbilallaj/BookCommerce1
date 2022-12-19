using BookCommerce1.DataAccess;
using BookCommerce1.DataAccess.Repository.IRepository;
using BookCommerce1.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce1.Web.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KategoriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Listo()
        {
            List<Kategoria> lista = _unitOfWork.Kategoria.ListoTeGjitha().ToList();
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
                _unitOfWork.Kategoria.Add(kategoria);
                _unitOfWork.Save();
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

            var kat= _unitOfWork.Kategoria.FirstOrDefault(x=>x.Id== categoriId);
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
                _unitOfWork.Kategoria.Update(kategoria);
                _unitOfWork.Save();
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

            var kat = _unitOfWork.Kategoria.FirstOrDefault(x=>x.Id== categoriId);
            if (kat == null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost,ActionName("Fshi")]
        public IActionResult FshiPost(int? categoriId)
        {
            var kat = _unitOfWork.Kategoria.FirstOrDefault(x=>x.Id== categoriId);
            if (kat == null)
            {
                return NotFound();
            }
            _unitOfWork.Kategoria.Remove(kat);
            _unitOfWork.Save();
            TempData["fshiMeSukes"] = "Eshte fshire me sukses";
            return RedirectToAction("Listo");

        }

    }
}
