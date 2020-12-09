using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Su primer nombre es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Primer nombre")]
        public string PrimerNombre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Segundo nombre")]
        public string SegundoNombre { get; set; }
       
        [Required(ErrorMessage = "Su primer apellido es requerido")]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }
        
        [Required(ErrorMessage = "Su segundo apellido es requerido")]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }
      
        [Display(Name = "Tipo de empleado")]
        public TipoDeEmpleado TipoDeEmpleado { get; set; }
        [NotMapped]
        [Display(Name = "Pedido")]
        public int IdPedido { get; set; }
        [Display(Name = "Correo eléctronico")]
        public string IdUsuario { get; set; }


        [NotMapped]
        public List<Modelo.AspNetUsers> LaListaDeUsuarios { get; set; }

        [NotMapped]
        public List<Modelo.Pedido> LaListaDePedidos { get; set; }
        [NotMapped]
        public virtual Pedido IdPedidoNavigation { get; set; }
        [NotMapped]
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }
    }
}
