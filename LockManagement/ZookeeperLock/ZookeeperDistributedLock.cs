using LockManagement.DistributedLock;
using org.apache.zookeeper;
using org.apache.zookeeper.recipes.@lock;

namespace LockManagement.ZookeeperLock
{
    internal class ZookeeperDistributedLock : IDistributedLock
    {

        private readonly WriteLock writeLock;
        public ZookeeperDistributedLock(string path, ZooKeeper zooKeeper)
        {

            writeLock = new WriteLock(zooKeeper, path, null);

        }

        public Task LockAsync(Action lockAcquiredAction, Action? lockReleasedAction = null)
        {
            var lockCallback = new LockCallback(() =>
            {
                try
                {
                    lockAcquiredAction();
                }
                finally
                {
                    writeLock.unlock();
                }
            }, lockReleasedAction);

            writeLock.setLockListener(lockCallback);

            return writeLock.Lock();
        }
    }
}
