using Microsoft.AspNetCore.Mvc;
using DataAccessNet;
using VSporMVC.Models;
using VSporCore.Extensions;
using System.Data;

namespace VSporMVC.Controllers
{
    public class BlogCategoryController : Controller
    {
        private readonly VSporEntities _entity;
        public BlogCategoryController(VSporEntities entity)
        {
            _entity=entity;
        }
        public IActionResult BlogTanimlama()
        {
            
            var tanimlama = new BlogCategorysTanimlama();
            tanimlama.List = _entity.BlogCategorys
                            .Select(a => new TanimlamaList()
                            {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList();

            return View(tanimlama);
        }
        [HttpGet]
        public IActionResult GuncelleTanimPartialView(int Id)
        {
            var getTanimlama = _entity.BlogCategorys
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.BlogCategorysTanimlama()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return PartialView("_GuncelleTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult SilTanimPartialView(int Id)
        {
            var getTanimlama = _entity.BlogCategorys
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new Models.BlogCategorysTanimlama()
            {
                Id = getTanimlama.Id,
              
            };
            return PartialView("_SilTanimPartialView", tanimlama);
        }
        [HttpGet]
        public IActionResult GuncelleTanim(int Id)
        {
            var getTanimlama = _entity.BlogCategorys
                .FirstOrDefault(a => a.Id == Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            var tanimlama = new BlogCategorysTanimlama()
            {
                Id = getTanimlama.Id,
                Name = getTanimlama.Name
            };
            return View(tanimlama);
        }


        [HttpPost]
        public IActionResult GuncelleTanim(BlogCategorysTanimlama tanimlama)
        {
            var getTanimlama = _entity.BlogCategorys.FirstOrDefault(a => a.Id == tanimlama.Id);
            if (getTanimlama == null)
            {
                return NotFound();
            }
            
            getTanimlama.Name = tanimlama.Name;
            _entity.SaveChanges();
            return RedirectToAction("BlogTanimlama");
        }

        [HttpPost]
        public IActionResult KaydetTanim(BlogCategorysTanimlama tanimlama)
        {
            if (tanimlama.Name.IsNotNull())
            {
                _entity.BlogCategorys.Add(new BlogCategorys()
                {
                    Name = tanimlama.Name
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("BlogTanimlama", tanimlama);
        }

        public IActionResult SilTanim(int Id)
        {
            var silinecekBlog = _entity.BlogCategorys.Find(Id); 
            if (silinecekBlog == null)
            {
                return NotFound();
            }
            else if (silinecekBlog != null)
            {
                _entity.BlogCategorys.Remove(silinecekBlog);
                
            }
            _entity.SaveChanges();
            return RedirectToAction("BlogTanimlama");
            
            

           
        }
    }
}
