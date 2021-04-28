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
{  //clase controlador del carrito de compras
    public class CarritoDeComprasController : BaseController//hereda el controlador base para la notificacion de mensajes.
    {
       
        private readonly UserManager<User> userManager; //instancia de la clase  usuario para que sirva como administrador
        private readonly IEmailSender emailSender;  //instancia de la clase por defecto IEmailsender  para  enviar correos 
        private readonly IWebHostEnvironment _env; //instacia de la clase IWebhostEnvironment para agregar/eliminar carpetas en el wwwroot del codigo

        //constructor del controlador de carrito de compras
        public CarritoDeComprasController(UserManager<User> userManager,IEmailSender sender,IWebHostEnvironment environment)
        {

            this.userManager = userManager;
            this.emailSender = sender;
            this._env = environment;

        }

        //Método para añadir productos al carrito de compras

        [HttpPost]
        public IActionResult AñadirAlCarrito(int id, int cantidad)
        {
            try 
            { 
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var producto = elCoordinador.ObtenerProductoPorId(id); //el coordinador obtiene el producto buscado por id
            if (producto == null || cantidad == 0)
            {
                Alert("Primero debe agregar la cantidad de producto al carrito. ¡Inténtelo de nuevo!", NotificationType.warning);
            }
            else  //si el producto no es nulo y la cantidad es valida 
            {

                producto.Cantidad = cantidad;  //se guarda la cantidad en la tabla producto 


                if (SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList") == null)   // condicion: si la lista de productos del carrito esta nulo
                    {

                    List<Producto> lista = new List<Producto>(); //se crea la lista de productos del carrito

                        lista.Add(producto); //se agrega el producto insgresado
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", lista); 
                    Alert("Agregado al carrito.", NotificationType.success);

                }
                else
                { //condicion: si la lista de los productos del carrito de compras no esta nulo 

                    var listaActual = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList"); //se obtiene la lista

                    var indice = siExiste(producto.Id);  // se busca la existencia del producto por id 
                    if (indice != -1) //condicion: si el producto ya existe en la lista del carrito
                    {
                        listaActual[indice].Cantidad += producto.Cantidad;  //se agrega la cantidad al producto de la lista
                        listaActual.Insert(indice, producto); // se inserta el producto a la lista
                        listaActual.RemoveAt(indice); //se elimina el antiguo producto 

                    }
                    else  //condicion: si el producto no existe en el carrito
                    {
                        listaActual.Add(producto); //se agrega el producto al carrito
                    }
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", listaActual);
                    Alert("Agregado al carrito.", NotificationType.success);
                }


            }
            return RedirectToAction("Tienda", "Home");
            
            }
            catch{
                Alert("No se ha podido agregar al carrito", NotificationType.error);
                return RedirectToAction("Tienda", "Home");
            }

        }


        //Método GET para visualizar el carrito de compras
        [HttpGet]
        public async Task<IActionResult> CarritoDeCompras()
        {
            var user = await userManager.GetUserAsync(HttpContext.User); //el administrador de usuarios obtiene el usuario logueado
            ViewBag.simboloDeColon = "₡";
            if (SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList") == null) 
            {

                Alert("No hay productos en el carrito", NotificationType.info);
                return RedirectToAction("Tienda", "Home");
            }
            else
            { //condicion: si el carrito tiene productos 

                var carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");  //se obtiene la lista del carrito de compras
                ViewBag.cart = carritoDeCompras;
                ViewBag.total = carritoDeCompras.Sum(producto => producto.Precio * producto.Cantidad);  //se suma el total del carrito


                CoordinadorDeDireccionesParaPedidos coordinadorDeDireccionesParaPedidos = new CoordinadorDeDireccionesParaPedidos(); 

                CartViewModel viewModel = new CartViewModel();  //se crea un objeto de la clase modelo cartViewModel o ¨carrito de compras model¨
                viewModel.pedido = new Pedido();   //se agrega un nuevo pedido
                viewModel.pedido.ListaDeDirecciones = coordinadorDeDireccionesParaPedidos.ListarDirecciones(user.Id);   //se listan las direcciones utilizadas en la vista 
                return View(viewModel);
            }




        }

        //Método  para quitar un producto del carrito de compras
        public IActionResult QuitarDelCarrito(int id)
        {
            List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");  //instancia del carrito de compras 
            int index = siExiste(id);      //si busca la existencia  del producto o indice 
            carritoDeCompras.RemoveAt(index); //se elimina de la lista del carrito de compras
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", carritoDeCompras); 
            return RedirectToAction("CarritoDeCompras");
        }

        //Método comprobar que exista un producto en especifico en el carrito de compras
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

        //Método para generar el pedido del carrito de compras

        [HttpPost]
        public async Task<JsonResult> GenerarPedido(Pedido pedido, float total)
        {

            
               
                List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
                var user = await userManager.GetUserAsync(HttpContext.User);
                var emailUser = await userManager.GetEmailAsync(user);
                var emailDephault = "asopaabi@outlook.es";
                var db = new Contexto();
                int idPedido = await InsertPedidoAsync(pedido, db, user); //agregar un pedido de forma asyncronica a la tabla Pedido.
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
                   await emailSender.SendEmailAsync(emailDephault, "Pedido", PlantillaCorreoPedido(existePedido, total, carritoDeCompras));

                Alert("Su pedido ha sido enviado.", NotificationType.success);
                    return Json(new {redirectUrl = Url.Action("Mostrar", "HistorialPedidos")});

                }
                return Json(new { redirectUrl = Url.Action("CarritoCompras") });
            
        }

        //Método para agregar pedido a la base de datos
        private async Task<int> InsertPedidoAsync(Pedido pedido, Contexto db, User user)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    CoordinadorDePedidos coordinadorDePedidos = new CoordinadorDePedidos(); //se crea un objeto del coordinador de pedidos

                    pedido.IdCliente = user.Id;
                    coordinadorDePedidos.Agregar(pedido);  // Agrega el pedido con ayuda del coordinador de pedidos
                    await dbContextTransaction.CommitAsync(); // Se hace un commit para asegurar la transacción
                    return pedido.Id;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();

                }
            }
            return 0;
        }

        //Método para agregar el detalle del pedido a la base de datos
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

        //Método para agregar el pago del pedido a la base de datos
        private async Task<bool> InsertPago(Contexto db, int idPedido, Pedido pedido, float total)
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {

                    Pago pago = new Pago(); //se crea un objeto de la clase Pago 
                      //se guardan los datos de pago 
                    pago.IdPedido = idPedido;
                    pago.Monto = total;
                   ViewBag.opcionesDePago = pedido.TipoPago;
                    pago.OpcionesDePago = pedido.TipoPago;
                    
                    db.Pago.Add(pago);//se agrega el pago a la tabla Pago 
                    await db.SaveChangesAsync(); //se guardan los cambios
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

        //Método para enviar plantilla del comprobante de pago al cliente
        public string PlantillaCorreoPedido(Pedido pedido, float total, List<Producto> carritoDeCompras)
        {
            
            string body = string.Empty;
            //using streamreader para leer la plantilla  html   
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


        //Método para dibujar la tabla con los productos, cantidad, precio y subtotal en la plantilla para enviar al correo
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
