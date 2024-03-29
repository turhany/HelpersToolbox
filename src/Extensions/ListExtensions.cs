﻿using HelpersToolbox.Internals;
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
        
        public static IList<T> SelectRandomFromList<T>(this List<T> source, int numberToChoose)
        {
            if (source == null || !source.Any())
            {
                return source;
            }

            if (source.Count <= numberToChoose)
            {
                return source;
            }

            List<T> response = new List<T>();

            for (int i = 1; i <= numberToChoose; i++)
            {
                int index = ThreadSafeRandom.Next(source.Count);

                if (!response.Contains(source[index]))
                {
                    response.Add(source[index]);
                }
                else
                {
                    i--;
                }
            }

            return response;
        }

        public static IList<T> Shuffle<T>(this IList<T> source)
        {
            if (source == null || !source.Any())
            {
                return source;
            }

            return source.OrderBy(x => ThreadSafeRandom.Next()).ToList();
        }
    }
}