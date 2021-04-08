using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{                                                                       //clase: coordinador de cantones
   public class CoordinadorDeCantones
    { 
        //se solicita al gestor los cantones de San jose
        public List<Modelo.Canton> ObtenerCantonesDeSanJose()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeSanJose();
        }

        //se solicita al gestor los cantones de alajuela
        public List<Modelo.Canton> ObtenerCantonesDeAlajuela()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeAlajuela();
        }

        //se solicita al gestor los cantones de  cartago
        public List<Modelo.Canton> ObtenerCantonesDeCartago()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeCartago();
        }

        //se solicita al gestor los cantones de heredia
        public List<Modelo.Canton> ObtenerCantonesDeHeredia()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeHeredia();
        }

        //se solicita al gestor los cantones de  guanacaste
        public List<Modelo.Canton> ObtenerCantonesDeGuanacaste()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeGuanacaste();
        }

        //se solicita al gestor los cantones de Puntarenas
        public List<Modelo.Canton> ObtenerCantonesDePuntarenas()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDePuntarenas();
        }

        //se solicita al gestor los cantones de limon
        public List<Modelo.Canton> ObtenerCantonesDeLimon()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeLimon();
        }

        //se solicita al gestor un canton por id
        public Modelo.Canton ObtenerCantonporId(int idCanton)
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerCantonesPorId(idCanton);
        }

       // se listan los cantones por id de provincias
        public List<Modelo.Canton> ListarCantonesPorIdDeProvincia(int idProvincia)
        {
            CoordinadorDeProvincias elCoordinador = new CoordinadorDeProvincias();
            var laProvincia = elCoordinador.ObtenerProviciaPorId(idProvincia);

            if (laProvincia.Id == 1)
            {
                return ObtenerCantonesDeSanJose();
            }else if (laProvincia.Id == 2)
            {
                return ObtenerCantonesDeAlajuela();
            }
            else if (laProvincia.Id == 3)
            {
                return ObtenerCantonesDeCartago();
            }
            else if (laProvincia.Id == 4)
            {
                return ObtenerCantonesDeHeredia();
            }
            else if (laProvincia.Id == 5)
            {
                return ObtenerCantonesDeGuanacaste();
            }
            else if (laProvincia.Id == 6)
            {
                return ObtenerCantonesDePuntarenas();
            }
            else 
            {
                return ObtenerCantonesDeLimon();
            }
            

        }




    }
}
