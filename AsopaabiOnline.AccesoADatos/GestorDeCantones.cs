using AsopaabiOnline.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsopaabiOnline.AccesoADatos
{                                                        //clase: gestor de cantones
    public class GestorDeCantones
    {

        //consulta en la tabla canton la lista de cantones de san jose 
        public List<Modelo.Canton> ObtenerListaDeCantonesDeSanJose()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton   //se busca en la tabla canton  los cantones cuya provincia sea igual a uno.
                              where elCanton.IdProvincia ==1
                              select elCanton;
            return elResultado.ToList();  

        }

        //consulta en la tabla canton la lista de cantones de Alajuela
        public List<Modelo.Canton> ObtenerListaDeCantonesDeAlajuela()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton   //se busca en la tabla canton  los cantones cuya provincia sea igual a dos
                              where elCanton.IdProvincia ==2
                              select elCanton;
            return elResultado.ToList();
        }


        //consulta en la tabla canton la lista de cantones de cartago
        public List<Modelo.Canton> ObtenerListaDeCantonesDeCartago()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton  //se busca en la tabla canton  los cantones cuya provincia sea igual a tres
                              where elCanton.IdProvincia == 3
                              select elCanton;
            return elResultado.ToList();
        }

        //consulta en la tabla canton la lista de cantones de heredia
        public List<Modelo.Canton> ObtenerListaDeCantonesDeHeredia()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 4   //se busca en la tabla canton  los cantones cuya provincia sea igual a cuatro
                              select elCanton;
            return elResultado.ToList();
        }

        //consulta en la tabla canton la lista de cantones de guanacaste
        public List<Modelo.Canton> ObtenerListaDeCantonesDeGuanacaste()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 5  //se busca en la tabla canton  los cantones cuya provincia sea igual a cinco
                              select elCanton;
            return elResultado.ToList();
        }

        //se busca en la tabla canton un canton en especifico por id
        public Canton ObtenerCantonesPorId(int idCanton)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Canton.Find(idCanton);
            return elResultado;
                             

        }

        //consulta en la tabla canton la lista de cantones de puntarenas 
        public List<Modelo.Canton> ObtenerListaDeCantonesDePuntarenas()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 6  //se busca en la tabla canton  los cantones cuya provincia sea igual a seis
                              select elCanton;
            return elResultado.ToList();
        }

        //consulta en la tabla canton la lista de cantones de limon
        public List<Modelo.Canton> ObtenerListaDeCantonesDeLimon()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elCanton in laBaseDeDatos.Canton
                              where elCanton.IdProvincia == 7  //se busca en la tabla canton  los cantones cuya provincia sea igual a siete
                              select elCanton;
            return elResultado.ToList();
        }

    }
}
