using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace QueryStringVsRouteData.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]//Route data has more priority than Query String
        //Url: /bookstore?bookid=5&isloggedin=true
        public IActionResult Index(int? bookid, bool? isloggedin) //by using IActionResult, since it is parent of ContentResult, FileResult, etc, it accomodate all
        {
            //Book id should be supplied
            if (bookid.HasValue == false)
            {
                //return new BadRequestResult(); 
                return BadRequest("Book id is not supplied or empty");
            }

            //Book id can't be less than or equal to 0
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than or equal to 0");
            }

            //Book id should be between 1 to 1000
            
            if (bookid <= 0)
            {
               return BadRequest("Book id can't be less than or equal to zero");
            }
            if (bookid > 1000)
            {

                return NotFound("Book id can't be greater than 1000.");
            }

            //isloggedin should be true
            if (isloggedin == false)
            {

                return StatusCode(401); //to use StatusCode as result.

            }
            return Content($"Book id: {bookid}", "text/plain");
        }
    }

    
}
