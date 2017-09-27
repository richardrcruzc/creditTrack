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
        [StringLength(100, ErrorMessage = "El {0} debe de ser almenos {2} y ub maxino de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre y Apellido")]
        public string Name { get; set; }
        [Display(Name = "Nombre Empresa o Negocio")]
        [Required(ErrorMessage ="Favor Digitar el Nombre del Negocio o Empresa")]
        [DataType(DataType.Text)]
        public string Empresa { get; set; }

         [DataType(DataType.Text)]
        public string Calle { get; set; }
         [DataType(DataType.Text)]
        public string Barrio { get; set; }
         [DataType(DataType.Text)]
        public string Sector { get; set; }
         [DataType(DataType.Text)]
        public string Municipio { get; set; }
         [DataType(DataType.Text)]
        public string Provincia { get; set; }


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
    }
}
