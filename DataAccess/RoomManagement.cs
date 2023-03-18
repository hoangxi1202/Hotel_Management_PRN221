using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoomManagement
    {
        private static RoomManagement instance = null;
        private static readonly object instanceLock = new object();
        private RoomManagement() { }
        public static RoomManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomManagement();
                    }
                }
                return instance;
            }
        }
        
        public List<Room> GetAll()
        {
            List<Room> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Rooms.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        //private bool IsBooking(Room room)
        //{
        //    bool result = false;
        //    try
        //    {
        //        var c = new Hotel_ManagementsContext();
        //        var a = c.BookingDetails.Where(x => x.)
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return result;
        //}
        public List<Room> GetAllvalid()
        {
            List<Room> list;
            try
            {
                var c = new Hotel_ManagementsContext();
                list = c.Rooms.Where(x => x.Status == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Room GetRoombyId(string id)
        {
            Room obj = null;

            try
            {
                var c = new Hotel_ManagementsContext();
                obj = c.Rooms.SingleOrDefault(c => c.RoomId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }

        public List<Room> GetRoombyHotelID(string id)
        {
            List<Room> obj = null;

            try
            {
                var c = new Hotel_ManagementsContext();
                obj = c.Rooms.Where(c => c.HotelId == id && c.Status==1).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }


        public void AddNew(Room room)
        {
            try
            {
                Room _obj = GetRoombyId(room.RoomId);
                if (_obj == null)
                {
                    var c = new Hotel_ManagementsContext();
                    c.Rooms.Add(room);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The room is already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }


        public void Update(Room room)
        {
            try
            {
                
                
                    var c = new Hotel_ManagementsContext();
                    c.Rooms.Update(room);
                    c.SaveChanges();
                
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remove(Room room)
        {
            try
            {
                if (room.Status == 1)
                {
                    room.Status = 0;
                }
                else if (room.Status == 0)
                {
                    room.Status = 1;
                }
        
                    var c = new Hotel_ManagementsContext();
                c.Rooms.Update(room);
                c.SaveChanges();
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }

}
