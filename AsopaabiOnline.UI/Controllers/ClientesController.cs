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
    public class  ClientesController : Controller
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

                
                    CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
                    elCoordinador.Agregar(elCliente);
                     return RedirectToAction("Mostrar");

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

        [HttpGet]
        [Route("Clientes/Actualizar")]
        public IActionResult Actualizar(int id)
        {
            CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
            var elClienteEncontrado = elCoordinador.ObtenerClientePorId(id);
          
            return View(elClienteEncontrado);
        }
        [HttpPost]
        [Route("Clientes/Actualizar")]
        public IActionResult Actualizar(Modelo.Cliente elCliente)
        {
            try
            {
                CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
                elCoordinador.Actualizar(elCliente);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Clientes/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
            var elClienteEncontrado = elCoordinador.ObtenerClientePorId(id);

            return View(elClienteEncontrado);
        }

        [HttpPost]
        [Route("Clientes/Eliminar")]
        public IActionResult Eliminar(Modelo.Cliente elCliente)
        {
            try
            {
                CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
                elCoordinador.Eliminar(elCliente);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Clientes/CambiarAClienteRegular")]
        public IActionResult CambiarAClienteRegular(int id)
        {
            CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
            var elClienteEncontrado = elCoordinador.ObtenerClientePorId(id);

            return View(elClienteEncontrado);
        }

        [HttpPost]
        [Route("Clientes/CambiarAClienteRegular")]
        public IActionResult CambiarAClienteRegular(Modelo.Cliente elCliente)
        {
            try
            {
                CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
                elCoordinador.CambiarAClienteRegular(elCliente);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        [Route("Clientes/CambiarAClienteFrecuente")]
        public IActionResult CambiarAClienteFrecuente(int id)
        {
            CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
            var elClienteEncontrado = elCoordinador.ObtenerClientePorId(id);

            return View(elClienteEncontrado);
        }

        [HttpPost]
        [Route("Clientes/CambiarAClienteFrecuente")]
        public IActionResult CambiarAClienteFrecuente(Modelo.Cliente elCliente)
        {
            try
            {
                CoordinadorDeClientes elCoordinador = new CoordinadorDeClientes();
                elCoordinador.CambiarAClienteFrecuente(elCliente);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }
    }
}
