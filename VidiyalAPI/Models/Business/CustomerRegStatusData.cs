using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidiyalAPI.Models.Business
{
    public class CustomerRegStatusData
    {
        public int CustomerRegStatusID { get; set; }
        public string CustomerRegStatus { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}