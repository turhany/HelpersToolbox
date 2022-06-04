using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace HelpersToolbox.Extensions
{
    public class MachineExtensions
    {
        public static List<IPAddress> GetIPV4Addresses()
        {
            var hostName = Dns.GetHostName();
            var ipV4s = Dns.GetHostAddresses(hostName).Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToList();
            return ipV4s;               
        }

        public static List<IPAddress> GetIPV6Addresses()
        {
            var hostName = Dns.GetHostName();
            var ipV6s = Dns.GetHostAddresses(hostName).Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6).ToList();
            return ipV6s;
        }
    }
}
