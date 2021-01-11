using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace AsopaabiOnline.UI.Controllers
{
    public class DireccionesParaPedidosController : Controller
    {
        [HttpGet]
        [Route("DireccionesParaPedidos/Agregar")]
        public IActionResult Agregar()
        {

            Modelo.DireccionPedido laDireccionDelPedido = new Modelo.DireccionPedido();
            
            CoordinadorDeProvincias elCoordinadorDeProvincias = new CoordinadorDeProvincias();


            laDireccionDelPedido.LaListaDeProvincias = elCoordinadorDeProvincias.ListarProvincias();
          
         
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
            catch (Exception excepcion)
            {
                Console.WriteLine(excepcion);
                return View();
            }
           

        }

     


        public JsonResult CargarCantones(int id)
        {
            CoordinadorDeCantones elCoordinador = new CoordinadorDeCantones();
            var losCantones = elCoordinador.ListarCantonesPorIdDeProvincia(id);
            return Json(new SelectList(losCantones, "Id", "Nombre"));
        }

        public JsonResult CargarDistritos(int id)
        {
            CoordinadorDeDistritos elCoordinador = new CoordinadorDeDistritos();
            var losDistritos = elCoordinador.ListarDistritosPorIdDeCanton(id);
            return Json(new SelectList(losDistritos, "Id", "Nombre"));
        }

        [HttpGet]
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

        [HttpGet]
        [Route("DireccionesParaPedidos/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
            var laDireccionEncontrada = elCoordinador.ObtenerDireccionesPorId(id);


            return View(laDireccionEncontrada);
        }

        [HttpPost]
        [Route("DireccionesParaPedidos/Eliminar")]
        public IActionResult Eliminar(Modelo.DireccionPedido laDireccion)
        {
            try
            {
                CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
                elCoordinador.Eliminar(laDireccion);
                return RedirectToAction("Mostrar");
            }
            catch
            {

                ViewBag.mensaje = "No se puede eliminar porque esta direccion tiene un pedido";
               return  View();
               
            }

        }
    }
}
