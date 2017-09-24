using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Models
{
    public class ContactEditViewModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [Display(Name ="Nombre completo")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
