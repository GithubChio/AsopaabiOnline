using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class PagosController : Controller
    {


        [HttpGet]
        public IActionResult Mostrar(Pedido pedidoIngresado)
        {
            CoordinadorDePagos coordinadorDePagos = new CoordinadorDePagos();
            return View(coordinadorDePagos.ListarPagos(pedidoIngresado.Id));
        }
    }
}
