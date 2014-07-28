using System;
using System.ComponentModel;
using System.Reflection;

namespace UILHost.Common
{
    // "where TEnum : struct, IComparable, IFormattable, IConvertible" is as close as we can get to a enum constraint

    public static class EnumExtensions 
    {
        public static T SetFlag<T>(this T value, T flag) where T : struct, IComparable, IFormattable, IConvertible
        {
            return value.SetFlag(flag, true);
        }

        public static T RemoveFlag<T>(this T value, T flag) where T : struct, IComparable, IFormattable, IConvertible
        {
            return value.SetFlag(flag, false);
        }

        public static T SetFlag<T>(this T value, T flag, bool set) where T : struct, IComparable, IFormattable, IConvertible
        {
            Type underlyingType = Enum.GetUnderlyingType(value.GetType());

            // note: AsInt mean: math integer vs enum (not the c# int type)
            dynamic valueAsType = Convert.ChangeType(value, underlyingType);
            dynamic flagAsType = Convert.ChangeType(flag, underlyingType);
            if (set && valueAsType == 0)
                return (T)flagAsType;
            if (set)
                valueAsType |= flagAsType;
            else
                valueAsType &= ~flagAsType;

            return (T)valueAsType;
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null)
                return string.Format("UNDEFINED : {0}", value);

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
