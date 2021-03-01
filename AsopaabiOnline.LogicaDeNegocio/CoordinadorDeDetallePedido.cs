using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeDetallePedido
    {

        public List<DetallePedido> ListarDetallePedido(int id)
        {
            GestorDetallePedido elGestor = new GestorDetallePedido();
            return elGestor.ObtenerLaListaDetallPedido(id);
        }
    }
}
