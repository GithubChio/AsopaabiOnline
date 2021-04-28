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
{ //controlador de Home
    public class HomeController : BaseController //hereda el controlador base para la notificacion de mensajes.
    
    {
       
        private readonly UserManager<User> userManager;   //instancia de la clase  usuario para que sirva como administrador
        public HomeController( UserManager<User> userManager) //constructor del controlador home
        {
           
            this.userManager = userManager;
           
        }

        //Método GET y POST para ir a la vista de la tienda de compras
        public IActionResult Tienda()
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var list = elCoordinador.ListarProductos();//el coordinador trae la lista de productos
            ViewBag.simboloDeColon = "₡";

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> TiendaAsync(string Search)
        {
            Contexto _context = new Contexto();

        var list = from product in _context.Producto 
                       select product;//se consulta  la lista de productos 

            if (!String.IsNullOrEmpty(Search)) //metodo  para  buscar productos en la tienda
            {
                list = list.Where(s => s.Nombre.Contains(Search));


            }

            return View(await list.ToListAsync()); //muesta en la tienda el producto buscado 
        }

        //Permite ir a la vista de acerca de nosotros

        [HttpGet]
        public IActionResult AcercaDeNosotros()
        {

            return View();
        }

        



    }
}

