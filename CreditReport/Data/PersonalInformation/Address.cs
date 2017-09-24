using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public sealed class Address
    {
        public static Address Create(string street , string number , string city , string zip , string country  , DateTime date)
        {
            var address = new Address { Street = street, Number = number, City = city, Zip = zip, Country = country , Date = date};
            return address;
        }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        private Address()
        {
        }

        #endregion

        public int AddressID { get; private set; }
        [Display(Name = "Calle")]
        public string Street { get; private set; }
        [Display(Name = "Numero")]
        public string Number { get; private set; }
        [Display(Name = "Ciudad/Provincia")]
        public string City { get; private set; }
        [Display(Name = "Codigo Postal")]
        public string Zip { get; private set; }
        [Display(Name = "Pais")]
        public string Country { get; private set; }
        [Display(Name = "Fecha")]
        public DateTime Date { get; private set; }

        [Display(Name = "Direccion")]
        public string CompleteAddress
        {
            get
            {
                return Number + ", " + Street + ", " + City + ", " + Zip + ", " + Country;
           
            }
        }

    }
}
