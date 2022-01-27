using System.IO;
using MsgPack.Serialization;

namespace HelpersToolbox.Extensions
{
    public class MessagePackExtensions
    {
        public static byte[] Serialize<T>(T thisObj)
        {
        	var serializer = MessagePackSerializer.Get<T>();

            using var byteStream = new MemoryStream();
            serializer.Pack(byteStream, thisObj);
            return byteStream.ToArray();
        }
        
        public static  T Deserialize<T>(byte[] bytes)
        {
        	var serializer = MessagePackSerializer.Get<T>();
            
            using var byteStream = new MemoryStream(bytes);
            return serializer.Unpack(byteStream);
        }
    }
}