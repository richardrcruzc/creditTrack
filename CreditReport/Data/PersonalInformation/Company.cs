using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class Company
    {
        public static Company New(string description, string address, string phone, string contact)
        {
            var company = new Company
            {
                Description = description,
                Address = address,
                Phone = phone,
                ContactName =  contact,
        };
            
            return company;
        }
        public  Company(){}
        public int CompanyID { get; private set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage ="Nombre o descripción de la empresa es requerido.")]
        public string Description { get; private set; }
        [DisplayName("Direccion")]
        public string Address { get; private set; }
        [DisplayName("Telefonos")]
        public string Phone { get; private set; }
        [DisplayName("Nombre Contacto")]
        public string ContactName { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
