using BusinessObject.DataAccess;
using DataAccess;
using Repository;
using System;
using System.Collections.Generic;

namespace Hotel_Management_Web.Pages
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddNew(Customer Customer) => CustomerManagement.Instance.AddNew(Customer);

        public string FindMaxString(List<Customer> Customer) => CustomerManagement.Instance.FindMaxString(Customer);
    

        public List<Customer> GetAllCustomer() => CustomerManagement.Instance.GetAllCar();

        public Customer GetCustomerbyId(string id) => CustomerManagement.Instance.GetCustomerbyId(id);

        public List<Customer> GetEmailCustomer(string Email) => CustomerManagement.Instance.GetEmailCustomer(Email);
     

        public Customer GetEmailStaffbyLogins(string Email, string Password) => CustomerManagement.Instance.GetEmailStaffbyLogins(Email,Password);


        public void Remove(Customer Customer) => CustomerManagement.Instance.AddNew(Customer);

      

        public void UpdateCustomer(Customer Customer) => CustomerManagement.Instance.AddNew(Customer);

    }
}