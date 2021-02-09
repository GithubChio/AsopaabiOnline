using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.Modelo;
using System.Linq;
namespace AsopaabiOnline.AccesoADatos
{
   public class GestorDeDireccionesParaPedidos
    {

        public void Agregar(Modelo.DireccionPedido laDireccionDelPedido)
        {
            
              Modelo.Contexto laBaseDeDatos = new Contexto();
            
            laBaseDeDatos.DireccionPedido.Add(laDireccionDelPedido); 
            laBaseDeDatos.Entry(laDireccionDelPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        public List<DireccionPedido> ListarDirecciones(string idCliente)
        {
            Contexto laBaseDeDatos = new Contexto();
            var elResultado = from laDireccion in laBaseDeDatos.DireccionPedido
                              where laDireccion.IdCliente == idCliente
              
                              select laDireccion;

            return elResultado.ToList();
        }
      

        public DireccionPedido ObtenerDireccionesPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.DireccionPedido.Find(id);
            return elResultado;
        }

        


        public void Actualizar(DireccionPedido laDireccionAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var laDireccionEnLaBD = ObtenerDireccionesPorId(laDireccionAActualizar.Id);

            laDireccionEnLaBD.Id = laDireccionAActualizar.Id;
            laDireccionEnLaBD.IdProvincia = laDireccionAActualizar.IdProvincia;
            laDireccionEnLaBD.IdCanton = laDireccionAActualizar.IdCanton;
            laDireccionEnLaBD.IdDistrito = laDireccionAActualizar.IdDistrito;
            laDireccionEnLaBD.Detalles = laDireccionAActualizar.Detalles;

            laBaseDeDatos.Entry(laDireccionEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();
        }

        public void Eliminar(DireccionPedido laDireccionAEliminar)
        {
            var laBaseDeDatos = new Contexto();
            var laDireccionEnlaBD = ObtenerDireccionesPorId(laDireccionAEliminar.Id);

            laBaseDeDatos.DireccionPedido.Remove(laDireccionEnlaBD);
            laBaseDeDatos.Remove(laDireccionEnlaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            laBaseDeDatos.SaveChanges();
        }


    }
}
