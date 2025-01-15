using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class AccountMgt
    {
        public static StoreDetails GetStoreDetails(string StoreUserName)
        {
            return new BaseSQL().GetStoreDetails(StoreUserName);
        }

        public static AuthDetails GetUserAuthDetails(string email, string StoreUserName)
        {
            return new AccountSQL().GetUserAuthDetails(email, StoreUserName);
        }

        public static Authentication GetUserFullDetails(string email, int userId, string StoreUserName)
        {
            return new AccountSQL().GetUserFullDetails(email, userId, StoreUserName);
        }

        public static bool AddStoreUserOTP(int userId, string OTP, string StoreUserName)
        {
            return new AccountSQL().AddStoreUserOTP(userId, OTP, StoreUserName);
        }

        public static bool AddEmailHistoryWithOTP(EmailMsg email, int userId, string OTP, string StoreUserName)
        {
            return new AccountSQL().AddEmailHistoryWithOTP(email, userId, OTP, StoreUserName);
        }

        public static int VerifyOTP(int StoreUserId, string Email, string Otp, string StoreUserName)
        {
            return new AccountSQL().VerifyOTP(StoreUserId, Email, Otp, StoreUserName);
        }

        public static ForgotPassword GetPassResetLink(string Email, string IpAddress, string StoreUserName)
        {
            return new AccountSQL().GetPassResetLink(Email, IpAddress, StoreUserName);
        }

        public static SetPassword ValidateResetPassToken(string token, string StoreUserName)
        {
            return new AccountSQL().ValidateResetPassToken(token,StoreUserName);
        }

        public static bool SetPassword(SetPassword setPassword, string StoreUserName)
        {
            return new AccountSQL().SetPassword(setPassword, StoreUserName);
        }

        public static int AddStoreUserTOTP(TotpUserData obj, string StoreUserName)
        {
            return new AccountSQL().AddStoreUserTOTP(obj, StoreUserName);
        }

        public static string GetUserTotpSecretKey(int StoreUserId, string StoreUserName)
        {
            return new AccountSQL().GetUserTotpSecretKey(StoreUserId, StoreUserName);
        }

        public static void TrackLoginHistory(string StoreUserName, string email, string ipAddress, bool isFailed = true, int storeUserId = 0)
        {
            new AccountSQL().TrackLoginHistory(StoreUserName, storeUserId, email, ipAddress, isFailed);
        }
    }
}
