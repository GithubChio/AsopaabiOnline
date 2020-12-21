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
       
        [Display(Name = "Id del Cliente")]

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Debe agregar un número teléfonico")]
        [Display(Name = "Telefono #1")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]

        public int Telefono1 { get; set; }

        [Required(ErrorMessage = "Debe agregar un número teléfonico")]
        [Display(Name = "Telefono #2")]
        
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]

        public int Telefono2 { get; set; }
      
      
        [NotMapped]
        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
