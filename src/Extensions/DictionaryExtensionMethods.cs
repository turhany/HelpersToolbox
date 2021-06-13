using System.Collections.Generic;

namespace HelpersToolbox.Extensions
{
    public static class DictionaryExtensionMethods
    {
        public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> merge)
        {
            foreach (var item in merge)
            {
                source[item.Key] = item.Value;
            }
        }
    }
}