using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class AccountMgt
    {
        public StoreDetails GetStoreDetails(string StoreUserName)
        {
            return new BaseSQL().GetStoreDetails(StoreUserName);
        }

        public AuthDetails GetUserAuthDetails(string email, string StoreUserName)
        {
            return new AccountSQL().GetUserAuthDetails(email, StoreUserName);
        }

        public Authentication GetUserFullDetails(string email, int userId, string StoreUserName)
        {
            return new AccountSQL().GetUserFullDetails(email, userId, StoreUserName);
        }

        public bool AddStoreUserOTP(int userId, string OTP, string StoreUserName)
        {
            return new AccountSQL().AddStoreUserOTP(userId, OTP, StoreUserName);
        }

        public bool AddEmailHistoryWithOTP(EmailMsg email, int userId, string OTP, string StoreUserName)
        {
            return new AccountSQL().AddEmailHistoryWithOTP(email, userId, OTP, StoreUserName);
        }

        public int VerifyOTP(int StoreUserId, string Email, string Otp, string StoreUserName)
        {
            return new AccountSQL().VerifyOTP(StoreUserId, Email, Otp, StoreUserName);
        }

        public ForgotPassword GetPassResetLink(string Email, string IpAddress, string StoreUserName)
        {
            return new AccountSQL().GetPassResetLink(Email, IpAddress, StoreUserName);
        }

        public SetPassword ValidateResetPassToken(string token, string StoreUserName)
        {
            return new AccountSQL().ValidateResetPassToken(token,StoreUserName);
        }

        public bool SetPassword(SetPassword setPassword, string StoreUserName)
        {
            return new AccountSQL().SetPassword(setPassword, StoreUserName);
        }

        public int AddStoreUserTOTP(TotpUserData obj, string StoreUserName)
        {
            return new AccountSQL().AddStoreUserTOTP(obj, StoreUserName);
        }

        public string GetUserTotpSecretKey(int StoreUserId, string StoreUserName)
        {
            return new AccountSQL().GetUserTotpSecretKey(StoreUserId, StoreUserName);
        }
    }
}
