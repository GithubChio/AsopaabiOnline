using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeHistorialPedidos
    {
        public void Agregar(HistorialPedido historialPedido)
        {
            var laBaseDeDatos = new Contexto();
            laBaseDeDatos.HistorialPedido.Add(historialPedido);
            laBaseDeDatos.Entry(historialPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        public List<HistorialPedido> ListarHistorialDePedidos(string idCliente)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elHistorial in laBaseDeDatos.HistorialPedido
                              where elHistorial.IdCliente == idCliente
                              select elHistorial;

            return elResultado.ToList();
                 
        }
    }
}
