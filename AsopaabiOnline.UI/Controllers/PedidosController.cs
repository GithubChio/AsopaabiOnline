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
    //controlador de Pedidos
    public class PedidosController : BaseController //hereda el controlador base para la notificacion de mensajes.
    {
        //Método para mostrar la lista de pedidos

        [HttpGet]
        [Route("Pedidos/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidos()); //el coordinador de pedidos lista los pedidos encontrados 
        }


        //Método GET y SET para actualizar un pedido

        [HttpGet]
        [Route("Pedidos/Actualizar")]
        public IActionResult Actualizar(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id); //el coordinador busca el pedido por Id y se lo pasa a la vista 

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/Actualizar")]
        public IActionResult Actualizar(Modelo.Pedido elPedido)
        {
            try
            {
                
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                
                if (elCoordinador.siExite(elPedido)) //el coordinador verifica la existencia antes de actualizar
                {
                    elCoordinador.Actualizar(elPedido); //el coordinador procede a actualizar el pedido
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
                Alert("No es posible actualizar este pedido. ¡Inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
            }
        }


        //Permite mostrar la pantalla para cambiar el estado del pedido
        [HttpGet]
        [Route("Pedidos/CambiarEstadoDePedido")]
        public IActionResult CambiarEstadoDePedido(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id); 
            ViewBag.IdDelPedido = elPedidoEncontrado.Id;
            return View();
        }

        //Método GET y POST que permite cambiar el estado del pedido a en proceso 
        [HttpGet]
        [Route("Pedidos/CambiarAPedidoEnProceso")]
        public IActionResult CambiarAPedidoEnProceso(int id)
        {

            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id); //se obtiene el pedido por el id

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/CambiarAPedidoEnProceso")]
        public IActionResult CambiarAPedidoEnProceso(Modelo.Pedido elPedido)
        {
            try
            {
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                if (elCoordinador.SiEstadoEsEnProceso(elPedido)) //si ya esta en estado en proceso le muestra un mensaje de advertencia
                {
                    Alert("Parece que este pedido ya está en proceso.", NotificationType.warning);
                }
                else if (elCoordinador.SiEstadoEsFinalizado(elPedido)) //si esta en estado finalizado le muestra un mensaje de advertencia
                {
                    Alert("No se puede cambiar porque este pedido ya esta finalizado.", NotificationType.warning);
                    return RedirectToAction("Mostrar");
                }
                    
                else 
                {
                    elCoordinador.CambiarAPedidoEnProceso(elPedido);
                    Alert("Pedido actualizado ha estado en proceso", NotificationType.success);
                }
               

                return RedirectToAction("PedidosEnProceso");
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
            }
        }



        //Método GET y POST que permite cambiar el estado del pedido a finalizado
        [HttpGet]
        [Route("Pedidos/CambiarAPedidoFinalizado")]
        public IActionResult CambiarAPedidoFinalizado(int id)
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            var elPedidoEncontrado = elCoordinador.ObtenerPedidoPorId(id);//el coordinador obtiene un pedido por id

            return View(elPedidoEncontrado);
        }
        [HttpPost]
        [Route("Pedidos/CambiarAPedidoFinalizado")]
        public IActionResult CambiarAPedidoFinalizado(Modelo.Pedido elPedido)
        {
            try
            {
                CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
                if (elCoordinador.SiEstadoEsFinalizado(elPedido)) //si ya esta en estado finalizado le muestra un mensaje de advertencia
                {
                    Alert("Parece que este pedido ya esta finalizado.", NotificationType.warning);
                }
                else if (elCoordinador.SiEstadoEsReciente(elPedido)) //si esta en estado reciente le muestra un mensaje de advertencia
                {
                    Alert("Primero se debe cambiar a estado en proceso para que el cliente le dé seguimiento", NotificationType.warning);
                    return RedirectToAction("Mostrar");
                }
                else
                {
                    elCoordinador.CambiarAPedidoFinalizado(elPedido);
                    Alert("Pedido actualizado ha estado finalizado", NotificationType.success);
                }


                return RedirectToAction("PedidosFinalizados");
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
            }
        }







        //Método para ver la lista de pedidos recientes

        [HttpGet]
        [Route("Pedidos/PedidosRecientes")]
        public IActionResult PedidosRecientes()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidosRecientes());
        }
        //Método para ver la lista de pedidos en proceso

        [HttpGet]
        [Route("Pedidos/PedidosEnProceso")]
        public IActionResult PedidosEnProceso()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidosEnProceso());
        }

        //Método para ver la lista de pedidos finalizados
        [HttpGet]
        [Route("Pedidos/PedidosFinalizados")]
        public IActionResult PedidosFinalizados()
        {
            CoordinadorDePedidos elCoordinador = new CoordinadorDePedidos();
            return View(elCoordinador.ListarPedidosFinalizados());
        }

    }
}
