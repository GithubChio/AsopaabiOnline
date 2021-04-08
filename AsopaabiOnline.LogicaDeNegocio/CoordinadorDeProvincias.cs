using System;
using System.Collections.Generic;
using System.Text;

using AsopaabiOnline.AccesoADatos;



namespace AsopaabiOnline.LogicaDeNegocio
{                                         //clase: coordinador de Provincias
    public class CoordinadorDeProvincias
    {
       
        //se solicita al gestor de provincias la lista de todas las provincias
        public List<Modelo.Provincia> ListarProvincias()
        {
            GestorDeProvincias elGestor = new GestorDeProvincias();
            return elGestor.ObtenerListaDeProvincias();

        }

        //se solicita al gestor de provincias una provincia por id
        public Modelo.Provincia ObtenerProviciaPorId(int id)
        {
            GestorDeProvincias elGestor = new GestorDeProvincias();
            return elGestor.ObtenerProvinciaPorId(id);
        }

    }
}
