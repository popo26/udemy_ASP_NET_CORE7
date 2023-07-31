using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DependencyInjectionExample.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ICitiesService _citiesService;
		
		////constructor --- most popular than using Dependency Injection in a method
		//public HomeController(ICitiesService citiesService)
		//{
		//	//create object of CitiesSErvice class
		//	//_citiesService = new CitiesService(); //Bad practice to create object of service class directly. Instead use dependency injection.
		//	_citiesService = citiesService;
		//}

		[Route("/")]
		public IActionResult Index([FromServices]ICitiesService _citiesService)
		{
			List<string> cities = _citiesService.GetCities();
			return View(cities);
		}
	}
}
