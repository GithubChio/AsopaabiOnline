using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDePedidos
    {

        //Permite agregar un pedido en la base de datos 
        public void Agregar(Modelo.Pedido elPedido)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
            //agregamos y guardamos el nuevo pedido en la base de datos
            laBaseDeDatos.Pedido.Add(elPedido);
            laBaseDeDatos.Entry(elPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        //Obtener la lista de pedidos
        public List<Pedido> ObtenerLaListaDePedidos()
        {
            var laBaseDeDatos = new Contexto();

            //se busca todos los pedidos existentes en la base de datos

            var elResultado = from losPedidos in laBaseDeDatos.Pedido orderby losPedidos.FechaPedido descending
                              select losPedidos;

            return elResultado.ToList();
        }


        //obtenemos un pedido en especifico
        public Modelo.Pedido ObtenerPedidoPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Pedido.Find(id);
            return elResultado;
        }

        //Metodo que permite actualizar un pedido 
        public void Actualizar(Pedido elPedidoAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var elPedidoEnLaBD = ObtenerPedidoPorId(elPedidoAActualizar.Id);//Encontramos el pedido a actualizar
              //le asignamos los nuevos valores
            elPedidoEnLaBD.Id = elPedidoAActualizar.Id;
            elPedidoEnLaBD.FechaEntrega = elPedidoAActualizar.FechaEntrega;
            elPedidoEnLaBD.Notas = elPedidoAActualizar.Notas;
            elPedidoEnLaBD.Estado = elPedidoAActualizar.Estado;
            elPedidoEnLaBD.IdDireccion = elPedidoAActualizar.IdDireccion;
            elPedidoEnLaBD.IdCliente = elPedidoAActualizar.IdCliente;
            //actualizamos y guardamos los cambios 
            laBaseDeDatos.Entry(elPedidoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();

        }

        //Obtener la lista de pedidos recientes
        public List<Pedido> ObtenerLaListaDePedidosRecientes()
        {
            var laBaseDeDatos = new Contexto();
            //si en la base de datos el pedido esta en estado reciente 
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.Reciente
                              select losPedidos;
            //devuelve la lista de pedidos recientes
            return elResultado.ToList();
        }
        //Obtener la lista de pedidos en proceso
        public List<Pedido> ObtenerLaListaDePedidosEnProceso()
        { //si en la base de datos el pedido esta en estado en proceso
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.EnProceso
                              select losPedidos;
            //devuelve la lista de pedidos en  proceso
            return elResultado.ToList();
        }

        //Obtener la lista de pedidos finalizados
        public List<Pedido> ObtenerLaListaDePedidosFinalizados()
        {//si en la base de datos el pedido esta en estado finalizado
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.Finalizado
                              select losPedidos;
            //devuelve la lista de pedidos finalizados
            return elResultado.ToList();
        }

       

       
    }
}
