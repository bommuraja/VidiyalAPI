using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VidiyalAPI;
using VidiyalAPI.Models.Business;

namespace VidiyalAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private bommuraj_Vidiyal db = new bommuraj_Vidiyal();

         // Method : 1
        // GET: api/DataEntryOperators
        public List<CustomerData> GetCustomers()
        {
            try
            {
                List<CustomerData> objList = new List<CustomerData>();

                var IncomeTypelist = new List<IncomeTypeData>();
                var IncomeTypeDB = db.IncomeTypes.ToList();

                foreach (var item in IncomeTypeDB)
                {
                    IncomeTypelist.Add(new IncomeTypeData
                    {
                        IncomeType1 = item.IncomeType1,
                        IncomeTypeID = item.IncomeTypeID
                    });
                }

                var CustomerRegStatuslist = new List<CustomerRegStatusData>();
                var CustomerRegStatusDB = db.CustomerRegStatus.ToList();

                foreach (var item in CustomerRegStatusDB)
                {
                    CustomerRegStatuslist.Add(new CustomerRegStatusData
                    {
                        CustomerRegStatusID = item.CustomerRegStatusID,
                        CustomerRegStatus = item.CustomerRegStatus
                    });
                }

                var Centerlist = new List<CenterData>();
                var CenterDB = db.Centers.ToList();

                foreach (var item in CenterDB)
                {
                    Centerlist.Add(new CenterData
                    {
                        CenterID = item.CenterID,
                        CenterName = item.CenterName
                    });
                }

                var UserAccountList = new List<UserAccountData>();

                var UserAccount = db.UserAccounts.ToList();

                foreach (var item in UserAccount)
                {
                    UserAccountList.Add(new UserAccountData
                    {
                        UserAccountID = item.UserAccountID,
                        FullName = item.FullName
                    });
                }

                var CustomerList = db.Customers.ToList();
                foreach (var item in CustomerList)
                {   
                    objList.Add(
                        new CustomerData
                        {
                            CustomerID = item.CustomerID,
                            CustomerName = item.CustomerName,
                            YearOfBirth = item.YearOfBirth,
                            KYCDetails = item.KYCDetails,
                            AdharcardDetails = item.AdharcardDetails,
                            VoterID = item.VoterID,
                            ContactNumber1 = item.ContactNumber1,
                            ContactNumber2 = item.ContactNumber2,
                            ContactNumber3 = item.ContactNumber3,
                            CenterID = item.CenterID,
                            CenterName = (item.CenterID != null && item.CenterID != 0) ? Centerlist.Where(m => m.CenterID == item.CenterID).FirstOrDefault().CenterName : "",
                            CenterList = new List<CenterData>(),
                            PermanentAddressLine1 = item.PermanentAddressLine1,
                            PermanentAddressLine2 = item.PermanentAddressLine2,
                            PermanentCity = item.PermanentCity,
                            PermanentPinCode = item.PermanentPinCode,
                            TemporaryAddressLine1 = item.TemporaryAddressLine1,
                            TemporaryAddressLine2 = item.TemporaryAddressLine2,
                            TemporaryCity = item.TemporaryCity,
                            TemporaryPinCode = item.TemporaryPinCode,
                            JoiningDate = item.JoiningDate,
                            IsActive = item.IsActive,
                            IncomeType = new List<IncomeTypeData>(),                            
                            IncomeType1 = new List<IncomeTypeData>(),
                            IncomeType2 = new List<IncomeTypeData>(),
                            IncomeTypeOne = item.IncomeTypeOne,
                            IncomeTypeOneName = (item.IncomeTypeOne != null && item.IncomeTypeOne != 0) ? IncomeTypelist.Where(m => m.IncomeTypeID == item.IncomeTypeOne).FirstOrDefault().IncomeType1 : "",
                            IncomeTypeTwo = item.IncomeTypeTwo,
                            IncomeTypeTwoName = (item.IncomeTypeTwo != null && item.IncomeTypeTwo != 0) ? IncomeTypelist.Where(m => m.IncomeTypeID == item.IncomeTypeTwo).FirstOrDefault().IncomeType1 : "",
                            IncomeTypeThree = item.IncomeTypeThree,
                            IncomeTypeThreeName = (item.IncomeTypeThree != null && item.IncomeTypeThree != 0) ? IncomeTypelist.Where(m => m.IncomeTypeID == item.IncomeTypeThree).FirstOrDefault().IncomeType1 : "",
                            IncomeNoteOne =item.IncomeNoteOne,
                            IncomeNoteTwo=item.IncomeNoteTwo,
                            IncomeNoteThree=item.IncomeNoteThree,
                            IncomeAmountOne=item.IncomeAmountOne,
                            IncomeAmountTwo=item.IncomeAmountTwo,
                            IncomeAmountThree=item.IncomeAmountThree,
                            CustomerRegStatusList  = new List<CustomerRegStatusData>(),
                            CustomerRegStatusID =item.CustomerRegStatusID,
                            CustomerRegStatusName = (item.CustomerRegStatusID != null && item.CustomerRegStatusID != 0) ? CustomerRegStatuslist.Where(m => m.CustomerRegStatusID == item.CustomerRegStatusID).FirstOrDefault().CustomerRegStatus : "",
                            UserAccountList = new List<UserAccountData>(),
                            RegStatusEnterdByID =item.RegStatusEnterdByID,
                            RegStatusEnterdByName = (item.RegStatusEnterdByID != null && item.RegStatusEnterdByID != 0) ? UserAccountList.Where(m => m.UserAccountID == item.RegStatusEnterdByID).FirstOrDefault().FullName : "",
                            RegStatusEnterdByDate =item.RegStatusEnterdByDate,
                            RegStatusReviewedByID=item.RegStatusReviewedByID,
                            RegStatusReviewedByName = (item.RegStatusReviewedByID != null && item.RegStatusReviewedByID != 0) ? UserAccountList.Where(m => m.UserAccountID == item.RegStatusReviewedByID).FirstOrDefault().FullName : "",
                            RegStatusReviewedByDate =item.RegStatusReviewedByDate,
                            RegStatusApprovedByID=item.RegStatusApprovedByID,
                            RegStatusApprovedByName = (item.RegStatusApprovedByID != null && item.RegStatusApprovedByID != 0) ? UserAccountList.Where(m => m.UserAccountID == item.RegStatusApprovedByID).FirstOrDefault().FullName : "",
                            RegStatusApprovedByDate =item.RegStatusApprovedByDate,
                            CreatedDate=item.CreatedDate,
                            CreatedBy=item.CreatedBy,
                            EntryComments=item.EntryComments,
                            ReviewComments=item.ReviewComments,
                            ApproveComments=item.ApproveComments

                        }
                    );
                    


                }
                return objList;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        // Method : 2
        [Route("api/DropCustomer/{id}")]
        public bool GetRemoveCustomerDetail(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return false;
            }
            try
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Method : 3
        // GET: api/DataEntryOperators/5
        [ResponseType(typeof(CustomerData))]
        public CustomerData GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            var IncomeTypelist = new List<IncomeTypeData>();
            foreach (var item in db.IncomeTypes)
            {
                IncomeTypelist.Add(new IncomeTypeData
                {
                    IncomeType1 = item.IncomeType1,
                    IncomeTypeID = item.IncomeTypeID
                });
            }

            var CustomerRegStatuslist = new List<CustomerRegStatusData>();
            var CustomerRegStatusDB = db.CustomerRegStatus.ToList();

            foreach (var item in CustomerRegStatusDB)
            {
                CustomerRegStatuslist.Add(new CustomerRegStatusData
                {
                    CustomerRegStatusID = item.CustomerRegStatusID,
                    CustomerRegStatus = item.CustomerRegStatus
                });
            }

            var Centerlist = new List<CenterData>();
            var CenterDB = db.Centers.ToList();

            foreach (var item in CenterDB)
            {
                Centerlist.Add(new CenterData
                {
                    CenterID = item.CenterID,
                    CenterName = item.CenterName
                });
            }
            var UserAccountList = new List<UserAccountData>();

            var UserAccount = db.UserAccounts.ToList();

            foreach (var item in UserAccount)
            {
                UserAccountList.Add(new UserAccountData
                {
                    UserAccountID = item.UserAccountID,
                    FullName = item.FullName
                });
            }

            CustomerData obj = new CustomerData();
            if (customer != null)
            {
                obj = new CustomerData
                {
                    CustomerID = customer.CustomerID,
                    CustomerName = customer.CustomerName,
                    YearOfBirth = customer.YearOfBirth,
                    KYCDetails = customer.KYCDetails,
                    AdharcardDetails = customer.AdharcardDetails,
                    VoterID = customer.VoterID,
                    ContactNumber1 = customer.ContactNumber1,
                    ContactNumber2 = customer.ContactNumber2,
                    ContactNumber3 = customer.ContactNumber3,
                    CenterID = customer.CenterID,
                    CenterName= (customer.Center!=null)?customer.Center.CenterName:"",
                    CenterList = Centerlist,
                    PermanentAddressLine1 = customer.PermanentAddressLine1,
                    PermanentAddressLine2 = customer.PermanentAddressLine2,
                    PermanentCity = customer.PermanentCity,
                    PermanentPinCode = customer.PermanentPinCode,
                    TemporaryAddressLine1 = customer.TemporaryAddressLine1,
                    TemporaryAddressLine2 = customer.TemporaryAddressLine2,
                    TemporaryCity = customer.TemporaryCity,
                    TemporaryPinCode = customer.TemporaryPinCode,
                    JoiningDate = customer.JoiningDate,
                    IsActive = customer.IsActive,
                    IncomeType = IncomeTypelist,
                    IncomeType1 = IncomeTypelist,
                    IncomeType2 = IncomeTypelist,
                    IncomeTypeOne = customer.IncomeTypeOne,
                    IncomeTypeOneName = (customer.IncomeTypeOne!=null && customer.IncomeTypeOne != 0) ? db.IncomeTypes.Where(m=>m.IncomeTypeID== customer.IncomeTypeOne).FirstOrDefault().IncomeType1:"",
                    IncomeTypeTwo = customer.IncomeTypeTwo,
                    IncomeTypeTwoName = (customer.IncomeTypeTwo != null && customer.IncomeTypeTwo != 0) ? db.IncomeTypes.Where(m => m.IncomeTypeID == customer.IncomeTypeTwo).FirstOrDefault().IncomeType1 : "",
                    IncomeTypeThree = customer.IncomeTypeThree,
                    IncomeTypeThreeName = (customer.IncomeTypeThree != null && customer.IncomeTypeThree != 0) ? db.IncomeTypes.Where(m => m.IncomeTypeID == customer.IncomeTypeThree).FirstOrDefault().IncomeType1 : "",
                    IncomeNoteOne = customer.IncomeNoteOne,
                    IncomeNoteTwo = customer.IncomeNoteTwo,
                    IncomeNoteThree = customer.IncomeNoteThree,
                    IncomeAmountOne = customer.IncomeAmountOne,
                    IncomeAmountTwo = customer.IncomeAmountTwo,
                    IncomeAmountThree = customer.IncomeAmountThree,
                    CustomerRegStatusList = CustomerRegStatuslist,
                    CustomerRegStatusID = customer.CustomerRegStatusID,
                    CustomerRegStatusName = (customer.CustomerRegStatusID != null && customer.CustomerRegStatusID != 0) ? db.CustomerRegStatus.Where(m => m.CustomerRegStatusID == customer.CustomerRegStatusID).FirstOrDefault().CustomerRegStatus : "",
                    UserAccountList = UserAccountList,
                    RegStatusEnterdByID = customer.RegStatusEnterdByID,
                    RegStatusEnterdByName = (customer.RegStatusEnterdByID != null && customer.RegStatusEnterdByID != 0) ? db.UserAccounts.Where(m => m.UserAccountID == customer.RegStatusEnterdByID).FirstOrDefault().FullName : "",
                    RegStatusEnterdByDate = customer.RegStatusEnterdByDate,
                    RegStatusReviewedByID = customer.RegStatusReviewedByID,
                    RegStatusReviewedByName = (customer.RegStatusReviewedByID != null && customer.RegStatusReviewedByID != 0) ? db.UserAccounts.Where(m => m.UserAccountID == customer.RegStatusReviewedByID).FirstOrDefault().FullName : "",
                    RegStatusReviewedByDate = customer.RegStatusReviewedByDate,
                    RegStatusApprovedByID = customer.RegStatusApprovedByID,
                    RegStatusApprovedByName = (customer.RegStatusApprovedByID != null && customer.RegStatusApprovedByID != 0) ? db.UserAccounts.Where(m => m.UserAccountID == customer.RegStatusApprovedByID).FirstOrDefault().FullName : "",
                    RegStatusApprovedByDate = customer.RegStatusApprovedByDate,
                    CreatedDate = customer.CreatedDate,
                    CreatedBy = customer.CreatedBy,
                    EntryComments=customer.EntryComments,
                    ReviewComments=customer.ReviewComments,
                    ApproveComments=customer.ApproveComments
                };
            }
            else
            {
                obj = new CustomerData
                {
                    CustomerID = 0,
                    CustomerName = "",
                    YearOfBirth ="",
                    KYCDetails = "",
                    AdharcardDetails = "",
                    VoterID = "",
                    ContactNumber1 = "",
                    ContactNumber2 = "",
                    ContactNumber3 = "",
                    CenterID = 0,
                    CenterList = Centerlist,
                    PermanentAddressLine1 = "",
                    PermanentAddressLine2 = "",
                    PermanentCity = "",
                    PermanentPinCode = "",
                    TemporaryAddressLine1 = "",
                    TemporaryAddressLine2 ="",
                    TemporaryCity = "",
                    TemporaryPinCode = "",
                    JoiningDate = "",
                    IsActive = 0,
                    IncomeType = IncomeTypelist,
                    IncomeType1 = IncomeTypelist,
                    IncomeType2 = IncomeTypelist,
                    IncomeTypeOne = 0,
                    IncomeTypeTwo = 0,
                    IncomeTypeThree = 0,
                    IncomeNoteOne = "",
                    IncomeNoteTwo = "",
                    IncomeNoteThree = "",
                    IncomeAmountOne = "",
                    IncomeAmountTwo = "",
                    IncomeAmountThree = "",
                    CustomerRegStatusList = CustomerRegStatuslist,
                    CustomerRegStatusID = 0,
                    UserAccountList = UserAccountList,
                    RegStatusEnterdByID = 0,
                    RegStatusEnterdByDate = "",
                    RegStatusReviewedByID = 0,
                    RegStatusReviewedByDate = "",
                    RegStatusApprovedByID = 0,
                    RegStatusApprovedByDate = "",
                    CreatedDate = "",
                    CreatedBy = "",
                    EntryComments="",
                    ReviewComments="",
                    ApproveComments=""
                };
            }
            return obj;
        }

        // Method : 4
        // POST: api/UserAccounts
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult PostCustomer(CustomerData customerData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (customerData.CustomerID > 0)
                {
                    Customer obj = db.Customers.Find(customerData.CustomerID);


                    obj.CustomerID = customerData.CustomerID;
                    obj.CustomerName = customerData.CustomerName;
                    obj.YearOfBirth = customerData.YearOfBirth;
                    obj.KYCDetails = customerData.KYCDetails;
                    obj.AdharcardDetails = customerData.AdharcardDetails;
                    obj.VoterID = customerData.VoterID;
                    obj.ContactNumber1 = customerData.ContactNumber1;
                    obj.ContactNumber2 = customerData.ContactNumber2;
                    obj.ContactNumber3 = customerData.ContactNumber3;
                    obj.CenterID = customerData.CenterID;
                    obj.PermanentAddressLine1 = customerData.PermanentAddressLine1;
                    obj.PermanentAddressLine2 = customerData.PermanentAddressLine2;
                    obj.PermanentCity = customerData.PermanentCity;
                    obj.PermanentPinCode = customerData.PermanentPinCode;
                    obj.TemporaryAddressLine1 = customerData.TemporaryAddressLine1;
                    obj.TemporaryAddressLine2 = customerData.TemporaryAddressLine2;
                    obj.TemporaryCity = customerData.TemporaryCity;
                    obj.TemporaryPinCode = customerData.TemporaryPinCode;
                    obj.JoiningDate = customerData.JoiningDate;
                    obj.IsActive = customerData.IsActive;

                    obj.IncomeTypeOne = null;
                    obj.IncomeTypeTwo = null;
                    obj.IncomeTypeThree = null;
                    obj.IncomeNoteOne = customerData.IncomeNoteOne;
                    obj.IncomeNoteTwo = customerData.IncomeNoteTwo;
                    obj.IncomeNoteThree = customerData.IncomeNoteThree;
                    obj.IncomeAmountOne = customerData.IncomeAmountOne;
                    obj.IncomeAmountTwo = customerData.IncomeAmountTwo;
                    obj.IncomeAmountThree = customerData.IncomeAmountThree;

                    obj.CustomerRegStatusID = (customerData.CustomerRegStatusID > 0) ? customerData.CustomerRegStatusID : null;
                    obj.RegStatusEnterdByID = (customerData.RegStatusEnterdByID > 0) ? customerData.RegStatusEnterdByID : null;
                    obj.RegStatusEnterdByDate = customerData.RegStatusEnterdByDate;
                    obj.RegStatusReviewedByID = (customerData.RegStatusReviewedByID > 0) ? customerData.RegStatusReviewedByID : null;
                    obj.RegStatusReviewedByDate = customerData.RegStatusReviewedByDate;
                    obj.RegStatusApprovedByID = (customerData.RegStatusApprovedByID > 0) ? customerData.RegStatusApprovedByID : null;
                    obj.RegStatusApprovedByDate = customerData.RegStatusApprovedByDate;
                    obj.CreatedDate = customerData.CreatedDate;
                    obj.CreatedBy = customerData.CreatedBy;

                    obj.EntryComments = customerData.EntryComments;
                    obj.ReviewComments = customerData.ReviewComments;
                    obj.ApproveComments = customerData.ApproveComments;

                    db.SaveChanges();

                }
                else
                {
                    Customer obj = new Customer
                    {
                        CustomerID = customerData.CustomerID,
                        CustomerName = customerData.CustomerName,
                        YearOfBirth = customerData.YearOfBirth,
                        KYCDetails = customerData.KYCDetails,
                        AdharcardDetails = customerData.AdharcardDetails,
                        VoterID = customerData.VoterID,
                        ContactNumber1 = customerData.ContactNumber1,
                        ContactNumber2 = customerData.ContactNumber2,
                        ContactNumber3 = customerData.ContactNumber3,
                        CenterID = customerData.CenterID,
                        PermanentAddressLine1 = customerData.PermanentAddressLine1,
                        PermanentAddressLine2 = customerData.PermanentAddressLine2,
                        PermanentCity = customerData.PermanentCity,
                        PermanentPinCode = customerData.PermanentPinCode,
                        TemporaryAddressLine1 = customerData.TemporaryAddressLine1,
                        TemporaryAddressLine2 = customerData.TemporaryAddressLine2,
                        TemporaryCity = customerData.TemporaryCity,
                        TemporaryPinCode = customerData.TemporaryPinCode,
                        JoiningDate = customerData.JoiningDate,
                        IsActive = customerData.IsActive,

                        IncomeTypeOne = null,
                        IncomeTypeTwo = null,
                        IncomeTypeThree = null,
                        IncomeNoteOne = customerData.IncomeNoteOne,
                        IncomeNoteTwo = customerData.IncomeNoteTwo,
                        IncomeNoteThree = customerData.IncomeNoteThree,
                        IncomeAmountOne = customerData.IncomeAmountOne,
                        IncomeAmountTwo = customerData.IncomeAmountTwo,
                        IncomeAmountThree = customerData.IncomeAmountThree,

                        CustomerRegStatusID = (customerData.CustomerRegStatusID > 0) ? customerData.CustomerRegStatusID : null,
                        RegStatusEnterdByID = (customerData.RegStatusEnterdByID > 0) ? customerData.RegStatusEnterdByID : null,
                        RegStatusEnterdByDate = customerData.RegStatusEnterdByDate,
                        RegStatusReviewedByID = (customerData.RegStatusReviewedByID > 0)? customerData.RegStatusReviewedByID : null,
                        RegStatusReviewedByDate = customerData.RegStatusReviewedByDate,
                        RegStatusApprovedByID = (customerData.RegStatusApprovedByID>0)? customerData.RegStatusApprovedByID:null,
                        RegStatusApprovedByDate = customerData.RegStatusApprovedByDate,
                        CreatedDate = customerData.CreatedDate,
                        CreatedBy = customerData.CreatedBy,

                        EntryComments=customerData.EntryComments,
                        ReviewComments=customerData.ReviewComments,
                        ApproveComments=customerData.ApproveComments
                    };
                    db.Customers.Add(obj);
                    db.SaveChanges();
                }

                return CreatedAtRoute("DefaultApi", new { id = customerData.CustomerID }, customerData);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
      
    }
}