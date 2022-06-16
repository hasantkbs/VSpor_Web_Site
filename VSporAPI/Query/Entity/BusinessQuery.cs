namespace VSporAPI.Query.Entity
{
    public class BusinessQuery
    {
        public const string GetBussinessSql = @"select * from [dbo].[Business] business 
            where 1=1";

        public const string GetBussinessCountSql =
       @"select 
          COUNT(business.Id)
          from Business business
          WHERE 1=1";
    }
}
