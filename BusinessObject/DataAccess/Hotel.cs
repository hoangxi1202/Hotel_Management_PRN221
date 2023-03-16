using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
            staff = new HashSet<staff>();
        }
        [Required(ErrorMessage = "HotelId is required")]
        [Display(Name = "HotelId")]
        [RegularExpression("^HO\\d*$", ErrorMessage = "Not correct format HotelId")]
        public string HotelId { get; set; }
        [Required(ErrorMessage = "HotelName is required")]
        [Display(Name = "HotelName")]
 
        public string HotelName { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
     
        public string Image { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
       
        public string Address { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        [Range(0, 1, ErrorMessage = "0 - 1")]
        public int Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<staff> staff { get; set; }

        public static explicit operator List<object>(Hotel v)
        {
            throw new NotImplementedException();
        }
    }
}
