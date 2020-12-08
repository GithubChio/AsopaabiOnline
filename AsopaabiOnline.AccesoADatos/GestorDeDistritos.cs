using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeDistritos
    {
        public List<Distrito> ObtenerDistritosDelCantonDeSanJose()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 1 
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeAlajuela()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 2
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeCartago()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 3
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeHeredia()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 4
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeGuanacaste()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 5
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDePuntarenas()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 6
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeLimon()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 7
                              select elDistrito;
            return elResultado.ToList();
        }
    }
}
