using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace BillingRecord.CustomResults
{
	public class RSSResult : ActionResult
	{
		SyndicationFeed feed;

		public RSSResult(SyndicationFeed feed)
		{
			this.feed = feed;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.ContentType = "application/rss+xml";
			Rss20FeedFormatter formatter = new Rss20FeedFormatter(this.feed);
			using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
			{
				formatter.WriteTo(writer);
			}
		}
	}
}