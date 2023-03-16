using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Staffs
{
    public class CreateModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();


        public IActionResult OnGet()
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null ||
               HttpContext.Session.GetString("password") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Id.Equals("2"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("2"))
            {
                // ViewData["HotelId"] = new SelectList(_context.Hotels, "HotelId", "HotelId");
                return Page();
            }
            return RedirectToPage("/Errors");
        }

        [BindProperty]
        public staff staff { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null ||
               HttpContext.Session.GetString("password") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Id.Equals("2"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("2"))
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                staf.AddNew(staff);


                return RedirectToPage("./Index");
            }
            return RedirectToPage("/Errors");
        }
    }
}
