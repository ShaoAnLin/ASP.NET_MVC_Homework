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
		private Random RandomGen = new Random();
		private DateTime StartDate = new DateTime(2010, 1, 1);

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
			
			for (int i = 0; i < 200; ++i)
			{
				var singleRecord = new BillingInfoViewModel()
				{
					Type = billingType[RandomGen.Next(0, 2)],
					Amount = RandomGen.Next(100, 1000),
					Date = RandomDateTime(),
					Message = messageName[RandomGen.Next(0, 8)]
				};
				testData.Add(singleRecord);
			}
			return View(testData);
		}

		public DateTime RandomDateTime()
		{
			int range = ((TimeSpan)(DateTime.Today - StartDate)).Days;
			return StartDate.AddDays(RandomGen.Next(range));
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