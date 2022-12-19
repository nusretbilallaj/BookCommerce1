using BookCommerce1.DataAccess;
using BookCommerce1.DataAccess.Repository.IRepository;
using BookCommerce1.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce1.Web.Areas.Admin.Controllers
{
    public class MbulesaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MbulesaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Listo()
        {
            List<Mbulesa> lista = _unitOfWork.Mbulesa.ListoTeGjitha().ToList();
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
                _unitOfWork.Mbulesa.Add(mbulesa);
                _unitOfWork.Save();
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

            var kat= _unitOfWork.Mbulesa.FirstOrDefault(x=>x.Id==categoriId);
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
                _unitOfWork.Mbulesa.Update(mbulesa);
                _unitOfWork.Save();
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

            var kat = _unitOfWork.Mbulesa.FirstOrDefault(x=>x.Id== categoriId);
            if (kat == null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost,ActionName("Fshi")]
        public IActionResult FshiPost(int? categoriId)
        {
            var kat = _unitOfWork.Mbulesa.FirstOrDefault(x=>x.Id== categoriId);
            if (kat == null)
            {
                return NotFound();
            }
            _unitOfWork.Mbulesa.Remove(kat);
            _unitOfWork.Save();
            TempData["fshiMeSukes"] = "Eshte fshire me sukses";
            return RedirectToAction("Listo");

        }

    }
}
