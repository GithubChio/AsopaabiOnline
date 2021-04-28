using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Identity;
using AsopaabiOnline.UI.Models;

namespace AsopaabiOnline.UI.Controllers
{ //controlador del historial de pedidos

    public class HistorialPedidosController : Controller
    {

        private readonly UserManager<User> userManager;//instancia de la clase  usuario para que sirva como administrador
        public HistorialPedidosController(UserManager<User> userManager) //constructor del controlador historial de pedidos
        {
            this.userManager = userManager;

        }

        //Método para mostrar el historial de pedidos en la vista de clientes
        public async Task<IActionResult> Mostrar()
        {
            CoordinadorDeHistorialPedidos coordinadorDeHistorial = new CoordinadorDeHistorialPedidos();
            var user = await userManager.GetUserAsync(HttpContext.User);//se obtiene el usuario que inicio sesion 

            return View(coordinadorDeHistorial.ListarHistorialDePedidos(user.Id));//  se lista el historial de pedidos del usuario 
        }


        //Método para mostrar el historial de pedidos buscando a un cliente en especifico en la vista de clientes de administradores
        [HttpGet]
        public async Task<IActionResult> MostrarHistorialPorClientesEnEspecifico(string id)
        {
            CoordinadorDeHistorialPedidos coordinadorDeHistorial = new CoordinadorDeHistorialPedidos();
            var user = await userManager.FindByIdAsync(id); //encontramos un usuario en especifico por el id

            return View(coordinadorDeHistorial.ListarHistorialDePedidos(user.Id));//el coordinador brinda la lista del historial de pedidos del   usuario
        }
    }
}
