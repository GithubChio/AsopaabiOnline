using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.LogicaDeNegocio
{
   public class CoordinadorDePagos
    {
        public List<Pago> ListarPagos(int idPedido)
        {
            GestorDePagos gestorDePago = new GestorDePagos();
           return  gestorDePago.ListarPago(idPedido);
        }

       
    }
}
