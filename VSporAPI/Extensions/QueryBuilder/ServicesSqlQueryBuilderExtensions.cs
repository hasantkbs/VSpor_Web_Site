using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class ServicesSqlQueryBuilderExtensions
    {
        public static string GetServicesSqlQuery(ServicesRequest request)
        {
            var stringBuilder = new StringBuilder(ServicesQuery.GetServicesSql);

            var countStringBuilder = new StringBuilder(ServicesQuery.GetServicesCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new ServicesRequest(), key))
                {
                    whereClauses.Add($"services.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new ServicesRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  services.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  services.Id DESC, services.Name, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY services.Name ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY services.Name ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
