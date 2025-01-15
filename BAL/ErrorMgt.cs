using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class ErrorMgt
    {
        public static void LogErrorToDB(ExecptionErrror objEx)
        {
            new DAL.BaseSQL().LogErrorToDB(objEx, objEx.StoreUserName);
        }
    }
}
