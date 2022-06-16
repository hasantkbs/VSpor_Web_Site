namespace VSporAPI.Query.Entity
{
    public class SaloonsQuery
    {
        public const string GetSaloonsSql = @"select * from [dbo].[Saloons] saloons 
            where 1=1";

        public const string GetSaloonsCountSql =
       @"select 
          COUNT(saloons.Id)
          from Saloons saloons
          WHERE 1=1";
    }
}
