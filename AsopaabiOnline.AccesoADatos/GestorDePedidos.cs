using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDePedidos
    {
        public void Agregar(Modelo.Pedido elPedido)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
            laBaseDeDatos.Pedido.Add(elPedido);
            laBaseDeDatos.Entry(elPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            laBaseDeDatos.SaveChanges();
        }

        public List<Pedido> ObtenerLaListaDePedidos()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              select losPedidos;

            return elResultado.ToList();
        }

        public Modelo.Pedido ObtenerPedidoPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Pedido.Find(id);
            return elResultado;
        }

        public void Actualizar(Pedido elPedidoAActualizar)
        {
            var laBaseDeDatos = new Contexto();
            var elPedidoEnLaBD = ObtenerPedidoPorId(elPedidoAActualizar.Id);

            elPedidoEnLaBD.Id = elPedidoAActualizar.Id;
           
            elPedidoEnLaBD.FechaEntrega = elPedidoAActualizar.FechaEntrega;
            elPedidoEnLaBD.Notas = elPedidoAActualizar.Notas;
            elPedidoEnLaBD.Estado = elPedidoAActualizar.Estado;
            elPedidoEnLaBD.IdDireccion = elPedidoAActualizar.IdDireccion;
            elPedidoEnLaBD.IdCliente = elPedidoAActualizar.IdCliente;

            laBaseDeDatos.Entry(elPedidoEnLaBD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            laBaseDeDatos.SaveChanges();

        }

        public List<Pedido> ObtenerLaListaDePedidosRecientes()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.Reciente
                              select losPedidos;

            return elResultado.ToList();
        }
        public List<Pedido> ObtenerLaListaDePedidosEnProceso()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.EnProceso
                              select losPedidos;

            return elResultado.ToList();
        }
        public List<Pedido> ObtenerLaListaDePedidosFinalizados()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.Finalizado
                              select losPedidos;

            return elResultado.ToList();
        }

       

       
    }
}
