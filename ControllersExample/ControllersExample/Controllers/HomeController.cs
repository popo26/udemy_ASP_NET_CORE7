using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller //you need to put a word "Controller" e.g. HomeController

    //If you don't want to use "Controller" after the class name, use [Controller]
    //[Controller]
    //public class Home

    {
        [Route("/")]
        [Route("home")]
        public ContentResult Index()
        {
            //return new ContentResult() { Content = "Hello from Index", 
            //ContentType = "text/plain"};

            // By adding ":Microsoft.AspNetCore.Mvc.Controller" after HomeController class, you can use this
            //return Content( "Hello from Index","text/plain");

            //return html
            return Content("<h1>Welcome</h1> <h2>Hello from Index in HTML</h2>", "text/html");
          
        }

        [Route("person")] 
        public JsonResult Person()
        {
           
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };
                return Json(person);//more shortcut way 
                //return new JsonResult(person);
                //above is better than directly returnning json below
                //return "{ \"key\":\"value\" }";           
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] //since it is inside {} you need to use // and {{}} inside regex
        public string Contact()
        {
            return "Hello from Comtact";
        }
    }
}
