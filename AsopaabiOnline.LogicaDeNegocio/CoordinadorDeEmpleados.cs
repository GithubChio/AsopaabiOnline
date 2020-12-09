using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
     public class CoordinadorDeEmpleados
    {

        public void Agregar(Modelo.Empleado elEmpleado) {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();
            elEmpleado.TipoDeEmpleado = Modelo.TipoDeEmpleado.Administrador;
            elGestor.Agregar(elEmpleado);
                
          }
        public List<Modelo.Empleado> ListarEmpleados()
        {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();
            return elGestor.ObtenerListaDeEmpleados();
        }

        public Modelo.Empleado ObtenerEmpleadoPorId(int id)
        {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();

            return elGestor.ObtenerEmpleadoPorId(id);
        }

        public void Actualizar(Modelo.Empleado elEmpleado)
        {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();
            Modelo.Empleado elEmpleadoAActualizar = elGestor.ObtenerEmpleadoPorId(elEmpleado.Id);

            elEmpleadoAActualizar.Id = elEmpleado.Id;
            elEmpleadoAActualizar.PrimerNombre = elEmpleado.PrimerNombre;
            elEmpleadoAActualizar.SegundoNombre = elEmpleado.SegundoNombre;
            elEmpleadoAActualizar.PrimerApellido = elEmpleado.PrimerApellido;
            elEmpleadoAActualizar.SegundoApellido = elEmpleado.SegundoApellido;

            elGestor.Actualizar(elEmpleadoAActualizar);
        }


        public void Eliminar(Modelo.Empleado elEmpleado)
        {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();
            Modelo.Empleado elEmpleadoAEliminar = elGestor.ObtenerEmpleadoPorId(elEmpleado.Id);
            elGestor.Eliminar(elEmpleadoAEliminar);

        }



        public void CambiarAEmpleadoAsistente(Modelo.Empleado elEmpleado)
        {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();
            Modelo.Empleado elEmpleadoACambiar = elGestor.ObtenerEmpleadoPorId(elEmpleado.Id);

            elEmpleadoACambiar.TipoDeEmpleado = Modelo.TipoDeEmpleado.Asistente;
            elGestor.Actualizar(elEmpleadoACambiar);
        }
        public void CambiarAEmpleadoAdministrador(Modelo.Empleado elEmpleado)
        {
            GestorDeEmpleados elGestor = new GestorDeEmpleados();
            Modelo.Empleado elEmpleadoACambiar = elGestor.ObtenerEmpleadoPorId(elEmpleado.Id);

            elEmpleadoACambiar.TipoDeEmpleado = Modelo.TipoDeEmpleado.Asistente;
            elGestor.Actualizar(elEmpleadoACambiar);
        }
    }
}
