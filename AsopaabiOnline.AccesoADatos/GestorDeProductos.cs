using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeProductos
    {

        //Permite agregar un producto en la base de datos 
        public void Agregar(Producto elProducto)
        {
            var laBaseDeDatos = new Contexto();
            //agregamos y guardamos el nuevo producto en la base de datos
            laBaseDeDatos.Producto.Add(elProducto); 
            laBaseDeDatos.Entry(elProducto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        //Permite obtener la lista de productos 
        public List<Producto> ObtenerListaDeProductos()
        {
            var laBaseDeDatos = new Contexto();
            //se busca todos los productos existentes en la base de datos

            var elResultado = from elProducto in laBaseDeDatos.Producto
                              select elProducto;
            return elResultado.ToList();
        }

        //se obtiene  un producto en especifico

        public Modelo.Producto  ObtenerProductoPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Producto.Find(id); //se busca la existencia de un producto en la base de datos
            return elResultado;
        }


       //Metodo que permite actualizar un producto 
        public void Actualizar(Producto elProductoAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var elProductoEnLaBD = ObtenerProductoPorId(elProductoAActualizar.Id); //Encontramos el producto a actualizar
            //le asignamos los nuevos valores
            elProductoEnLaBD.Id = elProductoAActualizar.Id;
            elProductoEnLaBD.Codigo = elProductoAActualizar.Codigo;
            elProductoEnLaBD.Imagen = elProductoAActualizar.Imagen;
            elProductoEnLaBD.Nombre = elProductoAActualizar.Nombre;
            elProductoEnLaBD.UnidadDeMedida = elProductoAActualizar.UnidadDeMedida;
            elProductoEnLaBD.Precio = elProductoAActualizar.Precio;
                    
            elProductoEnLaBD.Categoria = elProductoAActualizar.Categoria;
            elProductoEnLaBD.Estado = elProductoAActualizar.Estado;

            //actualizamos y guardamos los cambios 
            laBaseDeDatos.Entry(elProductoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();

        }
         
        //Permite eliminar un producto de la base de datos.
        public void Eliminar(Producto elProductoAEliminar)
        {
            var laBaseDeDatos = new Contexto();
            var elProductoEnLaBD = ObtenerProductoPorId(elProductoAEliminar.Id); //Encontramos el producto
            //eliminamos de la base de datos
            laBaseDeDatos.Producto.Remove(elProductoEnLaBD);
            laBaseDeDatos.Remove(elProductoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
          //guardamos cambios
            
            laBaseDeDatos.SaveChanges();
        }

        //Obtenemos una lista de productos por codigo 
        public List<Producto> ObtenerProductosPorCodigo(string codigo)
        {
            var laBaseDeDatos = new Contexto();
            //si el codigo del producto buscado es encontrado en la base de datos
            var elResultado = from elProducto in laBaseDeDatos.Producto 
                              where elProducto.Codigo == codigo
                              select elProducto;

            //se devuelve la lista del resultado 
            return elResultado.ToList();

        }

       
    }
}
