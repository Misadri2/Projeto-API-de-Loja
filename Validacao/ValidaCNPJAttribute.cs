using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio_API_GFT.Validacao
{
    public class ValidaCNPJAttribute : ValidationAttribute
    {
       public ValidaCNPJAttribute()
        {
            this.ErrorMessage = "The value {0} is invalid for CNPJ";
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueValidLength = 14;
                var maskChars = new[] { ".", "-", "/" };
                var multipliersForFirstDigit = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                var multipliersForSecondDigit = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                var mod11 = new Mod11();
                var isValid = mod11.IsValid(value.ToString(), valueValidLength, maskChars, multipliersForFirstDigit, multipliersForSecondDigit);

                if (!isValid)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return null;
        }
       
    }
} 
    
