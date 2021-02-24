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

     
        public List<Modelo.DireccionPedido> ListarDirecciones(string idCliente)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
          
            return  elGestor.ListarDirecciones(idCliente);
        }
        
      



        public Modelo.DireccionPedido ObtenerDireccionesPorId(int id)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            return elGestor.ObtenerDireccionesPorId(id);
        }
       
        public bool SiExiste(DireccionPedido direccionPedido)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            Modelo.DireccionPedido laDireccion = elGestor.ObtenerDireccionesPorId(direccionPedido.Id);
            if (laDireccion != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       


        public void Eliminar(DireccionPedido laDireccionAEliminar)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            Modelo.DireccionPedido laDireccion = elGestor.ObtenerDireccionesPorId(laDireccionAEliminar.Id);
            elGestor.Eliminar(laDireccion);
        }
    }




}
