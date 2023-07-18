using Microsoft.AspNetCore.Mvc;
using Assignment20.Models;

namespace Assignment20.Controllers
{
	public class HomeController : Controller
	{
		private List<CityWeather> cities = new List<CityWeather>() {
		new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TEmperatureFahrenheit = 33},
		new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TEmperatureFahrenheit = 60},
		new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-1-01 9:00"), TEmperatureFahrenheit = 82}
		};

		[Route("/")]
		public IActionResult Index()
		{
			return View(cities);
		}

		[Route("/weather/{cityCode?}")]
		public IActionResult City(string? cityCode)
		{
			if (string.IsNullOrEmpty(cityCode))
			{
				return View();
			}
			CityWeather? city = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();
			return View(city);
		}
	}
}
