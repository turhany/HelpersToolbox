using System;
using System.Linq;

namespace HelpersToolbox.Extensions
{
    public static class IntExtensions
    {
        public static T ToEnum<T>(this int value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase);
        }
        
        public static T ToEnum<T>(this long value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase);
        }
        
        public static bool IsEnumValueValid<T>(this int enumVal, bool zeroIsValid = false) where T : Enum
        {
            if (enumVal == 0 && !zeroIsValid)
                return false;

            var enumValues = Enum.GetValues(typeof(T));
            return enumValues.Cast<T>().Any(val => val.GetHashCode() == enumVal);
        }
        
        public static bool IsEnumValueValid<T>(this long enumVal, bool zeroIsValid = false) where T : Enum
        {
            if (enumVal == 0 && !zeroIsValid)
                return false;

            var enumValues = Enum.GetValues(typeof(T));
            return enumValues.Cast<T>().Any(val => val.GetHashCode() == enumVal);
        }
    }
}