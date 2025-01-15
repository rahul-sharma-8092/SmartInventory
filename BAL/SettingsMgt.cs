using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class SettingsMgt
    {
        public static int AddUpdateCategory(Categories category, string StoreUserName)
        {
            return new DAL.SettingsSQL().AddUpdateCategory(category, StoreUserName);
        }

        public static DataTable GetCategories(string StoreUserName)
        {
            return new DAL.SettingsSQL().GetCategories(StoreUserName);
        }

        public static string DeleteCategory(int id, string StoreUserName)
        {
            return new DAL.SettingsSQL().DeleteCategory(id,StoreUserName);
        }
    }
}
