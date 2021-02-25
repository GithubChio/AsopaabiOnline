using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeUsuarios
    {
        public List<AspNetUsers> ListarUsuarios()
        {
            GestorDeUsuarios elGestor = new GestorDeUsuarios();
            return elGestor.ObtenerListaDeUsuarios();
        }
        public Modelo.AspNetUsers ObtenerUsuarioPorId(string id)
        {
            GestorDeUsuarios elGestor = new GestorDeUsuarios();
            return elGestor.ObtenerUsuarioPorId(id);
        }

        public bool SiExiteDNI(AspNetUsers user)
        {
            GestorDeUsuarios elGestor = new GestorDeUsuarios();
            var elResultado = elGestor.ObtenerUsuarioPorDNI(user.Dni);
            if(elResultado != null)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

    }

}
