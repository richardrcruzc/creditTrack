using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Models
{
    public class PersonCreditListModel
    {
        public PersonCreditListModel()
        {
            Person = new PersonModel { };

            History = new List<CreditHistoryModel> { };
        }
            public PersonModel Person { get; set; }
        [DisplayName("Historico Deudas")]
        public List<CreditHistoryModel> History { get; set; }
    }


    public class PersonModel
    {
        public int PersonID { get; set; }
        [DisplayName("Cédula")]
        public string Identification { get; set; }
     public string FirstName { get; set; }

          public string LastName { get; set; }


        [DisplayName("Nombre(s) y Apellido(s)")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName ;
            }
        }

        [DisplayName("Apellido(s) y Nombre(s)")]
        public string FullName1
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

    }

    public class CreditHistoryModel
    {
        public int CreditHistoryID { get; set; }
        public int PersonID { get; set; }

        [DisplayName("Detalle de la Deuda")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime  Fecha { get; set; }
        public string Empresa { get; set; }



    }
}
