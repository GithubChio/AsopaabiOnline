using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
   public class CoordinadorDeCantones
    {
        public List<Modelo.Canton> ObtenerCantonesDeSanJose()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeSanJose();
        }

        public List<Modelo.Canton> ObtenerCantonesDeAlajuela()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeAlajuela();
        }

        public List<Modelo.Canton> ObtenerCantonesDeCartago()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeCartago();
        }

        public List<Modelo.Canton> ObtenerCantonesDeHeredia()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeHeredia();
        }
        public List<Modelo.Canton> ObtenerCantonesDeGuanacaste()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeGuanacaste();
        }

        public List<Modelo.Canton> ObtenerCantonesDePuntarenas()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDePuntarenas();
        }

        public List<Modelo.Canton> ObtenerCantonesDeLimon()
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerListaDeCantonesDeLimon();
        }

       public Modelo.Canton ObtenerCantonesporId(int idCanton)
        {
            GestorDeCantones elGestor = new GestorDeCantones();
            return elGestor.ObtenerCantonesPorId(idCanton);
        }

       
        public List<Modelo.Canton> ListarCantonesPorIdDeProvincia(int idProvincia)
        {
            CoordinadorDeProvincias elCoordinador = new CoordinadorDeProvincias();
            var laProvincia = elCoordinador.ObtenerProviciasPorId(idProvincia);

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
