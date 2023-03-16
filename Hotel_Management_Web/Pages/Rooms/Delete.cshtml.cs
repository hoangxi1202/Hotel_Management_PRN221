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

namespace Hotel_Management_Web.Pages.Rooms
{
    public class DeleteModel : PageModel
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();

        

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                if (role != "2")
                {
                    return RedirectToPage("/Error");
                }
            }
            if (id == null)
            {
                return NotFound();
            }

            Room = roomRepository.GetRoom(id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string myButton)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = roomRepository.GetRoom(id);

            if (Room != null)
            {
                roomRepository.Delete(Room);
            }

            return RedirectToPage("/Rooms/Index", new { buttonValue = myButton });
        }
    }
}
