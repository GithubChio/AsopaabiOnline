using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDePedidos
    {
        public List<Pedido> ListarPedidos()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidos();
        }
    }
}
