using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ExecptionErrror
    {
        public string StoreUserName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string URL { get; set; }
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public int UserId { get; set; } = 0;
        public int LogLevel { get; set; } = 2; // Error
    }
}
