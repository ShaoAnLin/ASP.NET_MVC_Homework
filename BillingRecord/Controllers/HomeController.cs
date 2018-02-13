using BillingRecord.Models;
using BillingRecord.Models.ViewModels;
using ServiceLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BillingRecord.Controllers
{
	public class HomeController : Controller
	{
		private readonly EFUnitOfWork _unitOfWork;
		private readonly BillingContentService _contentSvc;
		private const int _itemsPerPage = 10;

		public HomeController()
		{
			_unitOfWork = new EFUnitOfWork();
			_contentSvc = new BillingContentService(_unitOfWork);
		}

		[Route("")]
		[Route("~/skilltree")]
		public ActionResult Index()
		{
			ViewBag.EditMode = false;
			return View(new SearchRecordViewModel());
		}
		
		public ActionResult Create()
		{
			return View(new BillingInfoViewModel());
		}

		[HttpPost]
		[ActionName("Create")]
		[ValidateAntiForgeryToken]
		public ActionResult CreateConfirmed(BillingInfoViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (_contentSvc.ModelIsValid(model))
				{
					_contentSvc.Add(model);
					_contentSvc.Save();
					return RedirectToAction("Index");
				}
			}
			return View(model);
		}

		[ChildActionOnly]
		public ActionResult RecordList(int? page, bool editMode = false)
		{
			ViewBag.EditMode = editMode;

			var records = _contentSvc.GetRecords();
			int pageIdx = page ?? 1;
			var onePageOfProducts = records.ToPagedList(pageIdx, _itemsPerPage);

			ViewBag.OnePageOfProducts = onePageOfProducts;
			return View();
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Manage()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BillingInfoViewModel record = _contentSvc.GetRecord(id);
			return View(record);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		[ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public ActionResult EditConfirmed(BillingInfoViewModel model)
		{
			if (_contentSvc.Edit(model))
			{
				_contentSvc.Save();
			}
			return RedirectToAction("Manage");
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

		[Authorize(Roles = "Admin")]
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BillingInfoViewModel record = _contentSvc.GetRecord(id);
			return View(record);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id, string submitBtn)
		{
			if (submitBtn == "Delete")
			{
				if (_contentSvc.Delete(id))
				{
					_contentSvc.Save();
				}
			}
			return RedirectToAction("Manage");
		}

		[HttpGet]
		[Route("~/skilltree/{year:length(4)}/{month:length(2)}")]
		public ActionResult MonthRecord(string year, string month, int? page)
		{
			if (int.TryParse(year, out int yearResult) && int.TryParse(month, out int monResult))
			{
				return MonthRecord(new SearchRecordViewModel()
				{
					Year = yearResult,
					Month = monResult,
					Page = page
				});
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public ActionResult MonthRecord(SearchRecordViewModel model)
		{
			return View(model);
		}

		public ActionResult GetMonthRecords(SearchRecordViewModel model)
		{
			int pageIdx = model.Page ?? 1;
			var records = _contentSvc.GetRecords(model.Year, model.Month);

			if (records.Any())
			{
				var onePageOfRecords = records.ToPagedList(pageIdx, _itemsPerPage);
				ViewBag.OnePageOfProducts = onePageOfRecords;
				ViewBag.MonthRecord = true;
				ViewBag.SearchRecord = model;
				return View("RecordList", records);
			}
			return Content("沒有明細");
		}
	}
}