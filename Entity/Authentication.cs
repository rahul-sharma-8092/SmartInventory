using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Authentication
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime LoginTimeStamp { get; set; }
        public string IpAddress { get; set; }
    }

    public class AuthDetails
    {
        public int StoreUserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public int GroupId { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public bool ForceUpdatePassword { get; set; }
        public bool IsTempBlocked { get; set; }
        public bool Is2FAEnabled { get; set; }
        public bool IsOTPEnabled { get; set; }


    }
}
