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

        public Empleado ObtenerEmpleadoPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Empleado.Find(id);
            return elResultado;
        }

        public void Actualizar(Empleado elEmpleadoAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var elEmpleadoEnLaBD = ObtenerEmpleadoPorId(elEmpleadoAActualizar.Id);

            elEmpleadoEnLaBD.Id = elEmpleadoAActualizar.Id;
            elEmpleadoEnLaBD.PrimerNombre = elEmpleadoAActualizar.PrimerNombre;
            elEmpleadoEnLaBD.SegundoNombre = elEmpleadoAActualizar.SegundoNombre;
            elEmpleadoEnLaBD.PrimerApellido = elEmpleadoAActualizar.PrimerApellido;
            elEmpleadoEnLaBD.SegundoApellido = elEmpleadoAActualizar.SegundoApellido;
            elEmpleadoEnLaBD.TipoDeEmpleado = elEmpleadoAActualizar.TipoDeEmpleado;

            laBaseDeDatos.Entry(elEmpleadoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();
        }

        public void Eliminar(Empleado elEmpleadoAEliminar)
        {
            var laBaseDeDatos = new Contexto();
            var elEmpleadoEnLaBD = ObtenerEmpleadoPorId(elEmpleadoAEliminar.Id);
            laBaseDeDatos.Empleado.Remove(elEmpleadoEnLaBD);
            laBaseDeDatos.Remove(elEmpleadoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            laBaseDeDatos.SaveChanges();
        }
    }
}
