using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Identity;
using AsopaabiOnline.UI.Models;

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

        [HttpGet]
        [Route("Pedidos/CambiarEstadoDePedido")]
        public IActionResult CambiarEstadoDePedido(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id);
            ViewBag.IdDelPedido = elPedidoEncontrado.Id;
            return View();
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
                return RedirectToAction("PedidosEnProceso");
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
                return RedirectToAction("PedidosFinalizados");
            }
            catch
            {
                return View();
            }
        }









        [HttpGet]
        [Route("Pedidos/PedidosRecientes")]
        public IActionResult PedidosRecientes()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidosRecientes());
        }

        [HttpGet]
        [Route("Pedidos/PedidosEnProceso")]
        public IActionResult PedidosEnProceso()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidosEnProceso());
        }

        [HttpGet]
        [Route("Pedidos/PedidosFinalizados")]
        public IActionResult PedidosFinalizados()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidosFinalizados());
        }

    }
}
