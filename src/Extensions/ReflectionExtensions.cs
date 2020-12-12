using System.Reflection;

namespace HelpersToolbox.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasAttribute<T>(this FieldInfo info, bool inherit = true) => info.GetCustomAttributes(typeof(T), inherit).Length > 0;
    }
}