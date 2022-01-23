namespace LockManagement.DistributedLock
{
    // Provides interface for the distributed lock implementations
    public interface IDistributedLock
    {
        Task LockAsync(Action lockAcquiredAction, Action? lockReleasedAction = null);
        Task LockAsync<T>(Action<T> lockAcquiredAction, T input, Action? lockReleasedAction = null);
        Task LockAsync<T1, T2>(Action<T1, T2> lockAcquiredAction, T1 input1, T2 input2, Action? lockReleasedAction = null);
        Task LockAsync<T1, T2,T3>(Action<T1, T2,T3> lockAcquiredAction, T1 input1, T2 input2,T3 input3, Action? lockReleasedAction = null);
    }
}
