using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Repository;

namespace Hotel_Management_Web.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();
        private readonly IHotelRepository hotelRepository = new HotelRepository();
        private readonly ITypeRepository typeRepository = new TypeRepository();
        private readonly IStaffRepository staffRepository = new StaffRepository();
        [BindProperty]
        public Room Room { get; set; }
        [BindProperty]
        public Hotel Hotel { get; set; }
        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return RedirectToPage("/Error");
            }else
            {
                if (role != "2")
                {
                    return RedirectToPage("/Error");
                }
            }
            var staff = staffRepository.GetstaffbyId(HttpContext.Session.GetString("id"));
            Hotel = hotelRepository.GetHotel(staff.HotelId);
            ViewData["HotelId"] = new SelectList(hotelRepository.GetAll(), "HotelId", "HotelName");
            ViewData["TypeId"] = new SelectList(typeRepository.GetAllTypes(), "TypeId", "NameType");
            return Page();
        }

        
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string myButton)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            
            Room.Status = 1;
            roomRepository.Add(Room);

            return RedirectToPage("/Rooms/Index", new { buttonValue = myButton });
        }
    }
}
