using Microsoft.AspNetCore.Mvc;
using Assignment14.Models;
using Microsoft.VisualBasic;

namespace Assignment14.Controllers
{
	public class HomeController : Controller
	{
		private List<CityWeather> cities = new List<CityWeather>()
			{
			new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
			new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime =DateTime.Parse("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
			new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
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
