using BillingRecord.Models;
using BillingRecord.Models.ViewModels;
using ServiceLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
					return View("RecordList", _contentSvc.GetRecords());
				}
			}
			return View(model);
		}

		[ChildActionOnly]
		public ActionResult RecordList(bool editMode = false)
		{
			ViewBag.EditMode = editMode;
			return View(_contentSvc.GetRecords());
		}

		public ActionResult Manage()
		{
			return View();
		}

		public ActionResult Edit()
		{
			return View();
		}

		public ActionResult Detail(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BillingInfoViewModel record = _contentSvc.GetRecord(id);
			return View(record);
		}

		public ActionResult Delete()
		{
			return View();
		}
	}
}