using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedido = new HashSet<DetallePedido>();
            Empleado = new HashSet<Empleado>();
            HistorialPedido = new HashSet<HistorialPedido>();
            Pago = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Notas { get; set; }
        public EstadoDePedido Estado { get; set; }
       
        public int IdDireccion { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual DireccionPedido IdDireccionNavigation { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
