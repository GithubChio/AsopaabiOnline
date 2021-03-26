using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeUsuarios
    {

        //Obtiene toda la lista de usuarios  
        public List<AspNetUsers> ObtenerListaDeUsuarios()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elUsuario in laBaseDeDatos.AspNetUsers //se buscan todos los usuarios que se encuentren la tabla AspNetUsers  en la base de datos ASOPAABI ONLINE
                              select elUsuario;
            return elResultado.ToList();
        }

        // Obtiene un usuario por numero de ID 

        public AspNetUsers ObtenerUsuarioPorId(string id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.AspNetUsers.Find(id);//se busca un usuario en la base de datos ASOPAABI ONLINE
            return elResultado; // se obtiene el 

        }
        
    }
}
