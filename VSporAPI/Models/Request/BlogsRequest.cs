using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class BlogsRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? BlogCategoryId { get; set; }
        public string? Title { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
