namespace HelpersToolbox.Extensions
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Check object has property.
        /// </summary>
        /// <param name="item">The object item.</param>
        /// <param name="propertyName">Name of the object property.</param>
        /// <returns></returns>
        public static bool HasProperty(this object item, string propertyName) => item.GetType().GetProperty(propertyName) != null;
    }
}