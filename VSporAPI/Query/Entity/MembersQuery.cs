namespace VSporAPI.Query.Entity
{
    public class MembersQuery
    {
        public const string GetMembersSql = @"select * from [dbo].[Members] members 
            where 1=1";

        public const string GetMembersCountSql =
       @"select 
          COUNT(members.Id)
          from Members members
          WHERE 1=1";
    }
}
