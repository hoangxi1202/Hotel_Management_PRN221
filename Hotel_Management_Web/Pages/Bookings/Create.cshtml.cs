using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;
using DataAccess.Repository;
using Repository;

namespace Hotel_Management_Web.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBookingRepository bookingRepository = new BookingRepository();
        private readonly ICustomerRepository customerRepository = new CustomerRepository();
        private readonly IHotelRepository hotelRepository = new HotelRepository();

        public IActionResult OnGet()
        {
            ViewData["HotelId"] = new SelectList(hotelRepository.GetAll(), "HotelId", "HotelId");

            ViewData["CustomerId"] = new SelectList(customerRepository.GetAllCustomer(), "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Booking.CreateDate= DateTime.Now;
            bookingRepository.Create(Booking);

            return RedirectToPage("./Index");
        }
    }
}
