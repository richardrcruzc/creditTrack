using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class CreditHistory
    {
        public  CreditHistory()
        {
        }
        [Display(Name = "Id")]
        public int CreditHistoryID { get; set; }
        [Display(Name = "Persona")]
        public Person Person { get; set; }
         [Display(Name = "Descripcion")]
        public string Note { get; set; }
        [Display(Name = "Fecha")] 
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }



    }

    public class PaymentHistory
    {
        public int PaymentHistoryID { get; set; }
        public CreditHistory CreditHistory { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public PaymentHistoryStatus Status { get; set; }
        public int Over { get; set; }
    }
}
