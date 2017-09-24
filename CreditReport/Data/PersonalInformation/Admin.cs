using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class Admin
    {
        public static Admin CreateNew(string name)
        {
            var admin = new Admin { Name = name };
            return admin;
        }

        protected Admin()
        {
            Name = String.Empty;
        }
        public int AdminID { get; set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }
    }
}
