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

        public List<Cliente> ObtenerListaDeClientesConCedulaFisica()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCliente in laBaseDeDatos.Cliente
                              where elCliente.TipoDni==(int)Modelo.TipoDeDni.CedulaFisica
                              select elCliente;

            return elResultado.ToList();
           
        }

        public List<Cliente> ObtenerListaDeClientesConCedulaJuridica()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCliente in laBaseDeDatos.Cliente
                              where elCliente.TipoDni == (int)Modelo.TipoDeDni.CedulaJuridica
                              select elCliente;

            return elResultado.ToList();
        }
    }
}
