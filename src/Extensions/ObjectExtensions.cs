using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace HelpersToolbox.Extensions
{
    public static class ObjectExtensions
    {
        public static T GetPropertyValue<T>(this object item, string propertyName)
        {
            var propertyInfo = item.GetPropertyInfo(propertyName);
            return (T)propertyInfo.GetValue(item, null);
        }
        
        public static T SetPropertyValue<T>(this object item, string propertyName, T value)
        {
            var propertyInfo = item.GetPropertyInfo(propertyName);
            propertyInfo.SetValue(item, value);

            return value;
        }
        
        public static PropertyInfo GetPropertyInfo(this object item, string propertyName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var type = item.GetType();

            var propertyInfo = type
                .GetProperties(BindingFlags.NonPublic |
                               BindingFlags.Public |
                               BindingFlags.Instance |
                               BindingFlags.Static).FirstOrDefault(l => l.Name == propertyName);

            if (propertyInfo == null)
            {
                throw new ArgumentOutOfRangeException(propertyName);
            }

            return propertyInfo;
        }

        public static bool HasProperty(this object item, string propertyName) => item.GetType().GetProperty(propertyName) != null;

        public static T GetAttribute<T>(this FieldInfo info, bool inherit = true) where T : Attribute
        {
            var attributes = info.GetCustomAttributes(typeof(T), inherit);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }

        public static T DeepClone<T>(T obj) => obj != null ? JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj)) : default;
    }
}