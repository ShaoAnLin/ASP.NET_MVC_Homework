using BillingRecord.Models;
using ServiceLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingRecord.Controllers
{
	public class HomeController : Controller
	{
		private readonly EFUnitOfWork _unitOfWork;
		private readonly BillingContentService _contectSvc;

		public HomeController()
		{
			_unitOfWork = new EFUnitOfWork();
			_contectSvc = new BillingContentService(_unitOfWork);
		}

		public ActionResult Index()
		{
			return View();
		}

		[ChildActionOnly]
		public ActionResult RecordList()
		{	
			return View(_contectSvc.GetRecords(200));
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