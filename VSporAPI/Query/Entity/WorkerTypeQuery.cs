namespace VSporAPI.Query.Entity
{
    public class WorkerTypeQuery
    {
        public const string GetWorkerTypeSql = @"select * from [dbo].[WorkerType] workertype 
            where 1=1";

        public const string GetWorkerTypeCountSql =
       @"select 
          COUNT(workertype.Id)
          from WorkerType workertype
          WHERE 1=1";
    }
}
