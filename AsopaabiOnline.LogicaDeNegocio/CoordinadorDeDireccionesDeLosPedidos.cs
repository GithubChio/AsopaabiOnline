using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeDireccionesDeLosPedidos
    {

        public void Agregar(Modelo.DireccionPedido laDireccionDelPedido)
        {
            GestorDeDireccionesDeLosPedidos elGestor = new GestorDeDireccionesDeLosPedidos();
            elGestor.Agregar(laDireccionDelPedido);
        }

     
        
        
       

    }

       


    
}
