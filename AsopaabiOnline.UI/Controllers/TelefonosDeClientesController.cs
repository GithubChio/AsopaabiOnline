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
            CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();

            var idClienteEncontrado = elCoordinador.ObtenerIdDelClienteParaLostelefonos(id);


            return View(idClienteEncontrado);
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

        [HttpGet]
        [Route("TelefonosDeClientes/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();
            var telefonosEncontrados = elCoordinador.ObtenerTelefonoPorId(id);
            return View(telefonosEncontrados);
        }
        [HttpPost]
        [Route("TelefonosDeClientes/Eliminar")]
        public IActionResult Eliminar(Modelo.ClienteTelefono elTelefono)
        {
            try
            {
                CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();
                elCoordinador.Eliminar(elTelefono);
                return RedirectToAction("Mostrar","Clientes");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        [Route("TelefonosDeClientes/Actualizar")]
        public IActionResult Actualizar (int id)
        {
            CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();
            var telefonosEncontrados = elCoordinador.ObtenerTelefonoPorId(id);
            return View(telefonosEncontrados);
        }
        [HttpPost]
        [Route("TelefonosDeClientes/Actualizar")]
        public IActionResult Actualizar(Modelo.ClienteTelefono elTelefono)
        {
            try
            {
                CoordinadorDeLosTelefonosDeClientes elCoordinador = new CoordinadorDeLosTelefonosDeClientes();
                elCoordinador.Actualizar(elTelefono);
                return RedirectToAction("Mostrar", "Clientes");
            }
            catch
            {
                return View();
            }
        }


    }
}
