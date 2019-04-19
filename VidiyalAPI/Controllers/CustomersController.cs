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

                foreach (var item in db.Customers)
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
                            IsActive = item.IsActive

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
                    IsActive = customer.IsActive
                };
            }
            return obj;
        }

        // Method : 4
        // POST: api/UserAccounts
        [ResponseType(typeof(CustomerData))]
        public IHttpActionResult PostCustomer(CustomerData customerData)
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
                    IsActive = customerData.IsActive
                };
                db.Customers.Add(obj);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = customerData.CustomerID }, customerData);
        }
      
    }
}