using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDeDireccionesParaPedidos
    {

        public void Agregar(Modelo.DireccionPedido laDireccionDelPedido)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            elGestor.Agregar(laDireccionDelPedido);
        }

     
        public List<Modelo.DireccionPedido> ListarDirecciones()
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();

           return  elGestor.ListarDirecciones();
        }
        
       //public bool SiVacio()
       // {
       //     GestorDeDireccionesParaPedidos gestorDeDirecciones = new GestorDeDireccionesParaPedidos();
       //     var listaDeDirecciones = gestorDeDirecciones.ListarDirecciones();

       //     if (listaDeDirecciones.Count == 0)
       //     {
       //         return true;
       //     }
       //     else
       //     {
       //         return false;
       //     }

       // }

        public void Actualizar(Modelo.DireccionPedido laDireccion)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            Modelo.DireccionPedido laDireccionAActualizar = elGestor.ObtenerDireccionesPorId(laDireccion.Id);

            laDireccionAActualizar.Id = laDireccion.Id;
            laDireccionAActualizar.IdProvincia = laDireccion.IdProvincia;
            laDireccionAActualizar.IdCanton = laDireccion.IdCanton;
            laDireccionAActualizar.IdDistrito = laDireccion.IdDistrito;
            laDireccionAActualizar.Detalles = laDireccion.Detalles;
            elGestor.Actualizar(laDireccionAActualizar);
        }
       



        public Modelo.DireccionPedido ObtenerDireccionesPorId(int id)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            return elGestor.ObtenerDireccionesPorId(id);
        }
       
        


        public void Eliminar(Modelo.DireccionPedido laDireccionAEliminar)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            Modelo.DireccionPedido laDireccion = elGestor.ObtenerDireccionesPorId(laDireccionAEliminar.Id);
            elGestor.Eliminar(laDireccion);
        }
    }

       


    
}
