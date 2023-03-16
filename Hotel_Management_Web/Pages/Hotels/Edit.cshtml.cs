using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using DataAccess.Repository;

namespace Hotel_Management_Web.Pages.Hotels
{
    public class EditModel : PageModel
    {
        IHotelRepository hotelRepository = new HotelRepository();

        
        [BindProperty]
        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = hotelRepository.GetHotel(id);

            if (Hotel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            hotelRepository.Update(Hotel);

            return RedirectToPage("./Index");
        }

        
    }
}
