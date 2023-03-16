using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HotelRepository : IHotelRepository
    {
        public void Add(Hotel hotel) => HotelManagement.Instance.AddNew(hotel);

        public void Delete(Hotel hotel) => HotelManagement.Instance.Remove(hotel);

        public List<Hotel> GetAll() => HotelManagement.Instance.GetAll();
        public List<Hotel> GetAllValid() => HotelManagement.Instance.GetAllValid();

        public Hotel GetHotel(string id) => HotelManagement.Instance.GetHotelbyId(id);

        public void Update(Hotel hotel) => HotelManagement.Instance.Update(hotel);
    }
}
