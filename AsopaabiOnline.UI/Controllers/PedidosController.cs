using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;

namespace AsopaabiOnline.UI.Controllers
{
    public class PedidosController : Controller
    {
        

        [HttpGet]
        [Route("Pedidos/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidos());
        }

        [HttpGet]
        [Route("Pedidos/Actualizar")]
        public IActionResult Actualizar(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id);

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/Actualizar")]
        public IActionResult Actualizar(Modelo.Pedido elPedido)
        {
            try
            {
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                elCoordinador.Actualizar(elPedido);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        [Route("Pedidos/CambiarAPedidoEnProceso")]
        public IActionResult CambiarAPedidoEnProceso(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id);

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/CambiarAPedidoEnProceso")]
        public IActionResult CambiarAPedidoEnProceso(Modelo.Pedido elPedido)
        {
            try
            {
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                elCoordinador.CambiarAPedidoEnProceso(elPedido);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Pedidos/CambiarAPedidoFinalizado")]
        public IActionResult CambiarAPedidoFinalizado(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id);

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/CambiarAPedidoFinalizado")]
        public IActionResult CambiarAPedidoFinalizado(Modelo.Pedido elPedido)
        {
            try
            {
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                elCoordinador.CambiarAPedidoFinalizado(elPedido);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Pedidos/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id);

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/Eliminar")]
        public IActionResult Eliminar(Modelo.Pedido elPedido)
        {
            try
            {
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                elCoordinador.Eliminar(elPedido);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }


    }
}
