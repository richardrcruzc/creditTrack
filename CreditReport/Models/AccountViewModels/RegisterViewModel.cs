using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Favor Digitar el Nombre del Representante o Dueño.")]
        [StringLength(100, ErrorMessage = "El {0} debe de ser almenos {2} y un máxino de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre y Apellido")]
        public string Name { get; set; }
        [Display(Name = "Nombre Empresa o Negocio")]
        [Required(ErrorMessage ="Favor Digitar el Nombre del Negocio o Empresa")]
        [DataType(DataType.Text)]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Favor Digitar Calle, Casa y/o Apto Número.")]

        [Display(Name = "Calle, Casa y/o Apto Número")]
        [DataType(DataType.Text)]
        public string Calle { get; set; }
         [DataType(DataType.Text)]
        [Required(ErrorMessage = "Favor Digitar Barrio.")]
        public string Barrio { get; set; }
         [DataType(DataType.Text)]
        [Required(ErrorMessage = "Favor Digitar Sector")]
        public string Sector { get; set; }
         [DataType(DataType.Text)]
        [Required(ErrorMessage = "Favor Digitar Municipio.")]
        public string Municipio { get; set; }
         [DataType(DataType.Text)]
        [Required(ErrorMessage = "Favor Digitar la Provincia.")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "Favor Digitar Teléfono.")]

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        public List<SelectListItem> Municipios { get; set; }
        public List<SelectListItem> Provincias { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} Debe de Ser Almenos {2} y un Maximo de {1} Caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Clave")]
        [Compare("Password", ErrorMessage = "La Clave y la Confirmacion not son iguales, favor verificar.")]
        public string ConfirmPassword { get; set; }
    }
}
