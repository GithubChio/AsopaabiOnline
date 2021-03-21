using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.UI.Models.Enums;

namespace AsopaabiOnline.UI.Controllers
{
    public class DireccionesParaPedidosController : BaseController
    {
        private readonly UserManager<User> userManager;
        public DireccionesParaPedidosController(UserManager<User> userManager)
        {
            this.userManager = userManager;

        }



        [HttpGet]
    
        public IActionResult Agregar()
        {

            Modelo.DireccionPedido laDireccionDelPedido = new Modelo.DireccionPedido();

            CoordinadorDeProvincias elCoordinadorDeProvincias = new CoordinadorDeProvincias();


            laDireccionDelPedido.LaListaDeProvincias = elCoordinadorDeProvincias.ListarProvincias();


            return View(laDireccionDelPedido);
        }

        [HttpPost]
       
        public async Task<IActionResult> Agregar(Modelo.DireccionPedido laDireccion)
        {
            try
            {
                if (laDireccion != null)
                {
                    var user = await userManager.GetUserAsync(HttpContext.User);
                    CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
                    laDireccion.IdCliente = user.Id;
                    elCoordinador.Agregar(laDireccion);

                    Alert("Dirección guardada.", NotificationType.success);
                   


                }
                else
                {
                    Alert("Complete todos los campos.", NotificationType.warning);
                    return View();
                }


                return RedirectToAction("Mostrar");



            }
            catch
            {


                Alert("Complete todos los campos.", NotificationType.error);
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
        public async Task<IActionResult> Mostrar()
        {

            CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
            var user = await userManager.GetUserAsync(HttpContext.User);


            return  View(elCoordinador.ListarDirecciones(user.Id));
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

                if (elCoordinador.SiExiste(laDireccion))
                {
                    elCoordinador.Eliminar(laDireccion);
                    Alert( $"La dirección #{laDireccion.Id} ha sido eliminada.", NotificationType.success);
                }
                else
                {
                    Alert($"La dirección {laDireccion.Id} no existe", NotificationType.warning);
                }
               
                   

                    return RedirectToAction("Mostrar");

               

            }
            catch
            {
                Alert($"No se puede eliminar por que hay un pedido con la dirección #{laDireccion.Id}. ", NotificationType.error);

                return  RedirectToAction("Mostrar");
               
            }

        }

       
    }
}
