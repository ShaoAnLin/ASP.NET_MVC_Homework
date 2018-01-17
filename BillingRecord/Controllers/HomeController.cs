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

			string[] billingType = { "支出", "收入" };
			string[] messageName = { "伙食", "購物", "房租", "水電瓦斯", "網路電話", "交通", "休閒娛樂", "送禮請客" };

			Random rnd = new Random();
			for (int i = 0; i < 200; ++i)
			{
				var singleRecord = new BillingInfoViewModel()
				{
					Type = billingType[rnd.Next(0, 2)],
					Amount = rnd.Next(100, 1000),
					Date = "2017." + rnd.Next(1, 13) + "." + rnd.Next(1, 31),
					Message = messageName[rnd.Next(0, 8)]
				};
				testData.Add(singleRecord);
			}

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