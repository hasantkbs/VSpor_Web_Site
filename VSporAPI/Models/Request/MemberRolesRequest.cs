using VSporCore.Toolkit.Search;

namespace VSporAPI.Models.Request
{
    public class MemberRolesRequest:SearchDto
    {
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public int? MemberId { get; set; }
    }
}
