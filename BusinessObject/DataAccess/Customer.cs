using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }
        [Required(ErrorMessage = "CustomerId is required")]
        [Display(Name = "CustomerId")]
        [RegularExpression("^CU\\d{4,}$", ErrorMessage = "Not correct format CustomerId")]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "CustomerName is required")]
        [Display(Name = "CustomerName")]
       
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        
        public string Address { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
      
        public string Password { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
