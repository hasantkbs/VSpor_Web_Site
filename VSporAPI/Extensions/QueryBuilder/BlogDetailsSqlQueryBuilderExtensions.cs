using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class BlogDetailsSqlQueryBuilderExtensions
    {
        public static string GetBlogDetailsSqlQuery(BlogDetailsRequest request)
        {
            var stringBuilder = new StringBuilder(BlogDetailsQuery.GetBlogDetailsSql);

            var countStringBuilder = new StringBuilder(BlogDetailsQuery.GetBlogDetailsCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new BlogDetailsRequest(), key))
                {
                    whereClauses.Add($"blogdetails.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new BlogDetailsRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  blogdetails.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  blogdetails.Id DESC, blogdetails.SummartContent, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY blogdetails.SummartContent ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY blogdetails.SummartContent ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
