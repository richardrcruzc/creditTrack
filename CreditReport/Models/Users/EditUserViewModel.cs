using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Models.Users
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Favor Digitar el Nombre del Representante o Dueño.")]
        [StringLength(100, ErrorMessage = "El {0} debe de ser almenos {2} y un máxino de {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre y Apellido")]
        public string Name { get; set; }
        [Display(Name = "Nombre Empresa o Negocio")]
        [Required(ErrorMessage = "Favor Digitar el Nombre del Negocio o Empresa")]
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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public List<SelectListItem> ApplicationRoles { get; set; }
        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }

    }
}
