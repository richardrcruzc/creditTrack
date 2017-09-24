using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class MissingPerson:Person
    {
        public static MissingPerson Instance = new MissingPerson();
    }
}
