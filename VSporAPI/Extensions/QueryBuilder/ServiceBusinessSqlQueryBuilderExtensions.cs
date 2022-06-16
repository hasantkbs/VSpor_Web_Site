using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class ServiceBusinessSqlQueryBuilderExtensions
    {
        public static string GetServiceBusinessSqlQuery(ServicesBusinessRequest request)
        {
            var stringBuilder = new StringBuilder(ServiceBusinessQuery.GetServiceBusinessSql);

            var countStringBuilder = new StringBuilder(ServiceBusinessQuery.GetServiceBusinessCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new ServicesBusinessRequest(), key))
                {
                    whereClauses.Add($"servicebusiness.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new ServicesBusinessRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  servicebusiness.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  servicebusiness.Id DESC, servicebusiness.businessId, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY servicebusiness.businessId ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY servicebusiness.businessId ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
