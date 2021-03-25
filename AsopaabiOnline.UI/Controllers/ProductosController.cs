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


        //Método GET y  POST para agregar productos
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
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();  // se crea un objeto coordinador.
                if ( !elCoordinador.SiExiste(elProducto) || elProducto != null)
                {
                    if (elCoordinador.SiExiteCodigo(elProducto))
                    {
                        Alert("Parece que ya existe un producto con ese código,Inténtalo de nuevo agregando otro código diferente! ", NotificationType.warning);
                        return View(elProducto);
                    }
                    elProducto.Imagen = SubirImagen(elProducto); // se carga la imagen al codigo y se le asigna el nombre de la imagen del producto que se va a guardar
                    elCoordinador.Agregar(elProducto); // se agregan los productos a la base de datos
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
         


        //Se utiliza para eliminar la ruta de una imagen
        public void EliminarRutaDeImagen(Producto producto) 
        {
            try
            {
                CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();
                var elProductoEncontrado = elCoordinador.ObtenerProductoPorId(producto.Id); //se obtiene el producto
                string nombreDelaImagen = elProductoEncontrado.Imagen; //se obtiene el nombre de la imagen 
                string folder = Path.Combine(hostEnvironment.WebRootPath, "imagenes");  // se obtiene el folder de imagenes donde guardan

                string filePath = Path.Combine(folder, nombreDelaImagen); //creamos la ruta de una imagen en especifico 
                if (System.IO.File.Exists(filePath))  //si la ruta existe entonces se procede a eliminar
                {
                    System.IO.File.Delete(filePath); //se elimina esa ruta de la carpeta 
                }
            }
            catch
            {

            }
        }

        //Método para subir una imagen en una carpeta del codigo

        public string SubirImagen(Modelo.Producto elProducto)
        {

            string uniqueFileName = null;

            if (elProducto.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "imagenes"); //obtenemos  el folder donde se va a guardar la imagen 
                uniqueFileName = Guid.NewGuid().ToString() + "_" + elProducto.ImageFile.FileName; //generamos un nombre unico para la imagen 
                string filePath = Path.Combine(uploadsFolder, uniqueFileName); //generamos la ruta de la imagen 
                using (var fileStream = new FileStream(filePath, FileMode.Create)) 
                {
                    elProducto.ImageFile.CopyTo(fileStream); //se copia el archivo de la imagen la carpeta
                }
            }
            return uniqueFileName;
        }



        //Método para mostrar la lista de productos
        [HttpGet]
        [Route("Productos/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDeProductos elCoordinador = new CoordinadorDeProductos();

           
            return View(elCoordinador.ListarProductos());
        }


        //Método GET y SET para actualizar un producto
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
                if (elCoordinador.SiExiste(elProducto) )
                {

                    if (elProducto.ImageFile != null) //si se carga el archivo de la imagen entonces se copia al folder 
                    {
                        elProducto.Imagen = SubirImagen(elProducto); //se sube la imagen al folder del codigo
                    }

                    elCoordinador.Actualizar(elProducto); // actualiza los productos
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
                Alert("No es posible actualizar este producto. ¡Inténtalo de nuevo!", NotificationType.error);
                return RedirectToAction("Mostrar");
            }

        
      
    }



        //Método GET y SET para eliminar un producto
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
                    EliminarRutaDeImagen(elProducto); //se elimina la imagen del folder del codigo local 
                    elCoordinador.Eliminar(elProducto); //se elimina el producto
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
                Alert("No es posible eliminar este producto. ¡Inténtalo de nuevo!", NotificationType.error);
                return View();
            }



        }


        



    }

}
