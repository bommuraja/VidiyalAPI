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
                            CenterID = item.CenterID

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
            var cashPaymentStatu = db.Customers.Find(id);
            if (cashPaymentStatu == null)
            {
                return false;
            }
            try
            {
                db.Customers.Remove(cashPaymentStatu);
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
                    CenterID = customer.CenterID
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
                    CenterID = customerData.CenterID
                };
                db.Customers.Add(obj);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = customerData.CustomerID }, customerData);
        }
      
    }
}