using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidiyalAPI.Models.Business
{
    public class CenterData
    {
        public int CenterID { get; set; }
        public string CenterName { get; set; }
        public string CenterHeadName { get; set; }
        public string CenterAddressLine1 { get; set; }
        public string CenterAddressLine2 { get; set; }
        public string City { get; set; }
        public string CenterContactNumber { get; set; }
        public string CenterStartDate { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}