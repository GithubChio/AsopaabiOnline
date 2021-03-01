using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDetallePedido
    {
        public List<DetallePedido> ObtenerLaListaDetallPedido(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from detalle in laBaseDeDatos.DetallePedido
                             where detalle.IdPedidoNavigation.Id == id
                             
                              select detalle;

            return elResultado.ToList();
        }
    }
}
