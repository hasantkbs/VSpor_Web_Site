namespace VSporAPI.Query.Entity
{
    public class RouteModelsQuery
    {
        public const string GetRouteModelsSql = @"select * from [dbo].[RouteModels] routemodels 
            where 1=1";

        public const string GetRouteModelsCountSql =
       @"select 
          COUNT(routemodels.Id)
          from RouteModels routemodels
          WHERE 1=1";
    }
}
