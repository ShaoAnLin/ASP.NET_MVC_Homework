using BillingRecord.Models;
using BillingRecord.Models.ViewModels;
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
		private readonly BillingContentService _contentSvc;

		public HomeController()
		{
			_unitOfWork = new EFUnitOfWork();
			_contentSvc = new BillingContentService(_unitOfWork);
		}

		public ActionResult Index()
		{
			return View(new BillingInfoViewModel());
		}
		
		[HttpPost]
		public ActionResult Create(BillingInfoViewModel model)
		{
            if (ModelState.IsValid)
			{
				if (_contentSvc.ModelIsValid(model))
				{
					_contentSvc.Add(model);
					_contentSvc.Save();
					return View(_contentSvc.GetRecords());
				}
			}
			return View(model);
		}

		[ChildActionOnly]
		public ActionResult RecordList()
		{	
			return View(_contentSvc.GetRecords());
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