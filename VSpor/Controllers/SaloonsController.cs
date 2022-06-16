using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class SaloonsController : Controller
    {
        private readonly VSporEntities _entity;
        public SaloonsController(VSporEntities entity)
        {
            _entity = entity;
        }
        public IActionResult SaloonsTanimlama()
        {

            var tanimlama = new SaloonsTanimlama();
            tanimlama.List = _entity.Saloons
                            .Select(a => new SaloonTanimlama()
                            {
                                Id = a.Id,
                                BussinessId = a.BussinessId,
                                SaloonTypeId = a.SaloonTypeId,
                                M2 = a.M2,
                             
                            }).ToList();

            return View(tanimlama);
        }
        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Saloons
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new SaloonsTanimlama()
            {
                Id = getTanimlama.Id,
                BussinessId = getTanimlama.BussinessId,
                SaloonTypeId = getTanimlama.SaloonTypeId,
                M2 = getTanimlama.M2

            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Saloons
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new SaloonsTanimlama()
            {
                Id = getTanimlama.Id,
                

            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }


        [HttpPost]
        public IActionResult GuncelleTanim(SaloonsTanimlama tanimlama)
        {
            var getTanimlama = _entity.Saloons.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.BussinessId = tanimlama.BussinessId;
            getTanimlama.SaloonTypeId = (short)tanimlama.SaloonTypeId;
            getTanimlama.M2 = tanimlama.M2;
            
            _entity.SaveChanges();
            return RedirectToAction("SaloonsTanimlama");
        }
        [HttpPost]
        public IActionResult KaydetTanim(SaloonsTanimlama tanimlama)
        {
            if (tanimlama.BussinessId.IsNotDefault() || tanimlama.SaloonTypeId.IsNotDefault())
            {
                _entity.Saloons.Add(new Saloons()
                {
                    BussinessId = tanimlama.BussinessId,
                    SaloonTypeId = (short)tanimlama.SaloonTypeId,
                    M2 = tanimlama.M2,
                    

                });
                _entity.SaveChanges();
            }
            return RedirectToAction("SaloonsTanimlama", tanimlama);
        }
        public IActionResult SilTanim(int Id)
        {
            var silinecekSaloons = _entity.Saloons.Find(Id);
            if (silinecekSaloons == null)
            {
                return NotFound();
            }
            else if (silinecekSaloons != null)
            {
                _entity.Saloons.Remove(silinecekSaloons);

            }
            _entity.SaveChanges();
            return RedirectToAction("SaloonsTanimlama");

        }
    }
}
