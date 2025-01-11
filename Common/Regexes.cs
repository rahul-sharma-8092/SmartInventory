using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Regexes
    {
        public const string Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$";
        public const string Phone = @"^(\+?(\d{1,3}))?(\d{10,12})$";
        public const string Name = @"^[a-zA-Z\s]{3,50}$";
        public const string Address = @"^[a-zA-Z0-9\s\-,]{3,100}$";
        public const string City = @"^[a-zA-Z\s]{3,50}$";
        public const string PostalCode = @"^[a-zA-Z0-9\s\-,]{3,10}$";
        public const string Country = @"^[a-zA-Z\s]{3,50}$";
        public const string ProductDescription = @"^[a-zA-Z0-9\s\-,]{3,500}$";
        public const string ProductCode = @"^[a-zA-Z0-9\s\-,]{3,20}$";
        public const string ProductPrice = @"^\d{1,10}(\.\d{1,2})?$";
        public const string ProductQuantity = @"^\d{1,10}$";
       
    }
}
