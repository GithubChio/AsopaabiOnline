using AsopaabiOnline.Modelo;
using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeProvincias
    {

      //Obtener la lista de provincias

        public List<Provincia> ObtenerListaDeProvincias()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from lasProvincias in laBaseDeDatos.Provincia //Buscamos todas las provincias existentes en la base de datos
                              select lasProvincias;

            return elResultado.ToList();
        }

        //obtener una provincia en especifico
        public Provincia ObtenerProvinciaPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Provincia.Find(id); //Buscamos la provincia por el ID en la base de datos
            return elResultado;
        }
    }
}
