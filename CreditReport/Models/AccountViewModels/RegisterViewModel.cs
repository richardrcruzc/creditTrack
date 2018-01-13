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

        [Required(ErrorMessage = "Favor Digitar el Email.")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El 'Password' es requerido.")]
        [StringLength(100, ErrorMessage = "El {0} debe ser {2} caracteres minimo y un maximo de {1} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "El password debe tener como mínimo 6 caracteres y distingue mayúsculas de minúsculas. ")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Favor Confirmar Password.")]
        [DataType(DataType.Password, ErrorMessage = "El password debe tener como mínimo 6 caracteres y distingue mayúsculas de minúsculas. ")]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "El password y confirmación password debe ser iguales.")]
        public string ConfirmPassword { get; set; }
    }
}
