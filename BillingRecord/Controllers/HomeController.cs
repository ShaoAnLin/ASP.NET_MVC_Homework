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
		public ActionResult Index()
		{
			return View();
		}

		[ChildActionOnly]
		public ActionResult RecordList()
		{
			List<BillingInfoViewModel> testData = new List<BillingInfoViewModel>();
			var singleRecord = new BillingInfoViewModel()
			{
				Type = "Expense",
				Amount = 1000,
				Date = "2018.01.17",
				Message = "Eat"
			};
			testData.Add(singleRecord);

			var model = new BillingRecordViewModel()
			{
				RecordList = testData
			};
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