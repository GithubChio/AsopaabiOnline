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

        public void Actualizar(Cliente elClienteAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var elClienteEnlaBD = ObtenerClientePorId(elClienteAActualizar.Id);
          
            elClienteEnlaBD.Id = elClienteAActualizar.Id;
            elClienteEnlaBD.TipoDni = elClienteAActualizar.TipoDni;
            elClienteEnlaBD.Dni = elClienteAActualizar.Dni;
            elClienteEnlaBD.PrimerNombre = elClienteAActualizar.PrimerNombre;
            elClienteEnlaBD.SegundoNombre = elClienteAActualizar.SegundoNombre;
            elClienteEnlaBD.PrimerApellido = elClienteAActualizar.PrimerApellido;
            elClienteEnlaBD.SegundoApellido = elClienteAActualizar.SegundoApellido;
            elClienteEnlaBD.TipoDeCliente = elClienteAActualizar.TipoDeCliente;

            laBaseDeDatos.Entry(elClienteEnlaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();

        }

        public int ObtenerAñoDeNacimiento(Cliente elCliente)
        {
            var elClienteEnlaBD = ObtenerClientePorId(elCliente.Id);
            var elAño = elClienteEnlaBD.FechaDeNacimiento.Year;
            return elAño;
        }

        public void Eliminar(Cliente elClienteAEliminar)
        {
            var laBaseDeDatos = new Contexto();
            var elClienteEnlaBD = ObtenerClientePorId(elClienteAEliminar.Id);
            laBaseDeDatos.Cliente.Remove(elClienteEnlaBD);
            laBaseDeDatos.Remove(elClienteEnlaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            laBaseDeDatos.SaveChanges();
        }
    }
}
