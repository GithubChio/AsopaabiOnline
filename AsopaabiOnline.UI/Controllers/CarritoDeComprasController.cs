using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Helpers;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.UI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class CarritoDeComprasController : BaseController
    {
        private readonly UserManager<User> userManager;
        public CarritoDeComprasController(UserManager<User> userManager)
        {

            this.userManager = userManager;

        }

     

        [HttpPost]
        public IActionResult AñadirAlCarrito(int id, int cantidad)
        {

            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var producto = elCoordinador.ObtenerProductoPorId(id);
            if (producto == null || cantidad == 0)
            {
                Alert("Primero debe agregar la cantidad de producto al carrito. ¡Inténtelo de nuevo!", NotificationType.warning);
            }
            else
            {

                producto.Cantidad = cantidad;


                if (SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList") == null)
                {

                    List<Producto> lista = new List<Producto>();

                    lista.Add(producto);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", lista);
                    Alert("Agregado al carrito.", NotificationType.success);

                }
                else
                {

                    var listaActual = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");

                    var indice = siExiste(producto.Id);
                    if (indice != -1)
                    {
                        listaActual[indice].Cantidad += producto.Cantidad;
                        listaActual.Insert(indice, producto);
                        listaActual.RemoveAt(indice);

                    }
                    else
                    {
                        listaActual.Add(producto);
                    }
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", listaActual);
                    Alert("Agregado al carrito.", NotificationType.success);
                }


            }
            return RedirectToAction("Tienda", "Home");


        }



        [HttpGet]
        public async Task<IActionResult> CarritoDeCompras()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.simboloDeColon = "₡";
            if (SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList") == null)
            {

                Alert("No hay productos en el carrito", NotificationType.info);
                return RedirectToAction("Tienda", "Home");
            }
            else
            {

                var carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
                ViewBag.cart = carritoDeCompras;
                ViewBag.total = carritoDeCompras.Sum(producto => producto.Precio * producto.Cantidad);


                CoordinadorDeDireccionesParaPedidos coordinadorDeDireccionesParaPedidos = new CoordinadorDeDireccionesParaPedidos();

                CartViewModel viewModel = new CartViewModel();
                viewModel.pedido = new Pedido();
                viewModel.pedido.ListaDeDirecciones = coordinadorDeDireccionesParaPedidos.ListarDirecciones(user.Id);
                return View(viewModel);
            }




        }


        public IActionResult QuitarDelCarrito(int id)
        {
            List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
            int index = siExiste(id);
            carritoDeCompras.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", carritoDeCompras);
            return RedirectToAction("CarritoDeCompras");
        }


        private int siExiste(int id)
        {


            List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
            for (int laListaDeProductos = 0; laListaDeProductos < carritoDeCompras.Count; laListaDeProductos++)
            {
                if (carritoDeCompras[laListaDeProductos].Id.Equals(id))
                {
                    return laListaDeProductos;
                }
            }
            return -1;
        }



        [HttpPost]
        public async Task<IActionResult> GenerarPedido(Pedido pedido, float total)
        {
            List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
            var user = await userManager.GetUserAsync(HttpContext.User);
            var db = new Contexto();
            int idPedido = await InsertPedidoAsync(pedido, db, user);
            if (idPedido != 0)
            {
                bool seGuardoPago = await InsertPago(db, idPedido, pedido, total);
                var d = seGuardoPago;

            }
            bool seGuardoDetalle = idPedido == 0 ? false : await InsertDetallePedidoAsync(carritoDeCompras, idPedido, db);

            if (seGuardoDetalle)
            {
                HistorialPedido historialPedido = new HistorialPedido();
                Pedido existePedido = db.Pedido.Find(idPedido);
                historialPedido.IdCliente = existePedido.IdCliente;
                historialPedido.IdPedido = existePedido.Id;
                db.HistorialPedido.Add(historialPedido);
                await db.SaveChangesAsync();
                Alert("Su pedido ha sido enviado.", NotificationType.success);
                return RedirectToAction("Mostrar", "HistorialPedidos");

            }
            return RedirectToAction("CarritoDeCompras");

        }
        private async Task<int> InsertPedidoAsync(Pedido pedido, Contexto db, User user)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    CoordinadorDePedidos coordinadorDePedidos = new CoordinadorDePedidos();

                    pedido.IdCliente = user.Id;
                    coordinadorDePedidos.Agregar(pedido);
                    await dbContextTransaction.CommitAsync();
                    return pedido.Id;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();

                }
            }
            return 0;
        }
        private async Task<bool> InsertDetallePedidoAsync(List<Producto> carritoDeCompras, int idPedido, Contexto db)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    List<DetallePedido> detallePedido = new List<DetallePedido>();
                    foreach (var product in carritoDeCompras)
                    {

                        var detalle = new DetallePedido();
                        detalle.Cantidad = product.Cantidad;
                        detalle.IdPedido = idPedido;
                        detalle.IdProducto = product.Id;
                        detallePedido.Add(detalle);

                    }
                    await db.DetallePedido.AddRangeAsync(detallePedido);
                    await db.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", null);
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();

                }
            }
            return false;
        }
        private async Task<bool> InsertPago(Contexto db, int idPedido, Pedido pedido, float total)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    Pago pago = new Pago();
                    pago.IdPedido = idPedido;
                    pago.Monto = total;
                    pago.OpcionesDePago = pedido.TipoPago;
                    db.Pago.Add(pago);
                    await db.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();

                    return true;

                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();

                }
            }
            return false;
        }
    }
}
