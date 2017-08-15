using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Metronic.WebUI.Filters
{
    public class AuthenticateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var SessionMenu = new Metronic.Security.Session();
            
            //if (SessionMenu.IsActive("UserAuthenticate"))
            //{
            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            //}            
        }

        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //}

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //}

        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //}
    }

    //public class AuthorizeFilter : ActionFilterAttribute
    //{
    //    public String PageId { get; set; }

    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        filterContext.HttpContext.Trace.Write("(Logging Filter)Action Executing: " + filterContext.ActionDescriptor.ActionName);
    //        base.OnActionExecuting(filterContext);
    //    }

    //    public override void OnActionExecuted(ActionExecutedContext filterContext)
    //    {
    //        if (filterContext.Exception != null) filterContext.HttpContext.Trace.Write("(Logging Filter)Exception thrown");
    //        base.OnActionExecuted(filterContext);
    //    }

    //    public override void OnResultExecuted(ResultExecutedContext filterContext)
    //    {
    //        base.OnResultExecuted(filterContext);
    //    }

    //    public override void OnResultExecuting(ResultExecutingContext filterContext)
    //    {
    //        base.OnResultExecuting(filterContext);
    //    }
    //}

}

