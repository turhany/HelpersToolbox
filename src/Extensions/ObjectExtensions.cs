using System;
using System.ComponentModel.DataAnnotations;
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
        
        public static T GetFieldValue<T>(this object item, string fieldName)
        {
            var fieldInfo = item.GetFieldInfo(fieldName);
            return (T)fieldInfo.GetValue(item);
        }
        
        public static T SetFieldValue<T>(this object item, string fieldName, T value)
        {
            var fieldInfo = item.GetFieldInfo(fieldName);
            fieldInfo.SetValue(item, value);

            return value;
        }

        public static FieldInfo GetFieldInfo(this object item, string fieldName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var type = item.GetType();

            var fieldInfo = type
                .GetFields(BindingFlags.NonPublic |
                           BindingFlags.Public |
                           BindingFlags.Instance |
                           BindingFlags.Static).FirstOrDefault(l => l.Name == fieldName);

            if (fieldInfo == null)
            {
                throw new ArgumentOutOfRangeException(fieldName);
            }

            return fieldInfo;
        }

        public static bool HasField(this object item, string fieldName) => item.GetType().GetField(fieldName) != null;

        public static T DeepClone<T>(this T obj) => obj != null ? JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj)) : default;
        
        public static string ToJson(this object item)
        {
            if (item == null)
            {
                return string.Empty;
            }
            
            return JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All,
                ObjectCreationHandling = ObjectCreationHandling.Replace
            });
        }
        
        public static string GetDisplayName(this object enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}