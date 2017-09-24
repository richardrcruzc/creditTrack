using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class RelatedPerson
    {
        public RelatedPerson()
        { }
            public int RelatedPersonID { get; set; } 
        public PersonRelationShip RelationShip { get; set; }

         public   int PersonPrincipalID { get; set; }
        public Person PersonPrincipal { get; set; }
        public int PersonRelatedID { get; set; }
        public   Person PersonRelated { get; set; }

    }
}
