using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;
using DataAccess.Repository;

namespace Hotel_Management_Web.Pages.Staffs
{
    public class EditModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();
        private readonly IHotelRepository hotelRepository = new HotelRepository();


        [BindProperty]
        public staff staff { get; set; }
        private Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            string role = HttpContext.Session.GetString("role");

            if (role == null || role == "3")
            {
                return RedirectToPage("/Error");
            }
            
                if (id == null)
                {
                    return NotFound();
                }

                staff = staf.GetstaffbyId(id);

                if (staff == null)
                {
                    return NotFound();
                }
                Hotel = hotelRepository.GetHotel(staff.HotelId);
                staff.Hotel = Hotel;
                return Page();
            
           
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string role = HttpContext.Session.GetString("role");
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            staff.Hotel = Hotel;
                    staf.Updatestaff(staff);
                
                return RedirectToPage("./Index");
            
        }

       
    }
}
