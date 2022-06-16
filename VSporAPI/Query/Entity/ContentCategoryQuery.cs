namespace VSporAPI.Query.Entity
{
    public class ContentCategoryQuery
    {
        public const string GetContentCategorySql = @"select * from [dbo].[ContentCategory] contentcategory 
            where 1=1";

        public const string GetContentCategoryCountSql =
       @"select 
          COUNT(contentcategory.Id)
          from ContentCategory contentcategory
          WHERE 1=1";
    }
}
