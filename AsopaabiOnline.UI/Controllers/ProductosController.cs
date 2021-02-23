using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Models.Enums;

namespace AsopaabiOnline.UI.Controllers
{
    public class ProductosController : BaseController
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
                if (!elCoordinador.SiExiste(elProducto) || elProducto != null)
                {
                   
                   
                    elProducto.Imagen = SubirImagen(elProducto);
                    elCoordinador.Agregar(elProducto);
                    Alert("Producto guardado.", NotificationType.success);

                    
                }
                else
                {
                    Alert("Parece que este producto ya existe. Inténtalo de nuevo agregando otro!", NotificationType.warning);

                }

                return RedirectToAction("Mostrar");

            }
            catch
            {
                Alert("Se deben completar los campos para agregar el producto.", NotificationType.error);

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
                if (elCoordinador.SiExiste(elProducto))
                {
                  

                    if (elProducto.ImageFile != null)
                    {
                        elProducto.Imagen = SubirImagen(elProducto);
                    }
                    elCoordinador.Actualizar(elProducto);
                    Alert("Producto actualizado.", NotificationType.success);
                }
                else
                {
                    Alert("Parece que este producto NO existe.", NotificationType.warning);
                }
               
              

               
            return View(elProducto);
        }
        catch 
        {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
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
                if (elCoordinador.SiExiste(elProducto))
                {
                    EliminarRutaDeImagen(elProducto);
                    elCoordinador.Eliminar(elProducto);
                    Alert("Producto eliminado.", NotificationType.success);

                }
                else
                {
                    Alert("El producto que intentas eliminar, NO existe!", NotificationType.warning);
                }
               
              
                return RedirectToAction("Mostrar");

            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo!", NotificationType.error);
                return View();
            }



        }

        

    

    }

}
