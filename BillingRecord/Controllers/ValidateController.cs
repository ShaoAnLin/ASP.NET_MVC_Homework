using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingRecord.Controllers
{
    public class ValidateController : Controller
    {
        public ActionResult Index(DateTime Date)
		{
			bool isValid = DateTime.Compare(Date, DateTime.Now) <= 0;
			return Json(isValid, JsonRequestBehavior.AllowGet);
        }
    }
}