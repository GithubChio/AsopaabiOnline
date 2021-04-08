using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeUsuarios
    {

        //se consulta en la tabla AspNetUsers todos los usarios encontrados
        public List<AspNetUsers> ObtenerListaDeUsuarios()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elUsuario in laBaseDeDatos.AspNetUsers //se buscan todos los usuarios que se encuentren la tabla AspNetUsers 
                              select elUsuario;
            return elResultado.ToList();
        }

        //se consulta en la tabla AspNetUsers un usuario por medio del id

        public AspNetUsers ObtenerUsuarioPorId(string id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.AspNetUsers.Find(id);//se busca un usuario por el id 
            return elResultado; 

        }
        
    }
}
