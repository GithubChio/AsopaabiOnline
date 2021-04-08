using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.LogicaDeNegocio
{                                                               //clase: coordinador de Pago
    public class CoordinadorDePagos
    {
        //se solicita al gestor de pago la lista de pagos de un pedido
        public List<Pago> ListarPagos(int idPedido)
        {
            GestorDePagos gestorDePago = new GestorDePagos();
           return  gestorDePago.ListarPago(idPedido);
        }

       
    }
}
