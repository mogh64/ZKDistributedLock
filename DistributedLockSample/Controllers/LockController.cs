using LockManagement.DistributedLock;
using Microsoft.AspNetCore.Mvc;

namespace DistributedLockSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockController : ControllerBase
    {
        private readonly IDistributedLockerFactory distributedLockerFactory;

        private string data = "";
        public LockController(IDistributedLockerFactory distributedLockerFactory)
        {
            this.distributedLockerFactory = distributedLockerFactory;
        }
        [HttpGet]
        public async Task<string> Test()
        {

            var locker = distributedLockerFactory.Create("foo").GetLocker();
            await locker.LockAsync(DoAction);
            return data;
        }
        private void DoAction()
        {
            //do some action that is needed for distributed processes be synchronzed 
            Thread.Sleep(2000);
            data = "lock acquired";
        }
    }
}
