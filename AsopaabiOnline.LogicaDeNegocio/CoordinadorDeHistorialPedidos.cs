using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.AccesoADatos;



namespace AsopaabiOnline.LogicaDeNegocio
{                                                                                 //clase: coordinador de Historial de pedidos
    public class CoordinadorDeHistorialPedidos
    {

        //se solicita al gestor de HistorialPedido  agregar un pedido al historial
        public void Agregar(HistorialPedido historialPedido)
        {
            GestorDeHistorialPedidos gestorDeHistorial = new GestorDeHistorialPedidos();
             gestorDeHistorial.Agregar(historialPedido);

        }

        //se solicita al gestor de HistorialPedido la lista de historial de pedidos de un cliente 
        public List<HistorialPedido> ListarHistorialDePedidos(string IdCliente)
        {

            GestorDeHistorialPedidos gestorDeHistorial = new GestorDeHistorialPedidos();
            return gestorDeHistorial.ListarHistorialDePedidos(IdCliente);
        }
    }
}
