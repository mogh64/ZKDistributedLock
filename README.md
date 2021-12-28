# ZKDistributedLock
Distributed lock implementation in .Net Core 6
1- Set Zookeeper setttings in appsetting.json :
```
  "Zookeeper": {
    "HostPorts": "127.0.0.1:2181",
    "ConnectionTimeout": "20000"
  },
```
2- Inject IDistributedLockerFactory for acquiring lock in your service:
```
        private readonly IDistributedLockerFactory distributedLockerFactory;
       
        public LockController(IDistributedLockerFactory distributedLockerFactory)
        {
            this.distributedLockerFactory = distributedLockerFactory;
        }
```
3- Get a lock on a resource by name and define a callback to be called after getting the lock (it's an async action)
```
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
```
Lock will be released automatically after completeng the lock callback action.
You could get the NuGet package using this command:
```
Install-Package LockManagement -Version 1.0.1
```

