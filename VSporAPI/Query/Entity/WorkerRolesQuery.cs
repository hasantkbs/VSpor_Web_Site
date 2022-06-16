namespace VSporAPI.Query.Entity
{
    public class WorkerRolesQuery
    {
        public const string GetWorkerRolesSql = @"select * from [dbo].[WorkerRoles] workerroles 
            where 1=1";

        public const string GetWorkerRolesCountSql =
       @"select 
          COUNT(workerroles.Id)
          from WorkerRoles workerroles
          WHERE 1=1";
    }
}
