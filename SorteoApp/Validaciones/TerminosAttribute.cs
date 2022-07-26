using System.ComponentModel.DataAnnotations;


namespace SorteoApp.Validaciones
{
    public class TerminosAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is false)
            {
                return new ValidationResult("Debe aceptar los terminos para continuar.");
            }
            return ValidationResult.Success;
        }

    }
}

