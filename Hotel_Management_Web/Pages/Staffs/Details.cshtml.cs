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
    public class DetailsModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();


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
            else if (!Role.Equals("2") || !Role.Equals("1"))
            {
                return RedirectToPage("/Errors");
            }
            else if ((Role.Equals("2") || Role.Equals("1")) && staffs.Email.Equals(cont))
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
    }
}
