using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class Person : IAggregateRoot
    {
           public static Person CreateNew(Gender gender,string identification, string firstname, string lastname, 
               DateTime bob, string passport,   CivilStatus civil, string ocupation, string nationality)
            {
            var customer = new Person
            {
                Identification = identification,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender,
                DOB = bob,
                Passport = passport, 
                MaritalStatus = civil,
                Ocupation = ocupation,
                Nationality = nationality,
                Addresses = new List<Address>(),
                Contacts = new List<Contact>(),
                Inquiries = new List<Inquiry>(),
                CreditHistories = new List<CreditHistory>(),
                RelatedPersons = new List<RelatedPerson>(),

            };
                return customer;
            }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        public Person()
            {
            }

        #endregion

        public int PersonID { get;  set; }
        [DisplayName("Cédula")]
        [Required(ErrorMessage = "Cédula es requerida.")]
        [Remote("Cedula", "People", ErrorMessage = "No puede registrar este número de cédula ya que existe un registro con esta informaciones.")]
        [StringLength(11, MinimumLength = 1, ErrorMessage = "Número de cedula invalido, favor digitar XXX-XXXXX-X ")]
        public string Identification { get;  set; }
        [DisplayName("Fecha de Nacimiento")]
       // [Required(ErrorMessage = "Fecha de Nacimiento es requerida.")]
        public DateTime DOB { get;  set; }
        [DisplayName("Pasaporte")]
        public string Passport { get;  set; }
        [Display(Name = "Nacionalidad")]
        public string Nationality { get;  set; }
        [Display(Name = "Estado Civil")]
        public CivilStatus MaritalStatus { get;  set; }
       
        public string Ocupation { get;  set; }
        /// <summary>
        /// Id of the customer. Used to log in, it's checked for uniqueness. 
        /// </summary>
        [Display(Name = "Descripción de la situacion")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Descripción es requerida.")]
        public string PasswordHash { get;  set; }

        /// <summary>
        /// First name. 
        /// </summary>
        /// 
        [Display(Name = "Nombres")]
        [StringLength(50, MinimumLength = 2,ErrorMessage = "First name cannot be longer than 50 characters and no less than 2. ")]
        [Required(ErrorMessage = "Nombres es requerido.")]
        public string FirstName { get;  set; }

        /// <summary>
        /// Last name. 
        /// </summary>
        /// 
        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "Apellidos es requerido.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters and no less thatn 2 ")]
        public string LastName { get;  set; }
        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get;  set; }

        /// <summary>
        /// Gender: either Male or Female
        /// </summary>
        /// 
        [Display(Name = "Sexo")]
        public Gender Gender { get;  set; }

            /// <summary>
            /// URL of the avatar
            /// </summary>
            public string Avatar { get;  set; }

        /// <summary>
        /// Postal address of the customer  
        /// At the very minimum, you might want to use an Address object.
        /// </summary>
        ///  [DisplayName("Last Name")]
        [DisplayName("Direcciones")]

        public ICollection<Address> Addresses { get;  set; }
        [DisplayName("Empresas relacionadas")]

        public ICollection<RelateCompany> RelateCompanies { get;  set; }
        [DisplayName("Consultas")]

        public ICollection<Inquiry> Inquiries { get;  set; }
        [DisplayName("Historial de creditos")]

        public ICollection<CreditHistory> CreditHistories { get;  set; }
        [DisplayName("Personas relacionadas")]

        public ICollection<RelatedPerson> RelatedPersons { get;  set; }
         
        public ICollection<Contact> Contacts { get;  set; }
        public ICollection<Enrollment> Enrollment { get;  set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        #region Behavior

        /// <summary>
        /// Set the full postal address of the customer.
        /// </summary>
        /// <param name="address">New address</param>
        /// <returns>this instance</returns>
        public Person AddAddress(ICollection<Address> addresses)
            {

            foreach (var item in addresses)
            {
                Addresses.Add(item);
            }
            return this;
        }
        public Person AddContacts(ICollection<Contact> contacts)
        {

            foreach (var item in contacts)
            {
                Contacts.Add(item);
            }
            return this;
        }
        public Person AddInquiries(ICollection<Inquiry> inquiries)
        {

            foreach (var item in inquiries)
            {
                Inquiries.Add(item);
            }
            return this;
        }

        public Person AddCreditHistory(ICollection<CreditHistory> credits)
        {

            if (CreditHistories == null)
                CreditHistories = new List<CreditHistory>();
            foreach (var item in credits)
            {
                CreditHistories.Add(item);
            }
            return this;
        }


        public Person AddPersons(ICollection<RelatedPerson> Persons)
        {
            if (RelatedPersons == null)
                RelatedPersons = new List<RelatedPerson>();
            foreach (var item in Persons)
            {
                RelatedPersons.Add(item);
            }
            return this;
        }

        /// <summary>
        /// Set the password hash for the customer
        /// </summary>
        /// <param name="hash">Hash of a password to save</param>
        /// <returns>this object</returns>
        public Person SetPasswordHash(string hash)
            {
                PasswordHash = hash;
                return this;
            }

            
            /// <summary>
            /// Set the avatar
            /// </summary>
            /// <param name="url">URL for the customer picture</param>
            /// <returns>this object</returns>
            public Person SetAvatar(string url)
            {
                Avatar = url;
                return this;
            }

            /// <summary>
            /// Title for the customer (Mr, Mrs, etc)
            /// </summary>
            /// <returns>string</returns>
            public String GetTitle()
            {
                switch (Gender)
                {
                    case Gender.Masculino:
                        return "Mrs";
                    case Gender.Femenino:
                        return "Mr.";
                    default:
                        return "";
                }
            }

            #endregion

        public override string ToString()
        {
            var title = GetTitle();
            return String.Format("{0} {1} {2}", title, FirstName, LastName);
        }

        //#region Identity Management
        //public static bool operator ==(Person c1, Person c2)
        //{
        //    // Both null or same instance
        //    if (ReferenceEquals(c1, c2))
        //        return true;

        //    // Return false if one is null, but not both 
        //    if (((object)c1 == null) || ((object)c2 == null))
        //        return false;

        //    return c1.Equals(c2);
        //}
        //public static bool operator !=(Person c1, Person c2)
        //{
        //    return !(c1 == c2);
        //}

        //public override bool Equals(object obj)
        //{
        //    if (this == (Person)obj)
        //        return true;
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;
        //    var other = (Person)obj;

        //    // Your identity logic goes here.  
        //    // You may refactor this code to the method of an entity interface 
        //    return PersonID == other.PersonID;
        //}

        //public override int GetHashCode()
        //{
        //    return PersonID.GetHashCode();
        //}
        //#endregion
        }
    }
