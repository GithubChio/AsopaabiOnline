using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class DetallePedidoController : Controller
    {
        [HttpGet]
        public IActionResult MostrarDetalles(Pedido pedido)
        {
            CoordinadorDeDetallePedido elCoordinador = new CoordinadorDeDetallePedido();
            return View(elCoordinador.ListarDetallePedido(pedido));
        
        }




        public IActionResult Mostrar(Pedido pedido)
        {
            ViewBag.pedido = pedido.Id;
            CoordinadorDeDetallePedido elCoordinador = new CoordinadorDeDetallePedido();
            return View(elCoordinador.ListarDetallePedido(pedido));
           


        }
    }
}
