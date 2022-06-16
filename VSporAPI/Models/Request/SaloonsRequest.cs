using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class SaloonsRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? BussinessId { get; set; }
        public int? SaloonTypeId { get; set; }
        public string? M2 { get; set; }
    }
}
