namespace VSporAPI.Query.Entity
{
    public class MemberRolesQuery
    {
        public const string GetMemberRolesSql = @"select * from [dbo].[MemberRoles] memberroles 
            where 1=1";

        public const string GetMemberRolesCountSql =
       @"select 
          COUNT(memberroles.Id)
          from MemberRoles memberroles
          WHERE 1=1";
    }
}
