using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidiyalAPI.Models.Business
{
    public class UserAccountData
    {
        public int UserAccountID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string AliesName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}