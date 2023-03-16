using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingManagement
    {
        private static BookingManagement instance = null;
        private static readonly object instanceLock = new object();
        private BookingManagement() { }
        public static BookingManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingManagement();
                    }
                }
                return instance;
            }
        }
        public List<Booking> GetByHotelId(string id)
        {
            List<Booking> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Bookings.Where(x => x.HotelID == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public List<Booking> GetByCusId(string id)
        {
            List<Booking> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Bookings.Where(x => x.CustomerId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public Booking GetBooking(string id)
        {
            Booking list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Bookings.SingleOrDefault(c => c.BookingId== id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public string AutoID()
        {
            string id = "BO1";
            try
            {
                var c = new Hotel_ManagementsContext();

                var temp = c.Bookings.OrderBy(e => e.BookingId).LastOrDefault().BookingId.Substring(2);
                var temp1 = Int32.Parse(temp) + 1;
                id = "BO" + temp1.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return id;
        }
        public string AddNew(Booking booking)
        {
            try
            {
                booking.BookingId = AutoID();
                var c = new Hotel_ManagementsContext();
                c.Bookings.Add(booking);
                c.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return booking.BookingId;
        }
        public void Update(Booking booking)
        {
            try
            {


                var c = new Hotel_ManagementsContext();
                c.Bookings.Update(booking);
                c.SaveChanges();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remove(Booking booking)
        {
            try
            {
                if (booking.Status == 1)
                {
                    booking.Status = 0;
                }
                else if (booking.Status == 0)
                {
                    booking.Status = 1;
                }

                var c = new Hotel_ManagementsContext();
                c.Bookings.Update(booking);
                c.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
