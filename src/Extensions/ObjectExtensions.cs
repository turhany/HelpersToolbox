using System;
using System.Linq;
using System.Reflection;

namespace HelpersToolbox.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Gets the object item property value.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="item">The object item.</param>
        /// <param name="propertyName">Name of the object property.</param>
        public static T GetPropertyValue<T>(this object item, string propertyName)
        {
            var propertyInfo = item.GetPropertyInfo(propertyName);

            return (T)propertyInfo.GetValue(item, null);
        }

        /// <summary>
        /// Set the object item property value.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="item">The object item.</param>
        /// <param name="propertyName">Name of the object property.</param>
        /// <param name="value">Value for property.</param>
        /// <returns></returns>
        public static T SetPropertyValue<T>(this object item, string propertyName, T value)
        {
            var propertyInfo = item.GetPropertyInfo(propertyName);

            propertyInfo.SetValue(item, value);

            return value;
        }

        /// <summary>
        /// Get object item Property Info.
        /// </summary> 
        /// <param name="item">The object item.</param>
        /// <param name="propertyName">Name of the object property.</param>
        /// <returns></returns>
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
    }
}