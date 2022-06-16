namespace VSporAPI.Query.Entity
{
    public class SaloonTypesQuery
    {
     
            public const string GetSaloonTypesSql = @"select * from [dbo].[SaloonTypes] saloontypes 
            where 1=1";

            public const string GetSaloonTypesCountSql =
           @"select 
          COUNT(saloontypes.Id)
          from SaloonTypes saloontypes
          WHERE 1=1";
        
    }
}
