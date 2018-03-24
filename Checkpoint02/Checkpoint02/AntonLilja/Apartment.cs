using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Checkpoint02.AntonLilja
{
    class Apartment
    {
        List<Room> rooms = new List<Room>();
        public int NumberOfRooms { get => rooms.Count; }

        public void AddRoomsFromRoomArray(Room[] rooms)
        {
            foreach (var room in rooms)
                AddRoom(room);
        }

        public void AddRoom(Room room) => rooms.Add(room);

        //public static List<Room> GetRoomsWithLightsOn()
        //{

        //}

        //public static List<Room> GetLargestRooms()
        //{

        //}

        public List<Room> GetRoomList() => rooms;

        public List<Room> GetLitRooms()
        {
            var litList = new List<Room>();

            foreach (var room in rooms)
            {
                if (room.LightIsOn)
                    litList.Add(room);
            }

            return litList;
        }

        public List<Room> GetLargestRooms()
        {
            var sortedList = rooms.OrderBy(room => room.Size).ToList();

            if (sortedList.Count > 1)
            {
                for (int i = 0; i < sortedList.Count - 1; i++)
                {
                    if (sortedList[i].Size < sortedList[i + 1].Size)
                        sortedList.Remove(sortedList[i]);
                }
            }

            return sortedList;
        }
    }
}
