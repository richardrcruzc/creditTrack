using CreditReport.Data.PersonalInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class RelateCompany
    {
        public int RelateCompanyID { get; set; }
        public int PersonID { get; set; }
        public int CompanyID { get; set; }
        [Display(Name = "Relacion")]
        public CompanyRelationShip RelationShip { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        public string ContactType { get; set; }
        [Display(Name = "Persona")]
        public Person Person { get; set; }

        [Display(Name = "Empresa")]
        public Company Company { get; set; }
    }
}
