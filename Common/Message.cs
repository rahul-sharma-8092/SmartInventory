using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Message
    {
        // Server Error Messages
        public const string InternalServerError = "An internal server error occurred.";
        public const string SomethingWentWrong = "Something went wrong. Please try again later.";

        // Validation Messages
        public const string Success = "Operation completed successfully.";
        public const string RequiredField = "Required.";
        public const string InvalidInput = "Invalid.";

        // Authentication Messages
        public const string InvalidLogin = "Invalid username or password.";
        public const string AccountLocked = "Your account is locked. Please contact the administrator.";

        // Verification Messages
        public const string EmailInvitation = "An invitation has been sent to your email address.";
        public const string EmailVerification = "Your email has been successfully verified.";
        public const string EmailVerificationFailed = "Email verification failed. Please try again.";
        public const string InvalidVerificationLink = "The verification link is either expired or invalid.";

        // OTP Messages
        public const string OTPSent = "An OTP has been sent to your email address.";
        public const string OTPVerified = "OTP verification successful.";
        public const string OTPVerificationFailed = "OTP verification failed. Please try again.";

        // Password Messages
        public const string PasswordChanged = "Your password has been successfully changed.";
        public const string PasswordChangedFailed = "Password change failed. Please try again.";
        public const string ForgotPasswordLink = "A password reset link has been sent to your email address.";
    }
}
