using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CreditReport.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Empresa { get; set; }
        public string Calle { get; set; }
        public string Barrio { get; set; }
        public string Sector { get; set; }
        public string Municipio { get; set; }
        public string Provincia { get; set; }
    }
}
