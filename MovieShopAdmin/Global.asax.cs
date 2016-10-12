using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace MovieShopAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //SETUP OFF AUTOMAPPER TO ONLY LOAD MAPPING INFORMATION ONE TIME - BEGIN.
            Mapper.Initialize(config =>
            {
                config.CreateMap<MovieShopAdmin.Models.Customers.CustomersCreateViewModel, MovieShopBackend.Entities.Customer>();
                config.CreateMap<MovieShopAdmin.Models.Customers.CustomersCreateViewModel, MovieShopBackend.Entities.Address>();

                config.CreateMap<MovieShopAdmin.Models.Customers.CustomerEditViewModel, MovieShopBackend.Entities.Customer>();
                config.CreateMap<MovieShopAdmin.Models.Customers.CustomerEditViewModel, MovieShopBackend.Entities.Address>();
                config.CreateMap<MovieShopBackend.Entities.Customer, MovieShopAdmin.Models.Customers.CustomerEditViewModel>();
                config.CreateMap<MovieShopBackend.Entities.Address, MovieShopAdmin.Models.Customers.CustomerEditViewModel>();
            });
            //SETUP OFF AUTOMAPPER TO ONLY LOAD MAPPING INFORMATION ONE TIME - END.
        }
    }
}
