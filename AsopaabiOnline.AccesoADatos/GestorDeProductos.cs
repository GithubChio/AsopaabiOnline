using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeProductos
    {
        public void Agregar(Producto elProducto)
        {
            var laBaseDeDatos = new Contexto();
            laBaseDeDatos.Producto.Add(elProducto);
            laBaseDeDatos.Entry(elProducto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }
        public List<Producto> ObtenerListaDeProductos()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              select elProducto;

            return elResultado.ToList();
        }

        public Modelo.Producto  ObtenerProductoPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Producto.Find(id);
            return elResultado;
        }

        public void Actualizar(Producto elProductoAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var elProductoEnLaBD = ObtenerProductoPorId(elProductoAActualizar.Id);

            elProductoEnLaBD.Id = elProductoAActualizar.Id;
            elProductoEnLaBD.Imagen = elProductoAActualizar.Imagen;
            elProductoEnLaBD.Descripcion = elProductoAActualizar.Descripcion;
            elProductoEnLaBD.UnidadDeMedida = elProductoAActualizar.UnidadDeMedida;
            elProductoEnLaBD.PrecioCosto = elProductoAActualizar.PrecioCosto;
            elProductoEnLaBD.PrecioUnitario = elProductoAActualizar.PrecioUnitario;
            elProductoEnLaBD.Utilidad = elProductoAActualizar.Utilidad;
            elProductoEnLaBD.Categoria = elProductoAActualizar.Categoria;
            elProductoEnLaBD.Estado = elProductoAActualizar.Estado;

            laBaseDeDatos.Entry(elProductoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();

        }

        public void Eliminar(Producto elProductoAEliminar)
        {
            var laBaseDeDatos = new Contexto();
            var elProductoEnLaBD = ObtenerProductoPorId(elProductoAEliminar.Id);

            laBaseDeDatos.Producto.Remove(elProductoEnLaBD);
            laBaseDeDatos.Remove(elProductoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            laBaseDeDatos.SaveChanges();
        }
    }
}
