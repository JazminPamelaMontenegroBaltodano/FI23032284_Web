using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BinCalc.Models
{
    // Valida que el string:
    // - no sea vacío
    // - solo contenga 0 y 1
    // - longitud <= 8
    // - longitud múltiplo de 2 (2,4,6,8)
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class BinaryStringStrictAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var s = value as string ?? string.Empty;

            if (string.IsNullOrWhiteSpace(s))
                return new ValidationResult("El valor no puede ser vacío.");

            foreach (var ch in s)
            {
                if (ch != '0' && ch != '1')
                    return new ValidationResult("Solo se permiten caracteres 0 y 1.");
            }

            if (s.Length > 8)
                return new ValidationResult("La longitud no puede exceder 8 caracteres.");

            if (s.Length % 2 != 0)
                return new ValidationResult("La longitud debe ser múltiplo de 2 (2, 4, 6 u 8).");

            return ValidationResult.Success!;
        }
    }
}
