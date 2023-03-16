using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.DataAccess.Hotel_ManagementsContext _context;

        public DeleteModel(BusinessObject.DataAccess.Hotel_ManagementsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookingDetail = await _context.BookingDetails
                .Include(b => b.Booking)
                .Include(b => b.Room).FirstOrDefaultAsync(m => m.BookingDetailId == id);

            if (BookingDetail == null)
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

            BookingDetail = await _context.BookingDetails.FindAsync(id);

            if (BookingDetail != null)
            {
                _context.BookingDetails.Remove(BookingDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
