namespace VSporAPI.Query.Entity
{
    public class WorkersQuery
    {
        public const string GetWorkersSql = @"select * from [dbo].[Workers] workers 
            where 1=1";

        public const string GetWorkersCountSql =
       @"select 
          COUNT(workers.Id)
          from Workers workers
          WHERE 1=1";
    }
}
