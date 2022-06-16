using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class ContentCategoryRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? BusinessId { get; set; }
        public int? SaloonId { get; set; }
        public int? ContentId { get; set; }
    }
}
