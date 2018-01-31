using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingRecord.Models.ViewModels
{
	public class BillingInfoViewModel
	{
		public enum BillingType
		{
			Expense = 0,
			Income = 1
		}
		public BillingType Type { get; set; }
		public int Amount { get; set; }
		public DateTime Date { get; set; }
		public string Message { get; set; }
	}
}