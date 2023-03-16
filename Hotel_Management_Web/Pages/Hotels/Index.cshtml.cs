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
using Repository;

namespace Hotel_Management_Web.Pages.Hotels
{
    public class IndexModel : PageModel
    {
       IHotelRepository ho = new HotelRepository();
       IStaffRepository staf = new StaffRepository();

        public IList<Hotel> Hotel { get;set; }
        public string Role { get; set; }

        public async Task OnGetAsync()
        {
            Role = HttpContext.Session.GetString("role");
            if (Role == null || Role != "2")
            {
                Hotel = ho.GetAllValid();
            }else if (Role == "2")
            {
                var id = HttpContext.Session.GetString("id");
                staff staff = staf.GetstaffbyId(id);
                IList<Hotel> a = new List<Hotel>();
                Hotel = a;
                Hotel.Add(ho.GetHotel(staff.HotelId));
                //Hotel = (IList<Hotel>)ho.GetHotel(staff.HotelId);
            }
            else
            {
                Hotel = ho.GetAll();
            }
            
        }
    }
}
