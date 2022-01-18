using Microsoft.Extensions.Options;
using org.apache.zookeeper;
using System.Diagnostics;

namespace LockManagement.ZookeeperClient
{
    public class ZookeeperClientFactory : Watcher, IZookeeperClientFactory
    {
        private string hostPort = "127.0.0.1:21811";

        private int CONNECTION_TIMEOUT = 4000;
        private static ZooKeeper zooKeeperClient;


        public ZookeeperClientFactory(IOptions<ZookeeperSettings> options)
        {
            var settings = options.Value;

            if (!string.IsNullOrWhiteSpace(settings.HostPorts))
            {
                hostPort = settings.HostPorts;
            }
            if (settings.ConnectionTimeout > 0)
            {
                CONNECTION_TIMEOUT = settings.ConnectionTimeout;
            }
        }
        public ZooKeeper CreateClient()
        {
            if (zooKeeperClient == null || zooKeeperClient.getState()!=ZooKeeper.States.CONNECTED)
            {
                zooKeeperClient = createClient(this);
            }
            return zooKeeperClient;
        }
        private ZooKeeper createClient(Watcher watcher)
        {
            var zooKeeper = new ZooKeeper(hostPort, CONNECTION_TIMEOUT, NullWatcher.Instance);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < CONNECTION_TIMEOUT)
            {
                var state = zooKeeper.getState();
                if (state == ZooKeeper.States.CONNECTED || state == ZooKeeper.States.CONNECTING)
                {
                    break;
                }
            }
            sw.Stop();
            return zooKeeper;
        }

        public override Task process(WatchedEvent @event)
        {
            try
            {
                if (@event.getState() == Event.KeeperState.SyncConnected)
                {

                }
                else if (@event.getState() == Event.KeeperState.Disconnected)
                {

                }
                else if (@event.getState() == Event.KeeperState.Expired)
                {

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.CompletedTask;
        }

    }

    public class NullWatcher : Watcher
    {
        public static readonly NullWatcher Instance = new NullWatcher();
        private NullWatcher() { }
        public override Task process(WatchedEvent @event)
        {
            return Task.CompletedTask;
            // nada
        }
    }
}
