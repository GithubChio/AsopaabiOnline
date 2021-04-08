using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.LogicaDeNegocio
{
                                                                                     //clase: coordinador de  Detalle Pedido
    public class CoordinadorDeDetallePedido
    {
        //se le solicita al gestor de DetallePedido los detalles de un pedido
        public List<DetallePedido> ListarDetallePedido(Pedido pedido)
        {
            GestorDetallePedido elGestor = new GestorDetallePedido();
            return elGestor.ObtenerLaListaDetallPedido(pedido.Id);
        }
    }
}
