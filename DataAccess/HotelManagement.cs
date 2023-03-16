using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HotelManagement
    {
        private static HotelManagement instance = null;
        private static readonly object instanceLock = new object();
        private HotelManagement() { }
        public static HotelManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HotelManagement();
                    }
                }
                return instance;
            }
        }

        public List<Hotel> GetAll()
        {
            List<Hotel> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Hotels.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public List<Hotel> GetAllValid()
        {
            List<Hotel> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Hotels.Where(x => x.Status == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public Hotel GetHotelbyId(string id)
        {
            Hotel obj = null;

            try
            {
                var c = new Hotel_ManagementsContext();
                obj = c.Hotels.SingleOrDefault(c => c.HotelId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        public void AddNew(Hotel hotel)
        {
            try
            {
                
                
                    var c = new Hotel_ManagementsContext();
                    c.Hotels.Add(hotel);
                    c.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }


        public void Update(Hotel hotel)
        {
            try
            {


                var c = new Hotel_ManagementsContext();
                c.Hotels.Update(hotel);
                c.SaveChanges();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remove(Hotel hotel)
        {
            try
            {
                if (hotel.Status == 1)
                {
                    hotel.Status = 0;
                }
                else if (hotel.Status == 0)
                {
                    hotel.Status = 1;
                }

                var c = new Hotel_ManagementsContext();
                c.Hotels.Update(hotel);
                c.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
