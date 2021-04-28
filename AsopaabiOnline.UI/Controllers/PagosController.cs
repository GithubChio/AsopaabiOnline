using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{ //controlador de pagos
    public class PagosController : Controller
    {
        //permite mostrar los pagos de un pedido

        [HttpGet]
        public IActionResult Mostrar(Pedido pedidoIngresado)
        {
            CoordinadorDePagos coordinadorDePagos = new CoordinadorDePagos();
            return View(coordinadorDePagos.ListarPagos(pedidoIngresado.Id));//el coordinador le pasa la lista de pagos al controlador
        }

      
    }
}
