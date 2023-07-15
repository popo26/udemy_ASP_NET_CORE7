using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
	public class HomeController : Controller
	{
		[Route("/")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("about")]
		public IActionResult About()
		{
			return View();
		}

		[Route("friend-list")]
		public IActionResult LoadFriedsList()
		{
			PersonGridModel personGridModel2 = new PersonGridModel()
			{

				GridTitle = "Friends",
				Persons = new List<Person>()
				{
					new Person(){ PersonName = "John2", JobTitle = "Manager"},
					new Person(){ PersonName = "Jones3", JobTitle = "Receptionist"},
					new Person(){ PersonName = "William4", JobTitle = "Cleark"}
				}
			};

			return ViewComponent("Grid", new { grid = personGridModel2});
		}
	}
}
