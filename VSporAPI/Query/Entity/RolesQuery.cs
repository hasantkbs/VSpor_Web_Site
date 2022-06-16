namespace VSporAPI.Query.Entity
{
    public class RolesQuery
    {
        public const string GetRolesSql = @"select * from [dbo].[Roles] roles 
            where 1=1";

        public const string GetRolesCountSql =
       @"select 
          COUNT(roles.Id)
          from Roles roles
          WHERE 1=1";
    }
}
