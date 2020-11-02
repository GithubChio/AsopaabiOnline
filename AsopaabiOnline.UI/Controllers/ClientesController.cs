using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class ClientesController : Controller
    {
      
        [HttpGet]
        [Route("Clientes/Agregar")]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [Route("Clientes/Agregar")]
        public IActionResult Agregar(Modelo.Cliente elCliente)
        {
            try
            {

                if (ModelState.IsValid)
                {
                   CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
                    elCoordinador.Agregar(elCliente);
                    return RedirectToAction("Mostrar");
                }


                return View();
            }
            catch
            {

                return View();
            }
        }

        [HttpGet]
        [Route("Clientes/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
            
            return View(elCoordinador.ListarClientes());
        }


    }
}
