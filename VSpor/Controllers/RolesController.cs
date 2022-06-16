using DataAccessNet;
using Microsoft.AspNetCore.Mvc;
using VSporCore.Extensions;
using VSporMVC.Models;

namespace VSporMVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly VSporEntities _entity;
        public RolesController(VSporEntities entity)
        {
            _entity = entity;
        }
        public IActionResult RolesTanimlama()
        {

            var tanimlama = new Models.Roles();
            tanimlama.List = _entity.Roles
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
            var getTanimlama = _entity.Roles
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.Roles()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return View(tanimlama);
        }
        [HttpPost]
        public IActionResult GuncelleTanim(Models.Roles tanimlama)
        {
            var getTanimlama = _entity.Roles.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.Name = tanimlama.Name;
            _entity.SaveChanges();
            return RedirectToAction("RolesTanimlama");
        }
        [HttpPost]
        public IActionResult KaydetTanim(Models.Roles tanimlama)
        {
            if (tanimlama.Name.IsNotNull())
            {
                _entity.Roles.Add(new DataAccessNet.Roles()
                {
                    Name = tanimlama.Name
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("RolesTanimlama", tanimlama);
        }
        public IActionResult SilTanim(int Id)
        {
            var silinecekRoles = _entity.Roles.Find(Id);
            if (silinecekRoles == null)
            {
                return NotFound();
            }
            else if (silinecekRoles != null)
            {
                _entity.Roles.Remove(silinecekRoles);

            }
            _entity.SaveChanges();
            return RedirectToAction("RolesTanimlama");




        }




        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Roles
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.Roles()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.Roles
               .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.Roles()
            {
                Id = getTanimlama.Id,
             
            };
            return PartialView("_SilTanimPartialView", tanimlama);

        }


    }
}
