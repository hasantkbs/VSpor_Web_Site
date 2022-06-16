using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class BlogDetailsRequest: SearchDto
    {
        public int? Id { get; set; }
        public int? BlogId { get; set; }
        public string? SummartContent { get; set; }
        public string? Content { get; set; }
        public int? MemberId { get; set; }
    }
}
