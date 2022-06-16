
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporCore.Extensions;

namespace PMABLL
{
    public static class GetPropertiesClass
    {
        public static bool FindProp<T>(this T tClass, string value)
        {
            var result = typeof(T).GetProperties().FirstOrDefault(x => x.Name.ToLower() == value.ToLower());

            if (result != null)
                return true;
            else
                return false;
        }
        //public static (Dictionary<string, dynamic> propertyValue, Dictionary<string, Type> propertyType) FindPropValues<T>(this T tClass)
        //{
        //    var propertyValueList = new Dictionary<string, dynamic>();
        //    var propertyTypeList = new Dictionary<string, Type>();
        //    foreach (var propertyInfo in tClass.GetType().GetProperties())
        //    {
        //        var propertyName = propertyInfo.Name;
        //        var propertyValue = propertyInfo.GetValue(tClass);
        //        var propertyType= propertyInfo.PropertyType;

        //        if (propertyValue.IsNotNull() && propertyValue?.ToString() != "0" && propertyValue?.ToString() != "string" && propertyValue?.ToString() != "01/01/0001 00:00:00")
        //        {
        //            propertyValueList.Add(propertyName, propertyValue);
        //            propertyTypeList.Add(propertyName, propertyType);
        //        }
        //    }
        //    return (propertyValueList, propertyTypeList);   
        //}

        public static Dictionary<string, dynamic> FindPropValues<T>(this T tClass)
        {
            var propertyValueList = new Dictionary<string, dynamic>();

            foreach (var propertyInfo in tClass.GetType().GetProperties())
            {
                var propertyName = propertyInfo.Name;
                var propertyValue = propertyInfo.GetValue(tClass, null);
                var propertyType = propertyInfo.PropertyType;

                if (propertyValue.IsNotNull()
                    && (
                    (propertyName.ToUpper() != "ID")
                            || propertyValue.ToString() != "0")
                    && propertyName.ToUpper() != "STARTINDEX" && propertyName.ToUpper() != "MAXCOUNT"
                    && propertyName.ToUpper() != "ORDERBY"
                    && propertyName.ToUpper() != "SQLANDTEXT"
                    && propertyName.ToUpper() != "ISCREATECSV"
                    && propertyValue?.ToString() != "string" && propertyValue?.ToString() != "01/01/0001 00:00:00")
                {
                    propertyValueList.Add(propertyName, propertyValue);
                }
            }
             
            return propertyValueList;

        }
    }
}
