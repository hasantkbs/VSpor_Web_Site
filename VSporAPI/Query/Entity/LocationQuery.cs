namespace VSporAPI.Query.Entity
{
    public class LocationQuery
    {
        public const string GetLocationSql = @"select * from [dbo].[Location] location 
            where 1=1";


        public const string GetLocationCountSql =
           @"select 
          COUNT(Location.Id)
          from Location Location
          WHERE 1=1";
    }
}
