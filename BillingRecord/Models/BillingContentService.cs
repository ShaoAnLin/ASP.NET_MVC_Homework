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

		public List<BillingInfoViewModel> GetRecords(int num = 100)
		{
			var model = _billingRep.LookupAll().OrderByDescending(d => d.Dateee).Take(num).Select(d => new BillingInfoViewModel()
			{
				Id = d.Id,
				Type = (BillingType)d.Categoryyy,
				Amount = d.Amounttt,
				Date = d.Dateee,
				Message = d.Remarkkk
			}).ToList();

			return model;
		}

		public BillingInfoViewModel GetRecord(Guid? id)
		{
			var record = _billingRep.GetSingle(d => d.Id == id);
			var model = new BillingInfoViewModel
			{
				Id = record.Id,
				Type = (BillingType)record.Categoryyy,
				Amount = record.Amounttt,
				Date = record.Dateee,
				Message = record.Remarkkk
			};
			return model;
		}

		public void Add(BillingInfoViewModel model)
		{
			_billingRep.Create(new AccountBook {
				Id = Guid.NewGuid(),
				Categoryyy = (int)model.Type,
				Amounttt = model.Amount,
				Dateee = model.Date,
				Remarkkk = model.Message
			});
		}

		public bool ModelIsValid(BillingInfoViewModel model)
		{
			if (model.Amount < 0)
			{
				return false;
			}
			if (model.Date > DateTime.Now)
			{
				return false;
			}
			if (model.Message.Length > 100)
			{
				return false;
			}
			return true;
		}

		public void Save()
		{
			_unitOfWork.Save();
		}

		public bool Delete(Guid id)
		{
			var record = _billingRep.GetSingle(d => d.Id == id);
			if (record != null)
			{
				_billingRep.Remove(record);
				return true;
			}
			return false;
		}

		public bool Edit(BillingInfoViewModel model)
		{
			var record = _billingRep.GetSingle(d => d.Id == model.Id);
			if (record != null)
			{
				_billingRep.Remove(record);
				_billingRep.Create(new AccountBook
				{
					Id = model.Id,
					Categoryyy = (int)model.Type,
					Amounttt = model.Amount,
					Dateee = model.Date,
					Remarkkk = model.Message
				});
				return true;
			}
			return false;
		}
	}
}