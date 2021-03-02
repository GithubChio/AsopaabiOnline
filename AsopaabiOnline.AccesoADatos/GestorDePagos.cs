using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDePagos
    {

        public  List<Pago> ListarPago(int idPedido)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elPago in laBaseDeDatos.Pago
                              where elPago.IdPedido ==idPedido
                              select elPago;
            return elResultado.ToList();

        }
       
    }
}
