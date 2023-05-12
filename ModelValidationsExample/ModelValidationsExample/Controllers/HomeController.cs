using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //public IActionResult Index(
        //[Bind(nameof(Person.PersonName), 
        //    nameof(Person.Email), nameof(Person.Password), 
        //    nameof(Person.ConfirmPassword))]Person person) //With [Bind] only specified values are posted

        //[ModelBinder(BinderType = typeof(PersonModelBinder))] removed from Line16 after PersonbinderProvider is added.
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")]string UserAgent)//[FromBody] allows JSON, XML input into Model objects


        //With Linq
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                
                return BadRequest(errors);
            }
            return Content($"{person}, {UserAgent}");
        }

//Normal
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        List<string> errorsList = new List<string>();
        //        foreach (var value in ModelState.Values)
        //        {
        //            foreach (var error in value.Errors)
        //            {
        //                errorsList.Add(error.ErrorMessage);
        //            }
        //        }
        //        string errors = string.Join("\n", errorsList);
        //        return BadRequest(errors);
        //    }
        //    return Content($"{person}");
        //}
    }   
}
