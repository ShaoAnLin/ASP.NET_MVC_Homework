using BillingRecord.CustomResults;
using BillingRecord.Models;
using ServiceLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace BillingRecord.Controllers
{
    public class FeedController : Controller
	{
		private readonly EFUnitOfWork _unitOfWork;
		private readonly BillingContentService _contentSvc;

		public FeedController()
		{
			_unitOfWork = new EFUnitOfWork();
			_contentSvc = new BillingContentService(_unitOfWork);
		}

		// GET: Orders
		public ActionResult Index()
		{
			var feed = this.GetFeedData();
			return new RSSResult(feed);
		}

		private SyndicationFeed GetFeedData()
		{
			var feed = new SyndicationFeed(
				"我的帳本資料",
				"訂單RSS！",
				new Uri(Url.Action("Rss", "Feed", null, "http")));

			var items = new List<SyndicationItem>();

			var records = _contentSvc.GetRecords();

			foreach (var record in records)
			{
				var item = new SyndicationItem(
					string.Format("{0} {1}", record.Type, record.Amount),
					record.Message.ToString(),
					new Uri(Url.Action("Detail", "Home", new { id = record.Id }, "http")),
					"ID",
					record.Date);

				items.Add(item);
			}

			feed.Items = items;
			return feed;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_unitOfWork.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}