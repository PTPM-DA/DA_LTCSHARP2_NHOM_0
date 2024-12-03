using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shop_QuanAo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_Error()
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();

        //    var httpException = exception as HttpException;

        //    if (httpException != null)
        //    {
        //        int statusCode = httpException.GetHttpCode();

        //        if (statusCode == 404)
        //        {
        //            Response.Redirect("~/Error/NotFound");
        //        }
        //        else
        //        {
        //            Response.Redirect("~/Error");
        //        }
        //    }
        //    else
        //    {
        //        // Chuyển hướng đến trang lỗi chung
        //        Response.Redirect("~/Error");
        //    }

        //    Server.ClearError();
        //}
    }
}
