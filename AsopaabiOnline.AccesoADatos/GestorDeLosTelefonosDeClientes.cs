using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeLosTelefonosDeClientes
    {
        //public void Agregar(ClienteTelefono elTelefonoDelCliente)
        //{
        //    Modelo.Contexto laBaseDeDatos = new Contexto();
            
        //    laBaseDeDatos.ClienteTelefono.Add(elTelefonoDelCliente);
        //    laBaseDeDatos.Entry(elTelefonoDelCliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            
        //    laBaseDeDatos.SaveChanges();
        //}

        //public List<ClienteTelefono> ObtenerListaDeTelefonosDeClientes(int id)
        //{
        //    Modelo.Contexto laBaseDeDatos = new Contexto();
        //    Modelo.Cliente elNuevoCliente = new Cliente();
        //    GestorDeClientes elGestorDeClientes = new GestorDeClientes();

        //    elNuevoCliente = elGestorDeClientes.ObtenerClientePorId(id);

        //    var elResultado = from losTelefonosDelCliente in laBaseDeDatos.ClienteTelefono
        //                      where losTelefonosDelCliente.IdCliente == elNuevoCliente.Id
        //                      select losTelefonosDelCliente;

        //    return elResultado.ToList();
        //}

        //public ClienteTelefono ObtenerTelefonoPorId(int id)
        //{
        //    var LaBaseDeDatos = new Contexto();
        //    var elResultado = LaBaseDeDatos.ClienteTelefono.Find(id);
        //    return elResultado;
        //}

        //public void Actualizar(ClienteTelefono elTelefonoAActualizar)
        //{
        //    var laBaseDeDatos = new Contexto();
        //    var elTelefonoEnLaBD = ObtenerTelefonoPorId(elTelefonoAActualizar.Id);
            
        //    elTelefonoEnLaBD.Id = elTelefonoAActualizar.Id;
        //    elTelefonoEnLaBD.Telefono1 = elTelefonoAActualizar.Telefono1;
        //    elTelefonoEnLaBD.Telefono2 = elTelefonoAActualizar.Telefono2;


        //    laBaseDeDatos.Entry(elTelefonoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    laBaseDeDatos.SaveChanges();
        //}


        //public void Eliminar(ClienteTelefono elTelefonoAEliminar)
        //{
        //    var laBaseDeDatos = new Contexto();
        //    var elTelefonoEnLaBD = ObtenerTelefonoPorId(elTelefonoAEliminar.Id);

        //    laBaseDeDatos.ClienteTelefono.Remove(elTelefonoEnLaBD);
        //    laBaseDeDatos.Remove(elTelefonoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //    laBaseDeDatos.SaveChanges();
        //}


    }
}
