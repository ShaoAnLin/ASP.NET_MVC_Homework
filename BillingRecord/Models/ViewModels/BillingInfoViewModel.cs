using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingRecord.Models.ViewModels
{
	public class BillingInfoViewModel
	{
		public string Type { get; set; }
		public int Amount { get; set; }
		public string Date { get; set; }
		public string Message { get; set; }
	}
}