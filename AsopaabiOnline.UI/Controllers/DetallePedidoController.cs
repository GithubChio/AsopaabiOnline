using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class DetallePedidoController : Controller
    {
        [HttpGet]
        public IActionResult MostrarDetalles(int id)
        {
            CoordinadorDeDetallePedido elCoordinador = new CoordinadorDeDetallePedido();
            return View(elCoordinador.ListarDetallePedido(id));
        
        }
    }
}
