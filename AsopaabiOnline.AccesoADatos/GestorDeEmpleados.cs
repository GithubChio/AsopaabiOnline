using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeEmpleados
    {
        public void Agregar(Empleado elEmpleado)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
            laBaseDeDatos.Empleado.Add(elEmpleado);
            laBaseDeDatos.Entry(elEmpleado).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        


        public List<Empleado> ObtenerListaDeEmpleados()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elEmpleado in laBaseDeDatos.Empleado
                              select elEmpleado;
            return elResultado.ToList();
        }

    }
}
