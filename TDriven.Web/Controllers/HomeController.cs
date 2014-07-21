
namespace TDriven.Web.Controllers
{
	using System.Web.Mvc;
	using TDriven.Core.Service;

	public class HomeController : Controller
	{
		private readonly IProductService productService;

		public HomeController(IProductService productService)
		{
			this.productService = productService;
		}

		public ActionResult Index()
		{
			return View(this.productService.FindAll(criteria: x => x.Name.StartsWith("N")));
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}