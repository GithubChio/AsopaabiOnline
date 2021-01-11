using AsopaabiOnline.Modelo;
using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeProvincias
    {

      

        public List<Provincia> ObtenerListaDeProvincias()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from lasProvincias in laBaseDeDatos.Provincia
                              select lasProvincias;

            return elResultado.ToList();
        }

        public Provincia ObtenerProvinciaPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Provincia.Find(id);
            return elResultado;
        }
    }
}
