using System.Collections.Generic;
// ReSharper disable ConvertToUsingDeclaration

namespace HelpersToolbox.Extensions
{
    public static class EnumerableExtensions
    {
        //Source: https://stackoverflow.com/a/13710023/5160217
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int size)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    yield return YieldChunkElements(enumerator, size - 1);
            }
        }

        private static IEnumerable<T> YieldChunkElements<T>(IEnumerator<T> source, int size)
        {
            yield return source.Current;
            for (var i = 0; i < size && source.MoveNext(); i++)
                yield return source.Current;
        }
    }
}
