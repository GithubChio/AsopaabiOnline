using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;

namespace AsopaabiOnline.UI.Controllers
{
    public class TelefonosDeClientesController : Controller
    {

        [Route("TelefonosDeClientes/Agregar")]
        [HttpGet]
        public IActionResult Agregar(int id)
        {
            CoordinadorDeLosTelefonosDeClientes elTelefonoDelCliente = new CoordinadorDeLosTelefonosDeClientes();
           var elClienteEncontrado = elTelefonoDelCliente.ObtenerIdDelCliente(id);
            return View(elClienteEncontrado);
        }
        [Route("TelefonosDeClientes/Agregar")]
        [HttpPost]
        public IActionResult Agregar(Modelo.ClienteTelefono elTelefonoDelCliente)
        {
            try
            {

                CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();
                elCoordinador.Agregar(elTelefonoDelCliente);
                return RedirectToAction("Mostrar", "Clientes");
            }
            catch
            {


                return View();
            }
        }



        [HttpGet]
        [Route("TelefonosDeClientes/Mostrar")]
        public IActionResult Mostrar(int id)
        {
            CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();


            return View(elCoordinador.ListarTelefonosDeClientes(id));
        }


    }
}
