using AsopaabiOnline.AccesoADatos;
using System;
using System.Collections.Generic;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeClientes
    {
        public void Agregar(Modelo.Cliente elCliente)

        {
            GestorDeClientes elGestor = new GestorDeClientes();
            elCliente.TipoDeCliente = (int)Modelo.TipoDeCliente.Nuevo;
            elGestor.Agregar(elCliente);
        }

        public List<Modelo.Cliente> ListarClientes()
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            return elGestor.ObtenerListaDeClientes();
        }

        public List<Modelo.Cliente> ListarClientesConCedulaFisica()
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            return elGestor.ObtenerListaDeClientesConCedulaFisica();
        }
        public List<Modelo.Cliente> ListarClientesConCedulaJuridica()
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            return elGestor.ObtenerListaDeClientesConCedulaJuridica();
        }
    }
}
