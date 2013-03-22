using BestFitBusinessLayer.Models;
using System.Web.Mvc;

namespace BestFitPCBWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Init()
		{
			BestFitPCBContext db = new BestFitPCBContext();
			db.Database.CreateIfNotExists();
			return View();
		}

	}
}
