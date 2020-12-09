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
            ObtenerEdad(elCliente);
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
            Modelo.Cliente elClienteAActualizar = elGestor.ObtenerEmpleadoPorId(elCliente.Id);

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

            return elGestor.ObtenerEmpleadoPorId(id);
        }

        //public int ObtenerIdDelCliente(int id)
        //{
        //    GestorDeClientes elGestor = new GestorDeClientes();

        //    var elCliente=elGestor.ObtenerClientePorId(id);
        //    return elCliente.Id;
        //}

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
            Modelo.Cliente elClienteAEliminar = elGestor.ObtenerEmpleadoPorId(elCliente.Id);
            elGestor.Eliminar(elClienteAEliminar);

        }

        public void CambiarAClienteRegular(Modelo.Cliente elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            Modelo.Cliente ClienteACambiar = elGestor.ObtenerEmpleadoPorId(elCliente.Id);
            ClienteACambiar.TipoDeCliente = Modelo.TipoDeCliente.Regular;
            elGestor.Actualizar(ClienteACambiar);
        }

        public void CambiarAClienteFrecuente(Modelo.Cliente elCliente)
        {
            GestorDeClientes elGestor = new GestorDeClientes();
            Modelo.Cliente ClienteACambiar = elGestor.ObtenerEmpleadoPorId(elCliente.Id);
            ClienteACambiar.TipoDeCliente = Modelo.TipoDeCliente.Frecuente;
            elGestor.Actualizar(ClienteACambiar);
        }
    }
}
