using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomerbyId(string id);
       
    
        void AddNew(Customer Customer);
        void UpdateCustomer(Customer Customer);
        void Remove(Customer Customer);
        Customer GetEmailStaffbyLogins(string Email, string Password);
        string FindMaxString(List<Customer> Customer);
        List<Customer> GetEmailCustomer(string Email);


    }
}
