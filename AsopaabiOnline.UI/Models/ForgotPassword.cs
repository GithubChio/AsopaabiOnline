using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Debe agregar un correo electrónico válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }
}
