﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Staffs
{
    public class DeleteModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();


        [BindProperty]
        public staff staff { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string cont = HttpContext.Session.GetString("username");
            string Role = HttpContext.Session.GetString("role");
            staff staffs = staf.GetstaffbyId(id);

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (Role.Equals("2") || !Role.Equals("1") || Role.Equals("3"))
            {
                return RedirectToPage("/Errors");
            }
            else if (( Role.Equals("1")) && staffs.Email.Equals(cont))
            {
                if (id == null)
                {
                    return NotFound();
                }

                staff = staf.GetstaffbyId(id);


                if (staff == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return RedirectToPage("/Errors");
        }

        public async Task<IActionResult> OnPostAsync(string id)
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
                if (id == null)
                {
                    return NotFound();
                }

                staff = staf.GetstaffbyId(id);

                if (staff != null)
                {
                    staf.Remove(staff);
                }

                return RedirectToPage("./Index");
            }
            return RedirectToPage("/Errors");
        }
    }
}
