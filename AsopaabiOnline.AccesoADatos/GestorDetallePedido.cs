using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDetallePedido
    {
      //Obtener la lista de detalles de un pedido en especifico
        public List<DetallePedido> ObtenerLaListaDetallPedido(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from detalle in laBaseDeDatos.DetallePedido 
                             where detalle.IdPedido == id  //buscamos en la tabla de DetallePedido el pedido con el mismo id entrante
                             
                              select detalle;

            return elResultado.ToList();
        }
    }
}
