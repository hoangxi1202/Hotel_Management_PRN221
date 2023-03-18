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
        public bool isOnOtherHotel { get; set; }

        public string ButtonValue { get; set; }
        public string Role { get; set; }

        public IList<Room> Room { get; set; }
        public async Task OnGetAsync(string buttonValue)
        {

            Role = HttpContext.Session.GetString("role");
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                isOnOtherHotel = false;
            }
            else
            {
                var hotelID = roomRepository.GetRoom(cart[0].BookingDetail.RoomId).HotelId;
                isOnOtherHotel = hotelID != buttonValue;
            }
            ButtonValue = buttonValue;
            Room = roomRepository.GetRoombyHotelID(ButtonValue);
        }

        public IActionResult OnPost(string myButton)
        {
            
            return RedirectToPage("/Rooms/Index", new { buttonValue = myButton });
        }
    }
}
