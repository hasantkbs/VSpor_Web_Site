using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class RouteModelsSqlQueryBuilderExtensions
    {
        public static string GetRouteModelsSqlQuery(RouteModelsRequest request)
        {
            var stringBuilder = new StringBuilder(RouteModelsQuery.GetRouteModelsSql);

            var countStringBuilder = new StringBuilder(RouteModelsQuery.GetRouteModelsCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new RouteModelsRequest(), key))
                {
                    whereClauses.Add($"routemodels.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new RouteModelsRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  routemodels.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  routemodels.Id DESC, routemodels.Url, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY routemodels.Url ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY routemodels.Url ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
