using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDePagos
    {
        //Se obtiene el  pago de un pedido
        public List<Pago> ListarPago(int idPedido)
        {
            var laBaseDeDatos = new Contexto();
            //se consulta a la base de datos buscando un pago con ese pedido
            var elResultado = from elPago in laBaseDeDatos.Pago
                              where elPago.IdPedido ==idPedido
                              select elPago;

            //devuelve la lista
            return elResultado.ToList();

        }
       
    }
}
