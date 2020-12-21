using System;
using System.Collections.Generic;
using System.IO;

using AsopaabiOnline.AccesoADatos;
using Microsoft.AspNetCore.Hosting;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeProductos
    {
        private readonly IHostingEnvironment hosting;
        public void Agregar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            elProducto.Estado = Modelo.EstadoDeProducto.Disponible;
            elGestor.Agregar(elProducto);
        }
        public List<Modelo.Producto> ListarProductos()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductos();
        }

        public void Actualizar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoAActualizar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoAActualizar.Id = elProducto.Id;
            elProductoAActualizar.Imagen = elProducto.Imagen;
            elProductoAActualizar.Descripcion = elProducto.Descripcion;
            elProductoAActualizar.UnidadDeMedida = elProducto.UnidadDeMedida;
            elProductoAActualizar.PrecioCosto = elProducto.PrecioCosto;
            elProductoAActualizar.PrecioUnitario = elProducto.PrecioUnitario;
            elProductoAActualizar.Utilidad = elProducto.Utilidad;
            elProductoAActualizar.Categoria = elProductoAActualizar.Categoria;
            elProductoAActualizar.Estado = elProducto.Estado;

            elGestor.Actualizar(elProductoAActualizar);
            
        }

        public void Eliminar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoAEliminar = elGestor.ObtenerProductoPorId(elProducto.Id);
            elGestor.Eliminar(elProductoAEliminar);

        }

        public void GuardarLaImagen(Modelo.Producto elProduto)
        {
            
            string rutaDeLaImagen = null;
            if (elProduto.Imagen != null)
            {
                string rutaDeLaCarpeta = Path.Combine(hosting.WebRootPath, "imagenes");
                rutaDeLaImagen = Guid.NewGuid().ToString() + elProduto.Imagen.FileName;
                string rutaDefinitiva = Path.Combine(rutaDeLaCarpeta, rutaDeLaImagen);
                elProduto.Imagen.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
            }

            elProduto.Imagen = rutaDeLaImagen;
        }


    }
}
