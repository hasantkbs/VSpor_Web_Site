using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class WorkersController : Controller
    {
        private readonly VSporEntities _entity;
        public WorkersController(VSporEntities entity)
        {
            _entity = entity;
        }

        public IActionResult WorkersTanimlama()
        {

            var tanimlama = new WorkersTanimlama();
            tanimlama.List = _entity.Workers
                            .Select(a => new WorkersTanimlamaList()
                            {
                                Id = a.Id,
                                TCNo = a.TCNo,
                                PassportNo = a.PassportNo,
                                BirthDate = a.BirthDate,
                                Cv = a.Cv,
                                BusinessId = a.BusinessId,
                                OpenAddress = a.OpenAddress,
                                
                            }).ToList();

            return View(tanimlama);
        }

        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Workers
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new WorkersTanimlama()
            {
                Id = getTanimlama.Id,
                TCNo = getTanimlama.TCNo,
                PassportNo = getTanimlama.PassportNo,
                BirthDate = getTanimlama.BirthDate,
                Cv = getTanimlama.Cv,
                BusinessId = getTanimlama.BusinessId,
                OpenAddress = getTanimlama.OpenAddress,
               

            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Workers
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new WorkersTanimlama()
            {
                Id = getTanimlama.Id,
               
               

            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }

        [HttpPost]
        public IActionResult GuncelleTanim(WorkersTanimlama tanimlama)
        {
            var getTanimlama = _entity.Workers.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.TCNo = tanimlama.TCNo;
            getTanimlama.PassportNo = tanimlama.PassportNo;
            getTanimlama.BirthDate = tanimlama.BirthDate;
            getTanimlama.Cv = tanimlama.Cv;
            getTanimlama.BusinessId = tanimlama.BusinessId;
            getTanimlama.OpenAddress = tanimlama.OpenAddress;
          

            _entity.SaveChanges();
            return RedirectToAction("WorkersTanimlama");
        }

        [HttpPost]
        public IActionResult KaydetTanim(WorkersTanimlama tanimlama)
        {
            if ((tanimlama.TCNo.IsNotDefault() || tanimlama.PassportNo.IsNotDefault()))
            {
                _entity.Workers.Add(new Workers()
                {
                    TCNo = tanimlama.TCNo,
                    PassportNo = tanimlama.PassportNo,
                    BirthDate = tanimlama.BirthDate,
                    Cv = tanimlama.Cv,
                    BusinessId = tanimlama.BusinessId,
                    OpenAddress = tanimlama.OpenAddress,
                    
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("WorkersTanimlama", tanimlama);
        }

        public IActionResult SilTanim(int Id)
        {
            var silinecekWorkers = _entity.Workers.Find(Id);
            if (silinecekWorkers == null)
            {
                return NotFound();
            }
            else if (silinecekWorkers != null)
            {
                _entity.Workers.Remove(silinecekWorkers);

            }
            _entity.SaveChanges();
            return RedirectToAction("WorkersTanimlama");

        }

    }
}
