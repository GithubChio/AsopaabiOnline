using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Models
{
    public class Register
    {

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]

        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        [DataType(DataType.Text)]
        [Display(Name = "Número de identificación")]
        public string DNI { get; set; }
        
        [NotMapped]
        [Display(Name = "Tipo de identificación")]
        public DNIType DniType { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Segundo Nombre")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Primer apellido")]
        public string FirstLastName { get; set; }

        [Required(ErrorMessage = "El segundo apellido es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Segundo Apellido")]
        public string SecondLastName { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        [Display(Name = "Numero de telefono principal")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        [Display(Name = "Numero de telefono secundario")]
        public string PhoneNumber2 { get; set; }

        [Required(ErrorMessage = "Su fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        //[Range(typeof(DateTime), "31-12-1925", "31-12-2003", ErrorMessage = "No se aceptan menores de edad")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "El tipo de actividad es requerida")]
        [Display(Name = "Tipo de Actividad")]
        [EnumDataType(typeof(TipoDeActividad))]
        public TipoDeActividad ActivityType { get; set; }

       
    }
}
