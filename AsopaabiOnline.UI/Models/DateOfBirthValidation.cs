using System;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.UI.Models
{ 
    //clase para validar la fecha de nacimiento

    public class DateOfBirthValidation : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        protected override  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var register = (Register)validationContext.ObjectInstance;
          
            if (value != null)
            {
                if (register.DniType == DNIType.cedulaFisica) // si es cedula fisica
                {
                    var val = (DateTime)value;

                    if (val.AddYears(MinAge) > DateTime.Now) //no acepta menores de edad
                        return new ValidationResult("no se aceptan menores de edad");

                    if(val.AddYears(MaxAge) > DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                }
                if (register.DniType == DNIType.cedulaJuridica) //si es juridica 
                {
                    return ValidationResult.Success; //acepta cualquier fecha

                }

            }
            return new ValidationResult("Fecha requerida");
        }
       
    }
}