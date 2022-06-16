using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class ServicesController : Controller
    {
        private readonly VSporEntities _entity;
        public ServicesController(VSporEntities entity)
        {
            _entity = entity;
        }
        public IActionResult ServicesTanimlama()
        {

            var tanimlama = new ServicesTanimlama();
            tanimlama.List = _entity.Services
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
            var getTanimlama = _entity.Services
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new ServicesTanimlama()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return View(tanimlama);
        }
        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Services
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new ServicesTanimlama
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Services
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new ServicesTanimlama
            {
                Id = getTanimlama.Id,
               
            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }


        [HttpPost]
        public IActionResult GuncelleTanim(ServicesTanimlama tanimlama)
        {
            var getTanimlama = _entity.Services.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.Name = tanimlama.Name;
            _entity.SaveChanges();
            return RedirectToAction("ServicesTanimlama");
        }

        [HttpPost]
        public IActionResult KaydetTanim(ServicesTanimlama tanimlama)
        {
            if (tanimlama.Name.IsNotNull())
            {
                _entity.Services.Add(new Services()
                {
                    Name = tanimlama.Name
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("ServicesTanimlama", tanimlama);
        }

        public IActionResult SilTanim(int Id)
        {
            var silinecekServis = _entity.Services.Find(Id);
            if (silinecekServis == null)
            {
                return NotFound();
            }
            else if (silinecekServis != null)
            {
                _entity.Services.Remove(silinecekServis);

            }
            _entity.SaveChanges();
            return RedirectToAction("ServicesTanimlama");




        }
    }
}
