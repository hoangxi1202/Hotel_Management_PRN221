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

namespace Hotel_Management_Web.Pages.ManageStaff
{
    public class EditModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        [BindProperty]
        public staff Room { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Id.Equals("1"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("1"))
            {
                if (id == null)
                {
                    return NotFound();
                }
                Room = staf.GetstaffbyId(id);


                if (Room == null)
                {
                    return NotFound();
                }
                // ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId");
                //   ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId");
                return Page();
            }
            return RedirectToPage("/Errors");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Id.Equals("1"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("1"))
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }



                try
                {
                    staf.Updatestaff(Room);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return RedirectToPage("./Index");
            }
            return RedirectToPage("/Errors");
        }
       

    }
}
