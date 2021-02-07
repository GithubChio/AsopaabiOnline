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
        public DateTime FechaPedido { get; set; }

       
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }



        [Required(ErrorMessage = "Las notas son requeridas")]
        public string Notas { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public EstadoDePedido Estado { get; set; }

       
     
        [Display(Name ="Id de Direccion")]
        public int IdDireccion { get; set; }

       
        [Display(Name = "Id de Cliente")]
        public string IdCliente { get; set; }


        [NotMapped]
        public List<Modelo.DireccionPedido> ListaDeDirecciones { get; set; }

        public virtual AspNetUsers IdClienteNavigation { get; set; }
        public virtual DireccionPedido IdDireccionNavigation { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
