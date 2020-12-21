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
        [Display(Name = "Id Cliente")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de dni es requerido")]
        [Display(Name = "Tipo de DNI")]
        public TipoDeDni? TipoDni { get; set; }
        
        [Required(ErrorMessage = "el DNI es requerido")]
        [Display(Name ="DNI")]
        public string Dni { get; set; }

        
        [Required(ErrorMessage = "Su primer nombre es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$",ErrorMessage ="Ingrese unicamente letras y la primera en mayúscula")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$",ErrorMessage ="Ingrese unicamente letras y la primera en mayúscula")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "Su primer apellido es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Ingrese unicamente letras y la primera en mayúscula")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Su segundo apellido es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Ingrese unicamente letras y la primera en mayúscula")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }


        [Required(ErrorMessage = "Su fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        [Range(typeof(DateTime), "31-12-1925", "31-12-2003",ErrorMessage = "No se aceptan menores de edad")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        [Required (ErrorMessage ="El tipo de cliente es requerido")]
        [Display(Name = "Tipo de Cliente")]
        //[EnumDataType(typeof(TipoDeCliente))]
        public TipoDeCliente? TipoDeCliente { get; set; }
        [Required(ErrorMessage = "El tipo de actividad es requerido")]
        [Display(Name = "Tipo de Actividad")]
        
        public TipoDeActividad? TipoActividad { get; set; }
        [NotMapped]
        public int Edad { get; set; }
        [NotMapped]
        public string IdUsuario { get; set; }
   
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }

        [NotMapped]
        public virtual ICollection<ClienteTelefono> ClienteTelefono { get; set; }
        [NotMapped]
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        [NotMapped]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
