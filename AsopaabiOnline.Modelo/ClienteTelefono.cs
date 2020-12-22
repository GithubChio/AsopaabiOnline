using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class ClienteTelefono
    {
       
        

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Id del Cliente")]

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El número teléfonico es requerido")]
        [Display(Name = "Telefono #1")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]

        public int Telefono1 { get; set; }

        [Required(ErrorMessage = "El número teléfonico es requerido")]
        [Display(Name = "Telefono #2")]

        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]

        public int Telefono2 { get; set; }
      
      
     
        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
