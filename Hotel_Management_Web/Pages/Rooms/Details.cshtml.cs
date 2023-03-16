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
    public class DetailsModel : PageModel
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();
        private readonly IHotelRepository hotelRepository = new HotelRepository();
        private readonly ITypeRepository typeRepository = new TypeRepository();


        public Room Room { get; set; }
        

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            Room = roomRepository.GetRoom(id);
            Room.Hotel = hotelRepository.GetHotel(Room.HotelId);
            Room.Type = typeRepository.GetType(Room.TypeId);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
