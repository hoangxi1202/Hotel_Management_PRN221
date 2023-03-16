using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;

namespace Hotel_Management_Web.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.DataAccess.Hotel_ManagementsContext _context;

        public DeleteModel(BusinessObject.DataAccess.Hotel_ManagementsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Bookings
                .Include(b => b.Customer).FirstOrDefaultAsync(m => m.BookingId == id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Bookings.FindAsync(id);

            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
