using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class WorkerRolesRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? WorkerId { get; set; }
        public int? TypeId { get; set; }
    }
}
