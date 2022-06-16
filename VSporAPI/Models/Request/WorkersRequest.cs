using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class WorkersRequest:SearchDto
    {
        public int? Id { get; set; }
        public string? TCNo { get; set; }
        public string? PassportNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Cv { get; set; }
        public int? BusinessId { get; set; }
        public string? OpenAddress { get; set; }
    }
}
