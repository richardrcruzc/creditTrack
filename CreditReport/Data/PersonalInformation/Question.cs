using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
   
    public class Question
    {
        public Question()
        { }

        public int QuestionID { get; set; }

        // user ID from AspNetUser table
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        [DisplayName("Pregunta")]
        [Required(ErrorMessage = "Pregunta es requerida.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Favor ser mas espefico en su pregunta.")]

        public string Description { get; set; }     
        public QuestionStatus Status { get; set; }

        [InverseProperty("ChildrenQuestion")]
        public Question MotherQuestion { get; set; }
        public ICollection<Question> ChildrenQuestion { get; set; }


        public Question AddChildren(Question  question)
        {
            if (ChildrenQuestion == null)
                ChildrenQuestion = new List<Question>();

            ChildrenQuestion.Add(question);
            return this;
        }


    }
}
