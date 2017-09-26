using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public class Province
    {
        public int ProvinceID { get; set; }
        public string Name { get; set; }
        public ProvinceType ProvinceType { get; set; }

        [InverseProperty("ChildrenProvinces")]
        public Province MotherProvince { get; set; }
        public ICollection<Province> ChildrenProvinces { get; set; }

        public Province AddChildren(Province province)
        {
            if (ChildrenProvinces == null)
                ChildrenProvinces = new List<Province>();

            ChildrenProvinces.Add(province);
            return this;
        }
    }
}
