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
            HistorialPedido = new HashSet<HistorialPedido>();
            Pago = new HashSet<Pago>();
        }

        [Key]

        public int Id { get; set; }

       
       
        [Display(Name ="Fecha de Pedido")]
        [DataType(DataType.Date)]
        
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega requerida")]
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date)]
        
        public DateTime FechaEntrega { get; set; }



        [Required(ErrorMessage = "Las notas son requeridas")]
        public string Notas { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public EstadoDePedido Estado { get; set; }
        [NotMapped]
       
       [Display(Name = " Métodos de pago")]
        public OpcionesDePago TipoPago { get; set; }
     
        [Display(Name ="Dirección")]
        public int IdDireccion { get; set; }

       
        [Display(Name = " Cliente")]
        public string IdCliente { get; set; }


        [NotMapped]
        public List<Modelo.DireccionPedido> ListaDeDirecciones { get; set; }

        [NotMapped]
        public virtual AspNetUsers IdClienteNavigation { get; set; }
        [NotMapped]
        public virtual DireccionPedido IdDireccionNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        [NotMapped]
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        [NotMapped]
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
