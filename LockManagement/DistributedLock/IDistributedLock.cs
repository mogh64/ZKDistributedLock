namespace LockManagement.DistributedLock
{
    // Provides interface for the distributed lock implementations
    public interface IDistributedLock
    {
        Task LockAsync(Action lockAcquiredAction, Action? lockReleasedAction = null);
    }
}