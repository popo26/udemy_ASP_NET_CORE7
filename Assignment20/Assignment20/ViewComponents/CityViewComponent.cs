using Assignment20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment20.ViewComponents
{
	
	public class CityViewComponent: ViewComponent
	{
		
		public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
		{
			ViewBag.CityCssClass = GetCssClassByFahrenheit(city.TEmperatureFahrenheit);
			return View(city);
		}

		private string GetCssClassByFahrenheit(int TemperatureFahrenheit)
		{
			return TemperatureFahrenheit switch
			{
				(< 44) => "blue-back",
				(>= 44) and (< 75) => "green-back",
				(>= 75) => "orange-back"
			};
		}
	}
}
