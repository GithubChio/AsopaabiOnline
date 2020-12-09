using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;

namespace AsopaabiOnline.UI.Controllers
{
    public class DireccionPedidosController : Controller
    {
        [HttpGet]
        [Route("DireccionPedidos/Agregar")]
        public IActionResult Agregar()
        {

            Modelo.DireccionPedido laDireccionDelPedido = new Modelo.DireccionPedido();
            //CoordinadorDeDistritos elCoordinadorDeDistritos = new CoordinadorDeDistritos();
            //CoordinadorDeCantones elCoordinadorDeCantones = new CoordinadorDeCantones();
            CoordinadorDeProvincias elCoordinadorDeProvincias = new CoordinadorDeProvincias();


            laDireccionDelPedido.LaListaDeProvincias = elCoordinadorDeProvincias.ListarProvincias();
            if (ViewBag.SeleccionDeProvincia != null)
            {
                ViewBag.mensaje = "Debe seleccionar uno ";
            }
            //    laDireccionDelPedido.LaListaDeCantones = elCoordinadorDeCantones.ListarCantonesPorIdDeProvincia(laDireccionDelPedido.IdProvincia);
            //laDireccionDelPedido.LaListaDeDistritos = elCoordinadorDeDistritos.ListarDistritosPorIdDeCanton(laDireccionDelPedido.IdDistrito);
            return View(laDireccionDelPedido);
        }

        [Route("DireccionPedidos/Agregar")]
        public IActionResult Agregar(Modelo.DireccionPedido laDireccion)
        {
            try
            { 
                CoordinadorDeDireccionesDeLosPedidos elCoordinador = new CoordinadorDeDireccionesDeLosPedidos();

                elCoordinador.Agregar(laDireccion);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }


        }


    }
}
