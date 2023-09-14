using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4th_Monthly_Project_IsDB.AdminPart
{
    public class AdminRepo : IRepo
    {

        public IEnumerable<AdminInfo> ShowAdmin()
        {
            return AdminDB.AdminList;
        }

        public AdminInfo GetAdmin(int adminId)
        {
            AdminInfo adminInfo = AdminDB.AdminList.FirstOrDefault(x => x.AdminId == adminId);
            return adminInfo;
        }

        public void AddAdmin(AdminInfo adminInfo)
        {
            AdminDB.AdminList.Add(adminInfo);
        }

        public void UpdateAdmin(AdminInfo adminInfo)
        {
            AdminInfo _adminInfo = AdminDB.AdminList.FirstOrDefault(x => x.AdminId == adminInfo.AdminId);
            if (adminInfo.AdminName != null)
            {
                _adminInfo.AdminName = adminInfo.AdminName;
            }
            if (adminInfo.AdminPass != null)
            {
                _adminInfo.AdminPass = adminInfo.AdminPass;
            }
        }

        public void DeleteAdmin(int adminId)
        {
            AdminInfo adminInfo = AdminDB.AdminList.FirstOrDefault(x => x.AdminId == adminId);
            AdminDB.AdminList.Remove(adminInfo);
        }

    }
}
