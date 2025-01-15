using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class PageURL
    {
        //Error
        public const string FreeTrail = "/FreeTrail.aspx";
        public const string PageNotFound = "/PageNotFound.aspx";

        // Home
        public const string Default = "/Home/Default.aspx";
        public const string Dashboard = "/Home/Dashboard.aspx";
        public const string ChangePassword = "/Home/ChangePassword.aspx";
        public const string ForceUpdatePassword = "/Home/ForceUpdatePassword.aspx";
        public const string ForgotPassword = "/Home/ForgotPassword.aspx";
        public const string Login = "/Home/Login.aspx";
        public const string Register = "/Home/Register.aspx";
        public const string Setup2FA = "/Home/Setup2FA.aspx";
        public const string Verification2FA = "/Home/2FAVerification.aspx";
        public const string SmsEmailVerification = "/Home/SmsEmailVerification.aspx";

        // Customers
        public const string CustomersList = "/Home/Customers/CustomersList.aspx";
        public const string AddEditCustomer = "/Home/Customers/AddEditCustomer.aspx";

        // Products
        public const string ProductsList = "/Home/Products/ProductsList.aspx";
        public const string AddEditProduct = "/Home/Products/AddEditProduct.aspx";

        // Purchases
        public const string PurchasesList = "/Home/Purchases/PurchasesList.aspx";
        public const string AddPurchase = "/Home/Purchases/AddPurchase.aspx";

        // Sales
        public const string AddSale = "/Home/Sales/AddSale.aspx";
        public const string SalesList = "/Home/Sales/SalesList.aspx";
        public const string SaleDetails = "/Home/Sales/SaleDetails.aspx";

        // Settings
        public const string AddUpdateCategories = "/Home/Settings/AddUpdateCategories.aspx";
        public const string Setting = "/Home/Settings/Setting.aspx";
        public const string Configurations = "/Home/Settings/Configurations.aspx";
        public const string ListCategories = "/Home/Settings/ListCategories.aspx";

        // Suppliers
        public const string AddEditSupplier = "/Home/Suppliers/AddEditSupplier.aspx";
        public const string SuppliersList = "/Home/Suppliers/SuppliersList.aspx";
    }
}
