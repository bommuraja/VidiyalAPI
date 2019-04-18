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
    public class CentersController : ApiController
    {
        private bommuraj_Vidiyal db = new bommuraj_Vidiyal();

        // Method : 1
        // GET: api/Centers
        public List<CenterData> GetCenters()
        {
            try
            {
                List<CenterData> objList = new List<CenterData>();

                foreach (var item in db.Centers)
                {
                    objList.Add(
                        new CenterData
                        {
                            CenterID = item.CenterID,
                            CenterName = item.CenterName,
                            CenterHeadName = item.CenterHeadName,
                            CenterAddressLine1 = item.CenterAddressLine1,
                            CenterAddressLine2 = item.CenterAddressLine2,
                            City = item.City,
                            CenterContactNumber = item.CenterContactNumber,
                            CenterStartDate = item.CenterStartDate,
                            CreatedDate = item.CreatedDate,
                            CreatedBy = item.CreatedBy
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
        [Route("api/DropCenter/{id}")]
        public bool GetRemoveCenterDetail(int id)
        {
            var center = db.Centers.Find(id);
            if (center == null)
            {
                return false;
            }
            try
            {
                db.Centers.Remove(center);
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
        [ResponseType(typeof(CenterData))]
        public CenterData GetCenter(int id)
        {
            var center = db.Centers.Find(id);
            CenterData obj = new CenterData();
            if (center != null)
            {
                obj = new CenterData
                {
                    CenterID = center.CenterID,
                    CenterName = center.CenterName,
                    CenterHeadName = center.CenterHeadName,
                    CenterAddressLine1 = center.CenterAddressLine1,
                    CenterAddressLine2 = center.CenterAddressLine2,
                    City = center.City,
                    CenterContactNumber = center.CenterContactNumber,
                    CenterStartDate = center.CenterStartDate,
                    CreatedDate = center.CreatedDate,
                    CreatedBy = center.CreatedBy
                };
            }
            return obj;
        }

        // Method : 4
        // POST: api/UserAccounts
        [ResponseType(typeof(CenterData))]
        public IHttpActionResult PostCenter(CenterData centerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (centerData.CenterID > 0)
            {
                Center obj = db.Centers.Find(centerData.CenterID);

                obj.CenterID = centerData.CenterID;
                obj.CenterName = centerData.CenterName;
                obj.CenterHeadName = centerData.CenterHeadName;
                obj.CenterAddressLine1 = centerData.CenterAddressLine1;
                obj.CenterAddressLine2 = centerData.CenterAddressLine2;
                obj.City = centerData.City;
                obj.CenterContactNumber = centerData.CenterContactNumber;
                obj.CenterStartDate = centerData.CenterStartDate;
                obj.CreatedDate = centerData.CreatedDate;
                obj.CreatedBy = centerData.CreatedBy;
                db.SaveChanges();

            }
            else
            {
                Center obj = new Center
                {
                    CenterID = centerData.CenterID,
                    CenterName = centerData.CenterName,
                    CenterHeadName = centerData.CenterHeadName,
                    CenterAddressLine1 = centerData.CenterAddressLine1,
                    CenterAddressLine2 = centerData.CenterAddressLine2,
                    City = centerData.City,
                    CenterContactNumber = centerData.CenterContactNumber,
                    CenterStartDate = centerData.CenterStartDate,
                    CreatedDate = centerData.CreatedDate,
                    CreatedBy = centerData.CreatedBy
                };
                db.Centers.Add(obj);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = centerData.CenterID }, centerData);
        }

    }
}
