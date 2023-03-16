using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using DataAccess.Repository;

namespace Hotel_Management_Web.Pages.Hotels
{
    public class DetailsModel : PageModel
    {
        private readonly IHotelRepository hotelRepository = new HotelRepository();

        

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
    }
}
