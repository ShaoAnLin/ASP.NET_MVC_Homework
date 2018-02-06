using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BillingRecord.Startup))]
namespace BillingRecord
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
