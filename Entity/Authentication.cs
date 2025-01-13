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
        public bool Is2FAVerified { get; set; }
        public bool IsOTPEnabled { get; set; }
        public bool IsOTPVerified { get; set; }

    }

    public class ForgotPassword
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public DateTime GuidTimeStamp { get; set; }
        public bool IsGuidExpired { get; set; }
        public string ForgotURL { get; set; }
        public int ReturnCode { get; set; }
    }

    public class SetPassword
    {
        public int StoreUserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Guid { get; set; }
        public bool IsGuidExpired { get; set; }
        public int ReturnCode { get; set; }
    }

    public class TotpUserData
    {
        public int StoreUserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string SecretKey { get; set; }
        public bool Is2FAEnabled { get; set; }
        public bool Is2FAVerified { get; set; }
        public int ReturnCode { get; set; }
    }
}
