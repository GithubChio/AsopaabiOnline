﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AsopaabiOnline.UI.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DNITypeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var register = (Register)validationContext.ObjectInstance;
            if (value != null)
            {
                if (register.DniType == DNIType.cedulaFisica)
                {
                    var regex = new Regex(@"^[1-9]-\d{4}-\d{4}$");
                    return regex.Match(value?.ToString()).Success
                        ? ValidationResult.Success
                        : new ValidationResult("Ingrese un formato válido para cédula física. Ej: 1-0222-0222");
                }
                if (register.DniType == DNIType.cedulaJuridica)
                {
                    var regex = new Regex(@"^[1-9]-\d{3}-\d{6}$");
                    return regex.Match(value.ToString()).Success
                        ? ValidationResult.Success
                        : new ValidationResult("Ingrese un formato válido para cédula jurídica.Ej: 1-0222-256236");
                }
            }
            return new ValidationResult("DNI inválido");
        }
    }

}
