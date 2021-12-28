using LockManagement.DistributedLock;
using org.apache.zookeeper;

namespace LockManagement.ZookeeperLock
{
    public class ZookeeperDistributedLocker : IDistributedLocker
    {
        private readonly string path;
        private readonly ZooKeeper zookeeper;

        public ZookeeperDistributedLocker(string path, ZooKeeper zookeeper)
        {
            this.path = path;
            this.zookeeper = zookeeper;
        }
        public IDistributedLock GetLocker()
        {
            var zLock = new ZookeeperDistributedLock(path, zookeeper);
            return zLock;
        }
    }
}
