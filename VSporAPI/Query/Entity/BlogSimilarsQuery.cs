namespace VSporAPI.Query.Entity
{
    public class BlogSimilarsQuery
    {
        public const string GetBlogSimilarsSql = @"select * from [dbo].[BlogSimilars] blogsimilars 
            where 1=1";

        public const string GetBlogDetailsCountSql =
       @"select 
          COUNT(blogsimilars.Id)
          from BlogSimilars blogsimilars
          WHERE 1=1";
    }
}
