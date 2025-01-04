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
        public AuthDetails GetUserAuthDetails(string email)
        {
           return new AccountSQL().GetUserAuthDetails(email);
        }

        public Authentication GetUserFullDetails(string email, int userId)
        {
            return new AccountSQL().GetUserFullDetails(email, userId);
        }
    }
}
