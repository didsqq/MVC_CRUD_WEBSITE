using PP_5.DAL;
using PP_5.Models;
using System.Web.Mvc;

namespace PP_5.Controllers
{
    public class ProfileController : Controller
    {
        private ShopContext _shopContext = new ShopContext();
        // GET: Profile
        [HttpGet]
        public ActionResult Profile()
        {
            var customer = (Customer)Session["CurrentCustomer"];
            if (customer == null)
            {
                return View("~/Views/SignIn/SignIn.cshtml");
            }
            return View(customer);
        }
    }
}