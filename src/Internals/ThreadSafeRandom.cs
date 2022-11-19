using System; 
namespace HelpersToolbox.Internals
{
    //https://andrewlock.net/building-a-thread-safe-random-implementation-for-dotnet-framework/
    internal static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random _local;
        private static readonly Random Global = new Random();

        private static Random Instance
        {
            get
            {
                if (_local is null)
                {
                    int seed;
                    lock (Global)
                    {
                        seed = Global.Next();
                    }

                    _local = new Random(seed);
                }

                return _local;
            }
        }

        public static int Next() => Instance.Next();

        public static int Next(int maxValue) => Instance.Next(maxValue);
    }
}
