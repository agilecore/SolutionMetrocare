using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using Metrocare.Common;
using Metrocare.Domain;
using System.Web.Security;
using Metrocare.WebUI.Filters;

namespace Metrocare.WebUI.Controllers
{
    public class LoginController : Base
    {
        public LoginController()
        {
            ViewBag.Title = "Login";
        }

        public ActionResult Index()
        {
            return View(new PageLogin());
        }

        public ActionResult Enter(LoginFilter model)
        {
            if (ModelState.IsValid)
            {         
                var loginBusiness = new LoginBus();
                var obj = loginBusiness.GetItem(model);

                if (obj != null) 
                { 
                    var LogDto = new LogDto() { id_usuario = obj.id_usuario, dt_log = DateTime.Now };    
                    var logBusiness = new LogBus();

                    if (logBusiness.Add(LogDto))
                    {                          
                        var SessionMenu = new Metrocare.Security.Session();
                        SessionMenu.Start(obj, "UserAuthenticate");

                        return (RedirectToAction("List", "Dashboard"));
                    }
                }

                return (RedirectToAction("Index"));
            }
            else
            {
                return (RedirectToAction("Index"));
            }
        }

        public ActionResult Login()
        {
           return (View(new LoginDto()));
        }

        public ActionResult ReenviarSenha()
        {
            return View(new LoginDto());
        }

        public ActionResult Add()
        {
            return View(new UsuarioDto());
        }

        

    }
}
