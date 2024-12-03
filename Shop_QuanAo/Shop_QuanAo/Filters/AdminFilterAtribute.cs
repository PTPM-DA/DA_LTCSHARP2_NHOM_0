using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_QuanAo.Filters
{
    public class AdminFilterAtribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authCookie = HttpContext.Current.Request.Cookies["role"];
            if (authCookie == null || authCookie.Value != "Admin")
            {
                filterContext.Result = new RedirectResult("/Account/login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}