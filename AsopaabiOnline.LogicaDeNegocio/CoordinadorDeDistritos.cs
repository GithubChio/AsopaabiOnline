using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
   public class CoordinadorDeDistritos
    {
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDeSanJose()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDeSanJose();
            
        }
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDeAlajuela()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDeAlajuela();

        }
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDeCartago()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDeCartago();

        }
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDeHeredia()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDeHeredia();

        }
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDeGuanacaste()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDeGuanacaste();

        }
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDePuntarenas()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDePuntarenas();

        }
        public List<Modelo.Distrito> ObtenerDistritosDelCantonDeLimon()
        {
            GestorDeDistritos elGestor = new GestorDeDistritos();
            return elGestor.ObtenerDistritosDelCantonDeLimon();

        }


       
        public List<Modelo.Distrito> ListarDistritosPorIdDeCanton(int idCanton)
        {

            CoordinadorDeCantones elCoordinadorDeCantones = new CoordinadorDeCantones();
            var elCanton = elCoordinadorDeCantones.ObtenerCantonesporId(idCanton);
            if (elCanton.Id == 1)
            {
                return ObtenerDistritosDelCantonDeSanJose();
            }
            else if (elCanton.Id == 2)
            {
                return ObtenerDistritosDelCantonDeAlajuela();
            }
            else if (elCanton.Id == 3)
            {
                return ObtenerDistritosDelCantonDeCartago();
            }
            else if (elCanton.Id == 4)
            {
                return ObtenerDistritosDelCantonDeHeredia();
            }
            else if (elCanton.Id == 5)
            {
                return ObtenerDistritosDelCantonDeGuanacaste();
            }
            else if (elCanton.Id == 6)
            {
                return ObtenerDistritosDelCantonDePuntarenas();
            }
            else
            {
                return ObtenerDistritosDelCantonDeLimon();
            }

        }


    }
}
