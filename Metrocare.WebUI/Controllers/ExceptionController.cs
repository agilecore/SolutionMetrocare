using Metrocare.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metrocare.Common;

namespace Metrocare.WebUI.Controllers
{
    public class ExceptionController : Base
    {
        public ExceptionController()
        {
            ViewBag.Title = "Exception";
        }

        public ActionResult Error()
        {
            var exception = Server.GetLastError();
            var ExceptionDto = new ExceptionDto() { id_error = exception.HResult, message = exception.Message, dt_error = DateTime.Now };
            return (View(ExceptionDto));
        }
    }
}
