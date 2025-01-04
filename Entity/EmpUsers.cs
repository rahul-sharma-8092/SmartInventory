using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpUsers
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
        public string Mobile { get; set; }
        public string Guid { get; set; }
        public DateTime GuidTimeStamp { get; set; }
        public bool IsGuidExpired { get; set; }
        
    }
}
