using BillingRecord.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingRecord.Models
{
	public class BillingContentService
	{
		private readonly BillingDatabaseEntities _db;

		public BillingContentService()
		{
			_db = new BillingDatabaseEntities();
		}

		public List<BillingInfoViewModel> GetRecords(int num)
		{
			List<BillingInfoViewModel> model = _db.AccountBook.Take(num).Select(d => new BillingInfoViewModel()
			{
				Type = (d.Categoryyy == 0) ? "支出" : "收入",
				Amount = d.Amounttt,
				Date = d.Dateee,
				Message = d.Remarkkk
			}).ToList();

			return model;
		}
	}
}