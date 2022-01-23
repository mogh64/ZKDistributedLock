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
         public Task LockAsync<T>(Action<T> lockAcquiredAction, T input1, Action? lockReleasedAction = null)
        {
            var lockCallback = new LockCallback(() =>
            {
                try
                {
                    lockAcquiredAction(input1);
                }
                finally
                {
                    writeLock.unlock();
                }
            }, lockReleasedAction);

            writeLock.setLockListener(lockCallback);

            return writeLock.Lock();
        }
        public Task LockAsync<T1, T2>(Action<T1, T2> lockAcquiredAction, T1 input1, T2 input2, Action? lockReleasedAction = null)
        {
            var lockCallback = new LockCallback(() =>
            {
                try
                {
                    lockAcquiredAction(input1, input2);
                }
                finally
                {
                    writeLock.unlock();
                }
            }, lockReleasedAction);

            writeLock.setLockListener(lockCallback);

            return writeLock.Lock();
        }
        public Task LockAsync<T1, T2,T3>(Action<T1, T2,T3> lockAcquiredAction, T1 input1, T2 input2,T3 input3, Action? lockReleasedAction = null)
        {
            var lockCallback = new LockCallback(() =>
            {
                try
                {
                    lockAcquiredAction(input1, input2,input3);
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
