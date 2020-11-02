using System;
using System.Collections.Generic;
using System.Linq;
using AsopaabiOnline.Modelo;
namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeClientes
    {
        public void Agregar(Modelo.Cliente elCliente)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
            laBaseDeDatos.Cliente.Add(elCliente);
            laBaseDeDatos.Entry(elCliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        public List<Cliente> ObtenerListaDeClientes()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCliente in laBaseDeDatos.Cliente
                              select elCliente;

            return elResultado.ToList();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Cliente.Find(id);
            return elResultado;
        }

        public void Actualizar(Cliente elCliente)
        {
            var laBaseDeDatos = new Contexto();
            var elClienteEnlaBD = ObtenerClientePorId(elCliente.Id);

            elClienteEnlaBD.Id = elCliente.Id;
            elClienteEnlaBD.TipoDni = elCliente.TipoDni;
            elClienteEnlaBD.Dni = elCliente.Dni;
            elClienteEnlaBD.PrimerNombre = elCliente.PrimerNombre;
            elClienteEnlaBD.SegundoNombre = elCliente.SegundoNombre;
            elClienteEnlaBD.PrimerApellido = elCliente.PrimerApellido;
            elClienteEnlaBD.SegundoApellido = elCliente.SegundoApellido;

            laBaseDeDatos.Entry(elClienteEnlaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();

        }
    }
}
