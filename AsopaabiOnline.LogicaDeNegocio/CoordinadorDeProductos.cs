using System;
using System.Collections.Generic;
using System.IO;

using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Hosting;

namespace AsopaabiOnline.LogicaDeNegocio
{                                    //clase: coordinador de Productos
    public class CoordinadorDeProductos
    {
        //Solicita al Gestor de productos agregar un nuevo producto
        public void Agregar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            elProducto.Estado = Modelo.EstadoDeProducto.Disponible;
            elGestor.Agregar(elProducto);
        }
        //Solicita al Gestor de productos la lista de productos
        public List<Modelo.Producto> ListarProductos()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductos();
        }

        //Solicita al Gestor de productos actualizar un producto en especifico
        public void Actualizar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoAActualizar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoAActualizar.Id = elProducto.Id;
          
            elProductoAActualizar.Imagen = elProducto.Imagen;
            elProductoAActualizar.Nombre = elProducto.Nombre;
            elProductoAActualizar.UnidadDeMedida = elProducto.UnidadDeMedida;
            elProductoAActualizar.Precio = elProducto.Precio;
            elProductoAActualizar.Estado = elProducto.Estado;
            elProductoAActualizar.Categoria = elProducto.Categoria;
            elGestor.Actualizar(elProductoAActualizar);

        }
        //Solicita al Gestor de productos eliminar un producto
        public void Eliminar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoAEliminar = elGestor.ObtenerProductoPorId(elProducto.Id);
            elGestor.Eliminar(elProductoAEliminar);

        }

     //Solicita al Gestor de productos un producto por id para conocer la existencia de un producto en la tabla Productos de la Base de Datos ASOPAABI ONLINE
        public bool SiExiste(Modelo.Producto producto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProducto = elGestor.ObtenerProductoPorId(producto.Id);

            if(elProducto != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Solicita al Gestor de productos obtener un producto por el id
        public Modelo.Producto ObtenerProductoPorId(int id)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerProductoPorId(id);
        }


        //Solicita al Gestor de productos un producto por codigo para conocer la existencia de ese codigo o no .
        public bool SiExiteCodigo(Producto producto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elResultado = elGestor.ObtenerProductosPorCodigo(producto.Codigo);
            if (elResultado.Count > 0 )
            {
                return true;

            }
            else
            {
                return false;
            }

        }

    }
}
