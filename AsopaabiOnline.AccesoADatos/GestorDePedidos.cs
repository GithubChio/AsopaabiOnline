using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDePedidos
    {

        //Permite agregar un nuevo pedido en la tabla de Pedido
        public void Agregar(Modelo.Pedido elPedido)
        {
            Modelo.Contexto laBaseDeDatos = new Contexto();
           
            laBaseDeDatos.Pedido.Add(elPedido); //comienza el proceso para agregar el pedido en la tabla de Pedido  pero se guarda hasta que se indique el comando SaveChanges()
            laBaseDeDatos.Entry(elPedido).State = Microsoft.EntityFrameworkCore.EntityState.Added; //el comando entry proporciona acceso a la información de seguimiento de cambios y las operaciones a la entidad.
            laBaseDeDatos.SaveChanges();//Guarda todos los cambios hechos en el contexto de la  base de datos 
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


        //obtenemos de la tabla de Pedido un pedido en especifico por medio del id
        public Modelo.Pedido ObtenerPedidoPorId(int id)
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = laBaseDeDatos.Pedido.Find(id);
            return elResultado;
        }

        //permite actualizar un pedido en la tabla de Pedido
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
            laBaseDeDatos.SaveChanges(); //Guarda todos los cambios hechos en el contexto de la  base de datos 

        }

        //Busca en la tabla de Pedido la lista de pedidos en estado reciente
        public List<Pedido> ObtenerLaListaDePedidosRecientes()
        {
            var laBaseDeDatos = new Contexto();
            //si en la base de datos el pedido esta en estado reciente
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.Reciente
                              select losPedidos;
          
            return elResultado.ToList();   //devuelve la lista de pedidos recientes
        }

        //Busca en la tabla de Pedido la lista de pedidos en estado  en proceso
        public List<Pedido> ObtenerLaListaDePedidosEnProceso()
        { //si en la base de datos el pedido esta en estado en proceso
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.EnProceso
                              select losPedidos;
        
            return elResultado.ToList();  //devuelve la lista de pedidos en proceso
        }

        //Busca en la tabla de Pedido la lista de pedidos en estado finalizados
        public List<Pedido> ObtenerLaListaDePedidosFinalizados()
        {//si en la base de datos el pedido esta en estado finalizado
            var laBaseDeDatos = new Contexto();
            var elResultado = from losPedidos in laBaseDeDatos.Pedido
                              where losPedidos.Estado == Modelo.EstadoDePedido.Finalizado
                              select losPedidos;
            
            return elResultado.ToList();//devuelve la lista de pedidos finalizados
        }

       

       
    }
}
