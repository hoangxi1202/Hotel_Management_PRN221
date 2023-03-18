using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using DataAccess.Repository;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class IndexModel : PageModel
    {
        private readonly IBookingDetailRepository bookingDetailRepository = new BookingDetailRepository();
        private readonly IHotelRepository hotelRepository = new HotelRepository();
        private readonly IBookingRepository bookingRepository = new BookingRepository();
        private readonly IRoomRepository roomRepository = new RoomRepository();

        public IList<BookingDetail> BookingDetail { get;set; }
        public string HotelName { get; set; }
        public List<Item> cart { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                if (cart == null)
                {
                    BookingDetail = new List<BookingDetail>();
                }
                else
                {
                    BookingDetail = new List<BookingDetail>();
                    foreach (Item item in cart)
                    {
                        DateTime ngaymuon = item.BookingDetail.StartDate;
                        DateTime ngaytra = item.BookingDetail.EndDate;
                        TimeSpan Time = ngaytra - ngaymuon;
                        int TongSoNgay = Time.Days;
                        var roomid = item.BookingDetail.RoomId;
                        item.BookingDetail.Price = Math.Abs(roomRepository.GetRoom(roomid).RoomPrice * TongSoNgay);
                        BookingDetail.Add(item.BookingDetail);

                    }
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            else
            {
                BookingDetail = bookingDetailRepository.GetByBookingID(id);
                var bookingID = BookingDetail.FirstOrDefault().BookingId;
                var hotelID = bookingRepository.GetBooking(bookingID).HotelID;
                HotelName = hotelRepository.GetHotel(hotelID).HotelName;
            }

            
            
            return Page();
        }
        public IActionResult OnGetDelete(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            cart.RemoveAt(Int32.Parse(id));
            if (cart.Count == 0) { cart = null; }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("/BookingDetails/Index");
        }
    }
}
