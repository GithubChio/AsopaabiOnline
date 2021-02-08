using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeUsuarios
    {
        public List<AspNetUsers> ObtenerListaDeUsuarios()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elUsuario in laBaseDeDatos.AspNetUsers
                              select elUsuario;
            return elResultado.ToList();
        }

        public AspNetUsers ObtenerUsuarioPorId(string id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.AspNetUsers.Find(id);
            return elResultado;

        }
    }
}
