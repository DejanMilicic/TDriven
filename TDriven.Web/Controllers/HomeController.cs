using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDriven.Web.Controllers
{
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
			return View(this.productService.FindAll(x => x.Name.StartsWith("N")));
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