﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBookingRepository bookingRepository = new BookingRepository();
        private readonly IRoomRepository roomRepository = new RoomRepository();


        public IList<Booking> Booking { get;set; }
        

        public async Task<IActionResult> OnGetAsync()
        {
            string role = HttpContext.Session.GetString("role");
            string id = HttpContext.Session.GetString("hotelId");

            if (role == null)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                if (role == "2")
                {
                    Booking = bookingRepository.GetByHotelID(id);
                }
                else if (role == "3") 
                {
                    string cusId = HttpContext.Session.GetString("id");
                    Booking = bookingRepository.GetByCusID(cusId);
                }
            }
            
            return Page();
        }
    }
}
