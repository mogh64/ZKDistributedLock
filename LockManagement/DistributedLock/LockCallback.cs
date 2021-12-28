using org.apache.zookeeper.recipes.@lock;

namespace LockManagement.DistributedLock
{
    public class LockCallback : LockListener
    {
        private readonly Action _lockAcquiredAction;
        private readonly Action? _lockReleasedAction;

        public LockCallback(Action lockAcquiredAction, Action? lockReleasedAction)
        {
            _lockAcquiredAction = lockAcquiredAction;
            _lockReleasedAction = lockReleasedAction;
        }

        /// <summary>
        /// Acquisition lock successful callback
        /// </summary>
        /// <returns></returns>
        public Task lockAcquired()
        {
            _lockAcquiredAction.Invoke();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Release lock successfully callback
        /// </summary>
        /// <returns></returns>
        public Task lockReleased()
        {

            if (_lockReleasedAction != null)
                _lockReleasedAction.Invoke();

            return Task.CompletedTask;
        }

    }
}
