using System.ComponentModel.DataAnnotations;
namespace SorteoApp.Validaciones
{
    public class ProvinciaAttribute :  ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string prov = value.ToString();
            if (prov == "...")
            {
                return new ValidationResult("El campo Provincia es requerido..");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
