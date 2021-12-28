using LockManagement.DistributedLock;
using LockManagement.ZookeeperClient;

namespace LockManagement.ZookeeperLock
{
    public class ZookeeperDistributedLockerFactory : IDistributedLockerFactory
    {
        private readonly IZookeeperClientFactory zookeeperClientFactory;

        public ZookeeperDistributedLockerFactory(IZookeeperClientFactory zookeeperClientFactory)
        {
            this.zookeeperClientFactory = zookeeperClientFactory;
        }
        public IDistributedLocker Create(string path)
        {
            return new ZookeeperDistributedLocker($"/{path}", zookeeperClientFactory.CreateClient());
        }
    }
}
