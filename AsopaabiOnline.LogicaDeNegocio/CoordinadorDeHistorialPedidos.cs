using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.AccesoADatos;



namespace AsopaabiOnline.LogicaDeNegocio
{
   public class CoordinadorDeHistorialPedidos
    {


        public void Agregar(HistorialPedido historialPedido)
        {
            GestorDeHistorialPedidos gestorDeHistorial = new GestorDeHistorialPedidos();
             gestorDeHistorial.Agregar(historialPedido);

        }
        public List<HistorialPedido> ListarHistorialDePedidos(string IdCliente)
        {

            GestorDeHistorialPedidos gestorDeHistorial = new GestorDeHistorialPedidos();
            return gestorDeHistorial.ListarHistorialDePedidos(IdCliente);
        }
    }
}
