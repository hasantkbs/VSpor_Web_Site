using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class SaloonTypesController : Controller
    {
        private readonly VSporEntities _entity;
        public SaloonTypesController(VSporEntities entity)
        {
            _entity = entity;
        }
        public IActionResult SaloonTypesTanimlama()
        {

            var tanimlama = new Models.SaloonTypes();
            tanimlama.List = _entity.SaloonTypes
                            .Select(a => new TanimlamaList()
                            {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList();

            return View(tanimlama);
        }
        [HttpGet]
        public IActionResult GuncelleTanim(int Id)
        {
            var getTanimlama = _entity.SaloonTypes
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.SaloonTypes()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return View(tanimlama);
        }
        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.SaloonTypes
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.SaloonTypes()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.SaloonTypes
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.SaloonTypes()
            {
                Id = getTanimlama.Id,
            
            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }
        [HttpPost]
        public IActionResult GuncelleTanim(Models.SaloonTypes tanimlama)
        {
            var getTanimlama = _entity.SaloonTypes.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.Name = tanimlama.Name;
            _entity.SaveChanges();
            return RedirectToAction("SaloonTypesTanimlama");
        }
        [HttpPost]
        public IActionResult KaydetTanim(Models.SaloonTypes tanimlama)
        {
            if (tanimlama.Name.IsNotNull())
            {
                _entity.SaloonTypes.Add(new DataAccessNet.SaloonTypes()
                {
                    Name = tanimlama.Name
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("SaloonTypesTanimlama", tanimlama);
        }

        public IActionResult SilTanim(int Id)
        {
            var silinecekSaloonTypes = _entity.SaloonTypes.Find(Id);
            if (silinecekSaloonTypes == null)
            {
                return NotFound();
            }
            else if (silinecekSaloonTypes != null)
            {
                _entity.SaloonTypes.Remove(silinecekSaloonTypes);

            }
            _entity.SaveChanges();
            return RedirectToAction("SaloonTypesTanimlama");




        }
    }
}
