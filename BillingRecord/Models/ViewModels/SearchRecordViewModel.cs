using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingRecord.Models.ViewModels
{
	public class SearchRecordViewModel
	{
		[Display(Name = "年")]
		public int Year { get; set; }

		[Display(Name = "月")]
		public int Month { get; set; }

		public int? Page { get; set; }
	}
}