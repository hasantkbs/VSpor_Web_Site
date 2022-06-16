using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class BlogCategorysRequest:SearchDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

    }
}
