using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class SaloonsSqlQueryBuilderExtensions
    {
        public static string GetSaloonsSqlQuery(SaloonsRequest request)
        {
            var stringBuilder = new StringBuilder(SaloonsQuery.GetSaloonsSql);

            var countStringBuilder = new StringBuilder(SaloonsQuery.GetSaloonsCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new SaloonsRequest(), key))
                {
                    whereClauses.Add($"saloons.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new SaloonsRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  saloons.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  saloons.Id DESC, saloons.M2, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY saloons.M2 ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY saloons.M2 ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
