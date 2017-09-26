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

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción es Requerida.")]
        [StringLength(1500, MinimumLength = 5, ErrorMessage = "Favor Digitar una Descripción mas Amplia o Detallada.")]

        public string Note { get; set; }
        [Display(Name = "Fecha")] 
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }


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
