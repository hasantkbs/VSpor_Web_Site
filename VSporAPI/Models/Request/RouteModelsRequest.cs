using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class RouteModelsRequest:SearchDto
    {
        public int? Id { get; set; }
        public string? Url { get; set; }
        public string? PageType { get; set; }
        public string? RId { get; set; }
        public string? RefId { get; set; }
    }
}
