using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract.Objects;
using DataContract.Data;

namespace DormitoryApp.Services
{
    public class RoomDataStore : IDataStore<Room>
    {
        List<Room> Rooms;

        public RoomDataStore()
        {
            Rooms = new List<Room>();
            //var mockRooms = new List<Room>
            //{
            //    new Room { Number = Guid.NewGuid().ToString() },
            //    new Room { Number = Guid.NewGuid().ToString() },
            //    new Room { Number = Guid.NewGuid().ToString() },
            //};

            //foreach (var Room in mockRooms)
            //{
            //    Rooms.Add(Room);
            //}
            RoomRepository roomRepository = new RoomRepository();
            Rooms = roomRepository.GetAll();
        }

        public async Task<bool> AddMemberAsync(Room Room)
        {
            Rooms.Add(Room);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Room Room)
        {
            var _Room = Rooms.Where((Room arg) => arg.Number == Room.Number).FirstOrDefault();
            Rooms.Remove(_Room);
            Rooms.Add(Room);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Room Room)
        {
            var _Room = Rooms.Where((Room arg) => arg.Number == Room.Number).FirstOrDefault();
            Rooms.Remove(_Room);

            return await Task.FromResult(true);
        }

        public async Task<Room> GetMemberAsync(string id)
        {
            return await Task.FromResult(Rooms.FirstOrDefault(s => s.Number == Convert.ToInt32(id)));
        }

        public async Task<IEnumerable<Room>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Rooms);
        }
    }
}
