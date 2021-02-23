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
            elPedido.FechaEntrega = FechaActual.AddDays(8);
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
       
           
           

            elGestor.Actualizar(elPedidoAActualizar);

        }

       
        public void CambiarAPedidoEnProceso(Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoACambiar = ObtenerPedidoPorId(elPedido.Id);
            elPedidoACambiar.Estado = Modelo.EstadoDePedido.EnProceso;
            elGestor.Actualizar(elPedidoACambiar);
        }

        public bool SiEstadoEsEnProceso(Modelo.Pedido pedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedido = elGestor.ObtenerPedidoPorId(pedido.Id);
            if (elPedido.Estado == EstadoDePedido.EnProceso)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public bool SiEstadoEsFinalizado(Modelo.Pedido pedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedido = elGestor.ObtenerPedidoPorId(pedido.Id);
            if (elPedido.Estado == EstadoDePedido.Finalizado)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SiEstadoEsReciente(Modelo.Pedido pedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedido = elGestor.ObtenerPedidoPorId(pedido.Id);
            if (elPedido.Estado == EstadoDePedido.Reciente)
            {
                return true;
            }
            else
            {
                return false;
            }

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



        public bool siExite(Pedido pedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedido = elGestor.ObtenerPedidoPorId(pedido.Id);
            if (elPedido != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
