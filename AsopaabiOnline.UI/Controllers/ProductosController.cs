using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AsopaabiOnline.Modelo;

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

        public void EliminarRutaDeImagen(Producto producto)
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(producto.Id);
                string nombreDelaImagen = elProductoEncontrado.Imagen;
                string folder = Path.Combine(hostEnvironment.WebRootPath, "imagenes");

                string filePath = Path.Combine(folder, nombreDelaImagen);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch
            {

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

                if (elProducto.ImageFile != null)
                {
                    elProducto.Imagen = SubirImagen(elProducto);
                }
              

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
                EliminarRutaDeImagen(elProducto);
                elCoordinador.Eliminar(elProducto);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }



        }

        

    

    }

}
