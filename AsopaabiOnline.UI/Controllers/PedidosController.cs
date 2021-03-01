using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Identity;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.UI.Models.Enums;

namespace AsopaabiOnline.UI.Controllers
{
    public class PedidosController : BaseController
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
                
                if (elCoordinador.siExite(elPedido))
                {
                    elCoordinador.Actualizar(elPedido);
                    Alert("Pedido actualizado.", NotificationType.success);
                }
                else
                {
                    Alert("Parece que este pedido NO existe.", NotificationType.warning);
                }
                return View();
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
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
                if (elCoordinador.SiEstadoEsEnProceso(elPedido))
                {
                    Alert("Parece que este pedido ya esta en proceso.", NotificationType.warning);
                }
                else if (elCoordinador.SiEstadoEsFinalizado(elPedido))
                {
                    Alert("No se puede cambiar por que este pedido ya esta finalizado.", NotificationType.warning);
                    return RedirectToAction("Mostrar");
                }
                    
                else
                {
                    elCoordinador.CambiarAPedidoEnProceso(elPedido);
                    Alert("Se ha actualizado el estado de este pedido.", NotificationType.success);
                }
               

                return RedirectToAction("PedidosEnProceso");
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
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
                if (elCoordinador.SiEstadoEsFinalizado(elPedido))
                {
                    Alert("Parece que este pedido ya esta finalizado.", NotificationType.warning);
                }
                else if (elCoordinador.SiEstadoEsReciente(elPedido))
                {
                    Alert("Primero se debe cambiar a estado en proceso para que el cliente le de seguimiento", NotificationType.warning);
                    return RedirectToAction("Mostrar");
                }
                else
                {
                    elCoordinador.CambiarAPedidoFinalizado(elPedido);
                    Alert("Se ha actualizado el estado de este pedido.", NotificationType.success);
                }


                return RedirectToAction("PedidosFinalizados");
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
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
