using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingDetailManagement
    {
        private static BookingDetailManagement instance = null;
        private static readonly object instanceLock = new object();
        private BookingDetailManagement() { }
        public static BookingDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDetailManagement();
                    }
                }
                return instance;
            }
        }
        public List<BookingDetail> GetByBookingId(string id)
        {
            List<BookingDetail> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.BookingDetails.Where(x => x.BookingId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        

        public BookingDetail GetBooking(string id)
        {
            BookingDetail list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.BookingDetails.SingleOrDefault(c => c.BookingDetailId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        private string AutoID()
        {
            string id = "BD1";
            try
            {
                var c = new Hotel_ManagementsContext();

                var temp = c.BookingDetails.OrderBy(e => e.BookingDetailId).LastOrDefault().BookingDetailId.Substring(2);
                var temp1 = Int32.Parse(temp)+1;
                id = "BD" + temp1.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return id;
        }
        public void AddNew(BookingDetail bookingDetail)
        {
            try
            {
                bookingDetail.BookingDetailId = AutoID();
                var c = new Hotel_ManagementsContext();
                c.BookingDetails.Add(bookingDetail);
                c.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public void Update(BookingDetail bookingDetail)
        {
            try
            {


                var c = new Hotel_ManagementsContext();
                c.BookingDetails.Update(bookingDetail);
                c.SaveChanges();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remove(BookingDetail bookingDetail)
        {
            try
            {

                var c = new Hotel_ManagementsContext();
                c.BookingDetails.Remove(bookingDetail);
                c.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
