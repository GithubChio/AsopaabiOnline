using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Helpers;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.UI.Models.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class CarritoDeComprasController : BaseController
    {
       
        private readonly UserManager<User> userManager;
        private readonly IEmailSender emailSender;
        private readonly IWebHostEnvironment _env;
        public CarritoDeComprasController(UserManager<User> userManager,IEmailSender sender,IWebHostEnvironment environment)
        {

            this.userManager = userManager;
            this.emailSender = sender;
            this._env = environment;

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

            try
            {
               
                List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
                var user = await userManager.GetUserAsync(HttpContext.User);
                var emailUser = await userManager.GetEmailAsync(user);

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
                    await emailSender.SendEmailAsync(emailUser, "Pedido", PlantillaCorreoPedido(existePedido, total, carritoDeCompras));

                    Alert("Su pedido ha sido enviado.", NotificationType.success);
                    return RedirectToAction("Mostrar", "HistorialPedidos");

                }
                return RedirectToAction("CarritoDeCompras");
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Tienda", "Home");
            }
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
                   ViewBag.opcionesDePago = pedido.TipoPago;
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
        public string PlantillaCorreoPedido(Pedido pedido, float total, List<Producto> carritoDeCompras)
        {
            
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            var pathToFile = _env.WebRootPath
                          + Path.DirectorySeparatorChar.ToString()
                          + "EmailTemplates"
                          + Path.DirectorySeparatorChar.ToString()
                          + "PedidoEmail.html";


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                body = SourceReader.ReadToEnd();
            }
            string direccion = $"{pedido.IdDireccionNavigation.IdProvinciaNavigation.Nombre},{pedido.IdDireccionNavigation.IdCantonNavigation.Nombre},{pedido.IdDireccionNavigation.IdDistritoNavigation.Nombre}";
            string direccionDetalles = $" {pedido.IdDireccionNavigation.Detalles}";
            body =  body.Replace("{fechaPedido}", pedido.FechaPedido.Date.ToShortDateString());
            body = body.Replace("{idPedido}", pedido.Id.ToString());
            body = body.Replace("{direccion}",direccion);
            body = body.Replace("{direccionDetalles}", direccionDetalles);
            body = body.Replace("{cliente}", pedido.IdClienteNavigation.FullName);
            body = body.Replace("{fechaDeEntrega}", pedido.FechaEntrega.Date.ToShortDateString());
            body = body.Replace("{metodoDePago}", (@ViewBag.opcionesDePago).ToString());
            body = body.Replace("{Total}", total.ToString());
            body = body.Replace("{trs}", DrawTable(carritoDeCompras));
            body = body.Replace("{notas}", pedido.Notas);


            return body;
        }
        private string DrawTable(List<Producto> carritoDeCompras)
        {
            string trs = "";
            foreach(var producto in carritoDeCompras)
            {
                trs +=
                "<tr><td style=\"font-size: 12px; font-family: 'Open Sans', sans-serif; color: #bd4e09;  line-height: 18px;  vertical-align: top; padding:10px 0\" class=\"article\">" + producto.Nombre+"</td>" +
                 "<td style=\"font-size: 12px; font-family: 'Open Sans', sans-serif; color: #bd4e09;  line-height: 18px;  vertical-align: top; padding:10px 0;\"><small>" + producto.Cantidad + " </small></td>" +
                 " <td style=\"font-size: 12px; font-family: 'Open Sans', sans-serif; color: #bd4e09;  line-height: 18px;  vertical-align: top; padding:10px 0;\" align=\"center\">  " + producto.Precio  + "</td> " +
                "<td style=\"font-size: 12px; font-family: 'Open Sans', sans-serif; color: #bd4e09;  line-height: 18px;  vertical-align: top; padding:10px 0;\" align=\"right\">" + producto.Subtotal+ "</td></tr>";
            }
            return trs;
              
        }

       
        
    }
}
