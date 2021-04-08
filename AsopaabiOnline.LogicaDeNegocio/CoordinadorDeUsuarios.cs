using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{                                                             //clase: coordinador de usuarios
    public class CoordinadorDeUsuarios
    {
        //solicita al gestor de usuarios la lista de todos los usuarios
        public List<AspNetUsers> ListarUsuarios()
        {
            GestorDeUsuarios elGestor = new GestorDeUsuarios();
            return elGestor.ObtenerListaDeUsuarios();
        }

        //solicita al gestor de usuarios un usuario por id
        public Modelo.AspNetUsers ObtenerUsuarioPorId(string id)
        {
            GestorDeUsuarios elGestor = new GestorDeUsuarios();
            return elGestor.ObtenerUsuarioPorId(id);
        }

        

        

    }

}
