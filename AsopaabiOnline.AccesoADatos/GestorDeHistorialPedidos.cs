using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeHistorialPedidos
    {

        //Permite agregar un historial de pedido en la base de datos 
        public void Agregar(HistorialPedido historialPedido)
        {
            var laBaseDeDatos = new Contexto();
            //se agrega el historial de pedido a la base de datos
            laBaseDeDatos.HistorialPedido.Add(historialPedido);
            laBaseDeDatos.Entry(historialPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //se guardan los cambios
            laBaseDeDatos.SaveChanges();
        }

        //se obtiene la lista del historial de pedidos de un cliente en especifico
        public List<HistorialPedido> ListarHistorialDePedidos(string idCliente)
        {
            var laBaseDeDatos = new Contexto();
         //se buscan los historiales de pedidos por el id del cliente
            var elResultado = from elHistorial in laBaseDeDatos.HistorialPedido orderby elHistorial.IdPedidoNavigation.FechaPedido descending
                              where elHistorial.IdCliente == idCliente
                              select elHistorial;
            //se devuelven los resultados
            return elResultado.ToList();
                 
        }
    }
}
