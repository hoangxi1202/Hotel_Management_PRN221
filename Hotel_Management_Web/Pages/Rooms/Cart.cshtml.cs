using BusinessObject.DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Management_Web.Pages.Rooms
{
    public class CartModel : PageModel
    {
        //public List<Item> cart { get; set; }
        //public decimal Total { get; set; }
        //public void OnGet()
        //{
        //    cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    Total = cart.Sum(i => i.room.RoomPrice * i.Quantity);

        //}


        //public IActionResult OnGetBuyNow(string id)
        //{
        //    IRoomRepository rooms = new RoomRepository();
        //    var productModel = new Room();
        //    cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    if (cart == null)
        //    {
        //        cart = new List<Item>();
        //        cart.Add(new Item
        //        {
        //            room = rooms.GetRoom(id),
        //            Quantity = 1
        //        });
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //    }
        //    else
        //    {
        //        int index = Exists(cart, id);
        //        if (index == -1)
        //        {
        //            cart.Add(new Item
        //            {
        //                room = rooms.GetRoom(id),
        //                Quantity = 1
        //            });
        //        }
        //        else
        //        {
        //            cart[index].Quantity++;
        //        }
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //    }
        //    return RedirectToPage("Cart");
        //}

        //public IActionResult OnGetDelete(string id)
        //{
        //    cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    int index = Exists(cart, id);
        //    cart.RemoveAt(index);
        //    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //    return RedirectToPage("Cart");
        //}

        //public IActionResult OnPostUpdate(int[] quantities)
        //{
        // //   cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //  //  for (var i = 0; i < cart.Count; i++)
        //  //  {
        //  //      cart[i].Quantity = quantities[i];
        // //   }
        // //   SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        ////    return RedirectToPage("Cart");
        //   cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    if (quantities.Length != cart.Count)
        //    {
        //        // Handle the error - perhaps return an error message or redirect to an error page
        //        // For example:
        //        // return RedirectToAction("Index", "Error");
        //    }
        //    else
        //    {
        //        for (var i = 0; i < cart.Count; i++)
        //        {
        //            cart[i].Quantity = quantities[i];
        //        }
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //    }
        //    return RedirectToPage("Cart");
        //}

        //private int Exists(List<Item> cart, string id)
        //{
        //    for (var i = 0; i < cart.Count; i++)
        //    {
        //        if (cart[i].room.RoomId == id)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}
    }
}
