using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Identity;
using AsopaabiOnline.UI.Models;

namespace AsopaabiOnline.UI.Controllers
{
    public class HistorialPedidosController : Controller
    {

        private readonly UserManager<User> userManager;
        public HistorialPedidosController(UserManager<User> userManager)
        {
            this.userManager = userManager;

        }

        //Método para mostrar el historial de pedidos en la vista de clientes
        public async Task<IActionResult> Mostrar()
        {
            CoordinadorDeHistorialPedidos coordinadorDeHistorial = new CoordinadorDeHistorialPedidos();
            var user = await userManager.GetUserAsync(HttpContext.User);

            return View(coordinadorDeHistorial.ListarHistorialDePedidos(user.Id));
        }


        //Método para mostrar el historial de pedidos buscando a un cliente en especifico en la vista de clientes de administradores
        [HttpGet]
        public async Task<IActionResult> MostrarHistorialPorClientesEnEspecifico(string id)
        {
            CoordinadorDeHistorialPedidos coordinadorDeHistorial = new CoordinadorDeHistorialPedidos();
            var user = await userManager.FindByIdAsync(id);

            return View(coordinadorDeHistorial.ListarHistorialDePedidos(user.Id));
        }
    }
}
