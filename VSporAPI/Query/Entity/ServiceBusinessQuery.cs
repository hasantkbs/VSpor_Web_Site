namespace VSporAPI.Query.Entity
{
    public class ServiceBusinessQuery
    {
        public const string GetServiceBusinessSql = @"select * from [dbo].[ServiceBusiness] servicebusiness 
            where 1=1";

        public const string GetServiceBusinessCountSql =
       @"select 
          COUNT(servicebusiness.Id)
          from ServiceBusiness servicebusiness
          WHERE 1=1";
    }
}
