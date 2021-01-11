using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeCantones
    {
        public List<Modelo.Canton> ObtenerListaDeCantonesDeSanJose()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia ==1
                              select elCanton;
            return elResultado.ToList();  

        }

       
        public List<Modelo.Canton> ObtenerListaDeCantonesDeAlajuela()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia ==2
                              select elCanton;
            return elResultado.ToList();
        }

        

        public List<Modelo.Canton> ObtenerListaDeCantonesDeCartago()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 3
                              select elCanton;
            return elResultado.ToList();
        }
        public List<Modelo.Canton> ObtenerListaDeCantonesDeHeredia()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 4
                              select elCanton;
            return elResultado.ToList();
        }
        public List<Modelo.Canton> ObtenerListaDeCantonesDeGuanacaste()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 5
                              select elCanton;
            return elResultado.ToList();
        }

        public Canton ObtenerCantonesPorId(int idCanton)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Canton.Find(idCanton);
            return elResultado;
                             

        }

        public List<Modelo.Canton> ObtenerListaDeCantonesDePuntarenas()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 6
                              select elCanton;
            return elResultado.ToList();
        }
        public List<Modelo.Canton> ObtenerListaDeCantonesDeLimon()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 7
                              select elCanton;
            return elResultado.ToList();
        }

    }
}
