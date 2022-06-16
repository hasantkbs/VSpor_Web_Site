using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class WorkerTypesController : Controller
    {
        private readonly VSporEntities _entity;
        public WorkerTypesController(VSporEntities entity)
        {
            _entity = entity;
        }
        public IActionResult WorkerTypesTanimlama()
        {

            var tanimlama = new WorkerTypesTanimlama();
            tanimlama.List = _entity.WorkerType
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
            var tanimlama = new WorkerTypesTanimlama()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return View(tanimlama);
        }


        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.WorkerType
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new WorkerTypesTanimlama()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.WorkerType
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new WorkerTypesTanimlama()
            {
                Id = getTanimlama.Id,
             
            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }

        [HttpPost]
        public IActionResult GuncelleTanim(WorkerTypesTanimlama tanimlama)
        {
            var getTanimlama = _entity.WorkerType.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.Name = tanimlama.Name;
            _entity.SaveChanges();
            return RedirectToAction("WorkerTypesTanimlama");
        }

        [HttpPost]
        public IActionResult KaydetTanim(WorkerTypesTanimlama tanimlama)
        {
            if (tanimlama.Name.IsNotNull())
            {
                _entity.WorkerType.Add(new WorkerType()
                {
                    Name = tanimlama.Name
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("WorkerTypesTanimlama", tanimlama);
        }

        public IActionResult SilTanim(int Id)
        {
            var silinecekWorkerType = _entity.WorkerType.Find(Id);
            if (silinecekWorkerType == null)
            {
                return NotFound();
            }
            else if (silinecekWorkerType != null)
            {
                _entity.WorkerType.Remove(silinecekWorkerType);

            }
            _entity.SaveChanges();
            return RedirectToAction("WorkerTypesTanimlama");

        }
       
      
    }
  
}
