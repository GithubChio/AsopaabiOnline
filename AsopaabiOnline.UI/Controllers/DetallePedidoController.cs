using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{ // controlador de detalles del pedido
    public class DetallePedidoController : Controller
    {

        //Método para mostrar los detalles de un pedido 
        [HttpGet]
        public IActionResult MostrarDetalles(Pedido pedido)
        {
            CoordinadorDeDetallePedido elCoordinador = new CoordinadorDeDetallePedido();
            return View(elCoordinador.ListarDetallePedido(pedido)); //el coordinador obtiene la lista de detalles del pedido
        
        }


    }
}
