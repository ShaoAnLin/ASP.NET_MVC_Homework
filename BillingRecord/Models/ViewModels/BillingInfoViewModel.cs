using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		
		[Range(0, int.MaxValue, ErrorMessage="請輸入正整數")]
		public int Amount { get; set; }
		
		public DateTime Date { get; set; }
		
		[StringLength(100, ErrorMessage="請勿超過100字")]
		public string Message { get; set; }
	}
}