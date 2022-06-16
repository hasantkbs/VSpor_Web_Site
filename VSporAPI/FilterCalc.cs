using VSporCore.Extensions;

namespace VSporAPI
{
    
        public static class FilterCalc
        {
            public static string Run(string value, string operatorValue = "=")
            {
                if (value.Contains("*"))
                {
                    return $"like '{value.Replace("*", "%")}'";
                }
                else
                {
                    return $" {operatorValue} '{value}'";
                }
            }
            public static string SelectOperator(string propertyName)
            {
                if (propertyName.EndsWith("Start"))
                {
                    return $" >= ";
                }
                else if (propertyName.EndsWith("End"))
                {
                    return $" <= ";
                }
                else
                {
                    return $" = ";
                }
            }

            public static string GetKeyValue(string propertyName)
            {
                if (propertyName.EndsWith("Start"))
                {
                    return $"{propertyName.Substring(0, propertyName.Length - 5)}";
                }
                else if (propertyName.EndsWith("End"))
                {
                    return $"{propertyName.Substring(0, propertyName.Length - 3)}";
                }
                else
                {
                    return $"{propertyName}";
                }
            }


            public static string Run(DateTime? value, string operatorValue = "=")
            {
                var valueDateFormat = value.ToDateTimeDate();
                return $" {operatorValue} '{valueDateFormat}'";
            }
            public static string Run(DateTime value, string operatorValue = "=")
            {
                var valueDateFormat = value.ToDateTimeDate();
                return $" {operatorValue} '{valueDateFormat}'";
            }

            public static string Run(byte? value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(byte value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(short? value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(short value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }


            public static string Run(float? value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(float value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(double? value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(double value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(int value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(int? value, string operatorValue = "=")
            {
                return $" {operatorValue} {value}";
            }
            public static string Run(bool? value, string operatorValue = "=")
            {
                int state = value == true ? 1 : 0;
                return $" {operatorValue} {state}";
            }
            public static string Run(bool value, string operatorValue = "=")
            {
                int state = value == true ? 1 : 0;
                return $" {operatorValue} {state}";
            }
        }
    
}
