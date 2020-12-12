using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpersToolbox.Extensions
{
    public static class ListExtensions
    {
        public static IList<TSource> RemoveWhere<TSource>(this IList<TSource> list, Func<TSource, bool> expression)
        {
            var itemForRemove = list.Where(expression).ToArray();

            foreach (var item in itemForRemove)
            {
                list.Remove(item);
            }

            return list;
        }

        public static IList<TSource> WhereIf<TSource>(this IList<TSource> list, Func<TSource, bool> expression, bool condition) => condition ? list.Where(expression).ToList() : list;
    }
}