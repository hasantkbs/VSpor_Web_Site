using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class BusinessRequest : SearchDto
    {
        public int? Id { get; set; }
        public string? BusinessName { get; set; }
        public int? LocationId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
    }
}
