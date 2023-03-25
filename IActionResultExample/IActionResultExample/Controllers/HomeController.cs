using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        //Url: /bookstore?bookid=5&isloggedin=true
        public IActionResult Index() //by using IActionResult, since it is parent of ContentResult, FileResult, etc, it accomodate all
        {
            //Book id should be supplied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");

                //return new BadRequestResult(); Instead of 2 lines above, using BadRequestResult class.

                return BadRequest("Book id is not supplied");//Instead of above 2 ways, using a BadRequest method.BadRequest method uses 400 automatically.
            }

            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be null or empty");

                return BadRequest("Book id can't be null or empty");//Instead of above 2 ways, using a BadRequest method.BadRequest method uses 400 automatically.
            }

            //Book id should be between 1 to 1000
            int BookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (BookId <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be less than or equal to zero");

                return BadRequest("Book id can't be less than or equal to zero");//Instead of above 2 ways, using a BadRequest method.BadRequest method uses 400 automatically.
            }
            if (BookId > 1000)
            {
                //Response.StatusCode = 404;
                //return Content("Book id can't be greater than 1000.");

                return NotFound("Book id can't be greater than 1000.");//Instead of above 2 ways, using a NotFound method.NotFound method uses 404 automatically.
            }

            //isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");

                //return Unauthorized("User must be authenticated.");

                return StatusCode(401); //to use StatusCode as result.

            }

            //return new RedirectToActionResult("Books", "Store", new { }); //302 - Found
            return new RedirectToActionResult("Books", "Store", new { }, true); //301 - Moved Permanently
        }
    }
}
