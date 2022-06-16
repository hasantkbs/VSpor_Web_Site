using DataAccessNet;
namespace VSporMVC.Models
{
    public class BlogSimilarDetailsDTO: BlogDTOTanimlama
    {
        public List<Blogs> Bloglar { get; set; }
        public List<DataAccessNet.BlogDetails> BlogDetailss { get; set; }
        public List<BlogSimilars> BlogSimilars { get; set; }
        public List<BlogCategorys> BlogCategorysTanimlamas { get; set; }
    }

    public class BlogDTOTanimlama
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int SimilarBlogId { get; set; }
        public int BlogCategoryId { get; set; }
        public string Title { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string SummartContent { get; set; }
        public string Content { get; set; }
        public int MemberId { get; set; }
    }


}
