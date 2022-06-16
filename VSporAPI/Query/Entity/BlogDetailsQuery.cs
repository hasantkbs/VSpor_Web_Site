namespace VSporAPI.Query.Entity
{
    public class BlogDetailsQuery
    {
        public const string GetBlogDetailsSql = @"select * from [dbo].[BlogDetails] blogdetails 
            where 1=1";

        public const string GetBlogDetailsCountSql =
       @"select 
          COUNT(blogdetails.Id)
          from BlogDetails blogdetails
          WHERE 1=1";
    }
}
