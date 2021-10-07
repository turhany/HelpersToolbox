using System;

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
    }
}