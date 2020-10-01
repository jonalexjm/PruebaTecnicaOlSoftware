using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OLSoftware.Web.Helpers;

namespace OLSoftware.Web.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly IUserHelper userHelper;
        public AccountController1(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }



    }
}