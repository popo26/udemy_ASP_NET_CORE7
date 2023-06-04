using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
