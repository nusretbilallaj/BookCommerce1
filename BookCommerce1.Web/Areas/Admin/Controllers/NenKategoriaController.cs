using BookCommerce1.DataAccess;
using BookCommerce1.DataAccess.Repository.IRepository;
using BookCommerce1.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce1.Web.Areas.Admin.Controllers
{
    public class NenKategoriaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NenKategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Listo()
        {
            List<NenKategoria> lista = _unitOfWork.NenKategoria.ListoTeGjitha().ToList();
            return View(lista);
        }

        public IActionResult Krijo()
        {
            NenKategoria kat = new NenKategoria();
            return View(kat);
        }
        [HttpPost]
        public IActionResult Krijo(NenKategoria nenKategoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.NenKategoria.Add(nenKategoria);
                _unitOfWork.Save();
                TempData["suksesi"] = "U shtua me sukses";
                return RedirectToAction("Listo");
            }

            return View(nenKategoria);
        }
        public IActionResult Ndrysho(int? categoriId)
        {
            if (categoriId==null || categoriId==0)
            {
                return NotFound();
            }

            var kat= _unitOfWork.NenKategoria.FirstOrDefault(x=>x.Id== categoriId);
            if (kat==null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost]
        public IActionResult Ndrysho(NenKategoria nenKategoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.NenKategoria.Update(nenKategoria);
                _unitOfWork.Save();
                TempData["suksesi"] = "U ndryshua me sukses";
                return RedirectToAction("Listo");
            }

            return View(nenKategoria);
        }

        public IActionResult Fshi(int? categoriId)
        {
            if (categoriId == null || categoriId == 0)
            {
                return NotFound();
            }

            var kat = _unitOfWork.NenKategoria.FirstOrDefault(x=>x.Id== categoriId);
            if (kat == null)
            {
                return NotFound();
            }

            return View(kat);
        }
        [HttpPost,ActionName("Fshi")]
        public IActionResult FshiPost(int? categoriId)
        {
            var kat = _unitOfWork.NenKategoria.FirstOrDefault(x=>x.Id== categoriId);
            if (kat == null)
            {
                return NotFound();
            }
            _unitOfWork.NenKategoria.Remove(kat);
            _unitOfWork.Save();
            TempData["fshiMeSukes"] = "Eshte fshire me sukses";
            return RedirectToAction("Listo");

        }

    }
}
