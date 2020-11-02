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

        public void Actualizar(Modelo.Cliente elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            Modelo.Cliente elClienteAActualizar = elGestor.ObtenerClientePorId(elCliente.Id);

            elClienteAActualizar.Id = elCliente.Id;
            elClienteAActualizar.TipoDni = elCliente.TipoDni;
            elClienteAActualizar.Dni = elCliente.Dni;
            elClienteAActualizar.PrimerNombre = elCliente.PrimerNombre;
            elClienteAActualizar.SegundoNombre = elCliente.SegundoNombre;
            elClienteAActualizar.PrimerApellido = elCliente.PrimerApellido;
            elClienteAActualizar.SegundoApellido = elCliente.SegundoApellido;

            elGestor.Actualizar(elClienteAActualizar);
    }
}
