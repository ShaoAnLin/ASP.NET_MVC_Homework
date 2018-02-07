using System.Web.Mvc;

namespace BillingRecord.Areas.Login
{
    public class LoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
                "Login_default",
                "Login/{controller}/{action}/{id}",
				defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
			);
        }
    }
}