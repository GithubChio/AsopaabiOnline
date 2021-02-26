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
            elProductoEnLaBD.Codigo = elProductoAActualizar.Codigo;
            elProductoEnLaBD.Imagen = elProductoAActualizar.Imagen;
            elProductoEnLaBD.Nombre = elProductoAActualizar.Nombre;
            elProductoEnLaBD.UnidadDeMedida = elProductoAActualizar.UnidadDeMedida;
            elProductoEnLaBD.Precio = elProductoAActualizar.Precio;
                    
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


        public List<Producto> ObtenerProductosPorCodigo(string codigo)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              where elProducto.Codigo == codigo
                              select elProducto;

            return elResultado.ToList();

        }
        public List<Producto> ObtenerListaDeProductosConCategoriaDeFruta()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              where elProducto.Categoria == CategoriaDeProducto.Frutas
                              select elProducto;

            return elResultado.ToList();

        }
        public List<Producto> ObtenerListaDeProductosConCategoriaHortalizas()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              where elProducto.Categoria == CategoriaDeProducto.Hortalizas
                              select elProducto;

            return elResultado.ToList();

        }
        public List<Producto> ObtenerListaDeProductosConCategoriaRaicesYTuberculos()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              where elProducto.Categoria == CategoriaDeProducto.Raices_y_Tuberculos
                              select elProducto;

            return elResultado.ToList();

        }

        public List<Producto> ObtenerListaDeProductosConCategoriaFloresAromaticas()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              where elProducto.Categoria == CategoriaDeProducto.FloresAromaticas
                              select elProducto;

            return elResultado.ToList();

        }

        public List<Producto> ObtenerListaDeProductosConCategoriaOtros()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elProducto in laBaseDeDatos.Producto
                              where elProducto.Categoria == CategoriaDeProducto.Otros
                              select elProducto;

            return elResultado.ToList();

        }
    }
}
