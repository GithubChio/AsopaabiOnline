using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AsopaabiOnline.UI.Controllers
{
    public class ProductosController : Controller
    {
       private readonly IWebHostEnvironment hostEnvironment;


        public ProductosController(IWebHostEnvironment environment )
        {
            this.hostEnvironment = environment;
        }  

        [HttpGet]
        [Route("Productos/Agregar")]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [Route("Productos/Agregar")]
        public IActionResult Agregar(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elProducto.Imagen = SubirImagen(elProducto);
                elCoordinador.Agregar(elProducto);
                return RedirectToAction("Mostrar");

            }
            catch
            {
                return View();
            }
        }


        public string SubirImagen(Modelo.Producto elProducto)
        {

            string uniqueFileName = null;

            if (elProducto.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "imagenes");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + elProducto.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    elProducto.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        [Route("Productos/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();

           
            return View(elCoordinador.ListarProductos());
        }



    [HttpGet]
    [Route("Productos/Actualizar")]
    public IActionResult Actualizar(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }
    


    [HttpPost]
    [Route("Productos/Actualizar")]
    public IActionResult Actualizar(Modelo.Producto elProducto)
    {
        try
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            elCoordinador.Actualizar(elProducto);
            return RedirectToAction("Mostrar");
        }
        catch
        {
            return View();
        }

        
      
    }

        [HttpGet]
        [Route("Productos/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }



        [HttpPost]
        [Route("Productos/Eliminar")]
        public IActionResult Eliminar(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.Eliminar(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }



        }

        [HttpGet]
        public IActionResult CambiarCategoria(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);
            ViewBag.IdDeproducto = elProductoEncontrado.Id;
            return View();
        }

        [HttpGet]
        [Route("Productos/CategoriaFrutas")]
        public IActionResult CategoriaFrutas(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

       [HttpPost]
        [Route("Productos/CategoriaFrutas")]
        public IActionResult CategoriaFrutas(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarACategoriaFrutas(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        [Route("Productos/CategoriaHortalizas")]
        public IActionResult CategoriaHortalizas(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]
        [Route("Productos/CategoriaHortalizas")]
        public IActionResult CategoriaHortalizas(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarACategoriaHortalizas(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        [Route("Productos/CategoriaRaicesYTuberculos")]
        public IActionResult CategoriaRaicesYTuberculos(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]
        [Route("Productos/CategoriaRaicesYTuberculos")]
        public IActionResult CategoriaRaicesYTuberculos(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarACategoriaRaicesYTuberculos(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        [Route("Productos/CategoriaFloresAromaticas")]
        public IActionResult CategoriaFloresAromaticas(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]
        [Route("Productos/CategoriaFloresAromaticas")]
        public IActionResult CategoriaFloresAromaticas(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarACategoriaFloresAromaticas(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        [Route("Productos/CategoriaOtro")]
        public IActionResult CategoriaOtro(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]

        [Route("Productos/CategoriaOtro")]
        public IActionResult CategoriaOtro(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarACategoriaOtro(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        public IActionResult CambiarEstado(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);
            ViewBag.IdDeproducto = elProductoEncontrado.Id;
            return View();
        }

        [HttpGet]
        [Route("Productos/EstadoDisponible")]
        public IActionResult EstadoDisponible(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]

        [Route("Productos/EstadoDisponible")]
        public IActionResult EstadoDisponible(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarAEstadoDisponible(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        [Route("Productos/EstadoEnOferta")]
        public IActionResult EstadoEnOferta(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]

        [Route("Productos/EstadoEnOferta")]
        public IActionResult EstadoEnOferta(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarAEstadoEnOferta(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        [Route("Productos/EstadoNoDisponible")]
        public IActionResult EstadoNoDisponible(int id)
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
            var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(id);

            return View(elProductoEncontrado);
        }

        [HttpPost]

        [Route("Productos/EstadoNoDisponible")]
        public IActionResult EstadoNoDisponible(Modelo.Producto elProducto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                elCoordinador.CambiarAEstadoNoDisponible(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }

        }


    }

}
