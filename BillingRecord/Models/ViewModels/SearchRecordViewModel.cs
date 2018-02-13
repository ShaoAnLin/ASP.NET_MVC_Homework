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
		[Display(Name = "搜尋歷史紀錄")]
		[UIHint("MonthOnlyDateTime")]
		public DateTime SearchMonth { get; set; }

		public int? Page { get; set; }
	}
}