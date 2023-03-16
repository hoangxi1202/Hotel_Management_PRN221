using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStaffRepository
    {
        // List<staff> GetAll(int currentPage, int pageSize);
        List<staff> GetAll(int currentPage, int pageSize);
        staff GetEmailStaffbyLogins(string Email, string Password);
        List<staff> GetAllstaff();
        int Count();
        staff GetstaffbyId(string id);
        List<staff> Searchingstaff(string name);
         void AddNew(staff staff);
        

        void Updatestaff(staff staff);
        void Remove(staff staff);
       

        staff checkAdminLogin(string email, string password);
    }
}
