using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class ServicesBusinessRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? BusinessId { get; set; }
        public int? ServiceId { get; set; }
    }
}
