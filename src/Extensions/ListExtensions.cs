using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpersToolbox.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Removes list elements according to given expression.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>Given instance's itself.</returns>
        public static IList<TSource> RemoveWhere<TSource>(this IList<TSource> list, Func<TSource, bool> expression)
        {
            var toRemove = list.Where(expression).ToArray();

            foreach (var source in toRemove)
            {
                list.Remove(source);
            }

            return list;
        }
    }
}