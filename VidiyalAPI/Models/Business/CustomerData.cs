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
        public Nullable<int> IsActive { get; set; }

        public Nullable<int> IncomeTypeOne { get; set; }
        public Nullable<int> IncomeTypeTwo { get; set; }
        public Nullable<int> IncomeTypeThree { get; set; }
        public string IncomeNoteOne { get; set; }
        public string IncomeNoteTwo { get; set; }
        public string IncomeNoteThree { get; set; }
        public string IncomeAmountOne { get; set; }
        public string IncomeAmountTwo { get; set; }
        public string IncomeAmountThree { get; set; }

        public Nullable<int> CustomerRegStatusID { get; set; }
        public Nullable<int> RegStatusEnterdByID { get; set; }
        public string RegStatusEnterdByDate { get; set; }
        public Nullable<int> RegStatusReviewedByID { get; set; }
        public string RegStatusReviewedByDate { get; set; }
        public Nullable<int> RegStatusApprovedByID { get; set; }
        public string RegStatusApprovedByDate { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual CenterData Center { get; set; }
        public virtual CustomerRegStatu CustomerRegStatu { get; set; }
        public virtual List<CustomerRegStatusData> CustomerRegStatusList { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual UserAccount UserAccount1 { get; set; }
        public virtual UserAccount UserAccount2 { get; set; }

        public virtual List<IncomeTypeData> IncomeType { get; set; }
        public virtual List<IncomeTypeData> IncomeType1 { get; set; }
        public virtual List<IncomeTypeData> IncomeType2 { get; set; }
    }
}