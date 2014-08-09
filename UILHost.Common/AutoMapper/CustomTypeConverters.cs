using AutoMapper;
using System;
using System.Collections.Generic;

namespace UILHost.Common.AutoMapper
{
    public class StringToNullableDateTimeTypeConverter : ITypeConverter<string, DateTime?>
    {
        public DateTime? Convert(ResolutionContext context)
        {
            if (context.SourceValue.ToString().Trim() != String.Empty)
            {
                return DateTime.ParseExact(context.SourceValue.ToString(), "yyyyMMdd", null);
            }
            else
            {
                return null;
            }
        }
    }

    public class StringToDateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(ResolutionContext context)
        {
            return DateTime.ParseExact(context.SourceValue.ToString(), "yyyyMMdd", null);
        }
    }

    public class DateTimeToStringTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(ResolutionContext context)
        {
            return ((DateTime)context.SourceValue).ToString("yyyyMMdd");
        }
    }

    public class StringToBooleanTypeConverter : ITypeConverter<string, Boolean>
    {
        public bool Convert(ResolutionContext context)
        {
            return TypeConverterHelper.StringToBoolean(context.SourceValue.ToString());
        }
    }

    public class StringToIntTypeConverter : ITypeConverter<string, int>
    {
        public int Convert(ResolutionContext context)
        {
            return int.Parse(context.SourceValue.ToString());
        }
    }

    public class IntToStringTypeConverter : ITypeConverter<int, string>
    {
        public string Convert(ResolutionContext context)
        {
            return context.SourceValue.ToString();
        }
    }

    public class BooleanToStringTypeConverter : ITypeConverter<Boolean, string>
    {
        public string Convert(ResolutionContext context)
        {
            return TypeConverterHelper.BooleanToStringYN((bool)context.SourceValue);
        }
    }

    public class StringArrayToDecimalArrayTypeConverter : ITypeConverter<string[], decimal[]>
    {
        public decimal[] Convert(ResolutionContext context)
        {
            List<decimal> result = new List<decimal>();
            foreach (string value in (string[])context.SourceValue)
            {
                result.Add(System.Convert.ToDecimal(value.Replace("%", "")));
            }
            return result.ToArray();
        }
    }

    public class DecimalArrayToStringArrayTypeConverter : ITypeConverter<decimal[], string[]>
    {
        public string[] Convert(ResolutionContext context)
        {
            List<string> result = new List<string>();
            foreach (decimal value in (decimal[])context.SourceValue)
            {
                result.Add(value.ToString());
            }
            return result.ToArray();
        }
    }

    public class StringToDecimalTypeConverter : ITypeConverter<string, decimal>
    {
        public decimal Convert(ResolutionContext context)
        {
            string val = (string)context.SourceValue;
            
            if (val == String.Empty) 
                return 0;
            
            if (val.Contains("%")) val = val.Replace("%", "");
            return System.Convert.ToDecimal(val);
        }
    }

    public class DecimalToStringTypeConverter : ITypeConverter<decimal, string>
    {
        public string Convert(ResolutionContext context)
        {
            return ((decimal)context.SourceValue).ToString();
        }
    }

    //public class EnumToStringTypeConverter : ITypeConverter<Enum, string>
    //{
    //    public string Convert(ResolutionContext context)
    //    {
    //        return System.Convert.ToInt32( ((Enum)context.SourceValue)) .ToString();
    //    }
    //}

    //public class StringToStateTypeConverter : ITypeConverter<string, State>
    //{
    //    public Type Convert(ResolutionContext context)
    //    {
    //        return context.SourceType;
    //    }
    //}

    public static class TypeConverterHelper {
        
        public static bool StringToBoolean(string source) 
        {
            return (source == "Y" || source == "1") ? true : false;
        }

        public static string BooleanToStringYN(bool source)
        {
            return (source == true) ? "Y" : "N";
        }

        public static string BooleanToString10(bool source)
        {
            return (source == true) ? "1" : "0";
        }

        public static string StringYNToString10(string source)
        {
            return (source == "Y") ? "1" : "0";
        }

        public static string String10ToStringYN(string source)
        {
            return (source == "1") ? "Y" : "N";
        }

    }
}
