using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP_5.Controllers
{
    public class ToolsUserController : Controller
    {
        // GET: ToolsUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "SignIn");
        }
    }
}