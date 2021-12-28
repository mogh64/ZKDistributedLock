namespace LockManagement.DistributedLock
{
    public interface IDistributedLocker
    {

        /**
         * This method only fetches the lock object but does not explicitly lock. Lock has to be acquired and released.
         * specifically
         * @param key Fetch the lock object based on the key provided.
         * @return Implementation of DistributedLock object
         */
        IDistributedLock GetLocker();

    }
}