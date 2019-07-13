using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VidiyalAPI.Models.Business;

namespace VidiyalAPI.Controllers
{
    public class UserAccountController : ApiController
    {
        private bommuraj_Vidiyal db = new bommuraj_Vidiyal();

        [ResponseType(typeof(Models.Business.UserAccountData))]
        public Models.Business.UserAccountData GetUserAccount(string userName, string passWord)
        {
            try
            {
                var userRoleList = db.Roles.ToList();
                var userRoleDataList = new List<UserRoleData>();
                foreach (var item in userRoleList)
                {
                    var userRole = new UserRoleData
                    {
                        RoleID = item.RoleID,
                        RoleName = item.RoleName,
                        CreatedBy = item.CreatedBy,
                        CreatedDate = item.CreatedDate
                        
                    };
                    userRoleDataList.Add(userRole);
                }
                var userAccounts = db.UserAccounts.Where(m => m.UserName == userName && m.Password == passWord).SingleOrDefault();
                Models.Business.UserAccountData obj = new Models.Business.UserAccountData();
                if (userAccounts != null)
                {
                    obj = new Models.Business.UserAccountData
                    {
                        UserAccountID = userAccounts.UserAccountID,
                        RoleID = userAccounts.RoleID,
                        RoleName = userAccounts.Role.RoleName,
                        FullName=userAccounts.FullName,
                        AliesName=userAccounts.AliesName,
                        UserName = userAccounts.UserName,
                        Password = userAccounts.Password,
                        CreatedDate = userAccounts.CreatedDate,
                        CreatedBy = userAccounts.CreatedBy
                    };
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
