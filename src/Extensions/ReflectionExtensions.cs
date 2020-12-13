using System;
using System.Reflection;

namespace HelpersToolbox.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasAttribute<T>(this FieldInfo info, bool inherit = true) => info.GetCustomAttributes(typeof(T), inherit).Length > 0;

        public static T GetAttribute<T>(this FieldInfo info, bool inherit = true) where T : Attribute
        {
            var attributes = info.GetCustomAttributes(typeof(T), inherit);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
    }
}