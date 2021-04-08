using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.Modelo;

namespace AsopaabiOnline.LogicaDeNegocio
{                                                                        //clase: coordinador de Direcciones para pedidos
    public class CoordinadorDeDireccionesParaPedidos
    {
        //se solicita al gestor de DireccionPedido agregar una direccion 
        public void Agregar(Modelo.DireccionPedido laDireccionDelPedido)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            elGestor.Agregar(laDireccionDelPedido);
        }


        //se solicita al gestor de DireccionPedido  la lista de direcciones de un cliente 
        public List<Modelo.DireccionPedido> ListarDirecciones(string idCliente)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
          
            return  elGestor.ListarDirecciones(idCliente);
        }

        //se solicita al gestor de DireccionPedido  una direccion por id
        public Modelo.DireccionPedido ObtenerDireccionPorId(int id)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            return elGestor.ObtenerDireccionPorId(id);
        }
       
        //se solicita al gestor una direccion por id para saber si existe o no existe
        public bool SiExiste(DireccionPedido direccionPedido)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            Modelo.DireccionPedido laDireccion = elGestor.ObtenerDireccionPorId(direccionPedido.Id);
            if (laDireccion != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //se solicita al gestor de DireccionPedido  eliminar una direccion por medio del id

        public void Eliminar(DireccionPedido laDireccionAEliminar)
        {
            GestorDeDireccionesParaPedidos elGestor = new GestorDeDireccionesParaPedidos();
            Modelo.DireccionPedido laDireccion = elGestor.ObtenerDireccionPorId(laDireccionAEliminar.Id);
            elGestor.Eliminar(laDireccion);
        }
    }




}
