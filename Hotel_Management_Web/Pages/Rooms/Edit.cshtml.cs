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
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Rooms
{
    public class EditModel : PageModel
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();
        private readonly IHotelRepository hotelRepository = new HotelRepository();
        private readonly ITypeRepository typeRepository = new TypeRepository();


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
           ViewData["HotelId"] = new SelectList(hotelRepository.GetAll(), "HotelId", "HotelName");
           ViewData["TypeId"] = new SelectList(typeRepository.GetAllTypes(), "TypeId", "NameType");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string myButton)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Room).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RoomExists(Room.RoomId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            roomRepository.Update(Room);

            return RedirectToPage("/Rooms/Index", new { buttonValue = myButton });
        }

        //private bool RoomExists(string id)
        //{
        //    return _context.Rooms.Any(e => e.RoomId == id);
        //}
    }
}
