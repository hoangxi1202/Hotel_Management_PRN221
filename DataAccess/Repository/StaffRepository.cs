using BusinessObject.DataAccess;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StaffRepository : IStaffRepository
    {
        public void AddNew(staff staff) => StaffManagement.Instance.AddNew(staff);

        public staff checkAdminLogin(string email, string password) => StaffManagement.Instance.checkAdminLogin(email, password);

        public int Count() => StaffManagement.Instance.Count();
      

        public List<staff> GetAll(int currentPage, int pageSize) => StaffManagement.Instance.GetAll(currentPage, pageSize);
      




        //  public List<staff> GetAll(int currentPage, int pageSize) => StaffManagement.Instance.GetAll(currentPage, pageSize);


        public List<staff> GetAllstaff() => StaffManagement.Instance.GetAllstaff();

       

        public staff GetEmailStaffbyLogins(string Email, string Password) => StaffManagement.Instance.GetEmailStaffbyLogins(Email, Password);

     

        public staff GetstaffbyId(string id) => StaffManagement.Instance.GetstaffbyId(id);


        public void Remove(staff staff) => StaffManagement.Instance.Remove(staff);

        public List<staff> Searchingstaff(string name) => StaffManagement.Instance.Searchingstaff(name);
   

        public void Updatestaff(staff staff) => StaffManagement.Instance.Updatestaff(staff);
    }
}

       
