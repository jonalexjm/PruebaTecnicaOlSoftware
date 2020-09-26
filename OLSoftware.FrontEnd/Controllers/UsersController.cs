using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OLSoftware.FrontEnd.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Guardar(string nombre, string telefono, string direccion)
        {


            return View();
        }
    }
}
