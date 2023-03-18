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

namespace Hotel_Management_Web.Pages.Hotels
{
    public class DeleteModel : PageModel
    {
        private readonly IHotelRepository hotelRepository = new HotelRepository();

        [BindProperty]
        public Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return RedirectToPage("/Error");
            }
            else if (role != "2")
            {
                return RedirectToPage("/Error");
            }
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = hotelRepository.GetHotel(id.Trim());

            if (Hotel != null)
            {
                hotelRepository.Delete(Hotel);
            }

            return RedirectToPage("./Index");
        }
    }
}
