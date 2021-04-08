using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using AsopaabiOnline.AccesoADatos;

namespace AsopaabiOnline.LogicaDeNegocio
{                                                           //Clase coordinador de pedidos 
    public class CoordinadorDePedidos
    {

        //se solicita al gestor de pedidos  agregar un pedido
        public void Agregar(Modelo.Pedido elPedido)
        {

            GestorDePedidos elGestor = new GestorDePedidos();
            elPedido.Estado = Modelo.EstadoDePedido.Reciente;
            elPedido.FechaPedido = DateTime.Now;
            elPedido.FechaEntrega = DateTime.Now.AddDays(5);
            elGestor.Agregar(elPedido);
        }


        //se solicita al gestor de pedidos buscar un pedido por id
        public Modelo.Pedido ObtenerPedidoPorId(int id)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerPedidoPorId(id);
        }

        //se solicita al gestor de pedidos la lista de todos los pedidos
        public List<Pedido> ListarPedidos()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidos();
        }

        //se solicita al gestor de pedidos actualizar un pedido
        public void Actualizar (Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoAActualizar = elGestor.ObtenerPedidoPorId(elPedido.Id); //se encuentra el pedido a actualizar

            elPedidoAActualizar.Id = elPedido.Id;
           
            elPedidoAActualizar.FechaEntrega = elPedido.FechaEntrega;
       
           
           

            elGestor.Actualizar(elPedidoAActualizar);

        }

        //se solicita al gestor de pedidos cambiar un pedido a estado en proceso
        public void CambiarAPedidoEnProceso(Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoACambiar = ObtenerPedidoPorId(elPedido.Id); //se encuentra el pedido a cambiar
            elPedidoACambiar.Estado = Modelo.EstadoDePedido.EnProceso; //se cambia a estado en proceso
            elGestor.Actualizar(elPedidoACambiar);  //se solicita al gestor actualizar en el contexto de la base de datos
        }
         
        //se solicita al gestor un pedido por id para verificar si esta en estado en proceso
        public bool SiEstadoEsEnProceso(Modelo.Pedido pedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedido = elGestor.ObtenerPedidoPorId(pedido.Id);//se encuentra el pedido por id
            if (elPedido.Estado == EstadoDePedido.EnProceso)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //se solicita al gestor un pedido por id para verificar si esta en estado finalizado
        public bool SiEstadoEsFinalizado(Modelo.Pedido pedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedido = elGestor.ObtenerPedidoPorId(pedido.Id);//se encuentra el pedido por id
            if (elPedido.Estado == EstadoDePedido.Finalizado)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //se solicita al gestor un pedido por id para verificar si esta en estado reciente
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

        //se solicita al gestor de pedidos cambiar un pedido a estado finalizado

        public void CambiarAPedidoFinalizado(Modelo.Pedido elPedido)
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            var elPedidoACambiar = ObtenerPedidoPorId(elPedido.Id); //se encuentra el pedido a cambiar
            elPedidoACambiar.Estado = Modelo.EstadoDePedido.Finalizado;//se cambia a estado  finalizado
            elGestor.Actualizar(elPedidoACambiar);//se solicita al gestor actualizar en el contexto de la base de datos
        }



        //se solicita al gestor de pedidos la lista de pedidos recientes
        public List<Pedido> ListarPedidosRecientes()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidosRecientes();
        }

        //se solicita al gestor de pedidos la lista de pedidos en proceso
        public List<Pedido> ListarPedidosEnProceso()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidosEnProceso();
        }

        //se solicita al gestor de pedidos la lista de pedidos en proceso
        public List<Pedido> ListarPedidosFinalizados()
        {
            GestorDePedidos elGestor = new GestorDePedidos();
            return elGestor.ObtenerLaListaDePedidosFinalizados();
        }


        //se solicita al gestor un pedido por id para verificar si existe o no

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
