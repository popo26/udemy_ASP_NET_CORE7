using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController //you need to put a word "Controller"
    {
        [Route("/")]
        [Route("home")]
        public string Index()
        {
            return "Hello from Index";
        }

        [Route("about")] 
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] //since it is inside {} you need to use // and {{}} inside regex
        public string Contact()
        {
            return "Hello from Comtact";
        }
    }
}
