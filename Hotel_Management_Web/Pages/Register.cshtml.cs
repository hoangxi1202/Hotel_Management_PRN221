using BusinessObject.DataAccess;
using Hotel_Management_Web.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhanNhatHoangRazorPages.Pages
{
    public class RegisterModel : PageModel
    {
        ICustomerRepository Customers = new CustomerRepository();
        public IList<Customer> Customersa { get; set; }
        public string bi { get; set; }
        public string ao { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        public IActionResult OnGet()
        {
            Customersa = Customers.GetAllCustomer();
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToPage("Hotels/Index");
            }
            return Page();
            
        }
        public  IActionResult OnPost()
        {
            List<Customer> customers = Customers.GetEmailCustomer(Customer.Email);
            string output;
            output =  Customers.FindMaxString(Customers.GetAllCustomer());

            
            string a = output.Substring(0, 2);  // slice from beginning to index 2 (exclusive)
            int b = int.Parse(output.Substring(2));  // parse the numeric part of the string to an integer
            b += 1;  // increase the value of b by 1
            string result = a + b.ToString();  // combine a and b into a new string
            Console.WriteLine(result);  // outputs "CU2"
            Customer.Status = 1;
            Customer.CustomerId = result;
          if (Customers.GetEmailCustomer(Customer.Email) != null && (Customers.GetEmailCustomer(Customer.Email)).Count !=0)
            {
                bi = "The Email was used";
                return Page();
            }
            else if ( customers.Count==0)
            {
                Customers.AddNew(Customer);
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
