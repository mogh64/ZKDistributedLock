namespace LockManagement.DistributedLock
{
    public interface IDistributedLockerFactory
    {
        IDistributedLocker Create(string key);
    }
}
