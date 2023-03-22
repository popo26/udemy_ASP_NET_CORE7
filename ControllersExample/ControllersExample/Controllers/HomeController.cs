using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController //you need to put a word "Controller"
    {
        [Route("sayhello")] //attribute routing
        public string method1()
        {
            return "Hello from method1";
        }
    }
}
