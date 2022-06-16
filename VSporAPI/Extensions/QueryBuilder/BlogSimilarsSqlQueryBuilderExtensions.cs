using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class BlogSimilarsSqlQueryBuilderExtensions
    {
        public static string GetBlogSimilarsSqlQuery(BlogSimilarsRequest request)
        {
            var stringBuilder = new StringBuilder(BlogSimilarsQuery.GetBlogSimilarsSql);

            var countStringBuilder = new StringBuilder(BlogSimilarsQuery.GetBlogDetailsCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new BlogSimilarsRequest(), key))
                {
                    whereClauses.Add($"blogsimilars.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
                }
            }

            if (whereClauses.Any())
            {
                foreach (var whereClause in whereClauses)
                {
                    stringBuilder.Append($" AND {whereClause}");
                    countStringBuilder.Append($" AND {whereClause}");
                }
            }
            if (request.OrderBy.IsNotNull())
            {
                if (!string.IsNullOrEmpty(request.OrderBy.Name) && request.OrderBy.Name.IsNotDefault())
                {
                    if (GetPropertiesClass.FindProp(new BlogSimilarsRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  blogsimilars.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  blogsimilars.Id DESC, blogdetails.BlogId, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY blogdetails.BlogId ");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY blogdetails.BlogId ");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
