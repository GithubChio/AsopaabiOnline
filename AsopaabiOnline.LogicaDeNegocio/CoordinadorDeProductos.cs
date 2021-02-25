using System;
using System.Collections.Generic;
using System.IO;

using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Hosting;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeProductos
    {
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
            elProductoAActualizar.Codigo = elProducto.Codigo;
            elProductoAActualizar.Imagen = elProducto.Imagen;
            elProductoAActualizar.Nombre = elProducto.Nombre;
            elProductoAActualizar.UnidadDeMedida = elProducto.UnidadDeMedida;
            elProductoAActualizar.Precio = elProducto.Precio;
            elProductoAActualizar.Estado = elProducto.Estado;
            elProductoAActualizar.Categoria = elProducto.Categoria;
            elGestor.Actualizar(elProductoAActualizar);

        }

        public void Eliminar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoAEliminar = elGestor.ObtenerProductoPorId(elProducto.Id);
            elGestor.Eliminar(elProductoAEliminar);

        }


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


        public Modelo.Producto ObtenerProductoPorId(int id)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerProductoPorId(id);
        }

        public bool SiExiteCodigo(Producto producto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elResultado = elGestor.ObtenerProductoPorCodigo(producto.Codigo);
            if (elResultado.Count > 0 )
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        //public List<Modelo.Producto> ListaDeFrutas()
        //{
        //    GestorDeProductos elGestor = new GestorDeProductos();
        //    return elGestor.ObtenerListaDeProductosConCategoriaDeFruta();
        //}
        //public List<Modelo.Producto> ListaDeHortalizas()
        //{
        //    GestorDeProductos elGestor = new GestorDeProductos();
        //    return elGestor.ObtenerListaDeProductosConCategoriaHortalizas();
        //}
        //public List<Modelo.Producto> ListaDeRaicesYTuberculos()
        //{
        //    GestorDeProductos elGestor = new GestorDeProductos();
        //    return elGestor.ObtenerListaDeProductosConCategoriaRaicesYTuberculos();
        //}
        //public List<Modelo.Producto> ListaDeFloresAromaticas()
        //{
        //    GestorDeProductos elGestor = new GestorDeProductos();
        //    return elGestor.ObtenerListaDeProductosConCategoriaFloresAromaticas();
        //}

        //public List<Modelo.Producto> ListaDeOtrosProductos()
        //{
        //    GestorDeProductos elGestor = new GestorDeProductos();
        //    return elGestor.ObtenerListaDeProductosConCategoriaOtros();
        //}
    }
}
