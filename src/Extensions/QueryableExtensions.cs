using System;
using System.Linq;
using System.Linq.Expressions;

namespace HelpersToolbox.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate, bool condition) => condition ? queryable.Where(predicate) : queryable;
    }
}
