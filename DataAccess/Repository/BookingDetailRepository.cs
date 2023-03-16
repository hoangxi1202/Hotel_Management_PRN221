using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public void Create(BookingDetail bookingDetail) => BookingDetailManagement.Instance.AddNew(bookingDetail);

        public void Delete(BookingDetail bookingDetail) => BookingDetailManagement.Instance.Remove(bookingDetail);

        public BookingDetail GetBookingDetail(string id) => BookingDetailManagement.Instance.GetBooking(id);

        public List<BookingDetail> GetByBookingID(string bookingID) => BookingDetailManagement.Instance.GetByBookingId(bookingID);

        public void Update(BookingDetail bookingDetail) => BookingDetailManagement.Instance.Update(bookingDetail);
    }
}
