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
                        IncomeType1=item.IncomeType1,
                        IncomeTypeID=item.IncomeTypeID
                    });
                }

                var CustomerRegStatuslist = new List<CustomerRegStatusData>();
                var CustomerRegStatusDB = db.CustomerRegStatus.ToList();

                foreach (var item in CustomerRegStatusDB)
                {
                    CustomerRegStatuslist.Add(new CustomerRegStatusData
                    {
                       CustomerRegStatusID=item.CustomerRegStatusID,
                       CustomerRegStatus=item.CustomerRegStatus
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
                            IncomeType = IncomeTypelist,                            
                            IncomeType1 = IncomeTypelist,
                            IncomeType2 = IncomeTypelist,
                            IncomeTypeOne = item.IncomeTypeOne,
                            IncomeTypeTwo = item.IncomeTypeTwo,
                            IncomeTypeThree = item.IncomeTypeThree,
                            IncomeNoteOne =item.IncomeNoteOne,
                            IncomeNoteTwo=item.IncomeNoteTwo,
                            IncomeNoteThree=item.IncomeNoteThree,
                            IncomeAmountOne=item.IncomeAmountOne,
                            IncomeAmountTwo=item.IncomeAmountTwo,
                            IncomeAmountThree=item.IncomeAmountThree,
                            CustomerRegStatusList  = CustomerRegStatuslist,
                            CustomerRegStatusID =item.CustomerRegStatusID,
                            RegStatusEnterdByID=item.RegStatusEnterdByID,
                            RegStatusEnterdByDate=item.RegStatusEnterdByDate,
                            RegStatusReviewedByID=item.RegStatusReviewedByID,
                            RegStatusReviewedByDate=item.RegStatusReviewedByDate,
                            RegStatusApprovedByID=item.RegStatusApprovedByID,
                            RegStatusApprovedByDate=item.RegStatusApprovedByDate,
                            CreatedDate=item.CreatedDate,
                            CreatedBy=item.CreatedBy

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
                    IncomeTypeTwo = customer.IncomeTypeTwo,
                    IncomeTypeThree = customer.IncomeTypeThree,
                    IncomeNoteOne = customer.IncomeNoteOne,
                    IncomeNoteTwo = customer.IncomeNoteTwo,
                    IncomeNoteThree = customer.IncomeNoteThree,
                    IncomeAmountOne = customer.IncomeAmountOne,
                    IncomeAmountTwo = customer.IncomeAmountTwo,
                    IncomeAmountThree = customer.IncomeAmountThree,
                    CustomerRegStatusList = CustomerRegStatuslist,
                    CustomerRegStatusID = customer.CustomerRegStatusID,
                    RegStatusEnterdByID = customer.RegStatusEnterdByID,
                    RegStatusEnterdByDate = customer.RegStatusEnterdByDate,
                    RegStatusReviewedByID = customer.RegStatusReviewedByID,
                    RegStatusReviewedByDate = customer.RegStatusReviewedByDate,
                    RegStatusApprovedByID = customer.RegStatusApprovedByID,
                    RegStatusApprovedByDate = customer.RegStatusApprovedByDate,
                    CreatedDate = customer.CreatedDate,
                    CreatedBy = customer.CreatedBy
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

                    obj.IncomeTypeOne = customerData.IncomeTypeOne;
                    obj.IncomeTypeTwo = customerData.IncomeTypeTwo;
                    obj.IncomeTypeThree = customerData.IncomeTypeThree;
                    obj.IncomeNoteOne = customerData.IncomeNoteOne;
                    obj.IncomeNoteTwo = customerData.IncomeNoteTwo;
                    obj.IncomeNoteThree = customerData.IncomeNoteThree;
                    obj.IncomeAmountOne = customerData.IncomeAmountOne;
                    obj.IncomeAmountTwo = customerData.IncomeAmountTwo;
                    obj.IncomeAmountThree = customerData.IncomeAmountThree;

                    obj.CustomerRegStatusID = customerData.CustomerRegStatusID;
                    obj.RegStatusEnterdByID = customerData.RegStatusEnterdByID;
                    obj.RegStatusEnterdByDate = customerData.RegStatusEnterdByDate;
                    obj.RegStatusReviewedByID = customerData.RegStatusReviewedByID;
                    obj.RegStatusReviewedByDate = customerData.RegStatusReviewedByDate;
                    obj.RegStatusApprovedByID = customerData.RegStatusApprovedByID;
                    obj.RegStatusApprovedByDate = customerData.RegStatusApprovedByDate;
                    obj.CreatedDate = customerData.CreatedDate;
                    obj.CreatedBy = customerData.CreatedBy;

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

                        IncomeTypeOne = customerData.IncomeTypeOne,
                        IncomeTypeTwo = customerData.IncomeTypeTwo,
                        IncomeTypeThree = customerData.IncomeTypeThree,
                        IncomeNoteOne = customerData.IncomeNoteOne,
                        IncomeNoteTwo = customerData.IncomeNoteTwo,
                        IncomeNoteThree = customerData.IncomeNoteThree,
                        IncomeAmountOne = customerData.IncomeAmountOne,
                        IncomeAmountTwo = customerData.IncomeAmountTwo,
                        IncomeAmountThree = customerData.IncomeAmountThree,

                        CustomerRegStatusID = customerData.CustomerRegStatusID,
                        RegStatusEnterdByID = customerData.RegStatusEnterdByID,
                        RegStatusEnterdByDate = customerData.RegStatusEnterdByDate,
                        RegStatusReviewedByID = customerData.RegStatusReviewedByID,
                        RegStatusReviewedByDate = customerData.RegStatusReviewedByDate,
                        RegStatusApprovedByID = customerData.RegStatusApprovedByID,
                        RegStatusApprovedByDate = customerData.RegStatusApprovedByDate,
                        CreatedDate = customerData.CreatedDate,
                        CreatedBy = customerData.CreatedBy
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