using System;
using System.Collections.Generic;
using System.Text;

using AsopaabiOnline.AccesoADatos;



namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeProvincias
    {
       
        public List<Modelo.Provincia> ListarProvincias()
        {
            GestorDeProvincias elGestor = new GestorDeProvincias();
            return elGestor.ObtenerListaDeProvincias();

        }

        public Modelo.Provincia ObtenerProviciasPorId(int id)
        {
            GestorDeProvincias elGestor = new GestorDeProvincias();
            return elGestor.ObtenerProvinciaPorId(id);
        }

    }
}
