using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;
using DataAccess.Repository;

namespace Hotel_Management_Web.Pages.Hotels
{
    public class CreateModel : PageModel
    {
        private readonly IHotelRepository hotelRepository = new HotelRepository();

        

        public IActionResult OnGet()
        {
            return Page();
           
        }

        [BindProperty]
        public Hotel Hotel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Hotel.Status = 1;
            
            hotelRepository.Add(Hotel);

            return RedirectToPage("./Index");
        }
    }
}
