using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AsopaabiOnline.UI.Models.Enums;


namespace AsopaabiOnline.UI.Controllers
{
    public class HomeController : BaseController
    {
       
        private readonly UserManager<User> userManager;
        public HomeController( UserManager<User> userManager)
        {
           
            this.userManager = userManager;
        }


        public IActionResult Tienda()
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var list = elCoordinador.ListarProductos();
            ViewBag.simboloDeColon = "₡";

            return View(list);
        }




        [HttpGet]
        public IActionResult AcercaDeNosotros()
        {

            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}



    }
}

