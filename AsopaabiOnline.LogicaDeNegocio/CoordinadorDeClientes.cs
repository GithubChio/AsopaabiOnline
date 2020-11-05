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
            elCliente.TipoDeCliente = Modelo.TipoDeCliente.Nuevo;
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

        public Modelo.Cliente ObtenerClientePorId(int id)
        {
            GestorDeClientes elGestor = new GestorDeClientes();

            return elGestor.ObtenerClientePorId(id);
        }

        public int ObtenerEdad(Modelo.Cliente  elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
           int elAñoDeNacimiento = elGestor.ObtenerAñoDeNacimiento(elCliente);
            DateTime laFechaActual = DateTime.Now.Date;
            int elAñoActual = laFechaActual.Year;
      
            int laEdad=0;

            laEdad =(elAñoActual - elAñoDeNacimiento);
            return laEdad;

        }

        public void Eliminar(Modelo.Cliente elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            Modelo.Cliente elClienteAEliminar = elGestor.ObtenerClientePorId(elCliente.Id);
            elGestor.Eliminar(elClienteAEliminar);

        }

        public void CambiarAClienteRegular(Modelo.Cliente elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            Modelo.Cliente ClienteACambiar = elGestor.ObtenerClientePorId(elCliente.Id);
            ClienteACambiar.TipoDeCliente = Modelo.TipoDeCliente.Regular;
            elGestor.Actualizar(ClienteACambiar);
        }

        public void CambiarAClienteFrecuente(Modelo.Cliente elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            Modelo.Cliente ClienteACambiar = elGestor.ObtenerClientePorId(elCliente.Id);
            ClienteACambiar.TipoDeCliente = Modelo.TipoDeCliente.Frecuente;
            elGestor.Actualizar(ClienteACambiar);
        }
    }
}
