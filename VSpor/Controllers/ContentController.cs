using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class ContentController : Controller
    {
        private readonly VSporEntities _entity;
        public ContentController(VSporEntities entity)
        {
            _entity = entity;
        }
        public IActionResult ContentTanimlama()
        {

            var tanimlama = new Models.Content();
            tanimlama.List = _entity.Content
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
            var getTanimlama = _entity.Content
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.Content()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return View(tanimlama);
        }
        [HttpPost]
        public IActionResult GuncelleTanim(Models.Content tanimlama)
        {
            var getTanimlama = _entity.Content.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.Name = tanimlama.Name;
            _entity.SaveChanges();
            return RedirectToAction("ContentTanimlama");
        }
        [HttpPost]
        public IActionResult KaydetTanim(Models.Content tanimlama)
        {
            if (tanimlama.Name.IsNotNull())
            {
                _entity.Content.Add(new DataAccessNet.Content()
                {
                    Name = tanimlama.Name
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("ContentTanimlama", tanimlama);
        }
        public IActionResult SilTanim(int Id)
        {
            var silinecekContent = _entity.Content.Find(Id);
            if (silinecekContent == null)
            {
                return NotFound();
            }
            else if (silinecekContent != null)
            {
                _entity.Content.Remove(silinecekContent);

            }
            _entity.SaveChanges();
            return RedirectToAction("ContentTanimlama");




        }
        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Content
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.Content()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Content
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.Content()
            {
                Id = getTanimlama.Id,
               
            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }
    }
}
