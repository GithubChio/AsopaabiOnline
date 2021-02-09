using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{
    public class CoordinadorDePedidos
    {

        public void Agregar(Modelo.Pedido elPedido)
        {
          
            GestorDePedidos elGestor = new GestorDePedidos();
            var FechaActual = DateTime.Now;

            elPedido.Estado = Modelo.EstadoDePedido.Reciente;
            elPedido.FechaPedido = FechaActual;
            elGestor.Agregar(elPedido);
        }

        public Modelo.Pedido ObtenerPedidoPorId(int id)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerPedidoPorId(id);
        }

        public List<Pedido> ListarPedidos()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidos();
        }

        
        public void Actualizar (Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoAActualizar = elGestor.ObtenerPedidoPorId(elPedido.Id);

            elPedidoAActualizar.Id = elPedido.Id;
           
            elPedidoAActualizar.FechaEntrega = elPedido.FechaEntrega;
            elPedidoAActualizar.Notas = elPedido.Notas;
            elPedidoAActualizar.Estado = elPedido.Estado;
           

            elGestor.Actualizar(elPedidoAActualizar);

        }

        public void Eliminar (Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoAEliminar = elGestor.ObtenerPedidoPorId(elPedido.Id);
            elGestor.Eliminar(elPedidoAEliminar);
        }

        public void CambiarAPedidoEnProceso(Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoACambiar = ObtenerPedidoPorId(elPedido.Id);
            elPedidoACambiar.Estado = Modelo.EstadoDePedido.EnProceso;
            elGestor.Actualizar(elPedidoACambiar);
        }
        public void CambiarAPedidoFinalizado(Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoACambiar = ObtenerPedidoPorId(elPedido.Id);
            elPedidoACambiar.Estado = Modelo.EstadoDePedido.Finalizado;
            elGestor.Actualizar(elPedidoACambiar);
        }

      

        public List<Pedido> ListarPedidosRecientes()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidosRecientes();
        }
        public List<Pedido> ListarPedidosEnProceso()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidosEnProceso();
        }
        public List<Pedido> ListarPedidosFinalizados()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidosFinalizados();
        }

    }
}
