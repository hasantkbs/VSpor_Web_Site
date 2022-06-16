namespace VSporAPI.Query.Entity
{
    public class BlogCategorysQuery
    {
        public const string GetBlogCategorysSql = @"select * from [dbo].[BlogCategorys] blogcategorys 
            where 1=1";

        public const string GetBlogCategorysCountSql =
       @"select 
          COUNT(blogcategorys.Id)
          from BlogCategorys blogcategorys
          WHERE 1=1";
    }
}
