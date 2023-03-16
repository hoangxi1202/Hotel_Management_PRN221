using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Room
    {
        public Room()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }
        [Required(ErrorMessage = "RoomId is required")]
        [Display(Name = "RoomId")]
        [RegularExpression("^RO10\\d*$", ErrorMessage = "Not correct format RoomId")]
        public string RoomId { get; set; }
        [Required(ErrorMessage = "HotelId is required")]
        [Display(Name = "HotelId")]
        [RegularExpression("^HO\\d*$", ErrorMessage = "Not correct format HotelId")]
        public string HotelId { get; set; }
        [Required(ErrorMessage = "TypeId is required")]
        [Display(Name = "TypeId")]
        [RegularExpression("^TY\\d*$", ErrorMessage = "Not correct format BookingId")]
        public string TypeId { get; set; }
        [Required(ErrorMessage = "RoomDescription is required")]
        [Display(Name = "RoomDescription")]

        public string RoomDescription { get; set; }
        [Required(ErrorMessage = "RoomPrice is required")]
        [Display(Name = "RoomPrice")]
        public decimal RoomPrice { get; set; }
        [Required(ErrorMessage = "ImageString is required")]
        [Display(Name = "ImageString")]

        public string ImageString { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
