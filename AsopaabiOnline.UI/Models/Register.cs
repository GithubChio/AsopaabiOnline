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
        
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]

        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(20, ErrorMessage = "La contraseña  debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public  string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El número de identificación es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Número de identificación")]
        [DNITypeValidation]
        public string DNI { get; set; }
        
        [NotMapped]
        [Display(Name = "Tipo de identificación")]
        public DNIType DniType { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
         [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Segundo Nombre")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Primer apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string FirstLastName { get; set; }

        [Required(ErrorMessage = "El segundo apellido es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Segundo Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string SecondLastName { get; set; }


        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        [Display(Name = "Numero de teléfono principal")]
        [Required(ErrorMessage = "El número de teléfono es requerido")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        [Display(Name = "Número de teléfono secundario")]
        public string PhoneNumber2 { get; set; }

        [Required(ErrorMessage = "Su fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        [DateOfBirthValidation(MinAge =18, MaxAge =100,ErrorMessage ="No se permiten menores de edad")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


       
       
    }
}
