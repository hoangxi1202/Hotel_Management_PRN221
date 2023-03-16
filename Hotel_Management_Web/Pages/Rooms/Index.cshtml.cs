using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using Repository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();


        public string ButtonValue { get; set; }
        public string Role { get; set; }

        public IList<Room> Room { get; set; }
        public async Task OnGetAsync(string buttonValue)
        {

            Role = HttpContext.Session.GetString("role");
            
            ButtonValue = buttonValue;
            Room = roomRepository.GetRoombyHotelID(ButtonValue);
        }

        public IActionResult OnPost(string myButton)
        {
            return RedirectToPage("/Rooms/Index", new { buttonValue = myButton });
        }
    }
}
