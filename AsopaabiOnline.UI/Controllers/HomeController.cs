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
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> TiendaAsync(string Search)
        {
            Contexto _context = new Contexto();

        var list = from product in _context.Producto
                       select product;

            if (!String.IsNullOrEmpty(Search))
            {
                list = list.Where(s => s.Nombre.Contains(Search));


            }

            return View(await list.ToListAsync());
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

