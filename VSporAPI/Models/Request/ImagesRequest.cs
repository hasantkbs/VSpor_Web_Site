using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class ImagesRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? RefenceTypeId { get; set; }
        public int? RefenceId { get; set; }
        public string? Path { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public int? IsDefault { get; set; }
    }
}
