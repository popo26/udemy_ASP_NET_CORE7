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

        [Route("file-download")]
        public VirtualFileResult FileDownload() //when file is inside wwwroot
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf"); //shortcut way
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()//when file is outside wwwroot
        {
            //return new PhysicalFileResult(@"C:\Users\Ai\Desktop\Support Letter For Japan Kauri Education Trust.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\Ai\Desktop\Support Letter For Japan Kauri Education Trust.pdf", "application/pdf");//shortcut way
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3() //when returning in bytes.Not good example with this file. Good when you are encrypting.
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Ai\Desktop\Support Letter For Japan Kauri Education Trust.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf"); //shortcut way
        }

    }
}
