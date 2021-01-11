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

       
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Pedido")]
        public DateTime FechaPedido { get; set; }

       
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }



        [Required(ErrorMessage = "Las notas son requeridas")]
        public string Notas { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public EstadoDePedido Estado { get; set; }

       
        [NotMapped]
        [Display(Name ="Id de Direccion")]
        public int IdDireccion { get; set; }
        [NotMapped]
        [Display(Name = "Id de Cliente")]
        public int IdCliente { get; set; }

        
        [NotMapped]
        public List<Modelo.DireccionPedido> ListaDeDirecciones { get; set; }

        [NotMapped]
        public List<Modelo.Cliente> ListaDeClientes { get; set; }


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
