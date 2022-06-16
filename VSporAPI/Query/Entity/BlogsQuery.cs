namespace VSporAPI.Query.Entity
{
    public class BlogsQuery
    {
        public const string GetBlogsSql = @"select * from [dbo].[Blogs] blogs 
            where 1=1";

        public const string GetBlogsCountSql =
       @"select 
          COUNT(blogs.Id)
          from Blogs blogs
          WHERE 1=1";
    }
}
