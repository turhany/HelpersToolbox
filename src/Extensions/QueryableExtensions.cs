using System;
using System.Linq;
using System.Linq.Expressions;

namespace HelpersToolbox.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate, bool condition) => condition ? queryable.Where(predicate) : queryable;

        public static IQueryable<T> AddPaging<T>(this IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            pageNumber -= 1;
            
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            
            return queryable.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }
    }
}
