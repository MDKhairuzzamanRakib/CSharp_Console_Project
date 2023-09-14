using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4th_Monthly_Project_IsDB.AdminPart
{
    public interface IRepo
    {
        IEnumerable<AdminInfo> ShowAdmin();
        AdminInfo GetAdmin(int adminId);
        void AddAdmin(AdminInfo adminInfo);
        void UpdateAdmin(AdminInfo adminInfo);
        void DeleteAdmin(int adminId);
    }
}
