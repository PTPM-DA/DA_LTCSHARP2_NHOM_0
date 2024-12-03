using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_QuanAo.Filters
{
    public class AuthFilterAtribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authCookie = HttpContext.Current.Request.Cookies["auth"];
            if(authCookie == null || authCookie.Value=="")
            {
                filterContext.Result = new RedirectResult("/Account/login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}