using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace HelpersToolbox.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get the Description from the DescriptionAttribute.
        /// </summary>
        /// <param name="enumValue">Current Enum.</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description ?? string.Empty;
        }
    }
}
