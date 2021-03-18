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
    public class User: IdentityUser
    {

        public User()
        {

        }

      
        
      

        [Required(ErrorMessage = "Por favor ingrese su identificación")]
        [DataType(DataType.Text)]
        [Display(Name = "Número de identificación")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Segundo Nombre")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string SecondName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Primer apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string FirstLastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Segundo Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Solo se permiten letras y la primera debe ser mayúscula.")]
        public string SecondLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        [Display(Name = "Número de teléfono secundario")]

        public override string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        [Display(Name = "Número de teléfono secundario")]
   
        public string PhoneNumber2 { get; set; }


        [Required(ErrorMessage = "Su fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
       
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Tipo de actividad")]
        [EnumDataType(typeof(TipoDeActividad))]
        public TipoDeActividad ActivityType { get; set; }

        [Display(Name = "Tipo de cliente")]
        [EnumDataType(typeof(TipoDeCliente))]
        public TipoDeCliente CustomerType { get; set; }
        
        [Display(Name = "Tipo de usuario")]
        [EnumDataType(typeof(UserType))]
        public UserType   UserType { get; set; }

        [NotMapped]
        [Display(Name = "Nombre")]
        public  string Name { get { return (FirstName + " " + SecondName ); } }
        [NotMapped]
        [Display(Name = "Apellidos")]
        public string LastName { get { return (FirstLastName +" " + SecondLastName); } }

        [NotMapped]
        [Display(Name = "Edad")]
        public int Age { get { return (DateTime.Now - DateOfBirth).Days / 365; } }

        


    }
}
