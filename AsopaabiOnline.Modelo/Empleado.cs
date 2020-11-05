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
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "Su primer apellido es requerido")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Su segundo apellido es requerido")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [NotMapped]
        public TipoDeEmpleado TipoDeEmpleado { get; set; }
        [NotMapped]
        public int IdPedido { get; set; }
       
        public string IdUsuario { get; set; }
        [NotMapped]
        public virtual Pedido IdPedidoNavigation { get; set; }
        [NotMapped]
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }
    }
}
