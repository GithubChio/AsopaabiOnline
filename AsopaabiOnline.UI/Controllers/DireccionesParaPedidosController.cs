using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;

namespace AsopaabiOnline.UI.Controllers
{
    public class DireccionesParaPedidosController : Controller
    {
        [HttpGet]
        [Route("DireccionesParaPedidos/Agregar")]
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

        [HttpPost]
        [Route("DireccionesParaPedidos/Agregar")]
        public IActionResult Agregar(Modelo.DireccionPedido laDireccion)
        {
            try
            { 
                CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();

                elCoordinador.Agregar(laDireccion);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }


        }

        [Route("DireccionesParaPedidos/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
            return  View(elCoordinador.ListarDirecciones());
        }


        [HttpGet]
        [Route("DireccionesParaPedidos/Actualizar")]
        public IActionResult Actualizar(int id)
        {
            CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
            var laDireccionEncontrada = elCoordinador.ObtenerDireccionesPorId(id);

            return View(laDireccionEncontrada);
        }

        [HttpPost]
        [Route("DireccionesParaPedidos/Actualizar")]
        public IActionResult Actualizar(Modelo.DireccionPedido laDireccion)
        {
            try
            {
                CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
                elCoordinador.Actualizar(laDireccion);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }


    }
}
