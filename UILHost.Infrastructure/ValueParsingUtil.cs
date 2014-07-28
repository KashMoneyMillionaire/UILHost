using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Infrastructure
{
    public class ValueParsingUtil
    {
        public static bool ParseBool(string value, string defaultValue)
        {
            bool? parsedValue = ParseBool(value);
            
            if (parsedValue == null)
                parsedValue = ParseBool(defaultValue);
            if (parsedValue == null)
                throw new FormatException(string.Format("'{0}' and '{1}' cannot be parsed as a boolean value", value, defaultValue));

            return parsedValue.Value;
        }

        private static bool? ParseBool(string value)
        {
            if (value == null)
                return null;

            if (value.Trim() == "1" || value.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase)
                || value.Trim().Equals("TRUE", StringComparison.OrdinalIgnoreCase))
                return true;
            else if (value.Trim() == "0" || value.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase)
                || value.Trim().Equals("FALSE", StringComparison.OrdinalIgnoreCase))
                return false;

            return null;
        }

        public static int? ParseInt(string value, string defaultValue = null)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                if (string.IsNullOrEmpty(defaultValue))
                    return null;

                return int.Parse(defaultValue);
            }
        }

        public static DateTime ParseDateTime(string value, string defaultValue)
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch
            {
                return DateTime.Parse(defaultValue);
            }
        }

        /// <summary>
        /// Parses a comma, or range ('-') separated list of integers
        /// </summary>
        public static int[] ParseIntArray(string value, string defaultValue = null)
        {
            if(string.IsNullOrEmpty(value) && string.IsNullOrEmpty(defaultValue))
                return new int[] { };

            var strVal = value;
            if (strVal == null)
                strVal = defaultValue;

            if (string.IsNullOrEmpty(strVal))
                return ParseIntArray(null, defaultValue);

            if (strVal.Contains("-"))
            {
                var bounds = strVal.Split('-');
                var indexes = new List<int>();
                for (int i = int.Parse(bounds[0].Trim()); i <= int.Parse(bounds[1].Trim()); i++)
                    indexes.Add(i);
                return indexes.ToArray();
            }

            if (strVal.Contains(","))
                return strVal.Split(',').Select(i => int.Parse(i.Trim())).ToArray();

            return ParseIntArray(null, defaultValue);
        }

        public static T Parse<T>(string value, string defaultValue)
        {
            object returnValue = null;

            if (typeof(T) == typeof(int)) { returnValue = ValueParsingUtil.ParseInt(value, defaultValue); }
            else if (typeof(T) == typeof(bool)) { returnValue = ValueParsingUtil.ParseBool(value, defaultValue); }
            else if (typeof(T) == typeof(DateTime)) { returnValue = ValueParsingUtil.ParseDateTime(value, defaultValue); }
            else if (typeof(T) == typeof(string)) { returnValue = value; }
            else { throw new ArgumentException(string.Format("Cannot parse value as {0}. The conversion is not defined. :: value={1}, defaultValue={2}", typeof(T).FullName, value, defaultValue)); }

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }

    }
}
