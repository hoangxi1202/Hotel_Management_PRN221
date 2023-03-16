using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class staff
    {
        [Required(ErrorMessage = "StaffId is required")]
        [Display(Name = "StaffId")]
        [RegularExpression("^HOM\\d+$", ErrorMessage = "Not correct format StaffId")]
        public string StaffId { get; set; }
        [Required(ErrorMessage = "HotelId is required")]
        [Display(Name = "HotelId")]
        [RegularExpression("^HO\\d+$", ErrorMessage = "Not correct format HotelId")]
        public string HotelId { get; set; }
        [Required(ErrorMessage = "StaffName is required")]
        [Display(Name = "StaffName")]
       
        public string StaffName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
      
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
       
        public string Password { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        [Range(0, 1, ErrorMessage = "0 - 1")]
        public int Status { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
