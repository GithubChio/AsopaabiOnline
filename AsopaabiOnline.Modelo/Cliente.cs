using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class Cliente
    {
        public Cliente()
        {
            //ClienteTelefono = new HashSet<ClienteTelefono>();
            //HistorialPedido = new HashSet<HistorialPedido>();
            //Pedido = new HashSet<Pedido>();
        }
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="el tipo de DNI es requerido")]
        [Display(Name = "Tipo de DNI")]
        [EnumDataType(typeof(TipoDeDni))]
        public int TipoDni { get; set; }
        [Required(ErrorMessage = "el tipo de DNI es requerido")]
        public string Dni { get; set; }

        
        [Required(ErrorMessage = "Su primer nombre es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        //[StringLength(15, ErrorMessage = "")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        //[StringLength(15, ErrorMessage = "")]
        [Required(ErrorMessage = "Su primer apellido es requerido")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        //[StringLength(15, ErrorMessage = "")]
        [Required(ErrorMessage = "Su segundo apellido es requerido")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }


        [Required(ErrorMessage = "Su fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        [Range(typeof(DateTime), "31/12/1925", "31/12/2002",
    ErrorMessage = "El valor de{0} debe ser entre {1} y {2}")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        [EnumDataType(typeof(TipoDeCliente))]
        public int TipoDeCliente { get; set; }
        [Required]
        [Display(Name = "Tipo de Actividad")]
        [EnumDataType(typeof(TipoDeActividad))]
        public int TipoActividad { get; set; }

        public string IdUsuario { get; set; }
        [NotMapped]
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }

        [NotMapped]
        public virtual ICollection<ClienteTelefono> ClienteTelefono { get; set; }
        [NotMapped]
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        [NotMapped]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
