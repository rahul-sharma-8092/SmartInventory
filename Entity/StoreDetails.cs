using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StoreDetails
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreUserName { get; set; }
        public int SubscriberId { get; set; }
        public string Subscriber { get; set; }
        public int DBId { get; set; }
        public string Server { get; set; }
        public string DBName { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        public int Status { get; set; }
    }
}
