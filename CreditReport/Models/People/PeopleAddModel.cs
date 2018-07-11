using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Models.People
{
    public class PeopleAddModel
    {
        [DisplayName("Cédula")]
        [Required(ErrorMessage = "Cédula es requerida.")]
        [Remote("Cedula", "People", ErrorMessage = "No puede registrar este número de cédula ya que existe un registro con esta informaciones.")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Número de cedula invalido, favor digitar XXX-XXXXX-X ")]
        public string Identification { get; set; }

        [DisplayName("Nombres")]
        [Required(ErrorMessage = "El Nombre es Requerido.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Favor Digitar un Nombre Vâlido")]
        public string FirstName { get; set; }

        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "El Apellido es Requerido.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Favor Digitar un Apellido Vâlido")]
        public string LastName { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción es Requerida.")]
        [StringLength(1500, MinimumLength = 5, ErrorMessage = "Favor Digitar una Descripción mas Amplia o Detallada.")]
        public string Description { get; set; }

        public string Results { get; set; }

        [Required(ErrorMessage = "Debe seleccionar imagenes/uno o mas archivos")]
        public List<IFormFile> Files { get; set; }
        

    }
}
