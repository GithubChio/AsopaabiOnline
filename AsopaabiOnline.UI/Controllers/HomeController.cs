using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsopaabiOnline.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Tienda()
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var list = elCoordinador.ListarProductos();

            return View(list);
        }




        [HttpPost]
        public IActionResult AñadirAlCarrito (int id,int cantidad)
        {

            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var producto = elCoordinador.ObtenerProductoPorId(id);
            if (producto == null)
            {
                ViewBag.mensaje = "no hay productos";
            }
            else
            {
                producto.Cantidad = cantidad;

               if(producto.Cantidad == 0)
                {
                    ViewBag.mensaje = "Agregue una cantidad";

                }
                else {

                    if (SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList") == null)
                    {

                        List<Producto> lista = new List<Producto>();

                        lista.Add(producto);
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", lista);

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

                    }

                }

                


            }
            return RedirectToAction("Tienda", "Home");


        }


        [HttpGet]
        public IActionResult CarritoDeCompras()
        {

    
            if (SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList") == null)
            {

                return RedirectToAction("Tienda", "Home");

            }
            else
            {

                var carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
                ViewBag.cart = carritoDeCompras;
                ViewBag.total = carritoDeCompras.Sum(producto => producto.Precio * producto.Cantidad);




                return View();
            }
   
        }

        

        public JsonResult CargarDirecciones()
        {
            CoordinadorDeDireccionesParaPedidos coordinadorDeDirecciones = new CoordinadorDeDireccionesParaPedidos();
          var direcciones= coordinadorDeDirecciones.ListarDirecciones();
            return Json(new SelectList(direcciones));
        }




        public IActionResult QuitarDelCarrito(int id)
        {
            List<Producto> carritoDeCompras = SessionHelper.GetObjectFromJson<List<Producto>>(HttpContext.Session, "cartList");
            int index = siExiste(id);
            carritoDeCompras.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartList", carritoDeCompras);
            return RedirectToAction("Tienda");
        }






        //public IActionResult Privacidad()
        //{
        //    return View();
        //}

        //public  IActionResult AcercaDeNosotros()
        //{
        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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






    }
}
