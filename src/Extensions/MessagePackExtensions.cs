using MessagePack;
using MessagePack.Resolvers;

namespace HelpersToolbox.Extensions
{
    public class MessagePackExtensions
    {
        public static byte[] Serialize<T>(T obj)
        {
            return MessagePackSerializer.Serialize<T>(obj, TypelessContractlessStandardResolver.Options);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes, TypelessContractlessStandardResolver.Options);
        }
    }
}