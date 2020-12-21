using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="La fecha de pedido es requerida")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Pedido")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es requerida")]
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "Las notas son requeridas")]
        public string Notas { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public EstadoDePedido Estado { get; set; }

       
        [NotMapped]
        public int IdDireccion { get; set; }
        [NotMapped]
        public int IdCliente { get; set; }

        



        [NotMapped]
        public virtual Cliente IdClienteNavigation { get; set; }
        [NotMapped]
        public virtual DireccionPedido IdDireccionNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        [NotMapped]
        public virtual ICollection<Empleado> Empleado { get; set; }
        [NotMapped]
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        [NotMapped]
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
