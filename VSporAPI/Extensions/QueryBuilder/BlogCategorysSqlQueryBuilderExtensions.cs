using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class BlogCategorysSqlQueryBuilderExtensions
    {
        public static string GetBlogCategorysSqlQuery(BlogCategorysRequest request)
        {
            var stringBuilder = new StringBuilder(BlogCategorysQuery.GetBlogCategorysSql);

            var countStringBuilder = new StringBuilder(BlogCategorysQuery.GetBlogCategorysCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new BlogCategorysRequest(), key))
                {
                    whereClauses.Add($"blogcategorys.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new BlogCategorysQuery(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  location.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  blogcategorys.Id DESC, blogcategorys.Name, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY blogcategorys.Name ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY blogcategorys.Name ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
