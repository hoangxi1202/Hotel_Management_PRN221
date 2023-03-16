using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail> GetByBookingID(string bookingID);
        BookingDetail GetBookingDetail(string id);
        void Create(BookingDetail bookingDetail);
        void Update(BookingDetail bookingDetail);
        void Delete(BookingDetail bookingDetail);
    }
}
