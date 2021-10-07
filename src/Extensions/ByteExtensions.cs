using System;

namespace HelpersToolbox.Extensions
{
    public static class ByteExtensions
    {
        public static T ToEnum<T>(this byte value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase);
        }
    }
}