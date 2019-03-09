using OnlineInspection.Domain.Entities;
using OnlineInspection.WebUI.Binders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineInspection.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IModelBinder ModelCartBinder { get; private set; }

        protected void Application_Start()
        {
            Database.SetInitializer<Domain.Concrete.EFDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
