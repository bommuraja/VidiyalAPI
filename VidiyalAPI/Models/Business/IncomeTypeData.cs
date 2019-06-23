using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidiyalAPI.Models.Business
{
    public class IncomeTypeData
    {
        public int IncomeTypeID { get; set; }
        public string IncomeType1 { get; set; }
        public string IncomeDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}