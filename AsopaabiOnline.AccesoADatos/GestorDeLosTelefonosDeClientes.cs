using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeLosTelefonosDeClientes
    {
        public void Agregar(ClienteTelefono elTelefonoDelCliente)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
            
            laBaseDeDatos.ClienteTelefono.Add(elTelefonoDelCliente);
            laBaseDeDatos.Entry(elTelefonoDelCliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            
            laBaseDeDatos.SaveChanges();
        }

        public List<ClienteTelefono> ObtenerListaDeTelefonosDeClientes(int id)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
            Modelo.Cliente elNuevoCliente = new Cliente();
            GestorDeClientes elGestorDeClientes = new GestorDeClientes();

            elNuevoCliente = elGestorDeClientes.ObtenerEmpleadoPorId(id);

            var elResultado = from losTelefonosDelCliente in laBaseDeDatos.ClienteTelefono
                              where losTelefonosDelCliente.IdCliente == elNuevoCliente.Id
                              select losTelefonosDelCliente;

            return elResultado.ToList();
        }




    }
}
