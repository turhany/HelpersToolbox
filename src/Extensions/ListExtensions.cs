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

        public static IList<TSource> GetPage<TSource>(this IList<TSource> list, int pageNumber, int pageSize)
        {
            pageNumber -= 1;
            
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            
            return list.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }
    }
}