using Microsoft.AspNetCore.Mvc;
using DataAccessNet;
using VSporMVC.Models;
using VSporCore.Extensions;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSporMVC.Controllers
{
    public class BlogDTOController : Controller
    {
        private readonly VSporEntities _entity;
        public BlogDTOController(VSporEntities entity)
        {
            _entity = entity;
        }

        public IActionResult BlogDTOTanimlama()
        {
            BlogSimilarDetailsDTO model = new BlogSimilarDetailsDTO();
            model.Bloglar = _entity.Blogs.ToList();
            model.BlogSimilars = _entity.BlogSimilars.ToList();
            model.BlogDetailss = _entity.BlogDetails.ToList();
            model.BlogCategorysTanimlamas = _entity.BlogCategorys.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult KaydetTanim(BlogDTOTanimlama tanimlama)
        {
            if (tanimlama.BlogCategoryId.IsNotDefault())
            {
                _entity.Blogs.Add(new Blogs()
                {
                    BlogCategoryId = tanimlama.BlogCategoryId,
                    Title = tanimlama.Title,
                    AddDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                });
                _entity.SaveChanges();
            }
            if (tanimlama.BlogId.IsNotDefault())
            {
                _entity.BlogDetails.Add(new DataAccessNet.BlogDetails()
                {
                    BlogId = tanimlama.BlogId,
                    Content = tanimlama.Content,
                    SummartContent = tanimlama.SummartContent
                });
                _entity.SaveChanges();
            }
            if (tanimlama.BlogId.IsNotDefault() && tanimlama.SimilarBlogId.IsNotDefault())
            {
                _entity.BlogSimilars.Add(new DataAccessNet.BlogSimilars()
                {
                    BlogId = tanimlama.BlogId,
                    SimilarBlogId = tanimlama.SimilarBlogId
                });
                _entity.SaveChanges();
            }
            return RedirectToAction("BlogDTOTanimlama", tanimlama);
        }


        [HttpGet]
        public IActionResult BlogGuncelleTanimPartialView(int Id)
        {
            var blogsss = new BlogSimilarDetailsDTO();

            var getblogcategory= _entity.BlogCategorys
                .FirstOrDefault(c => c.Id == Id);

            var getTanimlama = _entity.Blogs
                .FirstOrDefault(a => a.Id == Id);

            var getTanimlama2 = _entity.BlogDetails
                .FirstOrDefault(a => a.Id == Id);

            var getTanimlama3 = _entity.BlogSimilars
                .FirstOrDefault(a => a.Id == Id);

            blogsss.Id = getblogcategory.Id;
            blogsss.AddDate = getTanimlama.AddDate;
            blogsss.UpdateDate = getTanimlama.UpdateDate;
            blogsss.Title = getTanimlama.Title;
            blogsss.Content = getTanimlama2.Content;
            blogsss.SummartContent = getTanimlama2.SummartContent;
            blogsss.BlogCategoryId = getTanimlama.BlogCategoryId;
            blogsss.BlogId = getTanimlama2.BlogId;
            //blogsss.MemberId = (int)getTanimlama2.MemberId;
            //blogsss.SimilarBlogId = getTanimlama3.SimilarBlogId;


            return PartialView("_BlogGuncelleTanimPartialView", blogsss);
        }

        [HttpPost]
        public IActionResult GuncelleTanim(BlogSimilarDetailsDTO tanimlama)
        {
            var getTanimlama = _entity.Blogs.FirstOrDefault(a => a.Id == tanimlama.BlogId);
            var getTanimlama2 = _entity.BlogSimilars.FirstOrDefault(a => a.Id == tanimlama.BlogId);
            var getTanimlama3 = _entity.BlogDetails.FirstOrDefault(a => a.Id == tanimlama.BlogId);

            if (getTanimlama == null)
            {
                return NotFound();
            }

            getTanimlama.Title = tanimlama.Title;
            getTanimlama.UpdateDate = tanimlama.UpdateDate;
            getTanimlama.BlogCategoryId = getTanimlama.BlogCategoryId;
            getTanimlama2.SimilarBlogId = getTanimlama2.SimilarBlogId;
            getTanimlama2.BlogId = getTanimlama2.BlogId;
            getTanimlama3.MemberId = getTanimlama3.MemberId;
            getTanimlama3.SummartContent = getTanimlama3.SummartContent;
            getTanimlama3.Content = getTanimlama3.Content;

            _entity.SaveChanges();
            return RedirectToAction("BlogDTOTanimlama");
        }

        public IActionResult SilTanim(int Id)
        {
            var silinecekblogs = _entity.Blogs.Find(Id);
            var silinecekblogdetails = _entity.BlogDetails.Find(Id);
            var silinecekblogsimilar = _entity.BlogSimilars.Find(Id);
            if (silinecekblogs == null && silinecekblogdetails == null && silinecekblogsimilar == null)
            {
                return NotFound();
            }
            else if (silinecekblogs != null && silinecekblogdetails != null && silinecekblogsimilar != null)
            {
                _entity.Blogs.Remove(silinecekblogs);
                _entity.BlogDetails.Remove(silinecekblogdetails);
                _entity.BlogSimilars.Remove(silinecekblogsimilar);

            }
            _entity.SaveChanges();
            return RedirectToAction("BlogDTOTanimlama");

        }



    }
}
