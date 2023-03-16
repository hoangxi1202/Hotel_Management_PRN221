using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
        List<Hotel> GetAllValid();
        Hotel GetHotel(string id);
        void Delete(Hotel hotel);
        void Update(Hotel hotel);
        void Add(Hotel hotel);
    }
}
