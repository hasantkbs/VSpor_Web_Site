using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class BlogSimilarsRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? BlogId { get; set; }
        public int? SimilarBlogId { get; set; }
    }
}
