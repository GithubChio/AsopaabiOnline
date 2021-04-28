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
{//controlador de direcciones para pedidos
    public class DireccionesParaPedidosController : BaseController //hereda el controlador base para la notificacion de mensajes.

    {
        private readonly UserManager<User> userManager; //instancia de la clase  usuario para que sirva como administrador
        public DireccionesParaPedidosController(UserManager<User> userManager)//constructor del controlador direcciones para pedidos 
        {
            this.userManager = userManager;

        }

         //Método GET y POST para agregar direcciones

        [HttpGet]
    
        public IActionResult Agregar()
        {

            Modelo.DireccionPedido laDireccionDelPedido = new Modelo.DireccionPedido();

            CoordinadorDeProvincias elCoordinadorDeProvincias = new CoordinadorDeProvincias(); 


            laDireccionDelPedido.LaListaDeProvincias = elCoordinadorDeProvincias.ListarProvincias();//el coordinador obtiene la lista de provincias 


            return View(laDireccionDelPedido); //se muestran las provincias en la vista
        }

        [HttpPost]
       
        public async Task<IActionResult> Agregar(Modelo.DireccionPedido laDireccion)
        {
            try
            {
                if (laDireccion != null)
                {
                    var user = await userManager.GetUserAsync(HttpContext.User); //el administrador de usuarios obtiene el usuario del inicio de sesion
                    CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos(); //se crea una instancia del coordinador de direcciones para pedidos
                    laDireccion.IdCliente = user.Id;  //se asigna el id del cliente a la direccion 
                    elCoordinador.Agregar(laDireccion); //el coordinador agrega la nueva direccion 

                    Alert("Dirección guardada.", NotificationType.success); //se muestra un mensaje de exito
                   


                }
                else //si no se agrega 
                {
                    Alert("Complete todos los campos.", NotificationType.info); // se  muestra un mensaje de informacion  
                    return View();
                }


                return RedirectToAction("Mostrar");



            }
            catch //si ocurre un error
            {


                Alert("Complete todos los campos.", NotificationType.error); // se muestra un mensaje de error
                return View();
            }
           

        }

     

        //Método para cargar los cantones en el select de la vista
        public JsonResult CargarCantones(int id)
        {
            CoordinadorDeCantones elCoordinador = new CoordinadorDeCantones();
            var losCantones = elCoordinador.ListarCantonesPorIdDeProvincia(id); //el coordinador brinda la lista de cantones por id de provincia 
            return Json(new SelectList(losCantones, "Id", "Nombre")); //se listan en un select
        }


        //Método para cargar los distritos en el select de la vista
        public JsonResult CargarDistritos(int id)
        {
            CoordinadorDeDistritos elCoordinador = new CoordinadorDeDistritos();
            var losDistritos = elCoordinador.ListarDistritosPorIdDeCanton(id);//el coordinador brinda la lista de los distritos por id de canton 
            return Json(new SelectList(losDistritos, "Id", "Nombre"));//se listan en un select
        }


        //Método para mostrar la lista de direcciones
        [HttpGet]
        [Route("DireccionesParaPedidos/Mostrar")]
        public async Task<IActionResult> Mostrar()
        {

            CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
            var user = await userManager.GetUserAsync(HttpContext.User); //el administrador de usuario trae el usuario logueado


            return  View(elCoordinador.ListarDirecciones(user.Id)); //el coordinador devuelve a la vista la lista de direcciones por id de usuario
        }


        //Método GET y POST para eliminar una direccion por id

        [HttpGet]
        [Route("DireccionesParaPedidos/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos();
            var laDireccionEncontrada = elCoordinador.ObtenerDireccionPorId(id); //el coordinador obtiene la direccion a eliminar por id 


            return View(laDireccionEncontrada);// retorna a la vista  la direccion encontrada 
        }

        [HttpPost]
        [Route("DireccionesParaPedidos/Eliminar")]
        public IActionResult Eliminar(Modelo.DireccionPedido laDireccion)
        {
            try
            {
                CoordinadorDeDireccionesParaPedidos elCoordinador = new CoordinadorDeDireccionesParaPedidos(); //se crea una instancia del  coordinador de direcciones para pedidos

                if (elCoordinador.SiExiste(laDireccion)) //se valida que exista la direccion 
                {
                    elCoordinador.Eliminar(laDireccion);//el coordinador procede a eliminar la direccion 
                    Alert( $"La dirección #{laDireccion.Id} ha sido eliminada.", NotificationType.success); //se muestra el mensaje de exito
                }
                else //si no existe
                {
                    Alert($"La dirección que intenta eliminar no existe", NotificationType.warning); //se advierte que el usuario no exite
                }
               
                   

                    return RedirectToAction("Mostrar");

               

            }
            catch
            {
                Alert($"No es posible eliminar esa dirección", NotificationType.error);

                return  RedirectToAction("Mostrar");
               
            }

        }

       
    }
}
