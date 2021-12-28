using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockManagement.ZookeeperClient
{
    public class ZookeeperSettings
    {
        public const string Name = "Zookeeper";
        public string? HostPorts { get; set; }
        public int ConnectionTimeout { get; set; } = 4000;
    }
}
