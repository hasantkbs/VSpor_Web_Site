namespace VSporAPI.Query.Entity
{
    public class ServicesQuery
    {
        public const string GetServicesSql = @"select * from [dbo].[Services] services 
            where 1=1";

        public const string GetServicesCountSql =
       @"select 
          COUNT(services.Id)
          from Services services
          WHERE 1=1";
    }
}
