using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.Modelo;
using System.Linq;
namespace AsopaabiOnline.AccesoADatos
{                                                        //clase: gestor de direcciones para pedidos
    public class GestorDeDireccionesParaPedidos
    {

        //Permite agregar a la tabla de DireccionPedido una direccion de un usuario
        public void Agregar(Modelo.DireccionPedido laDireccionDelPedido) 
        {
            
              Modelo.Contexto laBaseDeDatos = new Contexto();
            
            laBaseDeDatos.DireccionPedido.Add(laDireccionDelPedido);  //comienza el proceso para agregar la direccion a la tabla de Direcciones  pero se guarda hasta que se indique el comando SaveChanges()
            laBaseDeDatos.Entry(laDireccionDelPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added; //el comando entry proporciona acceso a la información de seguimiento de cambios y las operaciones a la entidad.
            laBaseDeDatos.SaveChanges(); //Guarda todos los cambios hechos en el contexto de la  base de datos 
        }

        //se realiza una consulta a la tabla direcciones de todas las direcciones asociadas a un id de un cliente en especifico.
        public List<DireccionPedido> ListarDirecciones(string idCliente)
        {
            Contexto laBaseDeDatos = new Contexto();
            var elResultado = from laDireccion in laBaseDeDatos.DireccionPedido
                              where laDireccion.IdCliente == idCliente
              
                              select laDireccion;

            return elResultado.ToList();
        }
      

        //se busca una direccion por numero de id  
        public DireccionPedido ObtenerDireccionPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.DireccionPedido.Find(id);
            return elResultado;
        }

        

        //se elimina una direccion de la tabla DireccionPedido de la base de datos
        public void Eliminar(DireccionPedido laDireccionAEliminar)
        {
            var laBaseDeDatos = new Contexto();
            var laDireccionEnlaBD = ObtenerDireccionPorId(laDireccionAEliminar.Id); //se obtiene la direccion por el id

            laBaseDeDatos.DireccionPedido.Remove(laDireccionEnlaBD); //se comienza el proceso para eliminar de la tabla DireccionPedido la direccion
            laBaseDeDatos.Remove(laDireccionEnlaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted; //elimina por completo la direccion cuando  se indique el comando SaveChanges()
            laBaseDeDatos.SaveChanges();//Guarda todos los cambios hechos en el contexto de la  base de datos 
        }


    }
}
