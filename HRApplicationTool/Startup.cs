using Hangfire;
using HRApplicationTool.Controllers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRApplicationTool.Startup))]
namespace HRApplicationTool
{
    public partial class Startup
    {
        // Config
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration
               .UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate("report",() => ToolConfigurationController.SendEmailReport(), Cron.Daily(13,00));
        }
    }
}
