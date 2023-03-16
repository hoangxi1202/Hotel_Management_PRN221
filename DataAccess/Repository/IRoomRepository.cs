using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        Room GetRoom(string roomId);
        List<Room> GetRoombyHotelID(string id);
        void Delete(Room room);
        void Update(Room room);
        void Add(Room room);
    }
}
