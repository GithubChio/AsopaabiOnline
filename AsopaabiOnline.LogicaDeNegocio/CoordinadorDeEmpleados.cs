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

    }
}
