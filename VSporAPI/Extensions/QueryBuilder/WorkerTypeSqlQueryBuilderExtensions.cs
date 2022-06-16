using PMABLL;
using System.Text;
using VSporAPI.Models.Request;
using VSporAPI.Query.Entity;
using VSporCore.Extensions;

namespace VSporAPI.Extensions.QueryBuilder
{
    public class WorkerTypeSqlQueryBuilderExtensions
    {
       
            public static string GetWorkerTypeSqlQuery(WorkerTypeRequest request)
            {
                var stringBuilder = new StringBuilder(WorkerTypeQuery.GetWorkerTypeSql);

                var countStringBuilder = new StringBuilder(WorkerTypeQuery.GetWorkerTypeSql);

                var whereClauses = new List<string>();

                var getProps = GetPropertiesClass.FindPropValues(request);
                foreach (var item in getProps)
                {
                    var key = item.Key;
                    var value = item.Value;

                    if (GetPropertiesClass.FindProp(new WorkerTypeRequest(), key))
                    {
                        whereClauses.Add($"workertypes.{FilterCalc.GetKeyValue(key)} {FilterCalc.Run(value, FilterCalc.SelectOperator(key))}");
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
                        if (GetPropertiesClass.FindProp(new WorkerTypeRequest(), request.OrderBy.Name))
                        {
                            stringBuilder.Append($" ORDER BY  workertypes.{request.OrderBy.Name} { request.OrderBy.Type}");
                        }
                        else
                        {
                            stringBuilder.Append(" ORDER BY  workertypes.Id DESC, workertypes.Name, workertypes.Name ");
                        }
                    }
                    else
                    {
                        stringBuilder.Append(" ORDER BY workertypes.Name ASC");
                    }
                }
                else
                {
                    stringBuilder.Append(" ORDER BY workertypes.Name ASC");
                }

                stringBuilder.Append($" OFFSET {request.StartIndex} ROWS FETCH NEXT {(request.MaxCount.IsNotDefault() ? request.MaxCount : 25)} ROWS ONLY;");

                stringBuilder.Append(countStringBuilder);
                return stringBuilder.ToString();
            }
        }
    }

