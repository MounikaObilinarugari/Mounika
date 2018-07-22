using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
namespace RentingVehicles
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Models.mydbcontext db = new Models.mydbcontext();
            db.Database.CreateIfNotExists();

            
            if (!Roles.RoleExists("Users"))
            {
                Roles.CreateRole("Users");
            }
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
