using org.apache.zookeeper;

namespace LockManagement.ZookeeperClient
{
    public interface IZookeeperClientFactory
    {
        ZooKeeper CreateClient();
    }
}
