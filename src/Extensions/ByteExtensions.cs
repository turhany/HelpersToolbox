using System;
using System.Linq;

namespace HelpersToolbox.Extensions
{
    public static class ByteExtensions
    {
        public static T ToEnum<T>(this byte value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase);
        }
        
        public static bool IsEnumValueValid<T>(this byte enumVal, bool zeroIsValid = false) where T : Enum
        {
            if (enumVal == 0 && !zeroIsValid)
                return false;

            var enumValues = Enum.GetValues(typeof(T));
            return enumValues.Cast<T>().Any(val => val.GetHashCode() == enumVal);
        }
    }
}