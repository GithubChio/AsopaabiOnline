using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeLosTelefonosDeClientes
    {
        
        public void Agregar(Modelo.ClienteTelefono elTelefonoDelCliente)
        {
            GestorDeLosTelefonosDeClientes elGestor = new GestorDeLosTelefonosDeClientes();
            
            elGestor.Agregar(elTelefonoDelCliente);
        }

        public Modelo.ClienteTelefono  ObtenerIdDelCliente(int id)
        {
            Modelo.ClienteTelefono elTelefonoDeCliente = new Modelo.ClienteTelefono();
            CoordinadorDeClientes elCoordinadorDeClientes = new CoordinadorDeClientes();

            var elClienteEncontrado = elCoordinadorDeClientes.ObtenerClientePorId(id);
            elTelefonoDeCliente.IdCliente = elClienteEncontrado.Id;

            return elTelefonoDeCliente;
        }

        public List<Modelo.ClienteTelefono> ListarTelefonosDeClientes(int id)
        {
            GestorDeLosTelefonosDeClientes elGestor = new GestorDeLosTelefonosDeClientes();
            return elGestor.ObtenerListaDeTelefonosDeClientes(id);
        }


    }
}
