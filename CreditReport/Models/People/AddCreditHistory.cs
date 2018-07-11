using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Models.People
{
    public class AddCreditHistory
    {
        public int PersonID { get; set; }
        
        [DisplayName("Cédula")]
         public string Identification { get; set; }

        [DisplayName("Nombres")]
         public string FirstName { get; set; }

        [DisplayName("Apellidos")]
         public string LastName { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción es Requerida.")]
        [StringLength(1500, MinimumLength = 5, ErrorMessage = "Favor Digitar una Descripción mas Amplia o Detallada.")]
        public string Description { get; set; }

        public string Resultados { get; set; }

        [Required(ErrorMessage = "Debe seleccionar imagenes/uno o mas archivos")]
        public List<IFormFile> Files { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

    }
}
