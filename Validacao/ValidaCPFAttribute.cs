using System.ComponentModel.DataAnnotations;
using Desafio_API_GFT.Models;

namespace Desafio_API_GFT.Validacao
{
    public class ValidaCPFAttribute : ValidationAttribute
    {		
		public ValidaCPFAttribute()
        {
            this.ErrorMessage = "The value {0} is invalid for CPF";
        }
	  protected override ValidationResult IsValid(object value,
            ValidationContext validationContext){
			if (value != null)
            {
                var valueValidLength = 11;
                var maskChars = new[] { ".", "-" };
                var multipliersForFirstDigit = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                var multipliersForSecondDigit = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

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

