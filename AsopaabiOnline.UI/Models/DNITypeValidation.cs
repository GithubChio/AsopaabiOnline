using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AsopaabiOnline.UI.Models
{ 
    //clase para validar el dni  
    [AttributeUsage(AttributeTargets.Property)]
    public class DNITypeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var register = (Register)validationContext.ObjectInstance;
            if (value != null)
            {
                if (register.DniType == DNIType.cedulaFisica) //si es cedula fisica 
                {
                    var regex = new Regex(@"^[1-9]-\d{4}-\d{4}$"); //usar el formato:  1-0222-0222
                    return regex.Match(value?.ToString()).Success
                        ? ValidationResult.Success
                        : new ValidationResult("Ingrese un formato válido para cédula física. Ej: 1-0222-0222");
                }
                if (register.DniType == DNIType.cedulaJuridica) //si es cedula juridica 
                {
                    var regex = new Regex(@"^[1-9]-\d{3}-\d{6}$"); //usar formato: 1-0222-256236
                    return regex.Match(value.ToString()).Success
                        ? ValidationResult.Success
                        : new ValidationResult("Ingrese un formato válido para cédula jurídica.Ej: 1-0222-256236");
                }
            }
            return new ValidationResult("DNI inválido");
        }
    }

}
