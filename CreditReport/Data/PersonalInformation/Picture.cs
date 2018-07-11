using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class Picture
    {
        public int PictureID { get; set; }
        public string PicturePath { get; set; }
         
        public CreditHistory CreditHistory { get; set; }

    }
}
