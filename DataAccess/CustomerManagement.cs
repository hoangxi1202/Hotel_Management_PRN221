using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class CustomerManagement
    {
        private static CustomerManagement instance = null;
        private static readonly object instanceLock = new object();
        private CustomerManagement() { }
        public static CustomerManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerManagement();
                    }
                }
                return instance;
            }
        }
        public List<Customer> GetEmailCustomer(string Email)
        {
            List<Customer> List = new List<Customer>();
            var c = new Hotel_ManagementsContext();
            try
            {
                List = c.Customers.Where(c => c.Email == Email).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return List;
        }
        public List<Customer> GetAllCar()
        {
            List<Customer> cars;
            try
            {
                var c = new Hotel_ManagementsContext();
                cars = c.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        public string FindMaxString(List<Customer> Customer)
        {
            string cus = null;
            try
            {


                var c = new Hotel_ManagementsContext();
                cus = Customer.Select(cust => cust.CustomerId)
                      .OrderBy(id => id)
                      .Last();



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cus;
        }

        public Customer GetCustomerbyId(string id)
        {
            Customer car = null;

            try
            {
                var c = new Hotel_ManagementsContext();
                car = c.Customers.SingleOrDefault(c => c.CustomerId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }
        public Customer GetEmailStaffbyLogins(string Email, string Password)
        {
            Customer staff = null;
            var c = new Hotel_ManagementsContext();
            try
            {
                staff = c.Customers.SingleOrDefault(c => c.Email == Email && c.Password == Password);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staff;
        }
        //  public List<Customer> SearchingCustomer(string name, int nums)
        //  {
        //      List<Customer> List = new List<Customer>();

        //  try
        //  {
        //      var c = new Hotel_ManagementsContext();
        //      List = c.Customer.Where(x => x.ProducerId == name || x.ProcuderName == name || x.Address == name || x.Country == name).ToList();

        //  }
        //    catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        //      return List;
        //   }

        public void AddNew(Customer Customer)
        {
            try
            {
                Customer _car1 = GetCustomerbyId(Customer.CustomerId);
                if (_car1 == null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.Customers.Add(Customer);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }


        public void UpdateCar(Customer cars)
        {
            try
            {
                Customer _car1 = GetCustomerbyId(cars.CustomerId);
                if (_car1 != null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.Customers.Update(cars);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The Customers does not already Exist");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remove(Customer car)
        {
            try
            {
                Customer _car1 = GetCustomerbyId(car.CustomerId);
                if (_car1 != null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.Customers.Remove(car);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The Customers does not already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
