using BillingRecord.Models.ViewModels;
using ServiceLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BillingRecord.Models.ViewModels.BillingInfoViewModel;

namespace BillingRecord.Models
{
	public class BillingContentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<AccountBook> _billingRep;

		public BillingContentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_billingRep = new Repository<AccountBook>(unitOfWork);
		}

		public List<BillingInfoViewModel> GetRecords(int num)
		{
			var source = _billingRep.LookupAll();
			var model = source.Take(num).Select(d => new BillingInfoViewModel()
			{
				Type = (BillingType)d.Categoryyy,
				Amount = d.Amounttt,
				Date = d.Dateee,
				Message = d.Remarkkk
			}).ToList();

			return model;
		}
	}
}