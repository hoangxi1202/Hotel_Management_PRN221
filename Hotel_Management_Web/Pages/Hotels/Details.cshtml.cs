using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Hotels
{
    public class DetailsModel : PageModel
    {
        private readonly IHotelRepository hotelRepository = new HotelRepository();


        public string Role { get; set; }
        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Role = HttpContext.Session.GetString("role");
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
