using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.Modelo;
using System.Linq;
namespace AsopaabiOnline.AccesoADatos
{
   public class GestorDeDireccionesDeLosPedidos
    {

        public void Agregar(Modelo.DireccionPedido laDireccionDelPedido)
        {
            GestorDeProvincias elGestorDeProvincias = new GestorDeProvincias();

            Modelo.Contexto laBaseDeDatos = new Contexto();
            
            laBaseDeDatos.DireccionPedido.Add(laDireccionDelPedido); 
            laBaseDeDatos.Entry(laDireccionDelPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        public List<Modelo.DireccionPedido> ObtenerListaDeDireccionesDeLosPedidos(int id)
        {
            Contexto laBaseDeDatos = new Contexto();
            var elResultado = from laDireccion in laBaseDeDatos.DireccionPedido
                           
                              select laDireccion;
            return elResultado.ToList();
            

        }

        

    }
}
