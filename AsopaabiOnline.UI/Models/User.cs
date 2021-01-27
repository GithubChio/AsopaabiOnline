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



        [Required(ErrorMessage = "Por favor ingrese su Cedula")]
        [DataType(DataType.Text)]
        [Display(Name = "DNI")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Segundo Nombre")]
        public string SecondName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Primer apellido")]
        public string FirstLastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Segundo Apellido")]
        public string SecondLastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Numero de telefono secundario")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "el número de celular debe tener 8 digitos númericos")]
        public string PhoneNumber2 { get; set; }


        [Required(ErrorMessage = "Su fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
       
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Tipo de Actividad")]
        [EnumDataType(typeof(TipoDeActividad))]
        public TipoDeActividad ActivityType { get; set; }

        [Display(Name = "Tipo de Cliente")]
        [EnumDataType(typeof(TipoDeCliente))]
        public TipoDeCliente CustomerType { get; set; }
        
        [Display(Name = "Tipo de Usuario")]
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
