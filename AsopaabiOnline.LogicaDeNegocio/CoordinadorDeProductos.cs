using System;
using System.Collections.Generic;
using System.IO;

using AsopaabiOnline.AccesoADatos;
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
            elProductoAActualizar.Nombre = elProducto.Nombre;
            elProductoAActualizar.UnidadDeMedida = elProducto.UnidadDeMedida;
            elProductoAActualizar.Precio = elProducto.Precio;
           

            elGestor.Actualizar(elProductoAActualizar);
            
        }

        public void Eliminar(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoAEliminar = elGestor.ObtenerProductoPorId(elProducto.Id);
            elGestor.Eliminar(elProductoAEliminar);

        }
        
        public Modelo.Producto ObtenerProductoPorId(int id)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerProductoPorId(id);
        }

        public void CambiarACategoriaFrutas(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Categoria = Modelo.CategoriaDeProducto.Frutas;
            elGestor.Actualizar(elProductoACambiar);

        }
        public void CambiarACategoriaHortalizas(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Categoria = Modelo.CategoriaDeProducto.Hortalizas;
            elGestor.Actualizar(elProductoACambiar);
        }
        public void CambiarACategoriaRaicesYTuberculos(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Categoria = Modelo.CategoriaDeProducto.Raices_y_Tuberculos;
            elGestor.Actualizar(elProductoACambiar);
        }
        public void CambiarACategoriaFloresAromaticas(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Categoria = Modelo.CategoriaDeProducto.FloresAromaticas;
            elGestor.Actualizar(elProductoACambiar);
        }
        public void CambiarACategoriaOtro(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Categoria = Modelo.CategoriaDeProducto.Otro;
            elGestor.Actualizar(elProductoACambiar);
        }

        public void CambiarAEstadoDisponible(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Estado = Modelo.EstadoDeProducto.Disponible;
            elGestor.Actualizar(elProductoACambiar);

        }
        public void CambiarAEstadoEnOferta(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Estado = Modelo.EstadoDeProducto.EnOferta;
            elGestor.Actualizar(elProductoACambiar);

        }
        public void CambiarAEstadoNoDisponible(Modelo.Producto elProducto)
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            var elProductoACambiar = elGestor.ObtenerProductoPorId(elProducto.Id);

            elProductoACambiar.Estado = Modelo.EstadoDeProducto.NoDisponible;
            elGestor.Actualizar(elProductoACambiar);

        }


        public List<Modelo.Producto> ListaDeFrutas()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductosConCategoriaDeFruta();
        }
        public List<Modelo.Producto> ListaDeHortalizas()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductosConCategoriaHortalizas();
        }
        public List<Modelo.Producto> ListaDeRaicesYTuberculos()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductosConCategoriaRaicesYTuberculos();
        }
        public List<Modelo.Producto> ListaDeFloresAromaticas()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductosConCategoriaFloresAromaticas();
        }

        public List<Modelo.Producto> ListaDeOtrosProductos()
        {
            GestorDeProductos elGestor = new GestorDeProductos();
            return elGestor.ObtenerListaDeProductosConCategoriaOtros();
        }
    }
}
