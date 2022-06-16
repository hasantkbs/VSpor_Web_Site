namespace VSporAPI.Query.Entity
{
    public class ImagesQuery
    {
        public const string GetImagesSql = @"select * from [dbo].[Images] images 
            where 1=1";

        public const string GetImagesCountSql =
       @"select 
          COUNT(images.Id)
          from Images images
          WHERE 1=1";
    }
}
