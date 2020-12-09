using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDePedidos
    {
        public List<Pedido> ObtenerLaListaDePedidos()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              select losPedidos;

            return elResultado.ToList();
        }
    }
}
