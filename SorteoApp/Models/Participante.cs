using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SorteoApp.Validaciones;

namespace SorteoApp.Models
{
    public class Participante : Base
    {
        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "La longitud del campo debe estar entre {2} y {1}")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [StringLength(15)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [EmailAddress]
        [Display(Name = "e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [Display(Name = "DNI")]       
        public string Dni { get; set; }  //<--- Esto o lo cambio a string o busco de hacer una validacion personalizada o buscar una validacion par ael error que sale



        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [Display(Name = "Codigo Postal")]
        public int CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        
        [Display(Name = "Provincia")]
        [Provincia]
        public string Provincia { get; set; }


        
        [Required(ErrorMessage = "El campo {0} es requerido..")]
        [Display(Name = "Acepto")]
        [Terminos]
        public bool Legal { get; set; }
    }
}
