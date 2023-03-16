using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();
        private readonly IBookingRepository bookingRepository = new BookingRepository();
        private readonly IBookingDetailRepository bookingDetailRepository = new BookingDetailRepository();


        public List<Item> cart { get; set; }
        public IActionResult OnGet(string id)
        {
            //ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            //ViewData["RoomId"] = new SelectList(roomRepository.GetAll(), "RoomId", "RoomId");
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return Page();
            }
            else if (role != "3")
            {
                return RedirectToPage("/Error");
            }
            Id = id;
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; }
        [BindProperty]
        public string Id { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            
            BookingDetail.RoomId = id;
            //DateTime ngaymuon = BookingDetail.StartDate;
            //DateTime ngaytra = BookingDetail.EndDate;
            //TimeSpan Time = ngaytra - ngaymuon;
            //int TongSoNgay = Time.Days;
            //BookingDetail.Price = roomRepository.GetRoom(id).RoomPrice * TongSoNgay;
            //BookingDetail.BookingId = "BO1";
            //bookingDetailRepository.Create(BookingDetail);
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null) cart = new List<Item>();
                
            
            cart.Add(new Item
                {
                    BookingDetail = BookingDetail,
                    Id = cart.Count
                });
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostCheckOut()
        {
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return RedirectToPage("/Index");
            }
            var cusId = HttpContext.Session.GetString("id");
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null || cart.Count == 0)
            {
                return RedirectToPage("/Index");
            }
            var hotelID = roomRepository.GetRoom(cart[0].BookingDetail.RoomId).HotelId;
            Booking booking = new Booking
            {
                HotelID = hotelID,
                CustomerId = cusId,
                CreateDate = DateTime.Now,
                TotalPrice= 0,
                Status= 1,
        };
            string bookingId = bookingRepository.Create(booking);

            decimal totalPrice = 0;
            foreach (Item item in cart)
            {
                totalPrice += item.BookingDetail.Price;
                item.BookingDetail.BookingId= bookingId;
                bookingDetailRepository.Create(item.BookingDetail);
            }
            booking.TotalPrice= totalPrice;
            bookingRepository.Update(booking);
            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("./Index");
        }
        public  IActionResult OnPostCheckPrice(string id)
        {
            DateTime ngaymuon = BookingDetail.StartDate;
            DateTime ngaytra = BookingDetail.EndDate;
            TimeSpan Time = ngaytra - ngaymuon;
            int TongSoNgay = Time.Days;
            var a = BookingDetail;
            BookingDetail.Price = roomRepository.GetRoom(id).RoomPrice * TongSoNgay;
            
            return Page();
            //return Page(new { BookingDetail = a });
        }

        private IActionResult Page(object value)
        {
            throw new NotImplementedException();
        }
    }
}
