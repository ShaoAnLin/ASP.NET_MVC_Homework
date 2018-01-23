using BillingRecord.Models;
using BillingRecord.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingRecord.Controllers
{
	public class HomeController : Controller
	{
		private BillingDatabaseEntities db = new BillingDatabaseEntities();

		public ActionResult Index()
		{
			return View();
		}

		[ChildActionOnly]
		public ActionResult RecordList()
		{
			List<BillingInfoViewModel> model = db.AccountBook.Take(200).Select(d => new BillingInfoViewModel()
			{
				Type = (d.Categoryyy == 0) ? "支出" : "收入",
				Amount = d.Amounttt,
				Date = d.Dateee,
				Message = d.Remarkkk
			}).ToList();
			
			return View(model);
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