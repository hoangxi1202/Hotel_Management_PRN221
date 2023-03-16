using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StaffManagement
    {
        private static StaffManagement instance = null;
        private static readonly object instanceLock = new object();
        private StaffManagement() { }
        public static StaffManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffManagement();
                    }
                }
                return instance;
            }
        }

        public List<staff> GetAllstaff()
        {
            List<staff> cars;
            try
            {
                var c = new Hotel_ManagementsContext();
                cars = c.staff.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }
        public List<staff> GetAll(int currentPage, int pageSize)
        {
            List<staff> StaffAccounts;
            try
            {
                var c = new Hotel_ManagementsContext();
                StaffAccounts = c.staff.OrderBy(c => c.StaffId).Skip((currentPage - 1) * pageSize)
                .Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return StaffAccounts;

        }
        public int Count()
        {
            int a;
            try
            {
                var c = new Hotel_ManagementsContext();
                a = c.staff.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return a;
        }
        public staff GetstaffbyId(string id)
        {
            staff car = null;

            try
            {
                var c = new Hotel_ManagementsContext();
                car = c.staff.SingleOrDefault(c => c.StaffId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }
        public staff GetEmailStaffbyLogins(string Email, string Password)
        {
            staff staff = null;
            var c = new Hotel_ManagementsContext();
            try
            {
                staff = c.staff.SingleOrDefault(c => c.Email == Email && c.Password == Password);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staff;
        }
        
        public List<staff> Searchingstaff(string name)
       {
           List<staff> List = new List<staff>();

            try
           {
               var c = new Hotel_ManagementsContext();
               List = c.staff.Where(x => x.StaffName == name || x.Email == name || x.Password == name ).ToList();

         }
           catch (Exception ex)
          {
               throw new Exception(ex.Message);
           }
           return List;
       }

        public void AddNew(staff staff)
        {
            try
            {
              staff _car1 = GetstaffbyId(staff.StaffId);
                if (_car1 == null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.staff.Add(staff);
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


        public void Updatestaff(staff cars)
        {
            try
            {             
                if (cars != null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.staff.Update(cars);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already Exist");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remove(staff car)
        {
            try
            {
                staff _car1 = GetstaffbyId(car.StaffId);
                if (_car1 != null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.staff.Remove(car);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public staff checkAdminLogin(string email, string password)
        {
            var c = new Hotel_ManagementsContext();
            staff admin = c.getDefaultAccounts();
            if (email == admin.Email && password == admin.Password)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }


    }
}
