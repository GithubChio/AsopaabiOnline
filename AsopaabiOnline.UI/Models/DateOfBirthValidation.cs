using System;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.UI.Models
{
    public class DateOfBirthValidation : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        protected override  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var register = (Register)validationContext.ObjectInstance;
          
            if (value != null)
            {
                if (register.DniType == DNIType.cedulaFisica)
                {
                    var val = (DateTime)value;

                    if (val.AddYears(MinAge) > DateTime.Now)
                        return new ValidationResult("no se aceptan menores de edad");

                    if(val.AddYears(MaxAge) > DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                }
                if (register.DniType == DNIType.cedulaJuridica)
                {
                    return ValidationResult.Success;

                }

            }
            return new ValidationResult("Fecha requerida");
        }
       
    }
}