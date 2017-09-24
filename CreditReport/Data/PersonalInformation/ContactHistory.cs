using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class Inquiry
    {
        public static Inquiry New( DateTime date, Company subcriptor, InquiryType inquiryType, Person person)
        {
            var inquiry = new Inquiry
            {
                Date = date,
                Subcriptor = subcriptor,
                InquiryType = inquiryType,
                Person = person,
            };
        return inquiry;
    }

        public Inquiry(){}
         
        public int InquiryID { get; set; }
        public DateTime Date { get; private set; }
        public Company Subcriptor { get; private set; }
        public InquiryType InquiryType { get; private set; }
        public Person Person { get; private set; }
    }
}
