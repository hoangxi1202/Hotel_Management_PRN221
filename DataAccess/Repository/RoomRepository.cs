using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public void Add(Room room) => RoomManagement.Instance.AddNew(room);

        public void Delete(Room room) => RoomManagement.Instance.Remove(room);

        public List<Room> GetAll() => RoomManagement.Instance.GetAll();

        public Room GetRoom(string roomId) => RoomManagement.Instance.GetRoombyId(roomId);

        public List<Room> GetRoombyHotelID(string id) => RoomManagement.Instance.GetRoombyHotelID(id);


        public void Update(Room room) => RoomManagement.Instance.Update(room);
    }
}
