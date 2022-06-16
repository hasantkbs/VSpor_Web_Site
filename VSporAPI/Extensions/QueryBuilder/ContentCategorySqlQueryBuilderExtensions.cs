using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class ContentCategorySqlQueryBuilderExtensions
    {
        public static string GetContentCategorySqlQuery(ContentCategoryRequest request)
        {
            var stringBuilder = new StringBuilder(ContentCategoryQuery.GetContentCategorySql);

            var countStringBuilder = new StringBuilder(ContentCategoryQuery.GetContentCategoryCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new ContentCategoryRequest(), key))
                {
                    whereClauses.Add($"contentcategory.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new ContentCategoryRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  contentcategory.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  contentcategory.Id DESC, contentcategory.businessId, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY contentcategory.businessId");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY contentcategory.businessId ");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
