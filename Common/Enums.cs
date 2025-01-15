using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum UserRole
    {
        ADMIN = 1,
        MANAGER = 2,
        STAFF = 3
    }

    public enum AuthStatus
    {
        LoggedOut = 0,
        LoggedIn = 1,
        InvalidCredentials = 2,
        LockedOut = 3,
        TwoFactorRequired = 4
    }

    public enum PasswordResetStatus
    {
        Pending = 1,
        Successful = 2,
        Failed = 3,
        Expired = 4
    }

    public enum OTPStatus
    {
        NotSent = 0,
        Sent = 1,
        Verified = 2,
        VerificationFailed = 3,
        Expired = 4
    }

    public enum OrderStatus
    {
        Pending = 1,
        Completed = 2,
        Cancelled = 3,
        Shipped = 4,
        Delivered = 5
    }

    public enum PaymentStatus
    {
        Pending = 1,
        Successful = 2,
        Failed = 3,
        Refunded = 4
    }

    public enum ProductAvailability
    {
        InStock = 1,
        OutOfStock = 2,
        BackOrdered = 3,
        Discontinued = 4
    }

    public enum TransactionType
    {
        Sale = 1,
        Purchase = 2,
        Refund = 3
    }

    public enum NotificationType
    {
        Email = 1,
        SMS = 2,
        PushNotification = 3
    }

    public enum SupplierStatus
    {
        Active = 1,
        Inactive = 2,
        PendingApproval = 3,
        Suspended = 4
    }

    public enum VerificationStatus
    {
        Pending = 1,
        Verified = 2,
        Failed = 3,
        Expired = 4
    }

    public enum SystemErrorCode
    {
        Unknown = 0,
        InvalidInput = 1,
        UnauthorizedAccess = 2,
        ResourceNotFound = 3,
        DatabaseError = 4
    }

    public enum TwoFactorStatus
    {
        Disabled = 0,
        Enabled = 1,
        Pending = 2,
        Failed = 3
    }

    public enum AuditActionType
    {
        Created = 1,
        Updated = 2,
        Deleted = 3,
        LoggedIn = 4,
        LoggedOut = 5
    }

    public enum CurrencyType
    {
        USD = 1,
        EUR = 2,
        GBP = 3,
        INR = 4,
        JPY = 5
    }

    public enum LogLevel
    {
        Info = 1,
        Error = 2,
        Critical = 3,
        Trace = 4,
        Debug = 5,
        Warning = 6
    }

    public enum SettingHandler
    {
        GetCategories = 1,
        DeleteCategory = 2,
    }
}
