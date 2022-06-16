namespace VSporAPI.Query.Entity
{
    public class ContentQuery
    {
        public const string GetContentTypeSql = @"select * from [dbo].[Content] content 
            where 1=1";

        public const string GetContentCountSql =
       @"select 
          COUNT(content.Id)
          from Content content
          WHERE 1=1";
    }
}
