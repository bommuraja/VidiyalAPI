using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidiyalAPI.Models.Business
{
    public class CustomerData
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string YearOfBirth { get; set; }
        public string KYCDetails { get; set; }
        public string AdharcardDetails { get; set; }
        public string VoterID { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string ContactNumber3 { get; set; }
        public Nullable<int> CenterID { get; set; }
        public string PermanentAddressLine1 { get; set; }
        public string PermanentAddressLine2 { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentPinCode { get; set; }
        public string TemporaryAddressLine1 { get; set; }
        public string TemporaryAddressLine2 { get; set; }
        public string TemporaryCity { get; set; }
        public string TemporaryPinCode { get; set; }
        public string JoiningDate { get; set; }
        public int IsActive { get; set; }
    }
}