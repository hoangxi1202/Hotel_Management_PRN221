using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public string Create(Booking booking) => BookingManagement.Instance.AddNew(booking);

        public void Delete(Booking booking) => BookingManagement.Instance.Remove(booking);

        public Booking GetBooking(string id) => BookingManagement.Instance.GetBooking(id);

        public List<Booking> GetByCusID(string cusID) => BookingManagement.Instance.GetByCusId(cusID);

        public List<Booking> GetByHotelID(string hotelID) => BookingManagement.Instance.GetByHotelId(hotelID);

        public string getID() => BookingManagement.Instance.AutoID();

        public void Update(Booking booking) => BookingManagement.Instance.Update(booking);
    }
}
