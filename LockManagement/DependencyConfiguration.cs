using LockManagement.DistributedLock;
using LockManagement.ZookeeperClient;
using LockManagement.ZookeeperLock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LockManagement
{
    public static class DependencyConfiguration
    {
        /// <summary>
        /// Register Zookeeper Distributed lock dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void RegisterZKDistributedLock(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<ZookeeperSettings>(Configuration.GetSection(ZookeeperSettings.Name));
            services.AddScoped<IDistributedLockerFactory, ZookeeperDistributedLockerFactory>();
            services.AddSingleton<IZookeeperClientFactory, ZookeeperClientFactory>();
        }
    }
}
