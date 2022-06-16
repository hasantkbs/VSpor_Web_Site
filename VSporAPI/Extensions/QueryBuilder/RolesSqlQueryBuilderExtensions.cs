using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class RolesSqlQueryBuilderExtensions
    {
        public static string GetRolesSqlQuery(RolesRequest request)
        {
            var stringBuilder = new StringBuilder(RolesQuery.GetRolesSql);

            var countStringBuilder = new StringBuilder(RolesQuery.GetRolesCountSql);

            var whereClauses = new List<string>();

            var getProps = GetPropertiesClass.FindPropValues(request);
            foreach (var item in getProps)
            {
                var key = item.Key;
                var value = item.Value;

                if (GetPropertiesClass.FindProp(new ContentRequest(), key))
                {
                    whereClauses.Add($"roles.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                    if (GetPropertiesClass.FindProp(new RolesRequest(), request.OrderBy.Name))
                    {
                        stringBuilder.Append($" ORDER BY  roles.{request.OrderBy.Name} { request.OrderBy.Type}");
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY  roles.Id DESC, roles.Name, workertypes.Name ");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY roles.Name ASC");
                }
            }
            else
            {
                stringBuilder.Append(" ORDER BY roles.Name ASC");
            }

            stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

            stringBuilder.Append(countStringBuilder);
            return stringBuilder.ToString();
        }
    }
}
