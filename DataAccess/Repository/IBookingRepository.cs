using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookingRepository
    {
        List<Booking> GetByHotelID(string hotelID);
        List<Booking> GetByCusID(string cusID);
        Booking GetBooking(string id);
        string getID();
        string Create(Booking booking);
        void Update(Booking booking);
        void Delete(Booking booking);
    }
}
