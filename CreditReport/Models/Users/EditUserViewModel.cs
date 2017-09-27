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
        public string Name { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }
        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }

        public string Empresa { get; set; }
        public string Calle { get; set; }
        public string Barrio { get; set; }
        public string Sector { get; set; }
        public string Municipio { get; set; }
        public string Provincia { get; set; }


        public List<SelectListItem> Municipios { get; set; }
        public List<SelectListItem> Provincias { get; set; }

    }
}
